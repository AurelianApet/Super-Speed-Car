using UnityEngine;
using System.Collections;
using System;

[RequireComponent (typeof(NetworkView))]
[RequireComponent (typeof(PhotonView))]
public class Game : ServerHighscore
{
	public static float TIME_OUT = 10;

	public enum GAME_STATE
	{
		INIT,
		DISCONNECTED,
		START,
		RUNNING,
		PAUSE,
		PRE_GAME_OVER,
		WIN,
		LOSE
	}

	//--------------------------------------------------------------------------------
	public static GAME_STATE gameState;

	//--------------------------------------------------------------------------------
	public AutoCam autoCam;
	public HandHeldCam handHeldCam;
	public Map map;
	public MenuRenderer menuRenderer;
	public TrailController trailController;
	public SoundManager soundManager;

	//--------------------------------------------------------------------------------
	public BaseCarManager carManager;
	EnvironmentEffectController[] environmentEffectController;
	PhotonView photonView;

	//--------------------------------------------------------------------------------
	DateTime from;
	float stateTime;
	
	public float StateTime {
		get {
			return stateTime;
		}
	}

	//--------------------------------------------------------------------------------
	int camMode = -1;
	float lastChangeCam;

	public float LastChangeCam {
		get {
			return lastChangeCam;
		}
	}

	void Awake ()
	{		
		ProfileManager.init ();
		
		PhotonNetwork.isMessageQueueRunning = true;
		Application.targetFrameRate = 30;
	}
	
	void Start ()
	{
		environmentEffectController = GetComponentsInChildren<EnvironmentEffectController> (true);

		Game.gameState = GAME_STATE.INIT;
		if (GameData.isSinglePlayer == true) {
			carManager = new SinglePlayerCarManger (this);
		} else {
			carManager = new MultiplayerCarManager (this);			
			
			if (GameData.isWifiMode == false) {
				this.OnInternetLevelLoaded ();
			}
		}	
		
		from = DateTime.Now;
		GameData.resetData ();

		GoogleAnalytics.LogScreen (Application.loadedLevelName + ",Car:" + ProfileManager.userProfile.SelectedCar);
	}

	void OnWifiLevelLoaded ()
	{		
		Time.timeScale = 0;
		if (networkView.isMine) {
			if (Network.peerType == NetworkPeerType.Server) {
				for (int i=0; i<GameData.numberPlayers; i++) {
					networkView.RPC ("initPlayer", RPCMode.All, i);
				}

				BaseCarManager.isFinishedLoading [0] = true;	
			} 
		} else { 
			networkView.RPC ("finishLoading", RPCMode.Server, BaseCarManager.mainPlayerID);
		} 
	}

	void OnInternetLevelLoaded ()
	{
		Time.timeScale = 0;
		photonView = PhotonView.Get (this); 
		if (photonView.isMine) {
			if (PhotonNetwork.isMasterClient) {
				for (int i=0; i<GameData.numberPlayers; i++) {
					photonView.RPC ("initPlayer", PhotonTargets.All, i);
				}
				
				BaseCarManager.isFinishedLoading [0] = true;	
			} 
		} else { 
			photonView.RPC ("finishLoading", PhotonTargets.MasterClient, BaseCarManager.mainPlayerID);
		}
	}

	void Update ()
	{
		if (GameData.isSinglePlayer == true) {
			this.updateSinglePlayerGame ();
		} else {
			if (GameData.isWifiMode == true) {
				this.updateWifiGame ();
			} else {
				this.updateInternetGame ();
			}
		}
	}

	void OnApplicationPause (bool pauseStatus)
	{
		if (pauseStatus == true) {
			this.pauseGame ();
		} else {
			this.resumeGame ();
		}
	}

