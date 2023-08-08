using UnityEngine;
using System.Collections;
using System;

public class PreGameOverMenu : BaseMenu
{
		Rect preGameOverPos;
	
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
		Rect preGameOverTimeTrial;
		Rect tipPos;
	
		//
		ImageButton continueButton;
	
		//
		int fontSize;
		Font tempFont;
		string tip;
	
		public PreGameOverMenu (MenuRenderer menuRenderer, Game game):base(menuRenderer,game)
		{
				if (GameData.selectedMode != GameData.GAME_MODE.TIME_TRIAL) {
						this.preGameOverPos = new Rect (0, 85, 800, 328);
			
						this.firstStarPos = new Rect (274, 98, 42, 42);
						this.secondStarPos = new Rect (321, 98, 42, 42);
						this.thirdStarPos = new Rect (369, 98, 42, 42);
			
						this.firstMissionStarPos = new Rect (498, 98, 21, 21);
						this.secondMissionStarPos = new Rect (498, 125, 21, 21);
			
						firstMissionPos = new Rect (525, 97, 300, 100);
						secondMissionPos = new Rect (525, 125, 300, 100);
			
				} else {
						this.preGameOverTimeTrial = new Rect (0, 85, 800, 328);
			
						this.firstStarPos = new Rect (300, 95, 45, 45);
						this.secondStarPos = new Rect (354, 95, 45, 45);
						this.thirdStarPos = new Rect (408, 95, 45, 45);
			
						this.firstMissionStarPos = new Rect (505, 94, 21, 21);
						this.secondMissionStarPos = new Rect (505, 125, 21, 21);
			
						firstMissionPos = new Rect (530, 94, 300, 100);
						secondMissionPos = new Rect (530, 125, 300, 100);
				}
		
				this.continueButton = new ImageButton (menuRenderer.nextUp, menuRenderer.nextDown,
		                                       new Rect (600, 420, 200, 50));
				this.continueButton.onClick = continueOnClick;
		
				firstMission = MissionDescription.getFirstMission (GameData.level);
				secondMission = MissionDescription.getSecondMission (GameData.level);
		
				tip = SceneLoader.getTip ();
				this.tipPos = new Rect (0, 425, 600, 50);
		}
	
