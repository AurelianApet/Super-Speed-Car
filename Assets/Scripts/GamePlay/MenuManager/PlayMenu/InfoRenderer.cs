using UnityEngine;
using System.Collections;
using System.Text;
using System;

public class InfoRenderer : BaseMenu
{
		Rect topMenuPos;

		//
		Rect lapTextPos;
		Rect orderTextPos;
		Rect timeTextPos;
		Rect checkTextPos;
		Rect kmPos;

		//
		Rect wrongWayPos;
		Rect eliminatePos;

		//
		Rect timePos;
		Rect flyPos;
		Rect driftPos;
		Rect obstaclePos;
		Rect nitroEarnedPos;
		Rect dollarEarnedPos;
		Rect powerUpNoticePos;

		//
		Rect nitroPos;
		Rect nitroClipSize;

		//
		Rect speedPos;
		Rect orderPos;
		Rect lapPos;
		Rect timeInfoPos;
		Rect checkInfoPos;
		Rect background;

		//
		int numberRaces;
		int fontSize;
		Font tempFont;

		//
		string posText;
		string lapText;
		string checkPointText;

		//
		float tempNitroBarWidth;
		int tempFontSize;

		//
		float lastDrift;
		float lastFly;
		float lastTransparent;
		Color nitroColor;

		//
		public string powerUpNotice;
		public float lastPowerUpNotice;

		public InfoRenderer (MenuRenderer menuRenderer, Game game):base(menuRenderer,game)
		{
				this.topMenuPos = new Rect ((800 - menuRenderer.topMenu.width) / 2, 0, 
		                            menuRenderer.topMenu.width, menuRenderer.topMenu.height);
		
				this.lapTextPos = new Rect (575, 110, 100, 30);
				this.orderTextPos = new Rect (160, -30, 100, 30);
				this.timeTextPos = new Rect (575, 110, 100, 30);
				this.checkTextPos = new Rect (575, 110, 100, 30);

				this.wrongWayPos = new Rect (160, 200, 500, 200);
				this.eliminatePos = new Rect (210, 100, 500, 200);

				this.timePos = new Rect (375, 45, 100, 100);
				this.driftPos = new Rect (130, 150, 400, 100);
				this.flyPos = new Rect (130, 180, 400, 100);
				this.obstaclePos = new Rect (130, 210, 400, 100);
				this.nitroEarnedPos = new Rect (500, 150, 400, 100);
				this.dollarEarnedPos = new Rect (500, 180, 400, 100);
				this.powerUpNoticePos = new Rect (190, 420, 600, 100);

				this.nitroPos = new Rect (0, 0, menuRenderer.nitroBar.width, menuRenderer.nitroBar.height);
				this.nitroClipSize = new Rect (topMenuPos.x, 0, menuRenderer.nitroBar.width, menuRenderer.nitroBar.height);

				this.speedPos = new Rect (360, 0, 100, 100);
				this.kmPos = new Rect (430, 0, 100, 100);

				this.orderPos = new Rect (180, -5, 200, 100);
				this.lapPos = new Rect (555, 130, 200, 50);
				this.timeInfoPos = new Rect (555, 130, 200, 100);
				this.checkInfoPos = new Rect (555, 130, 200, 50);

				this.tempNitroBarWidth = menuRenderer.nitroBar.width / 100f;

				this.posText = "/" + GameData.numberPlayers;
				this.lapText = "/" + GameData.numberRaces;
				this.checkPointText = "/" + GameData.numberCheckpoints;
				this.lastTransparent = 1;
				this.nitroColor = new Color (1, 1, 1, 1);

				this.background = new Rect (0, 0, 800, 480);

				this.powerUpNotice = string.Empty;
		}