	/**************************************************/
	/* Functions called from Update()         	      */
	/**************************************************/
	void updateSinglePlayerGame ()
	{
		switch (gameState) {
		case GAME_STATE.START:
			carManager.Update ();
			if (Time.timeSinceLevelLoad > 3) {
				Game.gameState = GAME_STATE.RUNNING;
				carManager.unfreeze ();
				soundManager.playMusic ();
				soundManager.playEngine ();
				
				if (GameData.selectedMode == GameData.GAME_MODE.ELIMINATION) {
					((SinglePlayerCarManger)carManager).lastEliminate = Time.timeSinceLevelLoad;
				}
			} 
			break;

		case GAME_STATE.RUNNING:			
			carManager.Update ();
			this.stateTime += Time.deltaTime;
			if (Input.GetKeyUp (KeyCode.Escape)) {
				this.pauseGame ();
			}
			break;			
			
		case GAME_STATE.PAUSE:
			this.updatePause ();
			break;

		case GAME_STATE.PRE_GAME_OVER:			
			carManager.UpdatePreGameOver ();
			if ((new TimeSpan (DateTime.Now.Ticks - from.Ticks)).TotalSeconds > 3 * map.cameraPoint.Length - 0.1f) {
				if (GameData.rank <= 3) {
					this.winGame ();
				} else {
					this.loseGame ();
				}
			}
			break;

		case GAME_STATE.WIN:	
			this.updateWin ();
			break;

		case GAME_STATE.LOSE:
			this.updateLose ();
			break;

		default:
			break;
		}				
	}

	//--------------------------------------------------------------------------------
	void updateWifiGame ()
	{
		switch (gameState) {
		case GAME_STATE.INIT:
			if (Network.peerType == NetworkPeerType.Server) {
				if (((MultiplayerCarManager)carManager).isLoadingComplete () == true 
					|| (new TimeSpan (DateTime.Now.Ticks - from.Ticks)).TotalSeconds > TIME_OUT) {

					networkView.RPC ("startGame", RPCMode.Others);							
					Game.gameState = Game.GAME_STATE.START;
					Time.timeScale = 1;
					soundManager.playCountDown ();
				}
			} 
			break;
			
		case GAME_STATE.START:
			if (Time.timeSinceLevelLoad > 3) {
				((MultiplayerCarManager)carManager).initLastReceivePosition ();

				Game.gameState = GAME_STATE.RUNNING;
				carManager.unfreeze ();
				soundManager.playMusic ();
				soundManager.playEngine ();
			} 
			break;
			
		case GAME_STATE.RUNNING:	
			this.exchangeWifiInformation ();
			break;
			
		case GAME_STATE.PAUSE:
			this.exchangeWifiInformation ();
			this.updatePause ();
			break;

		case GAME_STATE.PRE_GAME_OVER:		
			this.exchangeWifiInformation ();
			break;
			
		case GAME_STATE.WIN:
			this.exchangeWifiInformation ();
			this.updateWin ();
			break;
			
		case GAME_STATE.LOSE:
			this.exchangeWifiInformation ();
			this.updateLose ();
			break;
			
		default:
			break;
		}			
	}

	void exchangeWifiInformation ()
	{
		carManager.Update ();	
		this.stateTime += Time.deltaTime;
		
		if (Network.peerType == NetworkPeerType.Server) {
			if (Time.timeSinceLevelLoad - ((MultiplayerCarManager)carManager).lastSendRPC > MultiplayerCarManager.WIFI_RPC_DELTA_TIME) {
				for (int i=0; i<carManager.player.Length; i++) {
					networkView.RPC ("syncTransform", RPCMode.Others, i,
					                 carManager.player [i].transform.position, carManager.player [i].transform.rotation, 
					                 carManager.carInfo [i].RemainingDistance);
				}
				
				((MultiplayerCarManager)carManager).lastSendRPC = Time.timeSinceLevelLoad;
				
			}
		} else {
			if (Time.timeSinceLevelLoad - ((MultiplayerCarManager)carManager).lastSendRPC > MultiplayerCarManager.WIFI_RPC_DELTA_TIME) {
				networkView.RPC ("syncTransform", RPCMode.Server, BaseCarManager.mainPlayerID, 
				                 carManager.player [BaseCarManager.mainPlayerID].transform.position, carManager.player [BaseCarManager.mainPlayerID].transform.rotation,
				                 carManager.carInfo [BaseCarManager.mainPlayerID].RemainingDistance);
				
				((MultiplayerCarManager)carManager).lastSendRPC = Time.timeSinceLevelLoad;
			}
		}
		
		for (int i=0; i<carManager.player.Length; i++) {
			if (i != BaseCarManager.mainPlayerID) {
				if (Time.timeSinceLevelLoad - ((MultiplayerCarManager)carManager).lastReceivePostion [i] < 5) {
					carManager.player [i].transform.position = Vector3.Lerp (carManager.player [i].transform.position,
					                                                         ((MultiplayerCarManager)carManager).position [i], Time.deltaTime);
					carManager.player [i].transform.rotation = Quaternion.Lerp (carManager.player [i].transform.rotation,
					                                                            ((MultiplayerCarManager)carManager).rotation [i], Time.deltaTime);
					
				}
			}
		}
	}

