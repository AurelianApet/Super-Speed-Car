using UnityEngine;
using System.Collections;

public class PauseMenu : BaseMenu
{
	ImageButton continueButton;
	ImageButton restartButton;
	ImageButton mainMenuButton;

	//
	ImageButton nextVibrateButton;
	ImageButton prevVibrateButton;
	ImageButton nextQualityButton;
	ImageButton prevQualityButton;

	//
	ToggleButton vibrateButton;
	ThreeStateButton qualityButton;
	ToggleButton tiltButton;
	ToggleButton touchButton;
		
	//
	Rect settingsPos;
	Rect header;

	//		
	Rect soundPos;
	Rect musicPos;
	Rect sensitivityPos;

	//		
	Rect soundPosFrame;
	Rect musicPosFrame;
	Rect sensitivityPosFrame;

	//
	Rect firstMissionPos;
	Rect secondMissionPos;
	string firstMission;
	string secondMission;
	Rect firstMissionStarPos;
	Rect secondMissionStarPos;

	//
	Rect mapName;
	Rect gameMode;
	Rect playerName;
	Rect moneyRect;
	Rect starRect;

	//
	GUIStyle slider;
	GUIStyle thumb;

	//
	int fontSize;
	Font tempFont;
	
	public PauseMenu (MenuRenderer menuRenderer, Game game):base(menuRenderer,game)
	{
		this.settingsPos = new Rect (0, 0, 800, 480);
		this.header = new Rect (0, 0, 800, 26);
		
		this.continueButton = new ImageButton (menuRenderer.resumeUp, menuRenderer.resumeDown,
		                                       new Rect (25, 410, 152, 48));
		this.continueButton.onClick = continueOnClick;
		
		this.restartButton = new ImageButton (menuRenderer.retryUp, menuRenderer.retryDown,
		                                      new Rect (25, 120, 152, 48));
		this.restartButton.onClick = restartOnClick;
		
		this.mainMenuButton = new ImageButton (menuRenderer.quitRaceUp, menuRenderer.quitRaceDown,
		                                       new Rect (25, 190, 152, 48));
		this.mainMenuButton.onClick = mainMenuOnClick;

		this.nextVibrateButton = new ImageButton (menuRenderer.settingNext, menuRenderer.settingNextUp,
		                                       new Rect (545, 435, 152, 48));
		this.nextVibrateButton.onClick = nextVibrate;

		this.prevVibrateButton = new ImageButton (menuRenderer.settingDown, menuRenderer.settingDownUp,
		                                          new Rect (418, 435, 152, 48));
		this.prevVibrateButton.onClick = prevVibrate;

		this.nextQualityButton = new ImageButton (menuRenderer.settingNext, menuRenderer.settingNextUp,
		                                          new Rect (368, 435, 152, 48));
		this.nextQualityButton.onClick = nextQuality;
		
		this.prevQualityButton = new ImageButton (menuRenderer.settingDown, menuRenderer.settingDownUp,
		                                          new Rect (235, 435, 152, 48));
		this.prevQualityButton.onClick = prevQuality;
		
		this.qualityButton = new ThreeStateButton (menuRenderer.low, menuRenderer.medium, menuRenderer.high,
		                                   new Rect (280, 436, 100, 50));
		this.qualityButton.changeStateListener = changeState;
		this.qualityButton.setState (ProfileManager.setttings.Quality);
		
		this.vibrateButton = new ToggleButton (menuRenderer.onButton, menuRenderer.offButton,
		                                       new Rect (476, 436, 100, 50));
		this.vibrateButton.setChecked (ProfileManager.setttings.IsVibrate);
		this.vibrateButton.toggleOn = vibrateOn;
		this.vibrateButton.toggleOff = vibrateOff;

		this.tiltButton = new ToggleButton (menuRenderer.tiltOn, menuRenderer.tiltOff,
		                                    new Rect (616, 123, 144, 120));
		this.tiltButton.setChecked (ProfileManager.setttings.ControllerTilt);
		this.tiltButton.toggleOn = tiltOn;
		this.tiltButton.toggleOff = tiltOn;

		this.touchButton = new ToggleButton (menuRenderer.touchOn, menuRenderer.touchOff,
		                                     new Rect (616, 290, 144, 120));
		this.touchButton.setChecked (!ProfileManager.setttings.ControllerTilt);
		this.touchButton.toggleOn = touchOn;
		this.touchButton.toggleOff = touchOn;
		
		this.slider = menuRenderer.skin.GetStyle ("horizontalslider");
		this.thumb = menuRenderer.skin.GetStyle ("horizontalsliderthumb");		
		
		this.musicPos = new Rect (236, 150, 340, 16);
		this.soundPos = new Rect (236, 218, 340, 16);
		this.sensitivityPos = new Rect (236, 288, 340, 16);

		this.musicPosFrame = new Rect (236, 154, 340, 12);
		this.soundPosFrame = new Rect (236, 222, 340, 12);
		this.sensitivityPosFrame = new Rect (236, 290, 340, 12);
		
		this.gameMode = new Rect (50, 48, 200, 100);
		this.firstMissionPos = new Rect (250, 48, 300, 100);
		this.secondMissionPos = new Rect (550, 48, 300, 100);

		this.firstMissionStarPos = new Rect (456, 48, 23, 23);
		this.secondMissionStarPos = new Rect (765, 48, 23, 23);
		
		this.firstMission = MissionDescription.getFirstMission (GameData.level);
		this.secondMission = MissionDescription.getSecondMission (GameData.level);

		this.mapName = new Rect (600, -3, 200, 100);

		this.playerName = new Rect (10, 0, 200, 100);
		this.starRect = new Rect (220, 0, 200, 100);
		this.moneyRect = new Rect (400, 0, 200, 100);
	}
	
