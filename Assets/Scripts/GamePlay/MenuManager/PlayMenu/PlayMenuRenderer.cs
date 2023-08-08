using UnityEngine;
using System.Collections;

public class PlayMenuRenderer : BaseMenu
{
	Rect brakePosLeft;
	Rect nitroPosLeft;
	Rect brakePosRight;
	Rect nitroPosRight;

	//
	Rect brakeEventPos;
	Rect nitroEventPos;
	Rect leftTouchPos;
	Rect rightTouchPos;

	//
	ImageButton pauseButton;

	//
	Rect leftTouchRect;
	Rect rightTouchRect;

	//
	Rect firstPowerUpRect;
	Rect secondPowerUpRect;
	Rect thirdPowerUpRect;

	public PlayMenuRenderer (MenuRenderer menuRenderer, Game game):base(menuRenderer,game)
	{
		this.brakePosLeft = new Rect (10, 330, menuRenderer.brakeDown.width, menuRenderer.brakeDown.height);
		this.nitroPosLeft = new Rect (650, 330, menuRenderer.nitroDown.width, menuRenderer.nitroDown.height);

		this.changeControl ();

		this.brakePosRight = new Rect (540, 330, menuRenderer.brakeDown.width, menuRenderer.brakeDown.height);
		this.nitroPosRight = new Rect (660, 330, menuRenderer.nitroDown.width, menuRenderer.nitroDown.height);

		this.brakeEventPos = new Rect (0, 200, 300, 300);
		this.nitroEventPos = new Rect (500, 200, 300, 300);

		this.leftTouchPos = new Rect (0, 100, 300, 230);
		this.rightTouchPos = new Rect (500, 100, 300, 230);

		this.leftTouchRect = new Rect (0, 0, 100, 100);
		this.rightTouchRect = new Rect (0, 0, 100, 100);

		this.pauseButton = new ImageButton (menuRenderer.pauseUp, menuRenderer.pauseDown,
		                                    new Rect (0, 0, menuRenderer.pauseUp.width, menuRenderer.pauseDown.height));
		this.pauseButton.onClick = onPauseClick;

		this.firstPowerUpRect = new Rect (730, 10, 100, 50);
		this.secondPowerUpRect = new Rect (730, 70, 100, 50);
		this.thirdPowerUpRect = new Rect (730, 130, 100, 50);
	}

	public override void render ()
	{
		this.pauseButton.draw ();

		if (GameData.IsAutoSteer == false) {
			if (game.carManager.MainPlayer.isBrakeUsing () == false) {
				GUI.DrawTexture (brakePosLeft, menuRenderer.brakeUp);
			} else {
				GUI.DrawTexture (brakePosLeft, menuRenderer.brakeDown);
			}
		
			if (game.carManager.MainPlayer.isNitroUsing () == false) {
				GUI.DrawTexture (nitroPosLeft, menuRenderer.nitroUp);
			} else {
				GUI.DrawTexture (nitroPosLeft, menuRenderer.nitroDown);
			}

			if (ProfileManager.setttings.ControllerTilt == false) {
				if (game.carManager.MainPlayer.isBrakeUsing () == false) {
					GUI.DrawTexture (brakePosRight, menuRenderer.brakeUp);
				} else {
					GUI.DrawTexture (brakePosRight, menuRenderer.brakeDown);
				}
			
				if (game.carManager.MainPlayer.isNitroUsing () == false) {
					GUI.DrawTexture (nitroPosRight, menuRenderer.nitroUp);
				} else {
					GUI.DrawTexture (nitroPosRight, menuRenderer.nitroDown);
				}

				if (game.carManager.MainPlayer.handlingInfo.steer < 0) {
					GUI.DrawTexture (leftTouchRect, menuRenderer.touchPosImage);
				}

				if (game.carManager.MainPlayer.handlingInfo.steer > 0) {
					GUI.DrawTexture (rightTouchRect, menuRenderer.touchPosImage);
				}
			}
		}

		this.updatePowerUp (GameData.firstPowerUp, firstPowerUpRect, menuRenderer.getPowerUpImage (GameData.firstPowerUp));
		this.updatePowerUp (GameData.secondPowerUp, secondPowerUpRect, menuRenderer.getPowerUpImage (GameData.secondPowerUp));
		this.updatePowerUp (GameData.thirdPowerUp, thirdPowerUpRect, menuRenderer.getPowerUpImage (GameData.thirdPowerUp));
	}

	public void getInput ()
	{
		if (GameData.IsAutoSteer == false) {
			if (ProfileManager.setttings.ControllerTilt == true) {
				this.getInputTilt ();
			} else {
				this.getInputTouch ();
			}
		}
	}