	//--------------------------------------------------------------------------------
	void updateInternetGame ()
	{
		switch (gameState) {
		case GAME_STATE.INIT:
			if (PhotonNetwork.isMasterClient) {
				if (((MultiplayerCarManager)carManager).isLoadingComplete () == true 
					|| (new TimeSpan (DateTime.Now.Ticks - from.Ticks)).TotalSeconds > TIME_OUT) {
						
					photonView.RPC ("startGame", PhotonTargets.Others);							
					Game.gameState = Game.GAME_STATE.START;
					Time.timeScale = 1;
					soundManager.playCountDown ();
				}
			} 
			break;
			
		case GAME_STATE.START:
			if (Time.timeSinceLevelLoad > 3) {
				Game.gameState = GAME_STATE.RUNNING;
				carManager.unfreeze ();
				soundManager.playMusic ();
				soundManager.playEngine ();
			} 
			break;
			
		case GAME_STATE.RUNNING:			
			this.exchangeInternetInformation ();
			break;
			
		case GAME_STATE.PAUSE:
			this.exchangeInternetInformation ();
			this.updatePause ();
			break;
			
		case GAME_STATE.PRE_GAME_OVER:	
			this.exchangeInternetInformation ();
			break;
			
		case GAME_STATE.WIN:
			this.exchangeInternetInformation ();
			this.updateWin ();	
			break;
			
		case GAME_STATE.LOSE:
			this.exchangeInternetInformation ();
			this.updateLose ();
			break;
			
		default:
			break;
		}
	}

	void exchangeInternetInformation ()
	{
		carManager.Update ();	
		this.stateTime += Time.deltaTime;
		if (Input.GetKeyUp (KeyCode.Escape)) {
			this.pauseGame ();
		}
		
		if (Time.timeSinceLevelLoad - ((MultiplayerCarManager)carManager).lastSendRPC > MultiplayerCarManager.INTERNET_RPC_DELTA_TIME) {
			photonView.RPC ("syncTransform", PhotonTargets.Others, BaseCarManager.mainPlayerID,
			                carManager.player [BaseCarManager.mainPlayerID].transform.position,
			                carManager.player [BaseCarManager.mainPlayerID].transform.rotation, 
			                carManager.carInfo [BaseCarManager.mainPlayerID].RemainingDistance);
			
			((MultiplayerCarManager)carManager).lastSendRPC = Time.timeSinceLevelLoad;	
		}
		
		for (int i=0; i<carManager.player.Length; i++) {
			if (i != BaseCarManager.mainPlayerID) {
				if (Time.timeSinceLevelLoad - ((MultiplayerCarManager)carManager).lastReceivePostion [i] < 5) {
					carManager.player [i].transform.position = Vector3.Lerp (carManager.player [i].transform.position,
					                                                         ((MultiplayerCarManager)carManager).position [i], Time.deltaTime);
					carManager.player [i].transform.rotation = Quaternion.Lerp (carManager.player [i].transform.rotation,
					                                                            ((MultiplayerCarManager)carManager).rotation [i], Time.deltaTime);
					
				}
			}
		}
	}

	/**************************************************/
	/* RPC								         	  */
	/**************************************************/
	[RPC]
	void initPlayer (int id)
	{
		((MultiplayerCarManager)carManager).initPlayer (id);	
	}

	[RPC]
	void finishLoading (int id)
	{
		BaseCarManager.isFinishedLoading [id] = true;	
	}

	[RPC]
	void startGame ()
	{
		Game.gameState = Game.GAME_STATE.START;
		Time.timeScale = 1;
	}
	
