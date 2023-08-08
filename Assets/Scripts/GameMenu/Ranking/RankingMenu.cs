using UnityEngine;
using System.Collections;

public class RankingMenu : BaseHeaderMenu
{
	enum TOP_SCORE_TYPE
	{
		MY_POSITION,
		TOP_WEEK,
		TOP_MONTH,
		TOP_ALL_TIME,
		KING_OF_DAY
	}

	//
	public AudioSource audioSource;
	public AudioSource click;

	//
	public ServerHighscore serverHighScore;

	//
	public dfButton myPosition;
	public dfButton topWeek;
	public dfButton topMonth;
	public dfButton topAllTime;
	public dfButton kingOfDay;
	public dfSprite loadingIndicator;

	//
	public dfScrollPanel scrollPanel;
	public RankingRow[] myPositionList;

	//
	public Texture2D[] titleImage;
	public Texture2D[] flagImage;

	//
	TOP_SCORE_TYPE selectedTopScoreType;

	public void Start ()
	{
		ProfileManager.init ();
		
		audioSource.volume = ProfileManager.setttings.MusicVolume / 100f;
		audioSource.Play ();
		
		click.volume = ProfileManager.setttings.SoundVolume / 100f;

		for (int i=0; i<myPositionList.Length; i++) {
			this.myPositionList [i].setVisible (false);
		}

		this.chooseMyPositionRank ();
		
		serverHighScore.getScoreWeek (SystemInfo.deviceUniqueIdentifier, 25);
		serverHighScore.getScoreMonth (SystemInfo.deviceUniqueIdentifier, 25);		
		serverHighScore.getScoreAllTime (SystemInfo.deviceUniqueIdentifier, 25);	
		serverHighScore.getScoreKingOfDay (SystemInfo.deviceUniqueIdentifier, 50);	

		serverHighScore.postScore (ProfileManager.userProfile.Score, ProfileManager.userProfile.getNumberStar (),
		                           SystemInfo.deviceUniqueIdentifier, ProfileManager.userProfile.PlayerName, ProfileManager.userProfile.Nation.ToString ());
	}

	public void Update ()
	{
		if (Input.GetKeyUp (KeyCode.Escape)) {
			AutoFade.LoadLevel ("MainMenu");
		} else {
			this.updateInfo ();
				
			switch (selectedTopScoreType) {
			case TOP_SCORE_TYPE.MY_POSITION:
				if (ServerHighscore.topAllTime == null) {
					loadingIndicator.IsVisible = true;
				} else {
					loadingIndicator.IsVisible = false;				
				}	
				updateMyPosition (ServerHighscore.topAllTime);
				break;
					
			case TOP_SCORE_TYPE.TOP_WEEK:
				if (ServerHighscore.topWeek == null) {
					loadingIndicator.IsVisible = true;
				} else {
					loadingIndicator.IsVisible = false;			
				}
				updateTopUserScore (ServerHighscore.topWeek);
				break;
					
			case TOP_SCORE_TYPE.TOP_MONTH:
				if (ServerHighscore.topMonth == null) {
					loadingIndicator.IsVisible = true;
				} else {
					loadingIndicator.IsVisible = false;			
				}
				updateTopUserScore (ServerHighscore.topMonth);
				break;
					
			case TOP_SCORE_TYPE.TOP_ALL_TIME:
				if (ServerHighscore.topAllTime == null) {
					loadingIndicator.IsVisible = true;
				} else {
					loadingIndicator.IsVisible = false;			
				}
				updateTopUserScore (ServerHighscore.topAllTime);
				break;
					
			case TOP_SCORE_TYPE.KING_OF_DAY:
				if (ServerHighscore.topKingOfDay == null) {
					loadingIndicator.IsVisible = true;
				} else {
					loadingIndicator.IsVisible = false;			
				}
						updateTopUserScore (ServerHighscore.topKingOfDay);
				break;
					
			default:
				break;
			}
		}
	}

	public void chooseMyPositionRank ()
	{		
		selectedTopScoreType = TOP_SCORE_TYPE.MY_POSITION;

		myPosition.IsEnabled = true;
		topWeek.IsEnabled = false;
		topMonth.IsEnabled = false;
		topAllTime.IsEnabled = false;
		kingOfDay.IsEnabled = false;

		scrollPanel.ScrollPosition = Vector2.zero;

		click.Play ();
	}

