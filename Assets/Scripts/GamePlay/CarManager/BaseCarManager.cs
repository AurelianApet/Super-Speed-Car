using UnityEngine;
using System.Collections;

public abstract class BaseCarManager
{
	public static float CHASE_DISTANCE = 25 * 25;
	public static float INIT_DISTANCE = 100 * 100;

	//--------------------------------------------------------------------------------
	public static int mainPlayerID;
	public static int[] carID;
	public static string[] playerName;
	public static bool[] isFinishedLoading;

	//--------------------------------------------------------------------------------
	public GameObject[] player;
	public CarInfo[] carInfo;
	public CarDistance[] carDistance;
	public OrderInfo[] orderInfo;

	//--------------------------------------------------------------------------------
	BaseCarController mainPlayer;

	public BaseCarController MainPlayer {
		get {
			if (mainPlayer == null) {
				mainPlayer = player [mainPlayerID].GetComponent<CarData> ().CarController;
			}
			return mainPlayer;
		}
		set {
			mainPlayer = value;
		}
	}

	//--------------------------------------------------------------------------------
	protected Game game;
	public GameObject police;
	public bool isPoliceCaught;
	public float policeCaughtTime;
	public int numberRespawn;

	//--------------------------------------------------------------------------------
	CarDistance tempDistance = new CarDistance (0, null);

	public BaseCarManager (Game game)
	{
		this.game = game;
		this.player = new GameObject[GameData.numberPlayers];
		this.carInfo = new CarInfo[GameData.numberPlayers];
		this.carDistance = new CarDistance[GameData.numberPlayers];		
		this.orderInfo = new OrderInfo[GameData.numberPlayers];

		BaseCarManager.isFinishedLoading = new bool[GameData.numberPlayers]; 
	}
	
	public abstract void postUpdate ();

	public abstract void preGameOver ();

	public GameObject getPlayer ()
	{
		return player [mainPlayerID];
	}

	public void Update ()
	{
		for (int i=0; i<carDistance.Length; i++) {
			carDistance [i].Distance = carInfo [carDistance [i].ID].RemainingDistance;
			carDistance [i].setOrder (i);
		}
		
		for (int i=0; i<carDistance.Length; i++) {
			carDistance [i].Distance = carInfo [carDistance [i].ID].RemainingDistance;
			carDistance [i].setOrder (i);
		}
		
		if (GameData.isSinglePlayer == true) {
			this.updatePosition ();
			
		} else {
			switch (Game.gameState) {				
			case Game.GAME_STATE.START:
				this.updatePosition ();
				break;
				
			case Game.GAME_STATE.RUNNING:	
				this.updatePosition ();
				break;
				
			case Game.GAME_STATE.PAUSE:
				this.updatePosition ();
				break;
				
			case Game.GAME_STATE.PRE_GAME_OVER:	
				this.updatePositionAfterFinish ();
				break;
				
			case Game.GAME_STATE.WIN:
				this.updatePositionAfterFinish ();
				break;
				
			case Game.GAME_STATE.LOSE:
				this.updatePositionAfterFinish ();
				break;
				
			default:
				break;
			}
		}


		if (Game.gameState == Game.GAME_STATE.RUNNING) {
			if (GameData.selectedMode != GameData.GAME_MODE.CLASSIC) {
				if (GameData.isSinglePlayer == true) {
					if (police == null) {
						if (MainPlayer.carData.WantedBar >= 100) {
							this.initPolice ();
						}

						if (this.isPoliceCaught == true) {
							if (Time.timeSinceLevelLoad - this.policeCaughtTime >= 3) {
								MainPlayer.carData.rigidbody.constraints = RigidbodyConstraints.None;
								this.isPoliceCaught = false;
							} 
						}
					} else {
						if (this.isPoliceCaught == false) {
							if (Vector3.SqrMagnitude (MainPlayer.carData.transform.position - police.transform.position) < CHASE_DISTANCE) {
								if (MainPlayer.carData.PoliceCaughtBar >= 100) {
									game.soundManager.police.Stop ();
									MainPlayer.carData.policeCaught ();
					
									GameObject.Destroy (police);
									this.isPoliceCaught = true;
									this.policeCaughtTime = Time.timeSinceLevelLoad;
									GameData.isPoliceCaught = true;
					
								} else {
									MainPlayer.carData.PoliceCaughtBar += Time.deltaTime * 15;
								}
							} else {
								MainPlayer.carData.PoliceCaughtBar -= Time.deltaTime * 5;

								if (Vector3.SqrMagnitude (MainPlayer.carData.transform.position - police.transform.position) > INIT_DISTANCE) {
									this.respawnPoliceCar ();
								}
							}
						}
					}
				}
			}
		}

		this.postUpdate ();
	}

