using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;

public class InternetGameMenu : BaseMultiplayerGameMenu
{
	public static float WAITING_TIME = 31f;
	public static float SYNC_LEVEL_TIME = 0.1f;

	//
	public static string serverConnectionDetails = string.Empty;
	
	//
	string[] HOST = {
		"app-asia.exitgamescloud.com",
		"app-us.exitgamescloud.com",
		"app-eu.exitgamescloud.com",
		"app-jp.exitgamescloud.com"
		};
//		Photon AppId
	string APP_ID = "9128de8c-ae73-48f2-99a2-99a485f6c864";
	
	//
	bool isJoined = false;
	PhotonView photonView;
	
	//
	float lastWaitTime = 0;
	float lastSyncLevelNameTime = 0;

	//
	public AudioSource audioSource;
	public AudioSource click;
	
	//
	public ChangeAvatar changeAvatar;
	
	//
	public dfSprite[] mapPreview;
	public NetworkPlayerRow[] playerRowList;
	public dfLabel startGameLabel;
	public dfButton nextMapButton;
	public dfButton prevMapButton;
	public dfLabel betValue;

	//
	public dfPanel noticeDialog;
	public dfLabel messageTextDialog;
	
	//
	int numberDot;
	float lastChangeNumberDot;
	float remainingTime;

	//
	public static List<string> fakePlayerName = new List<string> ();
	public static List<int> fakePlayerAvatar = new List<int> ();
	
	//--------------------------------------------------------------------------------
	void Start ()
	{
		this.maxConnections = 6;
		
		GameData.isSinglePlayer = false;
		GameData.isWifiMode = false;
		
		PhotonNetwork.playerName = ProfileManager.userProfile.PlayerName;
		photonView = PhotonView.Get (this);
		
		this.serverState = SERVER_STATE.NOT_START;
		
		GameData.selectedMap = (GameData.MAP_NAME)UnityEngine.Random.Range (0, 8);
		for (int i=0; i<mapPreview.Length; i++) {
			mapPreview [i].gameObject.SetActive (false);
		}
		mapPreview [(int)GameData.selectedMap].gameObject.SetActive (true);
		
		if (PhotonNetwork.connectionState == ConnectionState.Disconnected) {
//						PhotonNetwork.ConnectToBestCloudServer ("King Of Racing 2");
			PhotonNetwork.ConnectToMaster (HOST [0], 5055, APP_ID, "King Of Racing 2");
		}
		PhotonNetwork.isMessageQueueRunning = true;		
		
		ExitGames.Client.Photon.Hashtable PlayerCustomProps = new ExitGames.Client.Photon.Hashtable ();				
		PlayerCustomProps ["CarID"] = ProfileManager.userProfile.SelectedCar;
		PlayerCustomProps ["FaceID"] = ProfileManager.userProfile.FacebookID;
		PlayerCustomProps ["Avatar"] = ProfileManager.userProfile.AvatarID;
		
		PhotonNetwork.player.SetCustomProperties (PlayerCustomProps);	

		ProfileManager.init ();
		
		audioSource.volume = ProfileManager.setttings.MusicVolume / 100f;
		audioSource.Play ();

		click.volume = ProfileManager.setttings.SoundVolume / 100f;

		betValue.Text = string.Format ("{0:n00}", GameData.betValue);

		fakePlayerName.Clear ();
		fakePlayerAvatar.Clear ();

		for (int i=0; i<6; i++) {
			fakePlayerName.Add (EnemyNameList.getEnemyName ());
			fakePlayerAvatar.Add (UnityEngine.Random.Range (0, changeAvatar.icon.Length));
		}

		GoogleAnalytics.LogScreen ("Bet Value:" + GameData.betValue);
	}
	
