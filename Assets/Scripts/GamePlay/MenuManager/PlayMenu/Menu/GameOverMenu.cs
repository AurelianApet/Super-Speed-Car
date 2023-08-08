using UnityEngine;
using System.Collections;
using System;

public class GameOverMenu : BaseMenu
{		
	Rect gameOverPos;

	//
	ImageButton continueButton;
	ImageButton restartButton;

	//
	Rect driftInfoPos;
	Rect flyInfoPos;
	Rect nitroInfoPos;
	Rect obstacleInfoPos;
	Rect dollarInfoPos;
	Rect rewardInfoPos;
	Rect scoreInfoPos;
	Rect nitroUsingInfoPos;
		
	//
	Rect firstStarPos;
	Rect secondStarPos;
	Rect thirdStarPos;

	//
	Rect firstMissionPos;
	Rect secondMissionPos;
	string firstMission;
	string secondMission;
	Rect firstMissionStarPos;
	Rect secondMissionStarPos;

	//
	Rect background;

	//
	Font tempFont;
	int fontSize;

	//
	int currentAcceleration = 10;

	public GameOverMenu (MenuRenderer menuRenderer, Game game):base(menuRenderer,game)
	{
		this.gameOverPos = new Rect (0, 85, 800, 328);

		this.continueButton = new ImageButton (menuRenderer.nextUp, menuRenderer.nextDown,
		                                       new Rect (550, 420, 200, 50));
		this.continueButton.onClick = continueOnClick;
		
		this.restartButton = new ImageButton (menuRenderer.restartUp, menuRenderer.restartDown,
		                                      new Rect (50, 420, 200, 50));
		this.restartButton.onClick = restartOnClick;
		
		this.driftInfoPos = new Rect (675, 195, 300, 50);
		this.flyInfoPos = new Rect (700, 230, 300, 50);
		this.nitroInfoPos = new Rect (725, 268, 300, 50);		
		this.dollarInfoPos = new Rect (750, 305, 300, 50);
		this.obstacleInfoPos = new Rect (775, 340, 300, 50);
		this.nitroUsingInfoPos = new Rect (800, 377, 300, 50);
		
		this.rewardInfoPos = new Rect (75, 240, 300, 50);
		this.scoreInfoPos = new Rect (75, 350, 300, 50);

		this.firstStarPos = new Rect (273, -20, 42, 42);
		this.secondStarPos = new Rect (320, -20, 42, 42);
		this.thirdStarPos = new Rect (368, -20, 42, 42);
		
		this.firstMissionStarPos = new Rect (498, 98, 21, 21);
		this.secondMissionStarPos = new Rect (498, 125, 21, 21);

		firstMissionPos = new Rect (525, 97, 300, 100);
		secondMissionPos = new Rect (525, 125, 300, 100);
		
		firstMission = MissionDescription.getFirstMission (GameData.level);
		secondMission = MissionDescription.getSecondMission (GameData.level);

		this.background = new Rect (0, 0, 800, 480);
	}
	