	public void chooseTopWeekRank ()
	{
		selectedTopScoreType = TOP_SCORE_TYPE.TOP_WEEK;

		myPosition.IsEnabled = false;
		topWeek.IsEnabled = true;
		topMonth.IsEnabled = false;
		topAllTime.IsEnabled = false;
		kingOfDay.IsEnabled = false;

		scrollPanel.ScrollPosition = Vector2.zero;

		click.Play ();
	}

	public void chooseTopMonthRank ()
	{
		selectedTopScoreType = TOP_SCORE_TYPE.TOP_MONTH;

		myPosition.IsEnabled = false;
		topWeek.IsEnabled = false;
		topMonth.IsEnabled = true;
		topAllTime.IsEnabled = false;
		kingOfDay.IsEnabled = false;

		scrollPanel.ScrollPosition = Vector2.zero;

		click.Play ();
	}

	public void chooseTopAllTimeRank ()
	{
		selectedTopScoreType = TOP_SCORE_TYPE.TOP_ALL_TIME;

		myPosition.IsEnabled = false;
		topWeek.IsEnabled = false;
		topMonth.IsEnabled = false;
		topAllTime.IsEnabled = true;
		kingOfDay.IsEnabled = false;

		scrollPanel.ScrollPosition = Vector2.zero;

		click.Play ();
	}

	public void chooseKingOfDayRank ()
	{
		selectedTopScoreType = TOP_SCORE_TYPE.KING_OF_DAY;
		
		myPosition.IsEnabled = false;
		topWeek.IsEnabled = false;
		topMonth.IsEnabled = false;
		topAllTime.IsEnabled = false;
		kingOfDay.IsEnabled = true;

		scrollPanel.ScrollPosition = Vector2.zero;
		
		click.Play ();
	}

	public void back ()
	{
		click.Play ();
		AutoFade.LoadLevel ("MainMenu");
	}

	void updateMyPosition (UserScoreCollections userScoreData)
	{
		if (userScoreData != null) {
			if (userScoreData.success == true && userScoreData.user_score != null) {
				int index = 0;

				for (int i=0; i<userScoreData.user_score.prev_user.Count; i++) {					
					myPositionList [index].setVisible (true);
					myPositionList [index].background.BackgroundColor = new Color (0, 0, 0, 0);
					myPositionList [index].updateMyPositionScore (userScoreData.user_score.prev_user [i]);
					index++;
				}

				myPositionList [index].setVisible (true);
				myPositionList [index].background.BackgroundColor = Color.gray;
				myPositionList [index].updateMyPositionScore (userScoreData.user_score.user);
				if (userScoreData.user_score.user.username != ProfileManager.userProfile.PlayerName) {
					serverHighScore.changeName (SystemInfo.deviceUniqueIdentifier, ProfileManager.userProfile.PlayerName);
				}

				index++;

				for (int i=0; i<userScoreData.user_score.next_user.Count; i++) {					
					myPositionList [index].setVisible (true);
					myPositionList [index].background.BackgroundColor = new Color (0, 0, 0, 0);
					myPositionList [index].updateMyPositionScore (userScoreData.user_score.next_user[i]);
					index++;
				}
			} else {
				this.clearAllText ();
			}
		} else {
			this.clearAllText ();
		}
	}

	void updateTopUserScore (UserScoreCollections userScoreData)
	{
		if (userScoreData != null) {
			if (userScoreData.success == true && userScoreData.top_list != null) {
				int index = 0;

				for (int i=0; i<userScoreData.top_list.Count; i++) {					
					if (index < myPositionList.Length) {
						myPositionList [index].background.BackgroundColor = new Color (0, 0, 0, 0);
						myPositionList [index].setVisible (true);
						myPositionList [index].updateMyPositionScore (userScoreData.top_list[i], index);
						
						index++;
					} else {
						break;
					}
				}
			
				for (int i=index; i<myPositionList.Length; i++) {
					this.myPositionList [i].setVisible (false);
				}
			} else {
				this.clearAllText ();
			}
		} else {
			this.clearAllText ();
		}
	}

	void clearAllText ()
	{
		for (int i=0; i<myPositionList.Length; i++) {
			this.myPositionList [i].setVisible (false);
		}
	}