	void Update ()
	{
		if (Input.GetKeyUp (KeyCode.Escape)) {
			AutoFade.LoadLevel ("ChooseOnlineMode");
			PhotonNetwork.Disconnect ();
		} else {
			this.updateInfo ();
		}
		
		if (this.isJoined == false) {
			if (Time.timeSinceLevelLoad - lastChangeNumberDot > 0.1f) {
				lastChangeNumberDot = Time.timeSinceLevelLoad;
				numberDot = (numberDot + 1) % 6;
				
			} else {				
				string text = "Connecting";
				
				for (int i=0; i<numberDot; i++) {
					text += ".";
				}
				
				startGameLabel.Text = text;
			}
			
			for (int i=0; i<playerRowList.Length; i++) {
				playerRowList [i].playerName.Text = string.Empty;
				playerRowList [i].playerCar.Text = string.Empty;
				playerRowList [i].playerAvatar.Texture = null;
				playerRowList [i].playerLoading.IsVisible = false;
			}
		} else {
			if (PhotonNetwork.room != null) {
				for (int i=0; i<PhotonNetwork.playerList.Length; i++) {
					playerRowList [i].playerName.Text = PhotonNetwork.playerList [i].name;
					playerRowList [i].playerCar.Text = GameData.getCarName (int.Parse (PhotonNetwork.playerList [i].customProperties ["CarID"].ToString ())).ToString ().Replace ('_', ' ');
					
					FacebookAvatar avatar = getAvatar (PhotonNetwork.playerList [i].customProperties ["FaceID"].ToString ());
					
					if (avatar.isError == false) {
						if (avatar.isAvatarLoaded == true) {
							playerRowList [i].playerAvatar.Texture = avatar.avatar;
							playerRowList [i].playerLoading.IsVisible = false;
						} else {
							playerRowList [i].playerAvatar.Texture = null;
							playerRowList [i].playerLoading.IsVisible = true;
						}
					} else {
						if (playerRowList [i].playerAvatar.Texture == null) {
							playerRowList [i].playerLoading.IsVisible = false;
							playerRowList [i].playerAvatar.Texture = changeAvatar.icon [int.Parse (PhotonNetwork.playerList [i].customProperties ["Avatar"].ToString ())];
						}
					}
				}

				if (WAITING_TIME - Time.timeSinceLevelLoad + lastWaitTime > 15) {
					for (int i=PhotonNetwork.playerList.Length; i<playerRowList.Length; i++) {
						playerRowList [i].playerName.Text = string.Empty;
						playerRowList [i].playerCar.Text = string.Empty;
						playerRowList [i].playerAvatar.Texture = null;
						playerRowList [i].playerLoading.IsVisible = false;
					}
				} else {
					if (PhotonNetwork.room.playerCount == 1) {
						if (WAITING_TIME - Time.timeSinceLevelLoad + lastWaitTime > 12) {
							for (int i=1; i<2; i++) {
								playerRowList [i].playerName.Text = fakePlayerName [i];
								playerRowList [i].playerCar.Text = GameData.getCarName (ProfileManager.userProfile.SelectedCar).ToString ().Replace ('_', ' ');
								playerRowList [i].playerAvatar.Texture = changeAvatar.icon [fakePlayerAvatar [i]];
								playerRowList [i].playerLoading.IsVisible = false;
							}
						} else if (WAITING_TIME - Time.timeSinceLevelLoad + lastWaitTime > 9) {
							for (int i=1; i<3; i++) {
								playerRowList [i].playerName.Text = fakePlayerName [i];
								playerRowList [i].playerCar.Text = GameData.getCarName (ProfileManager.userProfile.SelectedCar).ToString ().Replace ('_', ' ');
								playerRowList [i].playerAvatar.Texture = changeAvatar.icon [fakePlayerAvatar [i]];
								playerRowList [i].playerLoading.IsVisible = false;
							}
						} else if (WAITING_TIME - Time.timeSinceLevelLoad + lastWaitTime > 6) {
							for (int i=1; i<4; i++) {
								playerRowList [i].playerName.Text = fakePlayerName [i];
								playerRowList [i].playerCar.Text = GameData.getCarName (ProfileManager.userProfile.SelectedCar).ToString ().Replace ('_', ' ');
								playerRowList [i].playerAvatar.Texture = changeAvatar.icon [fakePlayerAvatar [i]];
								playerRowList [i].playerLoading.IsVisible = false;
							}
						} else if (WAITING_TIME - Time.timeSinceLevelLoad + lastWaitTime > 3) {
							for (int i=1; i<5; i++) {
								playerRowList [i].playerName.Text = fakePlayerName [i];
								playerRowList [i].playerCar.Text = GameData.getCarName (ProfileManager.userProfile.SelectedCar).ToString ().Replace ('_', ' ');
								playerRowList [i].playerAvatar.Texture = changeAvatar.icon [fakePlayerAvatar [i]];
								playerRowList [i].playerLoading.IsVisible = false;
							}
						} else if (WAITING_TIME - Time.timeSinceLevelLoad + lastWaitTime > 0) {
							for (int i=1; i<6; i++) {
								playerRowList [i].playerName.Text = fakePlayerName [i];
								playerRowList [i].playerCar.Text = GameData.getCarName (ProfileManager.userProfile.SelectedCar).ToString ().Replace ('_', ' ');
								playerRowList [i].playerAvatar.Texture = changeAvatar.icon [fakePlayerAvatar [i]];
								playerRowList [i].playerLoading.IsVisible = false;
							}
						}
					} else {
						for (int i=PhotonNetwork.playerList.Length; i<playerRowList.Length; i++) {
							playerRowList [i].playerName.Text = string.Empty;
							playerRowList [i].playerCar.Text = string.Empty;
							playerRowList [i].playerAvatar.Texture = null;
							playerRowList [i].playerLoading.IsVisible = false;
						}

						if (WAITING_TIME - Time.timeSinceLevelLoad + lastWaitTime < 1) {	
							if (PhotonNetwork.isMasterClient == true) {
								PhotonNetwork.room.open = false;
								PhotonNetwork.room.visible = false;
							}
						}
					}
				}
				
				if (PhotonNetwork.isMasterClient == true) {
					nextMapButton.IsVisible = true;
					prevMapButton.IsVisible = true;
					
					if (WAITING_TIME - Time.timeSinceLevelLoad + lastWaitTime > 0) {
						startGameLabel.Text = "Start  in  " + (int)(WAITING_TIME - Time.timeSinceLevelLoad + lastWaitTime) + "  seconds";
					} else {
						startGameLabel.Text = "Start  in  0  seconds";
					}
				} else {
					nextMapButton.IsVisible = false;
					prevMapButton.IsVisible = false;

					startGameLabel.Text = "Start  in  " + remainingTime + "  seconds";
				}

				if (PhotonNetwork.playerList.Length > 1) {
					if (PhotonNetwork.isMasterClient == true) {
						switch (this.serverState) {
						case SERVER_STATE.NOT_START:	
							if (Time.timeSinceLevelLoad - lastWaitTime >= WAITING_TIME 
								|| PhotonNetwork.room.playerCount == maxConnections) {									
								GameData.numberPlayers = PhotonNetwork.playerList.Length;
								GameData.numberRaces = getNumberRaces ();
								
								BaseCarManager.carID = new int[GameData.numberPlayers];
								for (int k=1; k<BaseCarManager.carID.Length; k++) {
									BaseCarManager.carID [k] = -1;
								}
								
								BaseCarManager.playerName = new string[GameData.numberPlayers];
								for (int k=1; k<BaseCarManager.playerName.Length; k++) {
									BaseCarManager.playerName [k] = UserProfile.DEFAULT_NAME;
								}
								
								BaseCarManager.mainPlayerID = 0;
								BaseCarManager.carID [0] = ProfileManager.userProfile.SelectedCar;
								BaseCarManager.playerName [0] = ProfileManager.userProfile.PlayerName;

								for (int i=0; i<PhotonNetwork.playerList.Length; i++) {
									if (PhotonNetwork.playerList [i].isMasterClient == false) {
										photonView.RPC ("photonInitGameData", PhotonNetwork.playerList [i], (int)GameData.selectedMap,
										                GameData.numberRaces, GameData.numberPlayers, i);
									}
								}
								
								stateTime = Time.timeSinceLevelLoad;
								this.serverState = SERVER_STATE.STARTING;

							} else {
								if (Time.timeSinceLevelLoad - lastSyncLevelNameTime > SYNC_LEVEL_TIME) {
									photonView.RPC ("syncLevelName", PhotonTargets.Others, (int)GameData.selectedMap, (int)(WAITING_TIME - Time.timeSinceLevelLoad + lastWaitTime));
									lastSyncLevelNameTime = Time.timeSinceLevelLoad;
								}
							}
							break;
							
						case SERVER_STATE.STARTING:
							if ((Time.timeSinceLevelLoad - stateTime > 5) || BaseCarManager.isInitCarID () == true) {
								List<CompactUserData> compactUserDataList = new List<CompactUserData> ();
								
								for (int k=0; k<BaseCarManager.carID.Length; k++) {
									CompactUserData compactUserData = new CompactUserData ();
									compactUserData.carID = BaseCarManager.carID [k];
									compactUserData.name = BaseCarManager.playerName [k];
									
									compactUserDataList.Add (compactUserData);
								}


								photonView.RPC ("photonSyncPlayerData", PhotonTargets.Others, JsonConvert.SerializeObject (compactUserDataList));
																								
								stateTime = Time.timeSinceLevelLoad;
								this.serverState = SERVER_STATE.READY;
							}
							break;
							
						case SERVER_STATE.READY:	
							photonView.RPC ("photonLoadGame", PhotonTargets.All, GameData.getMapPath (GameData.selectedMap));														
							break;
							
						default:
							break;
						}
					}
				} else {
					if (Time.timeSinceLevelLoad - lastWaitTime >= WAITING_TIME) {
						PhotonNetwork.Disconnect ();
												
						ProfileManager.userProfile.Money += GameData.betValue;
						GameData.betValue = 0;
						PlayerPrefs.Save ();
						
						GameData.numberPlayers = 6;
						GameData.isWifiMode = false;
						GameData.isSinglePlayer = true;
						
						GameData.selectedMode = GameData.GAME_MODE.CLASSIC;
						GameData.numberRaces = 2;
						GameData.level = -1;
						
						SceneLoader.scene = GameData.getMapPath (GameData.selectedMap);
						Application.LoadLevel ("Loading");
					}
				}
			}
		}
	}
	
