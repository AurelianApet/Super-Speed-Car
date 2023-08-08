using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserInfoScripts : BaseHeaderMenu
{
	public dfLabel[] LabelStart;
	public dfLabel LabelMoney, LabelCarsOwned, LabelTitle, LabelTitle1, LabelVip, LabelDiamond, titleScore;
	public Texture2D[] titleImage;
	public dfTextureSprite title, title1, avatarIcon, avatarIcon1;
	public dfButton btnNumberAchievement, VIP, useFacebookAvatar;
	public dfPanel VIPINFO, Notice, EditName;
	public dfTweenVector3 VIPTween;
	public dfProgressBar titleValue;
	public CarAchivement carAchievement;
	public ChallengeAchivement challengeAchievement;
	public SkillAchivement skillAchievement;
	public StarAchivement starAchievement;
	public dfSprite[] NameOfCar;
	public static bool isLoadingTitle = false;
	public MainMenuSound sound;
	public dfTextbox changename;
	public dfLabel facebookText;
	public dfLabel noticeMessage;
	public dfButton useFacebookAvatarCheckBox;

	//
	public ServerHighscore serverHighScore;
	public ChangeAvatar changeAvatar;

	//
	//public FacebookUserInfoHandler facebookUserInfoHandler;

	void Start ()
	{
		ProfileManager.init ();

		if (sound.mainMusic.isPlaying)
			sound.mainMusic.volume = ProfileManager.setttings.MusicVolume / 100f;
		sound.mainMusic.Play ();

		LabelMoney.Text = string.Format ("{0:n00}", ProfileManager.userProfile.Money);
		LabelDiamond.Text = string.Format ("{0:n00}", ProfileManager.userProfile.Diamond);

		LabelCarsOwned.Text = ProfileManager.userProfile.getNumberCar () + "/15";
		LabelTitle.Text = RewardData.getTitleText (RewardData.getTitleID (ProfileManager.userProfile.Score));
		LabelTitle1.Text = RewardData.getTitleText (RewardData.getTitleID (ProfileManager.userProfile.Score));
		this.titleScore.Text = ProfileManager.userProfile.Score + "/" + RewardData.getTitleLevel (ProfileManager.userProfile.Score);
		title.Texture = titleImage [RewardData.getTitleID (ProfileManager.userProfile.Score)];
		title1.Texture = titleImage [RewardData.getTitleID (ProfileManager.userProfile.Score)];
		if (AchievementMenu.getNumberAchivement () > 0) {
			btnNumberAchievement.Text = AchievementMenu.getNumberAchivement ().ToString ();
			btnNumberAchievement.IsVisible = true;
		} else {
			btnNumberAchievement.IsVisible = false;
		}
		LabelStart [0].Text = string.Format ("{0:n00}", ProfileManager.achievementProfile.MaxSpeedReach * 3.6f) + " Km/h";
		LabelStart [1].Text = string.Format ("{0:n00}", ProfileManager.achievementProfile.DriftDuration) + " Sec";
		LabelStart [2].Text = string.Format ("{0:n00}", ProfileManager.achievementProfile.FlyDuration) + " Sec";
		LabelStart [3].Text = string.Format ("{0:n00}", ProfileManager.achievementProfile.NitroUsingDuration);
		LabelStart [4].Text = string.Format ("{0:n00}", ProfileManager.achievementProfile.CoinEarn);
		LabelStart [5].Text = string.Format ("{0:n00}", ProfileManager.achievementProfile.NumberDestroyedObstacles);
		LabelStart [6].Text = string.Format ("{0:n00}", ProfileManager.achievementProfile.MultiplayerWin);
		LabelStart [7].Text = string.Format ("{0:n00}", ProfileManager.achievementProfile.MultiplayerLose);
		LabelStart [8].Text = string.Format ("{0:n00}", ProfileManager.userProfile.getNumberStarsBySeason (0));
		LabelStart [9].Text = string.Format ("{0:n00}", ProfileManager.userProfile.getNumberStarsBySeason (1));
		LabelStart [10].Text = string.Format ("{0:n00}", ProfileManager.userProfile.getNumberStarsBySeason (2));
		LabelStart [11].Text = string.Format ("{0:n00}", ProfileManager.userProfile.getNumberStarsBySeason (3));
		LabelStart [12].Text = string.Format ("{0:n00}", ProfileManager.userProfile.getNumberStarsBySeason (4));
		LabelStart [13].Text = string.Format ("{0:n00}", ProfileManager.userProfile.getNumberStarsBySeason (5));
		LabelStart [14].Text = string.Format ("{0:n00}", ProfileManager.userProfile.getNumberStarsBySeason (6));
		LabelStart [15].Text = string.Format ("{0:n00}", ProfileManager.userProfile.getNumberStarsBySeason (7));
		LabelStart [16].Text = string.Format ("{0:n00}", ProfileManager.userProfile.Score);

		for (int i=0; i<NameOfCar.Length; i++) {
			if (i == toShopCarID (ProfileManager.userProfile.SelectedCar))
				NameOfCar [i].IsVisible = true;
			else
				NameOfCar [i].IsVisible = false;
		}

		titleValue.Value = RewardData.getTitleProgress (ProfileManager.userProfile.Score);

		if (ProfileManager.userProfile.VipLevel == 0) {
			LabelVip.Text = "";
			VIP.IsVisible = false;
			avatarIcon.IsEnabled = false;
			avatarIcon1.IsEnabled = false;
						
		} else if (ProfileManager.userProfile.VipLevel == 1) {
			LabelVip.Text = "VIP 1";
			VIP.IsVisible = true;
			avatarIcon.IsEnabled = true;
			avatarIcon1.IsEnabled = true;

		} else if (ProfileManager.userProfile.VipLevel == 2) {
			LabelVip.Text = "VIP 2";
			VIP.IsVisible = true;
			avatarIcon.IsEnabled = true;
			avatarIcon1.IsEnabled = true;

		} else if (ProfileManager.userProfile.VipLevel == 3) {
			LabelVip.Text = "VIP 3";
			VIP.IsVisible = true;
			changename.IsVisible = true;
			avatarIcon.IsEnabled = true;
			avatarIcon1.IsEnabled = true;
		}

		//if (FB.IsInitialized == false) {
		//	FB.Init (OnInitComplete, OnHideUnity);
			
		//} else {
		//	this.OnInitComplete ();
		//}
	}

	void Update ()
	{
		if (Input.GetKeyUp (KeyCode.Escape)) {
			AutoFade.LoadLevel ("MainMenu");
		} else {
			this.updateInfo ();		
		
			//if (FB.IsLoggedIn == true) {
			//	facebookText.Text = "LIKE";

			//	if (ProfileManager.userProfile.UseFacebookAvatar == false) {
			//		avatarIcon.Texture = changeAvatar.icon [ProfileManager.userProfile.AvatarID];
					
			//	} else {
			//		if (avatar == null) {
			//			avatar = getAvatar (FB.UserId.ToString ());
			//		}
					
			//		if (avatar.isError == false) {
			//			if (avatar.isAvatarLoaded == true) {
			//				avatarIcon.Texture = avatar.avatar;
			//			} 
			//		}
			//	}
			//} else {
			//	facebookText.Text = "LOGIN";
			//	avatarIcon.Texture = changeAvatar.icon [ProfileManager.userProfile.AvatarID];
			//}

			if (ProfileManager.userProfile.UseFacebookAvatar == true) {
				useFacebookAvatarCheckBox.IsEnabled = false;
			} else {
				useFacebookAvatarCheckBox.IsEnabled = true;
			}

			if (sound.mainMusic.isPlaying)
				sound.mainMusic.volume = ProfileManager.setttings.MusicVolume / 100f;
		}
	}

	int toShopCarID (int PlayerID)
	{
		switch (PlayerID) {
		case 0:
			return 0;
		case 1:
			return 2;
		case 2:
			return 1;
		case 3:
			return 14;
		case 4:
			return 5;
		case 5:
			return 11;
		case 6:
			return 9;
		case 7:
			return 8;
		case 8:
			return 12;
		case 9:
			return 4;
		case 10:
			return 3;
		case 11:
			return 7;
		case 12:
			return 13;
		case 13:
			return 10;
		case 14:
			return 3;
		default:
			return 0;
		}
	}

	public void BackOnClick ()
	{
		sound.BackSound ();
		AutoFade.LoadLevel ("MainMenu");
	}

	public void AchievementOnClick ()
	{
		sound.ButtonClick ();
		AutoFade.LoadLevel ("Achievement");

	}

	public void RankingOnClick ()
	{
		sound.ButtonClick ();
		AutoFade.LoadLevel ("RankingMenu");
	}

	public void TitleOnClick ()
	{
		sound.ButtonClick ();
		AutoFade.LoadLevel ("Achievement");
		isLoadingTitle = true;
	}

	public void ChangeAvatarOnClick ()
	{
		sound.ButtonClick ();
		if (ProfileManager.userProfile.VipLevel != 0) {
			AutoFade.LoadLevel ("Avatar");
		} else {
			Notice.IsVisible = true;
			noticeMessage.Text = "Buy VIP to change avatar";
		}
	}

	public void ShowVipInfo ()
	{
		sound.ButtonClick ();
		VIPINFO.IsVisible = true;
		VIPTween.Play ();
	}

	public void CloseVipInfo ()
	{
		sound.ButtonClick ();
		VIPINFO.IsVisible = false;
	}

	public void ChangeNational ()
	{
		sound.ButtonClick ();
		if (ProfileManager.userProfile.VipLevel == 2 || ProfileManager.userProfile.VipLevel == 3) {
			AutoFade.LoadLevel ("National");
		} else {
			Notice.IsVisible = true;
			noticeMessage.Text = "Buy VIP to change country";
		}
	}
	
	public void CloseNotice ()
	{
		Notice.IsVisible = false;
	}

	//public void useFacebookAvatarOnClick ()
	//{
	//	ProfileManager.userProfile.UseFacebookAvatar = !ProfileManager.userProfile.UseFacebookAvatar;
	//}

	//public void FacebookOnClick ()
	//{
	//	if (FB.IsLoggedIn == false) {			
	//		FB.Login ("publish_actions", LoginCallback);

	//	} else {	
	//		CallFBFeed ();
	//	}	
	//}

	//void LoginCallback (FBResult result)
	//{
	//	if (result.Error != null) {
			
	//	} else if (!FB.IsLoggedIn) {
			
	//	} else {						
	//		facebookUserInfoHandler.feedCallback ();

	//		ProfileManager.userProfile.FacebookID = FB.UserId;
	//		PlayerPrefs.Save ();
	//	}
	//}

	//string FeedToId = "";
	//string FeedLink = "https://play.google.com/store/apps/developer?id=SPLAY%20GAME";
	//string FeedLinkName = "King Of Racing 2: reborn";
	//string FeedLinkCaption = "";
	//string FeedLinkDescription = "đang có tại https://play.google.com/store/apps/developer?id=SPLAY%20GAME, nhanh tay tải và nhận nhiều phần thưởng hấp dẫn.";
	//string FeedPicture = "http://i.imgur.com/NLCasfr.png";
	//string FeedMediaSource = "";
	//string FeedActionName = "";
	//string FeedActionLink = "";
	//string FeedReference = "";
	//bool IncludeFeedProperties = false;
	//private Dictionary<string, string[]> FeedProperties = new Dictionary<string, string[]> ();
	
	//public void CallFBFeed ()
	//{
	//	Dictionary<string, string[]> feedProperties = null;
	//	if (IncludeFeedProperties) {
	//		feedProperties = FeedProperties;
	//	}
	//	FB.Feed (
	//		toId: FeedToId,
	//		link: FeedLink,
	//		linkName: FeedLinkName,
	//		linkCaption: FeedLinkCaption,
	//		linkDescription: FeedLinkDescription,
	//		picture: FeedPicture,
	//		mediaSource: FeedMediaSource,
	//		actionName: FeedActionName,
	//		actionLink: FeedActionLink,
	//		reference: FeedReference,
	//		properties: feedProperties,
	//		callback: Callback
	//	);
	//}
	
	//void Callback (FBResult result)
	//{
	//	facebookUserInfoHandler.feedCallback ();
	//}

	public void ChangeYourName ()
	{
		if (changename.Text.Trim () != string.Empty) {
			ProfileManager.userProfile.PlayerName = changename.Text;			
			serverHighScore.changeName (SystemInfo.deviceUniqueIdentifier, ProfileManager.userProfile.PlayerName);

			PlayerPrefs.Save ();
			
			EditName.IsVisible = false;			
		}
	}

	public void EditNameOnClick ()
	{
		sound.ButtonClick ();
		if (ProfileManager.userProfile.VipLevel == 3) {
			EditName.IsVisible = true;
			changename.Text = ProfileManager.userProfile.PlayerName;

		} else {
			Notice.IsVisible = true;
			noticeMessage.Text = "Buy VIP to change name";
		}
	}

	//void OnInitComplete ()
	//{
	//}
	
	//void OnHideUnity (bool isGameShown)
	//{
	//}
	
	public FacebookAvatar getAvatar (string facebookID)
	{		
		FacebookAvatar fbAvatar = new FacebookAvatar (facebookID, null);
		this.loadFacebookAvatar (fbAvatar);
		fbAvatar.isStartLoading = true;
		
		return fbAvatar;
	}
	
	protected void loadFacebookAvatar (FacebookAvatar facebookAvatar)
	{
		StartCoroutine (getProfileImage (facebookAvatar));
	}
	
	IEnumerator getProfileImage (FacebookAvatar facebookAvatar)
	{
		WWW webRequest = new WWW ("https://graph.facebook.com/" + facebookAvatar.facebookID + "/picture?type=large"); //+ "?access_token=" + FB.AccessToken);
		
		Texture2D avatar = new Texture2D (128, 128, TextureFormat.DXT1, false); //TextureFormat must be DXT1 or DXT5
		
		yield return webRequest;
		
		if (webRequest.text != null) {
			if (webRequest.text.ToLower ().Contains ("error")) {
				facebookAvatar.isError = true;
				
			} else {
				if (webRequest.error == null || webRequest.error == string.Empty) {
					webRequest.LoadImageIntoTexture (avatar);
					facebookAvatar.avatar = avatar;
					facebookAvatar.isAvatarLoaded = true;
				} else {
					facebookAvatar.isError = true;
				}
			}			
		} else {		
			if (webRequest.error == null || webRequest.error == string.Empty) {
				webRequest.LoadImageIntoTexture (avatar);
				facebookAvatar.avatar = avatar;
				facebookAvatar.isAvatarLoaded = true;
				
			} else {
				facebookAvatar.isError = true;
			}
		}
	}
}