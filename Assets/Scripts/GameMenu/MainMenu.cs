using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using GoogleMobileAds.Api;
//using ChartboostSDK;
//using UnityEditor;

public class MainMenu : BaseHeaderMenu
{
//	private string videoAd;
	
//	private CBInPlay inPlayAd;
	
//	RewardBasedVideoAd rewardBasedVideo;
	
//	public GameObject videoButton;
	
//	public GameObject message;
	
	#if UNITY_BB10
	[System.Runtime.InteropServices.DllImport("libbps", EntryPoint="virtualkeyboard_change_options")]
	private static extern void virtualkeyboard_change_options(int layout, int enter);
	
	private const int VIRTUALKEYBOARD_LAYOUT_DEFAULT = 0;
	private const int VIRTUALKEYBOARD_ENTER_DEFAULT = 0;
	#endif

	protected static string requestURL = "http://kingofracing.sunkhoai.com/check_time.php";
	public static DateTime currentTime = new DateTime (2015, 1, 1);
	public static DateTime currentSystemTime;
	public static bool isCheckTime = false;

	//
	public enum MENU_ITEM
	{
		SETTINGS,
		CAREER,
		QUICK_RACE,
		ACHIVEMENT,
		MULTIPLAYER,
		SHOP,
		DOWNLOAD
	}

	public dfPanel RegisterModeDialog, ConfirmDialog, SettingDialog;
	public dfTextbox txtName;
	public dfButton btnEnter, btnSetting, btnCarrer, btnQuickRace, btnMultiplayer;

	//
	public dfSprite giftFrame;
	public dfLabel giftNumber;

	//
	public dfSprite questFrame;
	public dfLabel questNumber;

	//
	public dfSprite achivementFrame;
	public dfLabel achivementNumber;

	//--------
	public MainMenuSound sound;
	//------
	public dfPanel careerPanel;
	public static bool isLoadingShop = false;

	//
	public Texture2D[] titleImage;

	//
	public dfSprite[] mapEvent;
	public dfRadialSprite loadingEvent;
	public dfLabel mapLabel;
	public dfLabel eventTime;

	//
	public dfTextureSprite[] offerImage;
	public dfLabel offerTime;
	public dfButton offerPanel;
	DateTime offerEndTime;

	//
	public dfTextureSprite titleIcon;
	public dfSprite titleProgress;
	public dfLabel titleLabel;
	public dfLabel titleScore;

	//
	public dfPanel checkNameDialog;
	public dfTextureSprite kingEventIcon;
	DateTime eventEndTime;

	void OnEnable() {
		// Listen related event
//		Chartboost.didCompleteRewardedVideo += didCompleteRewardedVideo;
//		Chartboost.didCacheRewardedVideo += didCacheRewardedVideo;
	}
	
	void OnDisable() {
		// Remove handler
//		Chartboost.didCompleteRewardedVideo -= didCompleteRewardedVideo;
//		Chartboost.didCacheRewardedVideo -= didCacheRewardedVideo;
	}