	void OnApplicationQuit ()
	{
		if (PhotonNetwork.networkingPeer != null) {
			PhotonNetwork.networkingPeer.Disconnect ();
			PhotonNetwork.networkingPeer.StopThread ();
		}
		
		PhotonNetwork.InternalCleanPhotonMonoFromSceneIfStuck ();
		PhotonNetwork.Disconnect ();
	}

	void OnApplicationPause (bool pauseStatus)
	{
		if (pauseStatus == true) {
			PhotonNetwork.Disconnect ();
		} 
	}
	
	//--------------------------------------------------------------------------------
	public void OnJoinedLobby ()
	{
		logErrorMessage ("Joined Lobby");

//		ExitGames.Client.Photon.Hashtable customRoomProperties = new ExitGames.Client.Photon.Hashtable ();
//		customRoomProperties.Add ("rank", GameData.getCarRank (GameData.getCarName (ProfileManager.userProfile.SelectedCar)));
//		PhotonNetwork.JoinRandomRoom (customRoomProperties, 0);

		if (KORChat.roomName != string.Empty) {
			if (isJoinInvitedRoom == false) {
				PhotonNetwork.JoinRandomRoom ();
			} else {
				PhotonNetwork.JoinRoom (KORChat.roomName);
			}
		} else {
			isJoinInvitedRoom = false;
			PhotonNetwork.JoinRandomRoom ();
		}
	}
	
