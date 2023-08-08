using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;

[RequireComponent (typeof(NetworkView))]
public class WifiGameMenu : BaseMultiplayerGameMenu
{
		public static string HOST = "127.0.0.1";
		public static int PORT = 23456;

		//
		public AudioSource audioSource;
		public AudioSource click;

		//
		public dfPanel chooseActionPanel;
		public dfPanel createRoomPanel;
		public dfPanel joinRoomPanel;
		public dfButton ipHistoryPanel;

		//
		public ChangeAvatar changeAvatar;

		//
		public dfLabel playerName;
		public dfLabel playerLevel;
		public dfLabel playerIP;
		public dfSprite[] mapPreview;
		public NetworkPlayerRow[] createPlayerRowList;
	
		//
		public dfTextbox hostInputField;
		public dfButton joinRoomButton;
		public dfButton quitRoomButton;
		public dfButton[] ipHistoryList;
		public NetworkPlayerRow[] joinPlayerRowList;
	
		//
		int i;
		List<CompactWifiUserData> wifiUserDataList;
		float lastUpdate;
	
		//--------------------------------------------------------------------------------
		void Start ()
		{
				this.maxConnections = 5;
		
				GameData.isSinglePlayer = false;
				GameData.isWifiMode = true;	
		
				this.serverState = SERVER_STATE.NOT_START;
		
				GameData.selectedMap = (GameData.MAP_NAME)UnityEngine.Random.Range (0, 8);
				for (int i=0; i<mapPreview.Length; i++) {
						mapPreview [i].gameObject.SetActive (false);
				}
				mapPreview [(int)GameData.selectedMap].gameObject.SetActive (true);
		
				this.wifiUserDataList = new List<CompactWifiUserData> ();

				ProfileManager.init ();
		
				audioSource.volume = ProfileManager.setttings.MusicVolume / 100f;
				audioSource.Play ();

				click.volume = ProfileManager.setttings.SoundVolume / 100f;
		}
	
		void Update ()
		{
				if (Input.GetKeyUp (KeyCode.Escape)) {
						AutoFade.LoadLevel ("ChooseOnlineMode");
						Network.Disconnect ();
				} else {
						this.updateInfo ();
				}
		
				if (createRoomPanel.gameObject.activeSelf == true) {
						this.updateCreateRoomPanel ();
			
				} else if (joinRoomPanel.gameObject.activeSelf == true) {
						this.updateJoinRoomPanel ();
				}
		}
	
		void OnConnectedToServer ()
		{
				networkView.RPC ("addPlayer", RPCMode.Server, ProfileManager.userProfile.SelectedCar, ProfileManager.userProfile.PlayerName,
		                 ProfileManager.userProfile.FacebookID, Network.player.ipAddress.ToString (), ProfileManager.userProfile.AvatarID);
		}
	
		void OnDisconnectedFromServer (NetworkDisconnection info)
		{
				this.wifiUserDataList.Clear ();
		}
	
		void OnPlayerDisconnected (NetworkPlayer player)
		{
				Network.RemoveRPCs (player);
				Network.DestroyPlayerObjects (player);

				networkView.RPC ("removePlayer", RPCMode.All, player.ipAddress);
		}
	
		void OnServerInitialized ()
		{
				this.addCompactUserData (ProfileManager.userProfile.SelectedCar, ProfileManager.userProfile.PlayerName, 
		                         ProfileManager.userProfile.FacebookID, Network.player.ipAddress.ToString (), ProfileManager.userProfile.AvatarID);
		}

		void OnApplicationPause (bool pauseStatus)
		{
				if (pauseStatus == true) {
						Network.Disconnect ();
				} 
		}
	
		//--------------------------------------------------------------------------------
		public void openCreateRoomPanel ()
		{
				click.Play ();
				chooseActionPanel.gameObject.SetActive (false);
				createRoomPanel.gameObject.SetActive (true);
		
				NetworkConnectionError error = Network.InitializeServer (maxConnections, PORT, false);
				logErrorMessage (error.ToString ());
				playerIP.Text = string.Empty;
		}
	
		public void openJoinRoomPanel ()
		{
				click.Play ();
				chooseActionPanel.gameObject.SetActive (false);
				joinRoomPanel.gameObject.SetActive (true);
		
				hostInputField.Text = ProfileManager.userProfile.ipHistoryList [0];
		}
	
		public void back ()
		{
				click.Play ();
				AutoFade.LoadLevel ("ChooseOnlineMode");
				Network.Disconnect ();
		}
	