	void Start ()
	{
//		RequestRewardBasedVideo ();
//		Chartboost. cacheRewardedVideo (CBLocation.Default);

		GameData.SCALE = new Vector2 (800f / Screen.width, 480f / Screen.height);
		GameData.MATRIX_SCALING = Matrix4x4.TRS (Vector3.zero, Quaternion.identity,
		                                         new Vector3 (Screen.width / 800f, Screen.height / 480f, 1f));

		#if UNITY_BB10
		virtualkeyboard_change_options(VIRTUALKEYBOARD_LAYOUT_DEFAULT, VIRTUALKEYBOARD_ENTER_DEFAULT);
		#endif

		ProfileManager.init ();
		if (sound.mainMusic.isPlaying)
			sound.mainMusic.volume = ProfileManager.setttings.MusicVolume / 100f;


		if (ProfileManager.userProfile.IsHasName == false) {
			this.RegisterModeDialog.IsVisible = true;
			careerPanel.IsVisible = false;
			btnCarrer.IsEnabled = true;
			
		} else {
			this.RegisterModeDialog.IsVisible = false;
			careerPanel.IsVisible = true;
			btnCarrer.IsEnabled = false;
		}
		playerNameLabel.Text = ProfileManager.userProfile.PlayerName.ToUpper ();

		GameData.isSinglePlayer = true;

		int numberAchivement = AchievementMenu.getNumberAchivement ();
		if (numberAchivement > 0) {
			achivementNumber.Text = numberAchivement.ToString ();
		} else {
			achivementFrame.IsVisible = false;
		}

		int numberQuest = ProfileManager.questProfile.getNumberUnfinishedQuest ();
		if (numberQuest > 0) {
			questNumber.Text = numberQuest.ToString ();
		} else {
			questFrame.IsVisible = false;
		}

		int numberGift = GiftMenu.getNumberGift ();
		if (numberGift > 0) {
			giftNumber.Text = numberGift.ToString ();
		} else {
			giftFrame.IsVisible = false;
		}

		this.titleLabel.Text = RewardData.getTitleText (RewardData.getTitleID (ProfileManager.userProfile.Score));
		this.titleProgress.FillAmount = RewardData.getTitleProgress (ProfileManager.userProfile.Score);
		this.titleIcon.Texture = titleImage [RewardData.getTitleID (ProfileManager.userProfile.Score)];
		this.titleScore.Text = ProfileManager.userProfile.Score + "/" + RewardData.getTitleLevel (ProfileManager.userProfile.Score);

		ProfileManager.eventProfile.generateEventData ();
		ProfileManager.offerProfile.generateOfferData ();

		ProfileManager.eventProfile.updateEventProfileData ();
		ProfileManager.offerProfile.updateOfferProfileData ();

		ProfileManager.userProfile.checkVIP ();		

		if (isCheckTime == false) {
			StartCoroutine (checkTimeOnline ());
		}
		StartCoroutine (finishLoadingEvent ());

		if (ProfileManager.offerProfile.offerProfileList.Count == 0) {
			offerPanel.IsVisible = false;
		} else {
			int carID = UnityEngine.Random.Range (0, ProfileManager.offerProfile.offerProfileList.Count);

			offerImage [ProfileManager.offerProfile.convertCarIDtoInt (ProfileManager.offerProfile.offerProfileList [carID].id)].IsVisible = true;
			try {
				offerEndTime = DateTime.Parse (ProfileManager.offerProfile.offerProfileList [carID].end);
			} catch {
				offerEndTime = DateTime.Now;
				offerTime.IsVisible = false;
			}
		}

		//if (FB.IsInitialized == false) {
		//	FB.Init (OnInitComplete, OnHideUnity);
			
		//} else {
		//	this.OnInitComplete ();
		//}

		LevelLoader.isLoading = true;

//		confrimVideoAd ();
	}
	
	IEnumerator finishLoadingEvent ()
	{
		yield return new WaitForSeconds (3f);
		loadingEvent.IsVisible = false;

		int eventID = ProfileManager.eventProfile.eventProfileList [0].id;

		GameData.MAP_NAME mapName = EventDescription.getEventMap (eventID);
		mapLabel.Text = EventDescription.getEventName (eventID);
		mapEvent [(int)mapName].IsVisible = true;
		eventTime.IsVisible = true;

		try {
			eventEndTime = DateTime.Parse (ProfileManager.eventProfile.eventProfileList [0].end);
		} catch {
			eventEndTime = DateTime.Now;
			eventTime.IsVisible = false;
		}
	}
	