	public void OnFailedToConnectToPhoton (DisconnectCause cause)
	{
		logServerMessage (cause);
	}
	
	public void OnConnectionFail (DisconnectCause cause)
	{
		logServerMessage (cause);
	}
	
	public void OnJoinedRoom ()
	{
		logErrorMessage ("Joined Room");
		isJoined = true;	
		
		this.lastWaitTime = Time.timeSinceLevelLoad;
	}
	
	public void OnCreatedRoom ()
	{
		logErrorMessage ("Room Created");
		
		KORMessage message = new KORMessage ();
		message.isInvite = true;
		message.mes = PhotonNetwork.room.name;
		
		KORChat.chatClient.PublishMessage (KORChat.CHANNELS [0], JsonConvert.SerializeObject (message));
	}
	
	public void OnPhotonCreateRoomFailed ()
	{
		logErrorMessage ("Create Room Failed");
	}
	
	public void OnPhotonJoinRoomFailed ()
	{
		logErrorMessage ("Join Room Failed");

		PhotonNetwork.JoinRandomRoom ();
	}
	
	public void OnPhotonRandomJoinFailed ()
	{
		logErrorMessage ("Random Join Room Failed");
		
		RoomOptions roomOptions = new RoomOptions ();
		roomOptions.isOpen = true;
		roomOptions.isVisible = true;
		roomOptions.maxPlayers = 6;

//		roomOptions.customRoomProperties = new ExitGames.Client.Photon.Hashtable ();
//		roomOptions.customRoomProperties.Add ("rank", GameData.getCarRank (GameData.getCarName (ProfileManager.userProfile.SelectedCar)));
//
//		roomOptions.customRoomPropertiesForLobby = new string[1];
//		roomOptions.customRoomPropertiesForLobby [0] = "rank";
		
		TypedLobby typedLobby = new TypedLobby ();
		
		PhotonNetwork.CreateRoom (null, roomOptions, typedLobby);
	}
	