	public override void render ()
	{
		GUI.DrawTexture (this.settingsPos, menuRenderer.settingsFrame);	
		GUI.DrawTexture (this.header, menuRenderer.header);	
		
		this.vibrateButton.draw ();
		this.qualityButton.draw ();
		this.tiltButton.draw ();
		this.touchButton.draw ();

		this.continueButton.draw ();
		this.restartButton.draw ();
		this.mainMenuButton.draw ();

		this.nextVibrateButton.draw ();
		this.prevVibrateButton.draw ();
		this.nextQualityButton.draw ();
		this.prevQualityButton.draw ();
		
		soundPosFrame.width = 340 * ProfileManager.setttings.SoundVolume / 100f;
		GUI.DrawTexture (this.soundPosFrame, menuRenderer.bar);	

		musicPosFrame.width = 340 * ProfileManager.setttings.MusicVolume / 100f;
		GUI.DrawTexture (this.musicPosFrame, menuRenderer.bar);	

		sensitivityPosFrame.width = 340 * ProfileManager.setttings.Sensitivity / 100f;
		GUI.DrawTexture (this.sensitivityPosFrame, menuRenderer.bar);	
		
		ProfileManager.setttings.SoundVolume = GUI.HorizontalSlider (soundPos,
		                                                             ProfileManager.setttings.SoundVolume, 0, 100, slider, thumb);
		
		ProfileManager.setttings.MusicVolume = GUI.HorizontalSlider (musicPos,
		                                                             ProfileManager.setttings.MusicVolume, 0, 100, slider, thumb);
		
		ProfileManager.setttings.Sensitivity = GUI.HorizontalSlider (sensitivityPos, 
		                                                             ProfileManager.setttings.Sensitivity, 0, 100, slider, thumb);

		this.fontSize = GUI.skin.label.fontSize;
		this.tempFont = GUI.skin.label.font;
		GUI.skin.label.font = menuRenderer.textFont;

		GUI.contentColor = Color.black;
		GUI.skin.label.fontSize = 30;	
		GUI.Label (mapName, GameData.selectedMap.ToString ().ToUpper ().Replace ("_", " "));

		GUI.skin.label.fontSize = 20;	
		GUI.Label (moneyRect, string.Format ("{0:n00}", ProfileManager.userProfile.Money));
		GUI.Label (starRect, string.Format ("{0:n00}", ProfileManager.userProfile.getNumberStar ()));
		GUI.Label (playerName, ProfileManager.userProfile.PlayerName);

		GUI.contentColor = Color.yellow;
		GUI.Label (gameMode, GameData.selectedMode.ToString ().ToUpper ().Replace ("_", " "));

		GUI.contentColor = Color.white;

		if (GameData.isSinglePlayer == true) {			
			GUI.Label (firstMissionPos, firstMission);
			GUI.Label (secondMissionPos, secondMission);
			
			if (GameData.FirstMission == true) {
				GUI.DrawTexture (firstMissionStarPos, menuRenderer.starImage);
			}

			if (GameData.SecondMission == true) {
				GUI.DrawTexture (secondMissionStarPos, menuRenderer.starImage);
			}
		}	
		GUI.contentColor = Color.white;
		GUI.skin.label.fontStyle = FontStyle.Normal;
		GUI.skin.label.fontSize = fontSize;
		GUI.skin.label.font = tempFont;
	}
	