	public void UpdatePreGameOver ()
	{
		if (Time.timeSinceLevelLoad - game.LastChangeCam > 3) {
			game.changeCam ();
		}
	}

	public void updatePosition ()
	{
		for (int i=0; i<carDistance.Length-1; i++) {
			for (int j=i+1; j<carDistance.Length; j++) {
				if (carDistance [i].Distance > carDistance [j].Distance) {
					tempDistance.ID = carDistance [i].ID;
					tempDistance.Distance = carDistance [i].Distance;
					tempDistance.carData = carDistance [i].carData;
					
					carDistance [i].ID = carDistance [j].ID;
					carDistance [i].Distance = carDistance [j].Distance;
					carDistance [i].carData = carDistance [j].carData;
					
					carDistance [j].ID = tempDistance.ID;
					carDistance [j].Distance = tempDistance.Distance;
					carDistance [j].carData = tempDistance.carData;
				}
			}
		}
	}
	
	public void updatePositionAfterFinish ()
	{
		int playerIndex = 0;
		
		for (int i=0; i<carDistance.Length-1; i++) {
			if (carDistance [i].ID == BaseCarManager.mainPlayerID) {
				playerIndex = i;
				break;
			}
		}
		
		for (int i=playerIndex+1; i<carDistance.Length-1; i++) {
			for (int j=i+1; j<carDistance.Length; j++) {
				if (carDistance [i].Distance > 0 && carDistance [j].Distance > 0) {
					if (carDistance [i].Distance > carDistance [j].Distance) {
						tempDistance.ID = carDistance [i].ID;
						tempDistance.Distance = carDistance [i].Distance;
						tempDistance.carData = carDistance [i].carData;
						
						carDistance [i].ID = carDistance [j].ID;
						carDistance [i].Distance = carDistance [j].Distance;
						carDistance [i].carData = carDistance [j].carData;
						
						carDistance [j].ID = tempDistance.ID;
						carDistance [j].Distance = tempDistance.Distance;
						carDistance [j].carData = tempDistance.carData;
					}
				}
			}
		}
	}

	public int getCarID (int id)
	{
		for (int j=0; j<carID.Length; j++) {
			if (carInfo [j].ID == id) {
				return  BaseCarManager.carID [carInfo [j].ID];
			}
		}
		return 0;
	}

	public int getOrder (int id)
	{
		for (int j=0; j<carDistance.Length; j++) {
			if (carDistance [j].ID == id) {
				return j + 1;
			}
		}
		return carDistance.Length;
	}

	public CarData findLastOrderWithID ()
	{
		for (int j=carDistance.Length-1; j>-1; j--) {
			if (carDistance [j].carData.gameObject.activeInHierarchy == true) {
				return carDistance [j].carData;
			}
		}

		return null;
	}

	public void changePath (GameData.PATH_CHANGER_DIRECTION direction, PathChangingController pathChangerController, int carID)
	{
		switch (direction) {
		case GameData.PATH_CHANGER_DIRECTION.IN_IN:
			carInfo [mainPlayerID].NextWaypoint = game.map.path [pathChangerController.subPathID].waypointList.Length - 1;
			carInfo [mainPlayerID].PathChanger = pathChangerController;
			break;

		case GameData.PATH_CHANGER_DIRECTION.OUT_OUT:
			carInfo [mainPlayerID].NextWaypoint = pathChangerController.inWaypointID;
			carInfo [mainPlayerID].PathChanger = null;
			break;

		case GameData.PATH_CHANGER_DIRECTION.IN_OUT:
			carInfo [mainPlayerID].NextWaypoint = pathChangerController.inWaypointID;
			carInfo [mainPlayerID].PathChanger = null;
			break;

		case GameData.PATH_CHANGER_DIRECTION.OUT_IN:
			carInfo [mainPlayerID].NextWaypoint = 1;
			carInfo [mainPlayerID].PathChanger = pathChangerController;
			break;

		default:
			break;
		}
	}