	public void OnPhotonMaxCccuReached ()
	{
		logErrorMessage ("All Server are full");
	}
	
	//--------------------------------------------------------------------------------
	[RPC]
	void photonInitGameData (int selectedMap, int numberRaces, int numberPlayers, int id)
	{
		GameData.selectedMap = (GameData.MAP_NAME)selectedMap;
		GameData.numberRaces = numberRaces;
		GameData.numberPlayers = numberPlayers;
		
		BaseCarManager.mainPlayerID = id;
		BaseCarManager.carID = new int[GameData.numberPlayers];
		BaseCarManager.playerName = new string[GameData.numberPlayers];

		photonView.RPC ("photonInitCarID", PhotonTargets.MasterClient, id, 
		                ProfileManager.userProfile.SelectedCar, ProfileManager.userProfile.PlayerName);
	}
	
	[RPC]
	void photonInitCarID (int id, int carID, string playerName)
	{
		BaseCarManager.carID [id] = carID;
		BaseCarManager.playerName [id] = playerName;
	}
	
	[RPC]
	void photonSyncPlayerData (string data)
	{
		try {
			List<CompactUserData> compactUserDataList = JsonConvert.DeserializeObject<List<CompactUserData>> (data);
			
			for (int i=0; i<BaseCarManager.playerName.Length; i++) {
				BaseCarManager.playerName [i] = compactUserDataList [i].name;
			}
			
			for (int i=0; i<BaseCarManager.carID.Length; i++) {
				BaseCarManager.carID [i] = compactUserDataList [i].carID;
			}
		} catch {
		}
	}
	
	[RPC]
	void photonLoadGame (string scene)
	{
		PhotonNetwork.isMessageQueueRunning = false;

		Application.LoadLevel (scene);
	}
	
	[RPC]
	void syncLevelName (int selectedMap, int remainingTime)
	{
		GameData.selectedMap = (GameData.MAP_NAME)selectedMap;
		this.remainingTime = remainingTime;
		
		for (int i=0; i<mapPreview.Length; i++) {
			mapPreview [i].gameObject.SetActive (false);
		}
		mapPreview [(int)GameData.selectedMap].gameObject.SetActive (true);
	}
	
	//--------------------------------------------------------------------------------
	protected void logServerMessage (DisconnectCause disconnectCause)
	{		
		switch (disconnectCause) {
		case DisconnectCause.ExceptionOnConnect:
			serverConnectionDetails = "No  internet  connection!  Please  try  again  later.";
			break;
			
		case DisconnectCause.SecurityExceptionOnConnect:
			serverConnectionDetails = "This  game  has  been  blocked  by  your  firewall!";
			break;
			
		case DisconnectCause.DisconnectByClientTimeout:
			serverConnectionDetails = "Client  timeout  disconnect!  Please  try  again  later.";
			break;
			
		case DisconnectCause.InternalReceiveException:
			serverConnectionDetails = "Socket  failure!  Please  try  again  later.";
			break;
			
		case DisconnectCause.DisconnectByServerTimeout:
			serverConnectionDetails = "Server  timeout  disconnect!  Please  try  again  later.";
			break;
			
		case DisconnectCause.DisconnectByServerLogic:
			serverConnectionDetails = "Server  has  disconnected  you!";
			break;
			
		case DisconnectCause.DisconnectByServerUserLimit:
			serverConnectionDetails = "Server  is  full!  Please  try  again  later.";
			break;
			
		case DisconnectCause.Exception:
			serverConnectionDetails = "Some  errors  has  occured!  Please  try  again  later.";
			break;
			
		case DisconnectCause.InvalidRegion:
			serverConnectionDetails = "Your  regional  IP  has  been  banned  from  server!";
			break;
			
		case DisconnectCause.MaxCcuReached:
			serverConnectionDetails = "Server  is  full!  Please  try  again  later.";
			break;
			
		case DisconnectCause.InvalidAuthentication:
			serverConnectionDetails = "Invalid  Authentication!  Please  try  again  later.";
			break;
			
		case DisconnectCause.AuthenticationTicketExpired:
			serverConnectionDetails = "Authentication  expired!  Please  try  again  later.";
			break;
			
		default:
			serverConnectionDetails = "Some  errors  has  occured!  Please  try  again  later.";
			break;
		}

		noticeDialog.IsVisible = true;
		messageTextDialog.Text = serverConnectionDetails;
	}