	[RPC]
	void syncTransform (int id, Vector3 position, Quaternion rotation, float distance)
	{
		if (id != BaseCarManager.mainPlayerID) {
//						if (distance < carManager.carInfo [id].RemainingDistance) {
			((MultiplayerCarManager)carManager).position [id] = position;
			((MultiplayerCarManager)carManager).rotation [id] = rotation;
			carManager.carInfo [id].RemainingDistance = distance;
			
			((MultiplayerCarManager)carManager).lastReceivePostion [id] = Time.timeSinceLevelLoad; 

			if (Time.timeSinceLevelLoad - ((MultiplayerCarManager)carManager).lastReceivePostion [id] > 5) {
				carManager.player [id].transform.position = position;
				carManager.player [id].transform.rotation = rotation;
			}
//						}
		}
	}

	/**************************************************/
	/* Update game state				         	  */
	/**************************************************/
	void updatePause ()
	{
		if (Input.GetKeyUp (KeyCode.Escape)) {
			this.resumeGame ();
		}
	}

	void updateWin ()
	{
		if (Input.GetKeyUp (KeyCode.Escape)) {
			AutoFade.LoadLevel ("MainMenu");
			Time.timeScale = 1;
		}
	}

	void updateLose ()
	{
		if (Input.GetKeyUp (KeyCode.Escape)) {
			AutoFade.LoadLevel ("MainMenu");
			Time.timeScale = 1;
		}
	}

	/**************************************************/
	/* Change game state				         	  */
	/**************************************************/
	public void pauseGame ()
	{
		if (Game.gameState == GAME_STATE.RUNNING) {
			Time.timeScale = 0;
			Game.gameState = GAME_STATE.PAUSE;
			this.soundManager.stopAllLoopSound ();
		}
	}

	public void resumeGame ()
	{
		if (Game.gameState == GAME_STATE.PAUSE) {
			Time.timeScale = 1;
			Game.gameState = GAME_STATE.RUNNING;
			this.soundManager.replayAll ();
		}
	}

	public void preGameOver ()
	{
		if (Game.gameState == GAME_STATE.RUNNING) {
			for (int i=0; i<carManager.player.Length; i++) {
				LODGroup lod = carManager.player [i].GetComponent<LODGroup> ();

				if (lod != null) {
					lod.ForceLOD (0);
				}
			}			
			
			carManager.MainPlayer.carData.changeController ();
			carManager.preGameOver ();

			menuRenderer.lastChangeToPreGameOver = Time.timeSinceLevelLoad;
			Game.gameState = GAME_STATE.PRE_GAME_OVER;
			from = DateTime.Now;	

			StartCoroutine (switchCameraView ());			

			soundManager.playPreGameOver ();

			this.calculateReward ();		
			this.calculateAchievement ();				

			GameData.resetGlobalPowerUp ();

			ProfileManager.userProfile.Money += GameData.reward;
			ProfileManager.userProfile.Score += GameData.score;

			PlayerPrefs.Save ();
		}
	}

	public void winGame ()
	{
		if (Game.gameState == GAME_STATE.PRE_GAME_OVER) {
			Game.gameState = GAME_STATE.WIN;
			soundManager.playWin ();

			Time.timeScale = 0;
			
			this.autoCam.gameObject.SetActive (true);
			this.handHeldCam.gameObject.SetActive (false);
		}
	}
	
	public void loseGame ()
	{
		if (Game.gameState == GAME_STATE.PRE_GAME_OVER) {	
			Game.gameState = GAME_STATE.LOSE;
			soundManager.playLose ();

			Time.timeScale = 0;
			
			this.autoCam.gameObject.SetActive (true);
			this.handHeldCam.gameObject.SetActive (false);
		}
	}

	//--------------------------------------------------------------------------------
	IEnumerator switchCameraView ()
	{
		yield return new WaitForSeconds (0.5f);

		this.autoCam.gameObject.SetActive (false);
		this.handHeldCam.gameObject.SetActive (true);
		this.changeCam ();			
	}

	public void changeCam ()
	{
		camMode = (camMode + 1) % map.cameraPoint.Length;
		this.lastChangeCam = Time.timeSinceLevelLoad;	
		
		this.handHeldCam.transform.position = map.cameraPoint [camMode].position;
	}

	public void changeQuality ()
	{
		for (int i=0; i<environmentEffectController.Length; i++) {
			environmentEffectController [i].ChangeQualitySettings ();
		}
	}