	public static bool isInitCarID ()
	{
		for (int i=0; i<carID.Length; i++) {
			if (carID [i] == -1) {
				return false;
			}
		}
		return true;
	}

	public void respawnPlayerCar ()
	{
//		if (Game.gameState == Game.GAME_STATE.RUNNING) {
//			if (this.isPoliceCaught == false) {
//				MainPlayer.carData.resetStuck ();
//		
//				Vector3 currentPos = carInfo [mainPlayerID].getCurrentWaypointPos ();
//				Vector3 nextPos = carInfo [mainPlayerID].getNextWaypointPos ();
//		
//				player [mainPlayerID].transform.position = new Vector3 (currentPos.x, currentPos.y, currentPos.z);
//				player [mainPlayerID].transform.rotation = Quaternion.LookRotation (nextPos - currentPos);
//
//				player [mainPlayerID].rigidbody.velocity = Vector3.zero;
//				player [mainPlayerID].rigidbody.angularVelocity = Vector3.zero;
//
//				player [mainPlayerID].rigidbody.constraints = RigidbodyConstraints.None;
//			}
//		}
	}

	public void respawnEnemyCar (int carID)
	{
		if (Game.gameState == Game.GAME_STATE.RUNNING) {
			Vector3 currentPos = carInfo [carID].getCurrentWaypointPos ();
			Vector3 nextPos = carInfo [carID].getNextWaypointPos ();
		
			player [carID].transform.position = new Vector3 (currentPos.x, currentPos.y, currentPos.z);
			player [carID].transform.rotation = Quaternion.LookRotation (nextPos - currentPos);
		}
	}

	public void initPolice ()
	{
		Vector3 previousWaypoint = carInfo [mainPlayerID].getPreviousWaypointPos (2);
		Vector3 nextWaypoint = carInfo [mainPlayerID].getNextWaypointPos ();
		
		police = (GameObject)GameObject.Instantiate (Resources.Load<GameObject> 
		                                             (GameData.getCarPrefab (GameData.CAR_NAME.POLICE)),
		                                             previousWaypoint, Quaternion.LookRotation (nextWaypoint - carInfo [mainPlayerID].getCurrentWaypointPos ()));
		police.name = "Police";
		
		police.layer = LayerDefinition.POLICE;

		CarData carData = police.GetComponent<CarData> ();
		carData.ID = 10;
		carData.isPlayer = false;
		carData.isPolice = true;

		game.soundManager.playPolice ();
	}

	public void respawnPoliceCar ()
	{
		if (Game.gameState == Game.GAME_STATE.RUNNING) {
			if (numberRespawn < 3) {
				Vector3 previousWaypoint = carInfo [mainPlayerID].getPreviousWaypointPos (2);
				Vector3 nextWaypoint = carInfo [mainPlayerID].getNextWaypointPos ();
		
				police.transform.position = previousWaypoint;
				police.transform.rotation = Quaternion.LookRotation (nextWaypoint - carInfo [mainPlayerID].getCurrentWaypointPos ());

			} else {
				numberRespawn = 0;
				MainPlayer.carData.WantedBar = 0;
				MainPlayer.carData.PoliceCaughtBar = 0;

				this.uncaught ();
			}
		}
	}

	public bool isWrongWay (int carID)
	{
		if (carID > -1 && carID < carInfo.Length) {
			return carInfo [carID].isWrongWay ();
		} else {
			return false;
		}
	}

	public void unfreeze ()
	{
		for (int i=0; i<player.Length; i++) {
			player [i].rigidbody.constraints = RigidbodyConstraints.None;
		}
	}

	public void uncaught ()
	{
		GameObject.Destroy (police);
		game.soundManager.police.Stop ();
		this.isPoliceCaught = false;
	}
}