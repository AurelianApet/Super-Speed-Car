using UnityEngine;
using System.Collections;

public class SinglePlayerCarManger : BaseCarManager
{		
	public static float AI_DISTANCE_CHECK_DELTA = 50;
	public static float AI_DISTANCE_CHECK_DELTA_B = 50;

	//
	public	float lastEliminate;
	public int numberEliminate;
	bool isEliminate;

	//
	float lastDistanceAICheck;
	float distanceDelta;

	public SinglePlayerCarManger (Game game):base(game)
	{
		BaseCarManager.mainPlayerID = 0;		
		
		BaseCarManager.carID = new int[GameData.numberPlayers];
		BaseCarManager.playerName = new string[GameData.numberPlayers];
		for (int i=0; i<BaseCarManager.isFinishedLoading.Length; i++) {
			BaseCarManager.isFinishedLoading [i] = true;
		}	

		this.initPlayer ();
		this.initEnemies ();

		for (int i=0; i<carInfo.Length; i++) {
			carInfo [i] = new CarInfo (game, player [i]);
			carDistance [i] = new CarDistance (i, player [i]);			
		}

		Game.gameState = Game.GAME_STATE.START;
		game.soundManager.playCountDown ();
	}
	
	public override void preGameOver ()
	{
		string[] tempName = new string[carID.Length];

		for (int i=0; i<carDistance.Length; i++) {
			int tempIndex = getOrder (i) - 1;
			
			orderInfo [tempIndex] = new OrderInfo ();
			orderInfo [tempIndex].id = i;
			orderInfo [tempIndex].carID = carID [i];
			orderInfo [tempIndex].playerName = playerName [i];
			
			carDistance [i].carData.OrderNumberController.deactivateAllNumber ();
		}
		
		playerName = tempName;
	}

	public override void postUpdate ()
	{
		for (int i=0; i<carInfo.Length; i++) {
			carInfo [i].Update ();
		}

		if (GameData.numberPlayers > 1) {
			this.updateCarAI ();
		}

		switch (GameData.selectedMode) {
		case GameData.GAME_MODE.CLASSIC:
			if (carInfo [mainPlayerID].RemainingDistance < 0) {
				int orderID = getOrder (mainPlayerID);
				switch (orderID) {
				case 1:
					GameData.rank = 1;
					game.preGameOver ();
					break;

				case 2:
					GameData.rank = 2;
					game.preGameOver ();
					break;

				case 3:
					GameData.rank = 3;
					game.preGameOver ();
					break;

				default:
					GameData.rank = orderID;
					game.preGameOver ();
					break;
				}
			}
			break;

		case GameData.GAME_MODE.TIME_TRIAL:
			if (carInfo [mainPlayerID].RemainingDistance < 0) {
				if (game.StateTime <= GameData.durationFirst) {
					GameData.rank = 1;
					game.preGameOver ();

				} else if (game.StateTime <= GameData.durationSecond) {
					GameData.rank = 2;
					game.preGameOver ();

				} else if (game.StateTime <= GameData.durationThird) {
					GameData.rank = 3;
					game.preGameOver ();

				} else {
					GameData.rank = 4;
					game.preGameOver ();
				}
			}
			break;

		case GameData.GAME_MODE.CHECK_POINT:
			if (carInfo [mainPlayerID].RemainingDistance < 0) {
				if (MainPlayer.carData.TotalCheckPointEarned >= GameData.numberCheckpoints) {
					int orderID = getOrder (mainPlayerID);
					switch (orderID) {
					case 1:
						GameData.rank = 1;
						game.preGameOver ();
						break;
					
					case 2:
						GameData.rank = 2;
						game.preGameOver ();
						break;
					
					case 3:
						GameData.rank = 3;
						game.preGameOver ();
						break;
					
					default:
						GameData.rank = orderID;
						game.preGameOver ();
						break;
					}
				} else { 
					GameData.rank = 4;
					game.preGameOver ();
				}
			}
			break;

		case GameData.GAME_MODE.ELIMINATION:
			if (this.isEliminate == true) {
				int orderID = getOrder (mainPlayerID);
				switch (orderID) {
				case 1:
					GameData.rank = 1;
					game.preGameOver ();
					break;
					
				case 2:
					GameData.rank = 2;
					game.preGameOver ();
					break;
					
				case 3:
					GameData.rank = 3;
					game.preGameOver ();
					break;
					
				default:
					GameData.rank = orderID;
					game.preGameOver ();
					break;
				}
			} else {
				if (Time.timeSinceLevelLoad - lastEliminate >= GameData.timeBetweenEliminate) {
					CarData data = this.findLastOrderWithID ();
					if (data != null) {
						data.freezeAll ();
						lastEliminate = Time.timeSinceLevelLoad;
						numberEliminate++;

						if (data.ID == mainPlayerID) {
							this.isEliminate = true;
						}

						if (numberEliminate == GameData.numberPlayers - 1) {
							this.isEliminate = true;
						}
					}
				}
			}
			break;

		default:
			break;
		}


		if (Game.gameState == Game.GAME_STATE.RUNNING) {
			MissionChecker.checkMission (this.game);
		}
	}