	void getInputTouch ()
	{
		if (Application.isEditor == true) {
			if (Input.GetMouseButtonDown (0)) {
				Vector2 mousePos = Input.mousePosition;
				mousePos.y = Screen.height - mousePos.y;	
				mousePos.Scale (GameData.SCALE);
					
				if (brakePosLeft.Contains (mousePos) || brakePosRight.Contains (mousePos)) {
					game.carManager.MainPlayer.useBrake (true);
						
				} else if (nitroPosLeft.Contains (mousePos) || nitroPosRight.Contains (mousePos)) {
					game.carManager.MainPlayer.useNitro (true);						
				} 

				if (leftTouchPos.Contains (mousePos)) {
					game.carManager.MainPlayer.steerLeft ();
					leftTouchRect.x = mousePos.x - 50;
					leftTouchRect.y = mousePos.y - 50;
							
				} else if (rightTouchPos.Contains (mousePos)) {
					game.carManager.MainPlayer.steerRight ();
					rightTouchRect.x = mousePos.x - 50;
					rightTouchRect.y = mousePos.y - 50;
							
				} else {
					game.carManager.MainPlayer.stopSteer ();
				}
			}		
				
			if (Input.GetMouseButtonUp (0)) {
				Vector2 mousePos = Input.mousePosition;
				mousePos.y = Screen.height - mousePos.y;
				mousePos.Scale (GameData.SCALE);	
					
				game.carManager.MainPlayer.useBrake (false);

				if (leftTouchPos.Contains (mousePos)) {
					game.carManager.MainPlayer.stopSteer ();

				} else if (rightTouchPos.Contains (mousePos)) {
					game.carManager.MainPlayer.stopSteer ();
				}
			}
		}
		
		if (Input.touchCount > 0) {
			foreach (Touch touch in Input.touches) {
				Vector2 touchPos = touch.position;
				touchPos.y = Screen.height - touchPos.y;								
				touchPos.Scale (GameData.SCALE);
				
				if (touch.phase == TouchPhase.Began) {
					if (brakePosLeft.Contains (touchPos) || brakePosRight.Contains (touchPos)) {
						game.carManager.MainPlayer.useBrake (true);
						
					} else if (nitroPosLeft.Contains (touchPos) || nitroPosRight.Contains (touchPos)) {
						game.carManager.MainPlayer.useNitro (true);						
					} 

					if (leftTouchPos.Contains (touchPos)) {
						game.carManager.MainPlayer.steerLeft ();	
						leftTouchRect.x = touchPos.x - 50;
						leftTouchRect.y = touchPos.y - 50;
							
					} else if (rightTouchPos.Contains (touchPos)) {
						game.carManager.MainPlayer.steerRight ();
						rightTouchRect.x = touchPos.x - 50;
						rightTouchRect.y = touchPos.y - 50;
							
					} 
					
				} else if (touch.phase == TouchPhase.Ended) {
					game.carManager.MainPlayer.useBrake (false);

					if (leftTouchPos.Contains (touchPos)) {
						game.carManager.MainPlayer.stopSteer ();

					} else if (rightTouchPos.Contains (touchPos)) {
						game.carManager.MainPlayer.stopSteer ();
					}

				} else if (touch.phase != TouchPhase.Canceled) {
					if (brakePosLeft.Contains (touchPos) || brakePosRight.Contains (touchPos)) {
						game.carManager.MainPlayer.useBrake (true);
						
					} else if (nitroPosLeft.Contains (touchPos) || nitroPosRight.Contains (touchPos)) {
						game.carManager.MainPlayer.useNitro (true);						
					} 
					
					if (leftTouchPos.Contains (touchPos)) {
						game.carManager.MainPlayer.steerLeft ();	
						leftTouchRect.x = touchPos.x - 50;
						leftTouchRect.y = touchPos.y - 50;
						
					} else if (rightTouchPos.Contains (touchPos)) {
						game.carManager.MainPlayer.steerRight ();
						rightTouchRect.x = touchPos.x - 50;
						rightTouchRect.y = touchPos.y - 50;
						
					}
				}
			}				
		}	
	}