	public void continueOnClick ()
	{
		game.soundManager.playClick ();
		PlayerPrefs.Save ();
		this.game.resumeGame ();

		game.carManager.MainPlayer.handlingInfo.steer = 0;	
	}
	
	public void restartOnClick ()
	{
		game.soundManager.playClick ();
		PlayerPrefs.Save ();

		if (GameData.isSinglePlayer == true) {
			SceneLoader.scene = Application.loadedLevelName;
			Application.LoadLevel ("Loading");
			
		} else {
			if (GameData.isWifiMode == true) {
				AutoFade.LoadLevel ("WifiGameMenu");
				
			} else {
				PhotonNetwork.Disconnect ();
				AutoFade.LoadLevel ("InternetGameMenu");
			}
		}

		Time.timeScale = 1;
	}
	
	public void mainMenuOnClick ()
	{
		game.soundManager.playClick ();
		PlayerPrefs.Save ();

		if (GameData.isSinglePlayer == true) {
			AutoFade.LoadLevel ("MainMenu");

		} else {
			if (GameData.isWifiMode == true) {
				AutoFade.LoadLevel ("WifiGameMenu");

			} else {
				PhotonNetwork.Disconnect ();
				AutoFade.LoadLevel ("InternetGameMenu");
			}
		}
		Time.timeScale = 1;

		GameData.resetGlobalPowerUp ();
	}
	
	public void vibrateOn ()
	{
		game.soundManager.playClick ();
		ProfileManager.setttings.IsVibrate = true;
	}
	
	public void vibrateOff ()
	{
		game.soundManager.playClick ();
		ProfileManager.setttings.IsVibrate = false;
	}
	
	public void changeState (int state)
	{
		game.soundManager.playClick ();				

		switch (state) {
		case 0:
			ProfileManager.setttings.Quality = 0;
			game.autoCam.changeQuality (0);			
			game.changeQuality ();
			break;

		case 1:
			ProfileManager.setttings.Quality = 1;
			game.autoCam.changeQuality (1);			
			game.changeQuality ();
			break;

		case 2:
			ProfileManager.setttings.Quality = 2;
			game.autoCam.changeQuality (2);			
			game.changeQuality ();
			break;

		default:
			ProfileManager.setttings.Quality = 1;
			game.autoCam.changeQuality (1);			
			game.changeQuality ();
			break;
		}
	}

	public void tiltOn ()
	{
		game.soundManager.playClick ();
		ProfileManager.setttings.ControllerTilt = true;		
		menuRenderer.changeControl ();

		this.tiltButton.setChecked (ProfileManager.setttings.ControllerTilt);
		this.touchButton.setChecked (!ProfileManager.setttings.ControllerTilt);
	}

	public void touchOn ()
	{
		game.soundManager.playClick ();
		ProfileManager.setttings.ControllerTilt = false;		
		menuRenderer.changeControl ();

		this.tiltButton.setChecked (ProfileManager.setttings.ControllerTilt);
		this.touchButton.setChecked (!ProfileManager.setttings.ControllerTilt);
	}

	public void nextVibrate ()
	{
		game.soundManager.playClick ();
		ProfileManager.setttings.IsVibrate = !ProfileManager.setttings.IsVibrate;
		this.vibrateButton.setChecked (ProfileManager.setttings.IsVibrate);
	}

	public void prevVibrate ()
	{
		game.soundManager.playClick ();
		ProfileManager.setttings.IsVibrate = !ProfileManager.setttings.IsVibrate;
		this.vibrateButton.setChecked (ProfileManager.setttings.IsVibrate);
	}

	public void nextQuality ()
	{
		game.soundManager.playClick ();		
		
		int state = ProfileManager.setttings.Quality;		
		state = (state + 1) % 3;
		changeState (state);
		this.qualityButton.setState (ProfileManager.setttings.Quality);
	}

	public void prevQuality ()
	{
		game.soundManager.playClick ();		
		
		int state = ProfileManager.setttings.Quality;		
		state--;
		if (state < 0) {
			state = 2;
		}
		changeState (state);
		this.qualityButton.setState (ProfileManager.setttings.Quality);
	}
}