	public void calculateAchievement ()
	{
		if (GameData.isUseNitro == false) {
			ProfileManager.achievementProfile.WinWithoutUsingNitro = true;
		}

		if (GameData.maxVelocityLimit > ProfileManager.achievementProfile.MaxSpeedReach) {
			ProfileManager.achievementProfile.MaxSpeedReach = GameData.maxVelocityLimit;
		}

		ProfileManager.achievementProfile.NumberDestroyedObstacles += carManager.MainPlayer.carData.TotalObstacleCollision;
		ProfileManager.achievementProfile.DollarEarned += carManager.MainPlayer.carData.TotalDollarEarned;

		ProfileManager.achievementProfile.DriftDuration += carManager.MainPlayer.carData.TotalDriftTime;
		ProfileManager.achievementProfile.FlyDuration += carManager.MainPlayer.carData.TotalFlyTime;

		ProfileManager.achievementProfile.NitroUsingDuration += carManager.MainPlayer.carData.TotalNitroUsingDuration;
		ProfileManager.achievementProfile.CoinEarn += carManager.MainPlayer.carData.TotalDollarEarned;

		switch (GameData.selectedMode) {
		case GameData.GAME_MODE.CLASSIC:
			ProfileManager.achievementProfile.NumberPlayClassic++;
			break;

		case GameData.GAME_MODE.CHECK_POINT:
			ProfileManager.achievementProfile.NumberPlayCheckPoint++;
			break;

		case GameData.GAME_MODE.TIME_TRIAL:
			ProfileManager.achievementProfile.NumberPlayTimeTrial++;
			break;

		case GameData.GAME_MODE.ELIMINATION:
			ProfileManager.achievementProfile.NumberPlayElimination++;
			break;

		default:
			break;
		}

		if (GameData.isSinglePlayer == false) {
			ProfileManager.achievementProfile.NumberPlayMultiplayer++;
			if (GameData.rank == 1) {
				ProfileManager.achievementProfile.MultiplayerWin++;
			} else {
				ProfileManager.achievementProfile.MultiplayerLose++;
			}
		} else {
			if (GameData.level == -1) {
				if (GameData.rank <= 3) {
					ProfileManager.achievementProfile.NumberQuickRaceWin++;
				}
			} else {
				ProfileManager.achievementProfile.NumberPlayCareer++;
			}
		}
	}