	void getInputTilt ()
	{
		if (Application.isEditor == true) {
			if (Input.GetMouseButtonDown (0)) {
				Vector2 mousePos = Input.mousePosition;
				mousePos.y = Screen.height - mousePos.y;	
				mousePos.Scale (GameData.SCALE);
					
				if (brakeEventPos.Contains (mousePos)) {
					game.carManager.MainPlayer.useBrake (true);
						
				} else if (nitroEventPos.Contains (mousePos)) {
					game.carManager.MainPlayer.useNitro (true);						
				} 
			}		
				
			if (Input.GetMouseButtonUp (0)) {
				Vector2 mousePos = Input.mousePosition;
				mousePos.y = Screen.height - mousePos.y;
				mousePos.Scale (GameData.SCALE);	
					
				game.carManager.MainPlayer.useBrake (false);
			}
		}
		
		if (Input.touchCount > 0) {
			foreach (Touch touch in Input.touches) {
				Vector2 touchPos = touch.position;
				touchPos.y = Screen.height - touchPos.y;								
				touchPos.Scale (GameData.SCALE);
				
				if (touch.phase == TouchPhase.Began) {
					if (brakeEventPos.Contains (touchPos)) {
						game.carManager.MainPlayer.useBrake (true);
						
					} else if (nitroEventPos.Contains (touchPos)) {
						game.carManager.MainPlayer.useNitro (true);
					} 	

				} else if (touch.phase == TouchPhase.Ended) {
					game.carManager.MainPlayer.useBrake (false);

				} else if (touch.phase != TouchPhase.Canceled) {
					if (brakeEventPos.Contains (touchPos)) {
						game.carManager.MainPlayer.useBrake (true);
						
					} else if (nitroEventPos.Contains (touchPos)) {
						game.carManager.MainPlayer.useNitro (true);
					}
				}
			}
		}	
	}

	void updatePowerUp (BasePowerUp powerUp, Rect powerUpRect, Texture powerUpImage)
	{
		if (powerUp != null) {
			if (powerUp.powerState != BasePowerUp.POWER_STATE.DISABLE) {
				powerUpRect.height = powerUpRect.height * powerUp.getPercent ();
				GUI.BeginGroup (powerUpRect);
				
				if (GameData.isPowerUsing () == false) {
					if (GUI.Button (new Rect (0, 0, 50, 50), powerUpImage)) {
						if (Game.gameState == Game.GAME_STATE.RUNNING) {							
							menuRenderer.infoRenderer.lastPowerUpNotice = Time.timeSinceLevelLoad;

							switch (powerUp.getPowerUpType ()) {
							case BasePowerUp.POWER_UP_TYPE.ACCELERATION:
								menuRenderer.infoRenderer.powerUpNotice = "    Using acceleration rank " + (powerUp.PowerUpItemLevel + 1);
								break;

							case BasePowerUp.POWER_UP_TYPE.HANDLING:
								menuRenderer.infoRenderer.powerUpNotice = "        Using hanlding rank " + (powerUp.PowerUpItemLevel + 1);
								break; 

							case BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER:
								menuRenderer.infoRenderer.powerUpNotice = "Using nitro multiplier rank " + (powerUp.PowerUpItemLevel + 1);
								break;

							case BasePowerUp.POWER_UP_TYPE.NITRO_RATE:
								menuRenderer.infoRenderer.powerUpNotice = "      Using nitro rate rank " + (powerUp.PowerUpItemLevel + 1);
								break;

							case BasePowerUp.POWER_UP_TYPE.NITRO_TANK:
								menuRenderer.infoRenderer.powerUpNotice = "      Using nitro tank rank " + (powerUp.PowerUpItemLevel + 1);
								break;

							case BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT:
								menuRenderer.infoRenderer.powerUpNotice = "  Using police prevent rank " + (powerUp.PowerUpItemLevel + 1);
								break;

							default:
								break;
							}
							powerUp.usePowerUp (game.carManager.MainPlayer.carData);
						}						
					}
				} else {
					if (powerUp.powerState == BasePowerUp.POWER_STATE.NOT_ACTIVE) {
						GUI.contentColor = new Color (0.2f, 0.2f, 0.2f, 1);
						if (GUI.Button (new Rect (0, 0, 50, 50), powerUpImage)) {
						}
						GUI.contentColor = Color.white;

					} else {
						if (GUI.Button (new Rect (0, 0, 50, 50), powerUpImage)) {
						}
					}
				}
				powerUpRect.height = 50;
				
				GUI.EndGroup ();
			}
		}
	}

	void onPauseClick ()
	{
		game.soundManager.playClick ();
		if (Game.gameState == Game.GAME_STATE.RUNNING) {
			game.pauseGame ();

		} else if (Game.gameState == Game.GAME_STATE.PAUSE) {
			game.resumeGame ();
		}
	}

	public void changeControl ()
	{					
		if (ProfileManager.setttings.ControllerTilt == true) {
			this.brakePosLeft.x = 10;
			this.brakePosLeft.y = 330;

			this.nitroPosLeft.x = 650;
			this.nitroPosLeft.y = 330;
		} else {
			this.brakePosLeft.x = 120;
			this.brakePosLeft.y = 330;
			
			this.nitroPosLeft.x = 0;
			this.nitroPosLeft.y = 330;
		}
	}
}