		public override void render ()
		{
				if (GameData.selectedMode != GameData.GAME_MODE.TIME_TRIAL) {
						GUI.DrawTexture (preGameOverPos, menuRenderer.preGameOverImage);
			
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
			
						this.fontSize = GUI.skin.label.fontSize;
						this.tempFont = GUI.skin.label.font;
						GUI.skin.label.font = menuRenderer.textFont;	
			
						GUI.contentColor = Color.white;
						this.continueButton.draw ();		
			
						GUI.skin.label.fontSize = 20;	
			
						GUI.skin.label.alignment = TextAnchor.MiddleCenter;
						GUI.Label (tipPos, tip);
						GUI.skin.label.alignment = TextAnchor.UpperLeft;
			
						if (GameData.isSinglePlayer == true) {
								GUI.Label (firstMissionPos, firstMission);
								GUI.Label (secondMissionPos, secondMission);
				
								if (GameData.FirstMission == true) {
										GUI.DrawTexture (firstMissionStarPos, menuRenderer.starImage);
								}
				
								if (GameData.SecondMission == true) {
										GUI.DrawTexture (secondMissionStarPos, menuRenderer.starImage);
								}
				
								for (int i=0; i<game.carManager.player.Length; i++) {
										if (game.carManager.orderInfo [i] != null) {
												if (game.carManager.orderInfo [i].id == BaseCarManager.mainPlayerID) {
														GUI.contentColor = Color.green;
												} else {
														GUI.contentColor = Color.white;
												}
						
												GUI.Label (new Rect (330, 195 + i * 36, 250, 50), game.carManager.orderInfo [i].playerName);
												GUI.Label (new Rect (550, 195 + i * 36, 400, 50), GameData.getCarName (game.carManager.orderInfo [i].carID).ToString ().Replace ('_', ' '));
										}
								}
				
								if (GameData.rank <= 3) {
										GUI.DrawTexture (new Rect (80, 105, 150, 33), menuRenderer.winGameImage);
					
								} else {
										GUI.DrawTexture (new Rect (80, 105, 138, 33), menuRenderer.loseGameImage);
								}
						} else {
								for (int i=0; i<game.carManager.carDistance.Length; i++) {
										if (game.carManager.carDistance [i].ID == BaseCarManager.mainPlayerID) {
												GUI.contentColor = Color.green;
										} else {
												GUI.contentColor = Color.white;
										}
					
										GUI.Label (new Rect (330, 195 + i * 36, 250, 50), BaseCarManager.playerName [game.carManager.carDistance [i].ID]);
										GUI.Label (new Rect (550, 195 + i * 36, 400, 50), GameData.getCarName (game.carManager.getCarID (game.carManager.carDistance [i].ID)).ToString ().Replace ('_', ' '));
								}
				
								if (GameData.rank == 1) {
										GUI.DrawTexture (new Rect (80, 105, 150, 33), menuRenderer.winGameImage);
					
								} else {
										GUI.DrawTexture (new Rect (80, 105, 138, 33), menuRenderer.loseGameImage);
								}
						}
			
						GUI.contentColor = Color.white;
						GUI.skin.label.fontStyle = FontStyle.Normal;
						GUI.skin.label.fontSize = fontSize;
						GUI.skin.label.font = tempFont;
				} else {
						GUI.DrawTexture (preGameOverTimeTrial, menuRenderer.timeTrialFrame);
			
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
			
						this.fontSize = GUI.skin.label.fontSize;
						this.tempFont = GUI.skin.label.font;
						GUI.skin.label.font = menuRenderer.textFont;	
			
						GUI.contentColor = Color.white;
						this.continueButton.draw ();
			
						GUI.skin.label.fontSize = 20;	
			
						GUI.skin.label.alignment = TextAnchor.MiddleCenter;
						GUI.Label (tipPos, tip);
						GUI.skin.label.alignment = TextAnchor.UpperLeft;
			
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
			
						GUI.Label (new Rect (120, 195, 250, 50), "1");
						GUI.Label (new Rect (360, 195, 250, 50), game.carManager.orderInfo [0].playerName);
						GUI.Label (new Rect (550, 195, 400, 50), GameData.getCarName (game.carManager.orderInfo [0].carID).ToString ().Replace ('_', ' '));
			
						GUI.skin.label.fontSize = 50;	
			
						GUI.contentColor = Color.green;
						GUI.Label (new Rect (535, 340, 250, 100), String.Format ("{0:00}", ((int)game.StateTime) / 60));
						GUI.Label (new Rect (595, 340, 250, 100), String.Format ("{0:00}", ((int)game.StateTime) % 60));
						GUI.Label (new Rect (655, 340, 250, 100), String.Format ("{0:000}", (game.StateTime - Mathf.FloorToInt (game.StateTime)) * 1000));
			
						GUI.skin.label.fontSize = 30;
			
						GUI.contentColor = Color.white;
						GUI.Label (new Rect (200, 275, 250, 100), GameData.durationFirst.ToString ());
			
						GUI.contentColor = Color.green;
						GUI.Label (new Rect (200, 317, 250, 100), GameData.durationSecond.ToString ());
			
						GUI.contentColor = Color.yellow;
						GUI.Label (new Rect (200, 358, 250, 100), GameData.durationThird.ToString ());
			
						GUI.contentColor = Color.white;
						GUI.skin.label.fontStyle = FontStyle.Normal;
						GUI.skin.label.fontSize = fontSize;
						GUI.skin.label.font = tempFont;
			
						if (GameData.rank <= 3) {
								GUI.DrawTexture (new Rect (80, 105, 150, 33), menuRenderer.winGameImage);
				
						} else {
								GUI.DrawTexture (new Rect (80, 105, 138, 33), menuRenderer.loseGameImage);
						}
				}
		}
	
		public void continueOnClick ()
		{
				game.soundManager.playClick ();
				menuRenderer.IsNextGUI = true;
		}
}