	void Update ()
	{
		if (Input.GetKeyUp (KeyCode.Escape)) {
			if (RegisterModeDialog.IsVisible == false) {
				if (SettingDialog.IsVisible == false) {
					ConfirmDialog.IsVisible = !ConfirmDialog.IsVisible;
				} else {
					SettingDialog.IsVisible = false;
					careerPanel.IsVisible = true;
					btnCarrer.IsEnabled = false;
				}
			}
		} else {
			this.updateInfo ();
			
			if (InternetGameMenu.isInKingOfDayEvent () == true) {
				kingEventIcon.IsVisible = true;
			} else {
				kingEventIcon.IsVisible = false;
			}
		}

		if (SettingDialog.IsVisible == true)
			btnSetting.IsEnabled = false;
		else 
			btnSetting.IsEnabled = true;
	
		if (sound.mainMusic.isPlaying)
			sound.mainMusic.volume = ProfileManager.setttings.MusicVolume / 100f;

		try {
			TimeSpan timeSpan = new TimeSpan (eventEndTime.Ticks - DateTime.Now.Ticks);

			if (DateTime.Compare (eventEndTime, DateTime.Now) > 0) {
				eventTime.Text = timeSpan.Days + "d " + timeSpan.Hours + "h " + timeSpan.Minutes + "m";
			} else {
				eventTime.Text = string.Empty;
			}
		} catch {
		}

		try {
			TimeSpan timeSpan = new TimeSpan (offerEndTime.Ticks - DateTime.Now.Ticks);
			
			if (DateTime.Compare (offerEndTime, DateTime.Now) > 0) {
				offerTime.Text = timeSpan.Days + "d " + timeSpan.Hours + "h " + timeSpan.Minutes + "m";
			} else {
				offerTime.Text = string.Empty;
			}
		} catch {
		}
	}

	public void singleplayerOnClick ()
	{
		sound.ButtonClick ();
		this.closeAll ();		
		careerPanel.IsVisible = true;		
		btnCarrer.IsEnabled = false;
	}

	public void quickRaceOnClick ()
	{
		sound.ButtonClick ();
		AutoFade.LoadLevel ("QuickRace");
	}

	public void multiplayerOnClick ()
	{
		sound.ButtonClick ();
		AutoFade.LoadLevel ("ChooseOnlineMode");
	}

	public void optionOnClick ()
	{
		this.closeAll ();
		sound.ButtonClick ();
		SettingDialog.IsVisible = true;
		btnSetting.IsEnabled = false;		
		btnCarrer.IsEnabled = true;
	}

	public void videoOnClick ()
	{
		sound.ButtonClick ();
//		watchAd ();
	}
	
	public void moreGamesOnClick ()
	{
		sound.ButtonClick ();
		#if UNITY_ANDROID
		Application.OpenURL ("http://play.google.com/store/apps/details?id=" + "bestracinggame.superspeedycarrace");
		#elif UNITY_IOS
		Application.OpenURL ("");
		#endif
	}

	public void ShopOnClick ()
	{
		sound.ButtonClick ();
		this.closeAll ();
		sound.ButtonClick ();
		AutoFade.LoadLevel ("Load");
		isLoadingShop = true;
	}

	public void achievementOnClick ()
	{
		sound.ButtonClick ();

		UserInfoScripts.isLoadingTitle = false;
		AutoFade.LoadLevel ("Achievement");
	}

	public void titleOnClick ()
	{
		sound.ButtonClick ();
		
		UserInfoScripts.isLoadingTitle = true;
		AutoFade.LoadLevel ("Achievement");
	}

	public void rankingOnClick ()
	{
		sound.ButtonClick ();
		AutoFade.LoadLevel ("RankingMenu");
	}

	public void questOnClick ()
	{
		sound.ButtonClick ();
		AutoFade.LoadLevel ("QuestMenu");
	}

	public void giftOnClick ()
	{
		sound.ButtonClick ();
		AutoFade.LoadLevel ("DailyLogin");
	}

	public void eventOnClick ()
	{
		sound.ButtonClick ();
		AutoFade.LoadLevel ("EventMenu");
	}

	public void offerOnClick ()
	{
		sound.ButtonClick ();
		OfferMenu.previousLevel = Application.loadedLevelName;

		AutoFade.LoadLevel ("OfferMenu");
	}

	public void RegisterOnClick ()
	{
		sound.ButtonClick ();
		if (txtName.Text.Trim () == string.Empty || txtName.Text.ToLower ().Trim () == "player name") {
			checkNameDialog.IsVisible = true;

		} else {
			this.RegisterModeDialog.IsVisible = false;
			ProfileManager.userProfile.PlayerName = txtName.Text;
			ProfileManager.userProfile.IsHasName = true;
			PlayerPrefs.Save ();			
			playerNameLabel.Text = ProfileManager.userProfile.PlayerName;	
			careerPanel.IsVisible = true;				
			btnCarrer.IsEnabled = false;	

//			KORChat.connect ();
		}
	}