	public void calculateReward ()
	{
		ProfileManager.questProfile.updateQuest (this);

		bool isPreCompleted = false;

		if (GameData.level > -1) {
			if (ProfileManager.userProfile.MapProfile [GameData.level].MainMission > 0) {
				isPreCompleted = true;
			}
			
			switch (GameData.rank) {
			case 1:
				if (ProfileManager.userProfile.MapProfile [GameData.level].MainMission < 3) {
					ProfileManager.userProfile.MapProfile [GameData.level].MainMission = 3;
				}
				this.nextLevel ();
				break;
				
			case 2:
				if (ProfileManager.userProfile.MapProfile [GameData.level].MainMission < 2) {
					ProfileManager.userProfile.MapProfile [GameData.level].MainMission = 2;
				}
				this.nextLevel ();
				break;
				
			case 3:
				if (ProfileManager.userProfile.MapProfile [GameData.level].MainMission < 1) {
					ProfileManager.userProfile.MapProfile [GameData.level].MainMission = 1;
				}
				this.nextLevel ();
				break;
				
			default:
				break;
			}
			
			if (GameData.FirstMission == true) {
				if (ProfileManager.userProfile.MapProfile [GameData.level].FirstMission == false) {
					ProfileManager.userProfile.MapProfile [GameData.level].FirstMission = true;
				}
			}
			
			if (GameData.SecondMission == true) {
				if (ProfileManager.userProfile.MapProfile [GameData.level].SecondMission == false) {
					ProfileManager.userProfile.MapProfile [GameData.level].SecondMission = true;
				}
			}
		}

		if (GameData.isSinglePlayer == true) {
			GameData.reward = carManager.MainPlayer.carData.TotalDollarEarned 
				+ RewardData.getReward (GameData.level, GameData.selectedMode, GameData.selectedMap, GameData.rank, isPreCompleted)
				* (GameData.IsDoubleReward == true ? 2 : 1);

			GameData.score = (int)(carManager.MainPlayer.carData.TotalDriftTime * 25 + carManager.MainPlayer.carData.TotalFlyTime * 30
				+ carManager.MainPlayer.carData.NitroEarned * 5 + carManager.MainPlayer.carData.TotalObstacleCollision * 15
				+ carManager.MainPlayer.carData.TotalDollarEarned + 2000 / this.stateTime + (6 - GameData.rank) * 50
				+ carManager.MainPlayer.carData.TotalNitroUsingDuration * 10);
			
			if (GameData.level > -1) {
				GameData.score = (int)(GameData.score * (1 + SeasonDescription.getSeason (GameData.level + 1) * 0.1f));

			} else {
				if (GameData.selectedEvent > -1) {
					ProfileManager.eventProfile.finishEvent (GameData.selectedEvent, GameData.rank);
				}
			}

			if (GameData.IsDoubleScore == true) {
				GameData.score *= 2;
			}
		} else {
			GameData.reward = carManager.MainPlayer.carData.TotalDollarEarned 
				+ RewardData.getReward (GameData.level, GameData.selectedMode, GameData.selectedMap, GameData.rank, isPreCompleted)
				* (GameData.IsDoubleReward == true ? 2 : 1);
			
			GameData.score = (int)(carManager.MainPlayer.carData.TotalDriftTime * 25 + carManager.MainPlayer.carData.TotalFlyTime * 30
				+ carManager.MainPlayer.carData.NitroEarned * 5 + carManager.MainPlayer.carData.TotalObstacleCollision * 15
				+ carManager.MainPlayer.carData.TotalDollarEarned + 2000 / this.stateTime + (6 - GameData.rank) * 50
				+ carManager.MainPlayer.carData.TotalNitroUsingDuration * 10);	

			if (GameData.isWifiMode == false) {
				if (GameData.rank == 1) {
					switch (carManager.player.Length) {
					case 2:							
						GameData.reward += GameData.betValue;
						break;

					case 3:
						GameData.reward += (int)(GameData.betValue * 1.5f);
						break;

					case 4:
						GameData.reward += GameData.betValue * 2;
						break;

					case 5:
						GameData.reward += (int)(GameData.betValue * 2.5f);
						break;

					case 6:
						GameData.reward += GameData.betValue * 3;
						break;

					default:
						break;
					}

					switch (GameData.betValue) {
					case 1000:							
						GameData.score = (int)(GameData.score * 1.3f);
						break;

					case 5000:
						GameData.score = (int)(GameData.score * 1.4f);
						break;

					case 10000:
						GameData.score = (int)(GameData.score * 1.5f);
						break;

					case 20000:
						GameData.score = (int)(GameData.score * 1.6f);
						break;

					case 50000:
						GameData.score = (int)(GameData.score * 1.7f);
						break;

					case 100000:
						GameData.score = (int)(GameData.score * 1.8f);
						break;

					case 300000:
						GameData.score = (int)(GameData.score * 1.9f);
						break;

					case 500000:
						GameData.score = (int)(GameData.score * 2f);
						break;

					default:
						break;
					}

					if (InternetGameMenu.isInKingOfDayEvent () == true) {
						GameData.score *= 2;
						GameData.reward *= 2;
					}	
				}
			}
		}		
		
		postScoreKingOfDay (ProfileManager.userProfile.Score, ProfileManager.userProfile.getNumberStar (),
		                    SystemInfo.deviceUniqueIdentifier, ProfileManager.userProfile.PlayerName, ProfileManager.userProfile.Nation.ToString ());
		
		postScore (ProfileManager.userProfile.Score, ProfileManager.userProfile.getNumberStar (),
		           SystemInfo.deviceUniqueIdentifier, ProfileManager.userProfile.PlayerName, ProfileManager.userProfile.Nation.ToString ());
	}

	public void nextLevel ()
	{
		if (GameData.level > -1) {
			if (ProfileManager.userProfile.isLevelUnlocked (ProfileManager.userProfile.SelectedLevel + 1)) {
				int season = SeasonDescription.getSeason (GameData.level + 1);

				if (GameData.level + 1 < SeasonDescription.getNumberLevelBySeasonAccumulate (season)) {	
					ProfileManager.userProfile.SelectedLevel++;

				} else {
					if (season < 8) {
						if (ProfileManager.userProfile.isSeasonUnlocked (season + 1)) {
							ProfileManager.userProfile.SelectedLevel = SeasonDescription.getFirstLevelInSeason (season + 1);
						}
					}
				}
			}
		}
	}
}