		public override void render ()
		{
				GUI.DrawTexture (topMenuPos, menuRenderer.topMenu);

				nitroClipSize.width = game.carManager.MainPlayer.carData.NitroBar * tempNitroBarWidth;
				GUI.BeginGroup (nitroClipSize);
				if (game.carManager.MainPlayer.carData.NitroBar == 100) {
						nitroColor.a = lastTransparent;
						GUI.color = nitroColor;
						GUI.DrawTexture (this.nitroPos, menuRenderer.nitroBar);

						lastTransparent -= Time.deltaTime;
						if (lastTransparent < 0) {
								lastTransparent = 1;
						}
						GUI.color = Color.white;
				} else {
						GUI.DrawTexture (this.nitroPos, menuRenderer.nitroBar);
				}
				GUI.EndGroup ();

				this.fontSize = GUI.skin.label.fontSize;
				this.tempFont = GUI.skin.label.font;
				GUI.skin.label.fontSize = 25;
				GUI.skin.label.font = menuRenderer.numberFont;

				if (game.carManager.isWrongWay (BaseCarManager.mainPlayerID) == true && Game.gameState == Game.GAME_STATE.RUNNING && game.carManager.isPoliceCaught == false) {
						tempFontSize = GUI.skin.label.fontSize;
						GUI.skin.label.fontSize = 60;
						GUI.contentColor = Color.red;
						GUI.Label (wrongWayPos, "Wrong Way");
						GUI.skin.label.fontSize = tempFontSize;
				}

				GUI.skin.label.fontStyle = FontStyle.Italic;
		
				GUI.contentColor = Color.yellow;

				GUI.skin.label.fontSize = 10;
				GUI.Label (kmPos, "km/h");

				GUI.skin.label.fontSize = 25;
				GUI.Label (speedPos, ((int)(game.carManager.MainPlayer.carData.VelocityMagnitude * 3.6f)).ToString ());

				GUI.skin.label.fontSize = 20;
				GUI.contentColor = Color.white;
				GUI.Label (timePos, ((int)game.StateTime) / 60 + ":" + ((int)game.StateTime) % 60);		

				GUI.contentColor = Color.yellow;

				if (game.carManager.isPoliceCaught == false) {
						if (game.carManager.MainPlayer.carData.IsDrift) {
								GUI.Label (driftPos, "DRIFT: " + String.Format ("{0:0.00}", game.carManager.MainPlayer.carData.DriftTime));
						} else {
								if (lastDrift > 0) {
										if (Time.timeSinceLevelLoad - lastDrift < 2) {
												GUI.Label (driftPos, "DRIFT: " + String.Format ("{0:0.00}", game.carManager.MainPlayer.carData.DriftDuration));
										}
								}
						}

						if (game.carManager.MainPlayer.carData.IsFly) {
								GUI.Label (flyPos, "AIR: " + String.Format ("{0:0.00}", game.carManager.MainPlayer.carData.FlyTime));
						} else {
								if (lastFly > 0) {
										if (Time.timeSinceLevelLoad - lastFly < 2) {
												GUI.Label (flyPos, "AIR: " + String.Format ("{0:0.00}", game.carManager.MainPlayer.carData.FlyDuration));
										}
								}
						}

						if (game.carManager.MainPlayer.carData.LastObstacleCollisionTime > 0) {
								if (Time.timeSinceLevelLoad - game.carManager.MainPlayer.carData.LastObstacleCollisionTime < 2) {
										GUI.Label (obstaclePos, "OBSTACLE x " + game.carManager.MainPlayer.carData.TotalObstacleCollision);
								}
						}

						if (game.carManager.MainPlayer.carData.LastNitroEarnedTime > 0) {
								if (Time.timeSinceLevelLoad - game.carManager.MainPlayer.carData.LastNitroEarnedTime < 2) {
										GUI.Label (nitroEarnedPos, "Nitro Earned: " + game.carManager.MainPlayer.carData.LastNitroEarned + "%");
								}
						}

						if (game.carManager.MainPlayer.carData.LastDollarEarnedTime > 0) {
								if (Time.timeSinceLevelLoad - game.carManager.MainPlayer.carData.LastDollarEarnedTime < 2) {
										GUI.Label (dollarEarnedPos, "Coins Earned: " + game.carManager.MainPlayer.carData.LastDollarEarned);
								}
						}

						if (powerUpNotice != string.Empty) {
								if (Time.timeSinceLevelLoad - lastPowerUpNotice < 2) {
										GUI.Label (powerUpNoticePos, powerUpNotice);
								}
						}
				} else {
						GUI.skin.label.fontSize = 40;

						GUI.Label (new Rect (50, 200, 800, 100), "You are caught by police!");

						GUI.skin.label.fontSize = 20;
						GUI.Label (new Rect (300, 250, 400, 100), "Respawn in: " 
								+ String.Format ("{0:0}", 3 - (Time.timeSinceLevelLoad - game.carManager.policeCaughtTime)));

						GUI.skin.label.fontSize = fontSize;
				}

				GUI.contentColor = Color.white;

				switch (GameData.selectedMode) {
				case GameData.GAME_MODE.CLASSIC:
						GUI.contentColor = Color.yellow;
						GUIUtility.RotateAroundPivot (10, Vector2.zero);

						GUI.Label (orderTextPos, "Pos");			
						GUI.contentColor = Color.white;
						GUI.Label (orderPos, game.carManager.getOrder (BaseCarManager.mainPlayerID) + this.posText);

						GUIUtility.RotateAroundPivot (-10, Vector2.zero);

						GUI.contentColor = Color.yellow;
						GUIUtility.RotateAroundPivot (-10, Vector2.zero);

						GUI.Label (lapTextPos, "Laps");
						numberRaces = (GameData.numberRaces - game.carManager.carInfo [BaseCarManager.mainPlayerID].NumberRaces);
						if (numberRaces > GameData.numberRaces) {
								numberRaces = GameData.numberRaces;
						}			
						GUI.contentColor = Color.white;
						GUI.Label (lapPos, numberRaces + this.lapText);

						GUIUtility.RotateAroundPivot (10, Vector2.zero);
						break;
			
				case GameData.GAME_MODE.TIME_TRIAL:
						GUI.contentColor = Color.yellow;
						GUIUtility.RotateAroundPivot (-10, Vector2.zero);

						GUI.Label (timeTextPos, "Time");			
			
						if (game.StateTime < GameData.durationFirst) {
								GUI.contentColor = Color.white;
								GUI.Label (timeInfoPos, GameData.durationFirst.ToString ());
								GUI.contentColor = Color.white;
				
						} else if (game.StateTime < GameData.durationSecond) {
								GUI.contentColor = Color.green;
								GUI.Label (timeInfoPos, GameData.durationSecond.ToString ());
								GUI.contentColor = Color.white;
				
						} else if (game.StateTime < GameData.durationThird) {
								GUI.contentColor = Color.yellow;
								GUI.Label (timeInfoPos, GameData.durationThird.ToString ());
								GUI.contentColor = Color.white;
				
						} else {
								GUI.contentColor = Color.red;
								GUI.Label (timeInfoPos, GameData.durationThird.ToString ());
								GUI.contentColor = Color.white;
						}

						GUIUtility.RotateAroundPivot (10, Vector2.zero);
						break;
			
				case GameData.GAME_MODE.CHECK_POINT:
						GUI.contentColor = Color.yellow;
						GUIUtility.RotateAroundPivot (10, Vector2.zero);

						GUI.Label (orderTextPos, "Pos");
						GUI.contentColor = Color.white;			
						GUI.Label (orderPos, game.carManager.getOrder (BaseCarManager.mainPlayerID) + this.posText);

						GUIUtility.RotateAroundPivot (-10, Vector2.zero);						

						GUI.contentColor = Color.yellow;
						GUIUtility.RotateAroundPivot (-10, Vector2.zero);
						GUI.Label (checkTextPos, "Check");
			
						GUI.contentColor = Color.white;
						GUI.Label (checkInfoPos, game.carManager.MainPlayer.carData.TotalCheckPointEarned + this.checkPointText);
						GUIUtility.RotateAroundPivot (10, Vector2.zero);						
						break;

				case GameData.GAME_MODE.ELIMINATION:
						GUI.contentColor = Color.yellow;

						GUIUtility.RotateAroundPivot (10, Vector2.zero);

						GUI.Label (orderTextPos, "Pos");
						GUI.contentColor = Color.white;
						GUI.Label (orderPos, game.carManager.getOrder (BaseCarManager.mainPlayerID) + "/" 
								+ (GameData.numberPlayers - ((SinglePlayerCarManger)game.carManager).numberEliminate));

						GUIUtility.RotateAroundPivot (-10, Vector2.zero);

						if (Game.gameState == Game.GAME_STATE.RUNNING) {
								if (((SinglePlayerCarManger)game.carManager).getEliminateTime () < 10) {
										tempFontSize = GUI.skin.label.fontSize;
										GUI.skin.label.fontSize = 30;
										GUI.contentColor = Color.red;
										GUI.Label (eliminatePos, "ELIMINATE LAST IN " + 
												String.Format ("{0:0}", ((SinglePlayerCarManger)game.carManager).getEliminateTime ()));
										GUI.skin.label.fontSize = tempFontSize;
								}
						}
						break;
			
				default:
						break;
				}

				if (GameData.IsAutoSteer == true) {
						GUI.contentColor = Color.white;
						GUI.Label (new Rect (330, 430, 400, 50), "Auto drive");
						GUI.contentColor = Color.white;
				}

				GUI.contentColor = Color.white;
				GUI.skin.label.fontStyle = FontStyle.Normal;
				GUI.skin.label.fontSize = fontSize;
				GUI.skin.label.font = tempFont;
		
				if (game.carManager.isPoliceCaught == true) {
						GUI.color = Color.black;
						GUI.Box (background, string.Empty);
						GUI.color = Color.white;
				}
		}

		public void drawCountDown ()
		{
				GUI.skin.label.fontSize = 200;
				this.tempFont = GUI.skin.label.font;
				GUI.skin.label.font = menuRenderer.numberFont;

				if (((3 - (int)Time.timeSinceLevelLoad)) == 1) {
						GUI.Label (new Rect ((800 - 50) / 2, (480 - 250) / 2, 200, 200),
			           		Mathf.Abs (3 - (int)Time.timeSinceLevelLoad).ToString ());
				} else {
						GUI.Label (new Rect ((800 - 100) / 2, (480 - 250) / 2, 200, 200),
			           		Mathf.Abs (3 - (int)Time.timeSinceLevelLoad).ToString ());
				}

				GUI.skin.label.font = tempFont;
				GUI.skin.label.fontSize = fontSize;
		}

		public void setLastDrift ()
		{
				this.lastDrift = Time.timeSinceLevelLoad;
		}

		public void setLastFly ()
		{
				this.lastFly = Time.timeSinceLevelLoad;
		}
}