	public void nextMap ()
	{
		click.Play ();

		int selectedMap = (int)GameData.selectedMap;
		
		selectedMap = (selectedMap + 1) % 8;
		GameData.selectedMap = (GameData.MAP_NAME)selectedMap;
		
		for (int i=0; i<mapPreview.Length; i++) {
			mapPreview [i].gameObject.SetActive (false);
		}
		mapPreview [(int)GameData.selectedMap].gameObject.SetActive (true);
	}
	
	public void prevMap ()
	{
		click.Play ();

		int selectedMap = (int)GameData.selectedMap;
		
		selectedMap--;
		if (selectedMap < 0) {
			selectedMap = 7;
		}
		GameData.selectedMap = (GameData.MAP_NAME)selectedMap;
		
		for (int i=0; i<mapPreview.Length; i++) {
			mapPreview [i].gameObject.SetActive (false);
		}
		mapPreview [(int)GameData.selectedMap].gameObject.SetActive (true);
	}
	
	public void quitRoom ()
	{
		click.Play ();

		PhotonNetwork.Disconnect ();
		this.isJoined = false;
		
		AutoFade.LoadLevel ("ChooseOnlineMode");
	}
	
	public static bool isInKingOfDayEvent ()
	{
		DateTime currentTime = MainMenu.currentTime.AddTicks (DateTime.Now.Ticks - MainMenu.currentSystemTime.Ticks);

		if (MainMenu.currentTime.CompareTo (new DateTime (2015, 1, 1)) != 0) {
			if (currentTime.Hour >= 20 && currentTime.Hour < 21) {
				return true;
				
			} else if (currentTime.Hour >= 8 && currentTime.Hour < 9) {
				return true;
				
			} else {
				return false;
			}
		} else {
			return false;
		}
	}

	public static TimeSpan getTimeBeforeKingOfDay ()
	{
		DateTime currentTime = MainMenu.currentTime.AddTicks (DateTime.Now.Ticks - MainMenu.currentSystemTime.Ticks);
		
		DateTime eventTime;

		if (currentTime.Hour < 8) {
			eventTime = new DateTime (currentTime.Year, currentTime.Month, currentTime.Day, 8, 0, 0);
			
		} else if (currentTime.Hour < 20) {
			eventTime = new DateTime (currentTime.Year, currentTime.Month, currentTime.Day, 20, 0, 0);
			
		} else {
			DateTime tempTime = new DateTime (currentTime.Year, currentTime.Month, currentTime.Day, 8, 0, 0);
			tempTime = currentTime.AddDays (1);

			eventTime = new DateTime (tempTime.Year, tempTime.Month, tempTime.Day, 8, 0, 0);
		}

		return new TimeSpan (eventTime.Ticks - currentTime.Ticks);
	}

	public static TimeSpan getKingOfDayDuration ()
	{
		DateTime currentTime = MainMenu.currentTime.AddTicks (DateTime.Now.Ticks - MainMenu.currentSystemTime.Ticks);
		
		DateTime eventTime = new DateTime (currentTime.Year, currentTime.Month, currentTime.Day, 9, 0, 0);
		
		if (currentTime.Hour < 9) {
			eventTime = new DateTime (currentTime.Year, currentTime.Month, currentTime.Day, 9, 0, 0);
			
		} else if (currentTime.Hour < 21) {
			eventTime = new DateTime (currentTime.Year, currentTime.Month, currentTime.Day, 21, 0, 0);
			
		} 
		
		return new TimeSpan (eventTime.Ticks - currentTime.Ticks);
	}
}