		//--------------------------------------------------------------------------------
		public void updateCreateRoomPanel ()
		{
				playerName.Text = ProfileManager.userProfile.PlayerName;
				playerLevel.Text = ProfileManager.userProfile.getNumberStar ().ToString ();
		
				if (Network.peerType == NetworkPeerType.Disconnected) {
						playerIP.Text = string.Empty;
			
				} else if (Network.peerType == NetworkPeerType.Connecting) {
						playerIP.Text = string.Empty;
			
				} else {
						if (playerIP.Text == string.Empty) {
								playerIP.Text = Network.player.ipAddress.ToString ();
						}
			
						if (Network.peerType == NetworkPeerType.Server) {
								switch (this.serverState) {
								case SERVER_STATE.NOT_START:
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

												networkView.RPC ("syncPlayerData", RPCMode.Others, JsonConvert.SerializeObject (compactUserDataList));
																		
												stateTime = Time.timeSinceLevelLoad;
												this.serverState = SERVER_STATE.READY;
										}
										break;
					
								case SERVER_STATE.READY:	
										networkView.RPC ("loadGame", RPCMode.All, GameData.getMapPath (GameData.selectedMap), 1);
										break;
					
								default:
										break;
								}
						}
			
						for (i=0; i<wifiUserDataList.Count; i++) {
								if (i < createPlayerRowList.Length) {
										createPlayerRowList [i].playerName.Text = wifiUserDataList [i].name;
										createPlayerRowList [i].playerCar.Text = GameData.getCarName (wifiUserDataList [i].carID).ToString ().Replace ('_', ' ');
					
										FacebookAvatar avatar = getAvatar (wifiUserDataList [i].facebookID);
					
										if (avatar.isError == false) {
												if (avatar.isAvatarLoaded == true) {
														createPlayerRowList [i].playerAvatar.Texture = avatar.avatar;
														createPlayerRowList [i].playerLoading.IsVisible = false;
												} else {
														createPlayerRowList [i].playerAvatar.Texture = null;
														createPlayerRowList [i].playerLoading.IsVisible = true;
												}
										} else {
												if (createPlayerRowList [i].playerAvatar.Texture == null) {
														createPlayerRowList [i].playerLoading.IsVisible = false;
														createPlayerRowList [i].playerAvatar.Texture = changeAvatar.icon [wifiUserDataList [i].defaultAvatar];
												}
										}
								}
						}
			
						for (i=wifiUserDataList.Count; i<createPlayerRowList.Length; i++) {
								createPlayerRowList [i].playerName.Text = string.Empty;
								createPlayerRowList [i].playerCar.Text = string.Empty;
								createPlayerRowList [i].playerAvatar.Texture = null;
								createPlayerRowList [i].playerLoading.IsVisible = false;
						}
			
						if (Network.peerType == NetworkPeerType.Server) {
								if (Time.timeSinceLevelLoad - lastUpdate > 1) {
										lastUpdate = Time.timeSinceLevelLoad;
										foreach (CompactWifiUserData userData in wifiUserDataList) {
												networkView.RPC ("addPlayer", RPCMode.Others, userData.carID, userData.name, userData.facebookID, userData.ip, userData.defaultAvatar);
										}
								}
						}
				}
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
				chooseActionPanel.gameObject.SetActive (true);
				createRoomPanel.gameObject.SetActive (false);
				joinRoomPanel.gameObject.SetActive (false);
		
				Network.Disconnect ();
		
