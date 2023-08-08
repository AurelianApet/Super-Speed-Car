using UnityEngine;
using System.Collections;
using ExitGames.Client.Photon.Chat;
using Newtonsoft.Json;

public class KORChat : MonoBehaviour,IChatClientListener
{
	public static string[] CHAT_APP_ID = {
		"68928c68-34fc-4cde-90c8-5d3177f56bd8",
		"5fcef014-28b5-4375-8ce3-af0c62436ba2",
		"67f3d829-b089-4ced-824a-12c6ec8847ef",
		"73a9d450-9aab-49ca-ac7a-2d7d0a87f3a3"};
	public static string GAME_VERSION = "1.0";
	public static string[] CHANNELS = {"global"};
	public static bool isCanChat = false;

	//
	public static ChatClient chatClient;
	public static string roomName = string.Empty;
	public static string inviteUser = string.Empty;
	static float lastReceiveRoomName;

	//
	static int currentAppID = 0;
	BaseHeaderMenu baseHeaderMenu;

    private static bool isQuit = false;
	//--------------------------------------------------------------------------------
	public void Start ()
	{
#if UNITY_EDITOR
        PlayerPrefs.DeleteAll();
#endif

        DontDestroyOnLoad (this.gameObject);
	}

	public void init ()
	{		
        //GetComponentsInChildren<ImageButton>().Length
		chatClient = new ChatClient (this);			
		chatClient.ChatRegion = "ASIA";
	}

	public static void connect(){
//		chatClient.Connect (CHAT_APP_ID [currentAppID], GAME_VERSION, ProfileManager.userProfile.PlayerName, null);			
//		isCanChat = false;
	}

	public void OnLevelWasLoaded (int level)
	{
		baseHeaderMenu = GameObject.FindObjectOfType<BaseHeaderMenu> ();
	}

	public void Update ()
	{
		if (chatClient != null) {
			chatClient.Service (); 
		}	
	}

	public void OnApplicationQuit ()
	{
		if (chatClient != null) {
            isQuit = true;
			chatClient.Disconnect ();
		}
	}

	//--------------------------------------------------------------------------------
	//Photon Chat events	
	public void OnConnected ()
	{
//		Debug.Log ("Chat Connected");
		chatClient.Subscribe (CHANNELS);
	}
	
	public void OnDisconnected ()
	{
        //		Debug.Log ("Photon Chat Disconnected");
        if (!isQuit)
        {
            isCanChat = false;

            currentAppID = (currentAppID + 1) % CHAT_APP_ID.Length;
            chatClient.Connect(CHAT_APP_ID[currentAppID], GAME_VERSION, ProfileManager.userProfile.PlayerName, null);
        }
	}
	
	public void OnChatStateChange (ChatState state)
	{
//		Debug.Log ("Photon Chat StateChange: " + state);
	}
	
	public void OnSubscribed (string[] channels, bool[] results)
	{		
//		Debug.Log ("Photon Chat Subscribed");
		isCanChat = true;
//		for (int i=0; i<channels.Length; i++) {
//			Debug.Log (channels [i] + ": " + results [i]);
//		}
	}
	
	public void OnUnsubscribed (string[] channels)
	{
//		Debug.Log ("Photon Chat Unsubscribed");
//		foreach (string channel in channels) {
//			Debug.Log (channel);
//		}
	}
	
	public void OnGetMessages (string channelName, string[] senders, object[] messages)
	{
//		Debug.Log ("Photon Chat GetMessages: channelName= " + channelName);
		//		for (int i=0; i<senders.Length; i++) {
//			Debug.Log (senders [i] + ": " + messages [i]);	
//		}
		
		KORMessage message;
		if (Time.realtimeSinceStartup - lastReceiveRoomName > 5) {
			try {
				int index = Random.Range (0, messages.Length);

				message = JsonConvert.DeserializeObject<KORMessage> (messages [index].ToString ());
				inviteUser = senders [index];
			} catch {
				return;
			}
		} else {
			return;
		}

		if (message.isInvite == true) {
			roomName = message.mes;
			lastReceiveRoomName = Time.realtimeSinceStartup;

			if (baseHeaderMenu != null) {
				baseHeaderMenu.showInvite ();
			}
		}
	}
	
	public void OnPrivateMessage (string sender, object message, string channelName)
	{
//		Debug.Log ("Photon Chat PrivateMessage: sender= " + sender + " ; message= " + message + " ; channelName= " + channelName);
	}
	
	public void OnStatusUpdate (string user, int status, bool gotMessage, object message)
	{
//		Debug.Log ("Status update: user= " + user + " ; status= " + status + " ; gotMessage= " + gotMessage + " ; message= " + message);
	}
}