	public override void render ()
	{
		GUI.color = Color.black;
		GUI.Box (background, string.Empty);
		GUI.color = Color.white;

		GUI.DrawTexture (this.gameOverPos, menuRenderer.gameOverFrame);	

		switch (GameData.rank) {
		case 1:
			GUI.DrawTexture (firstStarPos, menuRenderer.starImage);
			GUI.DrawTexture (secondStarPos, menuRenderer.starImage);
			GUI.DrawTexture (thirdStarPos, menuRenderer.starImage);
			break;
			
		case 2:
			GUI.DrawTexture (firstStarPos, menuRenderer.starImage);
			GUI.DrawTexture (secondStarPos, menuRenderer.starImage);
			break;
			
		case 3:
			GUI.DrawTexture (firstStarPos, menuRenderer.starImage);
			break;
			
		default:
			break;
		}

		tempFont = GUI.skin.label.font;
		fontSize = GUI.skin.label.fontSize;
		GUI.skin.label.font = menuRenderer.textFont;		
		GUI.skin.label.fontSize = 20;

		GUI.Label (driftInfoPos, String.Format ("{0:0.00}", game.carManager.MainPlayer.carData.TotalDriftTime) + " seconds");
		GUI.Label (flyInfoPos, String.Format ("{0:0.00}", game.carManager.MainPlayer.carData.TotalFlyTime) + " seconds");
		GUI.Label (nitroInfoPos, game.carManager.MainPlayer.carData.TotalNumberNitroEarned.ToString () + " nitro");		
		GUI.Label (dollarInfoPos, game.carManager.MainPlayer.carData.TotalDollarEarned.ToString () + " coins");		
		GUI.Label (obstacleInfoPos, game.carManager.MainPlayer.carData.TotalObstacleCollision.ToString () + " obstacles");		
		GUI.Label (nitroUsingInfoPos, String.Format ("{0:0.00}", game.carManager.MainPlayer.carData.TotalNitroUsingDuration) + " seconds");

		GUI.contentColor = Color.yellow;
		GUI.skin.label.fontSize = 40;

		if (nitroUsingInfoPos.x > 600) {
			GUI.Label (rewardInfoPos, String.Format ("{0:0}", UnityEngine.Random.Range (1000, 9999)));
			GUI.Label (scoreInfoPos, String.Format ("{0:0}", UnityEngine.Random.Range (1000, 9999)));
		} else {
			GUI.Label (rewardInfoPos, String.Format ("{0:0}", GameData.reward));
			GUI.Label (scoreInfoPos, String.Format ("{0:0}", GameData.score));
		}

		GUI.skin.label.fontSize = 20;
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

		GUI.skin.label.fontSize = fontSize;
		GUI.skin.label.font = tempFont;

		this.continueButton.draw ();
		this.restartButton.draw ();

		if (GameData.rank <= 3) {
			GUI.DrawTexture (new Rect (80, 105, 150, 33), menuRenderer.winGameImage);
			
		} else {
			GUI.DrawTexture (new Rect (80, 105, 138, 33), menuRenderer.loseGameImage);
		}

		this.calculateGUIAnimation ();
	}

	public void continueOnClick ()
	{
		game.soundManager.playClick ();
		Time.timeScale = 1;

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
	}
	
	public void restartOnClick ()
	{
		game.soundManager.playClick ();
		Time.timeScale = 1;

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
	}

	public void calculateGUIAnimation ()
	{
		if (driftInfoPos.x > 600) {
			this.driftInfoPos.x -= currentAcceleration * Time.fixedDeltaTime;
		} else {
			this.driftInfoPos.x = 600;
		}

		if (flyInfoPos.x > 600) {
			this.flyInfoPos.x -= currentAcceleration * Time.fixedDeltaTime;
		} else {
			this.flyInfoPos.x = 600;
		}

		if (nitroInfoPos.x > 600) {
			this.nitroInfoPos.x -= currentAcceleration * Time.fixedDeltaTime;
		} else {
			this.nitroInfoPos.x = 600;
		}

		if (dollarInfoPos.x > 600) {
			this.dollarInfoPos.x -= currentAcceleration * Time.fixedDeltaTime;
		} else {
			this.dollarInfoPos.x = 600;
		}

		if (obstacleInfoPos.x > 600) {
			this.obstacleInfoPos.x -= currentAcceleration * Time.fixedDeltaTime;
		} else {
			this.obstacleInfoPos.x = 600;
		}

		if (nitroUsingInfoPos.x > 600) {
			this.nitroUsingInfoPos.x -= currentAcceleration * Time.fixedDeltaTime;
		} else {
			this.nitroUsingInfoPos.x = 600;
		}

		if (firstStarPos.y < 98) {
			this.firstStarPos.y += currentAcceleration * Time.fixedDeltaTime;
		} else {
			this.firstStarPos.y = 98;
		}

		if (secondStarPos.y < 98) {
			this.secondStarPos.y += currentAcceleration * Time.fixedDeltaTime;
		} else {
			this.secondStarPos.y = 98;
		}

		if (thirdStarPos.y < 98) {
			this.thirdStarPos.y += currentAcceleration * Time.fixedDeltaTime;
		} else {
			this.thirdStarPos.y = 98;
		}

		currentAcceleration += (int)(500 * Time.fixedDeltaTime);
	}
}