	public static void detectLanguage ()
	{
		switch (Application.systemLanguage) {			
		case SystemLanguage.Afrikaans:
			ProfileManager.userProfile.Nation = 70;
			break;
			
		case SystemLanguage.Arabic:
			ProfileManager.userProfile.Nation = 79;
			break;
			
		case SystemLanguage.Basque:
			ProfileManager.userProfile.Nation = 71;
			break;
			
		case SystemLanguage.Belarusian:
			ProfileManager.userProfile.Nation = 63;
			break;
			
		case SystemLanguage.Bulgarian:
			ProfileManager.userProfile.Nation = 10;
			break;
			
		case SystemLanguage.Catalan:
			ProfileManager.userProfile.Nation = 71;
			break;
			
		case SystemLanguage.Chinese:
			ProfileManager.userProfile.Nation = 15;
			break;
			
		case SystemLanguage.Czech:
			ProfileManager.userProfile.Nation = 20;
			break;
			
		case SystemLanguage.Danish:
			ProfileManager.userProfile.Nation = 21;
			break;
			
		case SystemLanguage.Dutch:
			ProfileManager.userProfile.Nation = 51;
			break;
			
		case SystemLanguage.English:
			ProfileManager.userProfile.Nation = 80;
			break;
			
		case SystemLanguage.Estonian:
			ProfileManager.userProfile.Nation = 26;
			break;
			
		case SystemLanguage.Faroese:
			ProfileManager.userProfile.Nation = 21;
			break;
			
		case SystemLanguage.Finnish:
			ProfileManager.userProfile.Nation = 26;
			break;
			
		case SystemLanguage.French:
			ProfileManager.userProfile.Nation = 27;
			break;
			
		case SystemLanguage.German:
			ProfileManager.userProfile.Nation = 29;
			break;
			
		case SystemLanguage.Greek:
			ProfileManager.userProfile.Nation = 31;
			break;
			
		case SystemLanguage.Hebrew:
			ProfileManager.userProfile.Nation = 38;
			break;
			
		case SystemLanguage.Icelandic:
			ProfileManager.userProfile.Nation = 37;
			break;
			
		case SystemLanguage.Indonesian:
			ProfileManager.userProfile.Nation = 34;
			break;
			
		case SystemLanguage.Italian:
			ProfileManager.userProfile.Nation = 39;
			break;
			
		case SystemLanguage.Japanese:
			ProfileManager.userProfile.Nation = 41;
			break;
			
		case SystemLanguage.Korean:
			ProfileManager.userProfile.Nation = 42;
			break;
			
		case SystemLanguage.Latvian:
			ProfileManager.userProfile.Nation = 4;
			break;
			
		case SystemLanguage.Lithuanian:
			ProfileManager.userProfile.Nation = 21;
			break;
			
		case SystemLanguage.Norwegian:
			ProfileManager.userProfile.Nation = 55;
			break;
			
		case SystemLanguage.Polish:
			ProfileManager.userProfile.Nation = 59;
			break;
			
		case SystemLanguage.Portuguese:
			ProfileManager.userProfile.Nation = 60;
			break;
			
		case SystemLanguage.Romanian:
			ProfileManager.userProfile.Nation = 62;
			break;
			
		case SystemLanguage.Russian:
			ProfileManager.userProfile.Nation = 63;
			break;
			
		case SystemLanguage.SerboCroatian:
			ProfileManager.userProfile.Nation = 18;
			break;
			
		case SystemLanguage.Slovak:
			ProfileManager.userProfile.Nation = 68;
			break;
			
		case SystemLanguage.Slovenian:
			ProfileManager.userProfile.Nation = 69;
			break;
			
		case SystemLanguage.Spanish:
			ProfileManager.userProfile.Nation = 71;
			break;
			
		case SystemLanguage.Swedish:
			ProfileManager.userProfile.Nation = 72;
			break;
			
		case SystemLanguage.Thai:
			ProfileManager.userProfile.Nation = 74;
			break;
			
		case SystemLanguage.Turkish:
			ProfileManager.userProfile.Nation = 77;
			break;
			
		case SystemLanguage.Ukrainian:
			ProfileManager.userProfile.Nation = 78;
			break;
			
		case SystemLanguage.Vietnamese:
			ProfileManager.userProfile.Nation = 84;
			break;
			
		case SystemLanguage.Unknown:
			ProfileManager.userProfile.Nation = 84;
			break;
			
		case SystemLanguage.Hungarian:
			ProfileManager.userProfile.Nation = 32;
			break;
			
		default:
			ProfileManager.userProfile.Nation = 81;
			break;
		}
	}
}