	public void closeAll ()
	{
		careerPanel.IsVisible = false;
		if (SettingDialog.IsVisible == false) {
		} else {
			SettingDialog.IsVisible = false;
		}
	}

	public void confirmQuit ()
	{
		Application.Quit ();
	}

	public void cancelQuit ()
	{
		ConfirmDialog.IsVisible = false;
	}

	public void closeCheckNameDialog ()
	{
		checkNameDialog.IsVisible = false;
	}

	public void moreGames_1 ()
	{
		Application.OpenURL ("market://details?id=com.dev.superskycat");
	}

	public void moreGames_2 ()
	{
		Application.OpenURL ("market://details?id=com.splaygame.happyfarm");
	}

	//void OnInitComplete ()
	//{
	//	if (FB.IsLoggedIn == false) {
	//	} else {
	//	}	
	//}

	//void OnHideUnity (bool isGameShown)
	//{
	//}
	

	IEnumerator checkTimeOnline ()
	{
		WWW webRequest = new WWW (requestURL);
		
		yield return webRequest;

		if (webRequest.error == null || webRequest.error == string.Empty) {
			if (webRequest.text != null && webRequest.text != string.Empty) {
				try {
					currentTime = DateTime.Parse (webRequest.text);
		
					currentSystemTime = DateTime.Now;		
					isCheckTime = true;
				} catch {
					kingEventIcon.IsVisible = false;
				}
			} else {
				kingEventIcon.IsVisible = false;
			}
		} else {
			kingEventIcon.IsVisible = false;
		}
	}

/*	private void RequestRewardBasedVideo()
	{
		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-6826607111982104/8581359279";
		#elif UNITY_IPHONE
		string adUnitId = "";
		#else
		string adUnitId = "unexpected_platform";
		#endif
		
		rewardBasedVideo = RewardBasedVideoAd.Instance;
		
		AdRequest request = new AdRequest.Builder().Build();
		rewardBasedVideo.LoadAd(request, adUnitId);
		
		//Show Ad
		//		showAdd(rewardBasedVideo);
	}
	
	private void showAdd(RewardBasedVideoAd rewardBasedVideo)
	{
		if (rewardBasedVideo.IsLoaded())
		{
			//Subscribe to Ad event
			rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
			rewardBasedVideo.Show();
		}
	}
	
	public void HandleRewardBasedVideoRewarded(object sender, Reward args)
	{
        ProfileManager.userProfile.Money += 200;
		ProfileManager.userProfile.Diamond += 2;
		PlayerPrefs.Save();
		videoButton.SetActive (false);
		
//		messageShow ();
//		Invoke ("messageHide", 3f);
	}
	
	//Used to confirm gameover or resume by video(if available)
	public void confrimVideoAd(){
		
		inPlayAd = Chartboost.getInPlay(CBLocation.Default);
		
		if (rewardBasedVideo.IsLoaded ()) {
			videoAd = "admob";
			videoButton.SetActive (true);
		}else if (inPlayAd != null) {
			videoAd = "CB";
			videoButton.SetActive (true);
		}
		else {
			cancel();
		}
//		Debug.Log (videoAd);
	}

	public void watchAd(){
		if (videoAd == "admob") {
			showAdd (rewardBasedVideo);
		} else if (videoAd == "CB") {
			Chartboost.showRewardedVideo (CBLocation.Default);
		}
	}

	public void cancel(){
		videoButton.SetActive (false);
	}
	
	void didCompleteRewardedVideo(CBLocation location, int reward){
        ProfileManager.userProfile.Money += 200;
		ProfileManager.userProfile.Diamond += 2;
		PlayerPrefs.Save();
		videoButton.SetActive (false);
//		Debug.Log("Completed video with reward: "+reward);

		messageShow ();
		Invoke ("messageHide", 3f);
	}
	
	void didCacheRewardedVideo(CBLocation location) {
		Debug.Log("didCacheRewardedVideo: " + location);
	}

	void messageShow(){
		message.SetActive (true);
	}

	void messageHide(){
		message.SetActive (false);
	}
	*/
}