				this.wifiUserDataList.Clear ();
				facebookAvatarList.Clear ();
		}
	
		public void raceNow ()
		{
				click.Play ();
				if (this.serverState == SERVER_STATE.NOT_START) {
						if (Network.connections.Length > 0) {				
								this.serverState = SERVER_STATE.STARTING;

								if (Network.connections.Length + 1 > Map.NUMBER_SPAWN_POINTS) {
										GameData.numberPlayers = Map.NUMBER_SPAWN_POINTS;
								} else {
										GameData.numberPlayers = Network.connections.Length + 1;
								}

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
			
								int j = 1;
								foreach (NetworkPlayer client in Network.connections) {
										if (j <= GameData.numberPlayers - 1) {
												networkView.RPC ("initGameData", client, (int)GameData.selectedMap,
					                 getNumberRaces (), GameData.numberPlayers, j);
												j++;
										}
								}
			
								stateTime = Time.timeSinceLevelLoad;
						}
				}
		}
	
		//--------------------------------------------------------------------------------
		public void updateJoinRoomPanel ()
		{
				if (Network.peerType == NetworkPeerType.Disconnected) {
						joinRoomButton.gameObject.SetActive (true);	
						quitRoomButton.gameObject.SetActive (false);
				} else {
						joinRoomButton.gameObject.SetActive (false);	
						quitRoomButton.gameObject.SetActive (true);
				}
		
				for (i=0; i<wifiUserDataList.Count; i++) {
						if (i < joinPlayerRowList.Length) {
								joinPlayerRowList [i].playerName.Text = wifiUserDataList [i].name;
								joinPlayerRowList [i].playerCar.Text = GameData.getCarName (wifiUserDataList [i].carID).ToString ().Replace ('_', ' ');
				
								FacebookAvatar avatar = getAvatar (wifiUserDataList [i].facebookID);
				
								if (avatar.isError == false) {
										if (avatar.isAvatarLoaded == true) {
												joinPlayerRowList [i].playerAvatar.Texture = avatar.avatar;
												joinPlayerRowList [i].playerLoading.IsVisible = false;
										} else {
												joinPlayerRowList [i].playerAvatar.Texture = null;
												joinPlayerRowList [i].playerLoading.IsVisible = true;
										}
								} else {
										if (joinPlayerRowList [i].playerAvatar.Texture == null) {
												joinPlayerRowList [i].playerLoading.IsVisible = false;
												joinPlayerRowList [i].playerAvatar.Texture = changeAvatar.icon [wifiUserDataList [i].defaultAvatar];
										}
								}
						}
				}
		
				for (i=wifiUserDataList.Count; i<joinPlayerRowList.Length; i++) {
						joinPlayerRowList [i].playerName.Text = string.Empty;
						joinPlayerRowList [i].playerCar.Text = string.Empty;
						joinPlayerRowList [i].playerAvatar.Texture = null;
						joinPlayerRowList [i].playerLoading.IsVisible = false;
				}
		}
	
		public void joinRoom ()
		{
				click.Play ();
				if (Network.peerType == NetworkPeerType.Disconnected) {
						HOST = hostInputField.Text;
			
						NetworkConnectionError error = Network.Connect (HOST, PORT);
						logErrorMessage (error.ToString ());
			
						if (error == NetworkConnectionError.NoError) {
								ProfileManager.userProfile.insertIP (HOST);
						}
				}
		}
	
		public void openIPHistory ()
		{
				click.Play ();
				ipHistoryPanel.gameObject.SetActive (true);
		
				for (int i=0; i<ipHistoryList.Length; i++) {
						ipHistoryList [i].Text = ProfileManager.userProfile.ipHistoryList [i];
				}
		}
	
		public void closeIPHistory ()
		{
				click.Play ();
				ipHistoryPanel.gameObject.SetActive (false);
		}
	
		public void restoreIPHistory_1 ()
		{
				click.Play ();

				hostInputField.Text = ProfileManager.userProfile.ipHistoryList [0];
				ipHistoryPanel.gameObject.SetActive (false);
		}
	
		public void restoreIPHistory_2 ()
		{
				click.Play ();

				hostInputField.Text = ProfileManager.userProfile.ipHistoryList [1];
				ipHistoryPanel.gameObject.SetActive (false);
		}
	
		public void restoreIPHistory_3 ()
		{
				click.Play ();

				hostInputField.Text = ProfileManager.userProfile.ipHistoryList [2];
				ipHistoryPanel.gameObject.SetActive (false);
		}
	
		public void restoreIPHistory_4 ()
		{
				click.Play ();

				hostInputField.Text = ProfileManager.userProfile.ipHistoryList [3];
				ipHistoryPanel.gameObject.SetActive (false);
		}
	
		//--------------------------------------------------------------------------------
		[RPC]
		void initGameData (int selectedMap, int numberRaces, int numberPlayers, int id)
		{
				GameData.selectedMap = (GameData.MAP_NAME)selectedMap;
				GameData.numberRaces = numberRaces;
				GameData.numberPlayers = numberPlayers;
		
				BaseCarManager.mainPlayerID = id;
				BaseCarManager.carID = new int[GameData.numberPlayers];
				BaseCarManager.playerName = new string[GameData.numberPlayers];

				networkView.RPC ("initCarID", RPCMode.Server, id, ProfileManager.userProfile.SelectedCar, ProfileManager.userProfile.PlayerName);
		}
	
		[RPC]
		void initCarID (int id, int carID, string playerName)
		{
				BaseCarManager.carID [id] = carID;
				BaseCarManager.playerName [id] = playerName;
		}
	
		[RPC]
		void syncPlayerData (string data)
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
		void loadGame (string scene, int prefix)
		{
				SceneLoader.scene = scene;
				SceneLoader.prefix = prefix;
				SceneLoader.isLoadMultiplayerScene = true;
		
				Application.LoadLevel ("Loading");
		}
	
		//--------------------------------------------------------------------------------	
		[RPC]
		void addPlayer (int carID, string name, string facebookID, string ip, int defaultAvatar)
		{
				this.addCompactUserData (carID, name, facebookID, ip, defaultAvatar);
		}
	
		[RPC]
		void removePlayer (string ip)
		{
				int removeIndex = -1;
				for (int i=0; i<wifiUserDataList.Count; i++) {
						if (wifiUserDataList [i].ip == ip) {
								removeIndex = i;
								break;
						}
				}
		
				this.wifiUserDataList.RemoveAt (removeIndex);
		}
	
		void addCompactUserData (int carID, string playerName, string facebookID, string ip, int defaultAvatar)
		{
				foreach (CompactWifiUserData userData in wifiUserDataList) {
						if (userData.ip == ip) {
								userData.carID = carID;
								userData.name = playerName;
								userData.facebookID = facebookID;
								userData.ip = ip;
								userData.defaultAvatar = defaultAvatar;
				
								return;
						}
				}
		
				CompactWifiUserData compactWifiUserData = new CompactWifiUserData ();
		
				compactWifiUserData.carID = carID;
				compactWifiUserData.name = playerName;
				compactWifiUserData.facebookID = facebookID;
				compactWifiUserData.ip = ip;
				compactWifiUserData.defaultAvatar = defaultAvatar;
		
				this.wifiUserDataList.Add (compactWifiUserData);
		}
}