	void initPlayer ()
	{
		if (GameData.IsStartFirst == false) {
			player [0] = (GameObject)GameObject.Instantiate (Resources.Load<GameObject> 
		                                                 (GameData.getCarPrefab (GameData.getCarName (ProfileManager.userProfile.SelectedCar))),
		                                                 game.map.spawnPointsList [0].position, game.map.spawnPointsList [0].rotation);
		} else {
			player [0] = (GameObject)GameObject.Instantiate (Resources.Load<GameObject> 
			                                                 (GameData.getCarPrefab (GameData.getCarName (ProfileManager.userProfile.SelectedCar))),
			                                                 game.map.spawnPointsList [5].position, game.map.spawnPointsList [0].rotation);
		}

		carID [0] = ProfileManager.userProfile.SelectedCar;
		playerName [0] = ProfileManager.userProfile.PlayerName;
		player [0].name = "Player";

		game.autoCam.target = player [0];
		game.handHeldCam.setTarget (player [0]);

		player [0].GetComponent<CarData> ().ID = 0;
		player [0].rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ
			| RigidbodyConstraints.FreezeRotation;
	}

	void initEnemies ()
	{
		ID_Pool idPool = new ID_Pool (15);
		idPool.removeID (ProfileManager.userProfile.SelectedCar);

		for (int i=1; i<player.Length; i++) {
			carID [i] = idPool.allocateID ();
			if (InternetGameMenu.fakePlayerName.Count == 0) {
				playerName [i] = EnemyNameList.getEnemyName ();
			} else {
				playerName [i] = InternetGameMenu.fakePlayerName [i];
			}

			if (GameData.IsStartFirst == false) {
				player [i] = (GameObject)GameObject.Instantiate (Resources.Load<GameObject> 
			                                                 (GameData.getCarPrefab (GameData.getCarName (carID [i]))),
			                                                 game.map.spawnPointsList [i].position, game.map.spawnPointsList [i].rotation);
			} else {
				player [i] = (GameObject)GameObject.Instantiate (Resources.Load<GameObject> 
				                                                 (GameData.getCarPrefab (GameData.getCarName (carID [i]))),
				                                                 game.map.spawnPointsList [i - 1].position, game.map.spawnPointsList [i].rotation);
			}

//						player [i].name = "Enemy_" + i;	
			player [i].name = playerName [i];	
			player [i].rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ
				| RigidbodyConstraints.FreezeRotation;
			player [i].layer = LayerDefinition.ENEMY;

			CarData carData = player [i].GetComponent<CarData> ();
			carData.isPlayer = false;
			carData.ID = i;
		}
	}

	public float getEliminateTime ()
	{
		if (GameData.timeBetweenEliminate > (Time.timeSinceLevelLoad - lastEliminate)) {
			return GameData.timeBetweenEliminate - (Time.timeSinceLevelLoad - lastEliminate);
		} else {
			return 0;
		}
	}

	public void updateCarAI ()
	{
		if (Time.timeSinceLevelLoad - lastDistanceAICheck > 0.5f) {
			lastDistanceAICheck = Time.timeSinceLevelLoad;
			
			for (int i=4; i<carInfo.Length-1; i++) {
				distanceDelta = carInfo [i].RemainingDistance - carInfo [0].RemainingDistance;
				
				if (distanceDelta < 0) {
					if (distanceDelta < -AI_DISTANCE_CHECK_DELTA_B * 4) {
						carInfo [i].carData.changeAISpeed (carInfo [i].carData.InitialTopSpeed * 0.8f, false);
						
					} else if (distanceDelta < -AI_DISTANCE_CHECK_DELTA_B * 3) {
						carInfo [i].carData.changeAISpeed (carInfo [i].carData.InitialTopSpeed * 0.85f, false);
						
					} else if (distanceDelta < -AI_DISTANCE_CHECK_DELTA_B * 2) {
						carInfo [i].carData.changeAISpeed (carInfo [i].carData.InitialTopSpeed * 0.9f, false);
						
					} else if (distanceDelta < -AI_DISTANCE_CHECK_DELTA_B) {
						carInfo [i].carData.changeAISpeed (carInfo [i].carData.InitialTopSpeed * 0.95f, false);
						
					} else {
						carInfo [i].carData.resetAISpeed ();
					}
				} else {
					if (distanceDelta > AI_DISTANCE_CHECK_DELTA * 4) {
						carInfo [i].carData.changeAISpeed (carInfo [i].carData.InitialTopSpeed * 1.2f, true);
						
					} else if (distanceDelta > AI_DISTANCE_CHECK_DELTA * 3) {
						carInfo [i].carData.changeAISpeed (carInfo [i].carData.InitialTopSpeed * 1.15f, true);
						
					} else if (distanceDelta > AI_DISTANCE_CHECK_DELTA * 2) {
						carInfo [i].carData.changeAISpeed (carInfo [i].carData.InitialTopSpeed * 1.1f, true);
						
					} else if (distanceDelta > AI_DISTANCE_CHECK_DELTA) {
						carInfo [i].carData.changeAISpeed (carInfo [i].carData.InitialTopSpeed * 1.05f, true);
						
					} else {
						carInfo [i].carData.resetAISpeed ();
					}
				}
			}

			for (int i=2; i<=3; i++) {
				distanceDelta = carInfo [i].RemainingDistance - carInfo [0].RemainingDistance;
				
				if (distanceDelta < 0) {
					if (distanceDelta < -AI_DISTANCE_CHECK_DELTA_B * 4) {
						carInfo [i].carData.changeAISpeed (carInfo [i].carData.InitialTopSpeed * 0.8f, false);
						
					} else if (distanceDelta < -AI_DISTANCE_CHECK_DELTA_B * 3) {
						carInfo [i].carData.changeAISpeed (carInfo [i].carData.InitialTopSpeed * 0.8f, false);
						
					} else if (distanceDelta < -AI_DISTANCE_CHECK_DELTA_B * 2) {
						carInfo [i].carData.changeAISpeed (carInfo [i].carData.InitialTopSpeed * 0.9f, false);
						
					} else if (distanceDelta < -AI_DISTANCE_CHECK_DELTA_B) {
						carInfo [i].carData.changeAISpeed (carInfo [i].carData.InitialTopSpeed * 0.9f, false);
						
					} else {
						carInfo [i].carData.resetAISpeed ();
					}
				} else {
					if (distanceDelta > AI_DISTANCE_CHECK_DELTA * 4) {
						carInfo [i].carData.changeAISpeed (carInfo [i].carData.InitialTopSpeed * 1.1f, true);
						
					} else if (distanceDelta > AI_DISTANCE_CHECK_DELTA * 3) {
						carInfo [i].carData.changeAISpeed (carInfo [i].carData.InitialTopSpeed * 1.2f, true);
						
					} else if (distanceDelta > AI_DISTANCE_CHECK_DELTA * 2) {
						carInfo [i].carData.changeAISpeed (carInfo [i].carData.InitialTopSpeed * 1.3f, true);
						
					} else if (distanceDelta > AI_DISTANCE_CHECK_DELTA) {
						carInfo [i].carData.changeAISpeed (carInfo [i].carData.InitialTopSpeed * 1.4f, true);
						
					} else {
						carInfo [i].carData.resetAISpeed ();
					}
				}
			}

			distanceDelta = carInfo [carInfo.Length - 1].RemainingDistance - carInfo [0].RemainingDistance;
			
			if (distanceDelta < 0) {
				if (distanceDelta < AI_DISTANCE_CHECK_DELTA) {
					carInfo [carInfo.Length - 1].carData.changeAISpeed (carInfo [carInfo.Length - 1].carData.InitialTopSpeed 
						* Random.Range (0.7f, 1f), false);
				}
			} else {
				if (distanceDelta > AI_DISTANCE_CHECK_DELTA) {
					carInfo [carInfo.Length - 1].carData.changeAISpeed (carInfo [carInfo.Length - 1].carData.InitialTopSpeed 
						* Random.Range (1f, 1.3f), true);
				}
			}
		}
	}
}
