using UnityEngine;
using System.Collections;

public class MenuRenderer : MonoBehaviour
{
		public Ads ads;
		private bool isShown;
		public Font numberFont;
		public Font textFont;

		//
		public Texture miniMap;
		public Texture enemyIndicator;
		public Texture playerIndicator;
		public Texture policeIndicator;

		//
		public Texture brakeUp;
		public Texture brakeDown;
		public Texture nitroUp;
		public Texture nitroDown;

		//
		public Texture pauseUp;
		public Texture pauseDown;

		//
		public Texture topMenu;
		public Texture nitroBar;
		public Texture touchPosImage;
		public Texture minimapBackground;

		//
		public Texture settingsFrame;
		public Texture header;
		public GUISkin skin;
		public Texture low;
		public Texture medium;
		public Texture high;
		public Texture onButton;
		public Texture offButton;
		public Texture touchOn;
		public Texture touchOff;
		public Texture tiltOn;
		public Texture tiltOff;		

		//
		public Texture bar;

		//
		public Texture mainMenuUp;
		public Texture mainMenuDown;
		public Texture restartUp;
		public Texture restartDown;
		public Texture nextUp;
		public Texture nextDown;

		//
		public Texture preGameOverImage;
		public Texture timeTrialFrame;
		public Texture gameOverFrame;
		public Texture winGameImage;
		public Texture loseGameImage;
		public Texture starImage;

		//
		public Texture resumeUp;
		public Texture resumeDown;
		public Texture retryUp;
		public Texture retryDown;
		public Texture quitRaceUp;
		public Texture quitRaceDown;

		//
		public Texture settingNext;
		public Texture settingNextUp;
		public Texture settingDown;
		public Texture settingDownUp;

		//
		public Texture brokenGlass;
		public Texture flareEffect;

		//
		public Texture[] powerUpItem;

		//
		public MinimapRenderer minimapRenderer;
		public PlayMenuRenderer playMenuRenderer;
		public InfoRenderer infoRenderer;
		public Effect2DRenderer effect2DRenderer;

		//
		public GameOverMenu gameOverMenu;
		public PauseMenu pauseMenu;
		public MultiplayerListMenu multiplayerListMenu;
		public PreGameOverMenu preGameOverMenu;

		//
		Game game;
		bool isNextGUI = false;

		public bool IsNextGUI {
				get {
						return isNextGUI;
				}
				set {
						isNextGUI = value;
				}
		}

		//
		public float lastChangeToPreGameOver;

		void Start ()
		{
				ads.RequestBanner ();
				ads.HideBanner ();
				isShown = false;
				requestAd ();

				game = GameObject.FindObjectOfType<Game> ();

				this.minimapRenderer = new MinimapRenderer (this, game);
				this.playMenuRenderer = new PlayMenuRenderer (this, game);
				this.infoRenderer = new InfoRenderer (this, game);
				this.effect2DRenderer = new Effect2DRenderer (this, game);

				this.gameOverMenu = new GameOverMenu (this, game);
				this.pauseMenu = new PauseMenu (this, game);
				this.multiplayerListMenu = new MultiplayerListMenu (this, game);
				this.preGameOverMenu = new PreGameOverMenu (this, game);

				this.useGUILayout = false;
		}

		void OnGUI ()
		{
				GUI.matrix = GameData.MATRIX_SCALING;

				switch (Game.gameState) {
				case Game.GAME_STATE.INIT:
						this.multiplayerListMenu.render ();
						break;
			
				case Game.GAME_STATE.START:
						this.infoRenderer.render ();
						this.minimapRenderer.render ();
						this.playMenuRenderer.render ();

						this.infoRenderer.drawCountDown ();
						break;
			
				case Game.GAME_STATE.RUNNING:
						this.effect2DRenderer.render ();

						this.infoRenderer.render ();
						this.minimapRenderer.render ();
						this.playMenuRenderer.render ();
						break;
			
				case Game.GAME_STATE.PAUSE:
						this.pauseMenu.render ();
						break;

				case Game.GAME_STATE.PRE_GAME_OVER:	
						if (Time.timeSinceLevelLoad - lastChangeToPreGameOver > 0.5f) {
								if (isNextGUI == false) {
										this.preGameOverMenu.render ();
								} else {
										this.gameOverMenu.render ();
								}
						}
						if(!isShown){
							ads.ShowBanner();
							ShowAds();
							isShown = true;
						}
						break;

				case Game.GAME_STATE.WIN:
						if (isNextGUI == false) {
								this.preGameOverMenu.render ();
						} else {
								this.gameOverMenu.render ();
						}
						break;
			
				case Game.GAME_STATE.LOSE:
						if (isNextGUI == false) {
								this.preGameOverMenu.render ();
						} else {
								this.gameOverMenu.render ();
						}
						break;
			
				default:
						break;
				}
		}

		void Update ()
		{
				if (Game.gameState == Game.GAME_STATE.RUNNING) {
						this.playMenuRenderer.getInput ();
				}
		}

		public void setNitroFlareEffect (float leftX, float leftY, float rightX, float rightY)
		{
				effect2DRenderer.setNitroFlareEffect (leftX, leftY, rightX, rightY);
		}

		public void activateBrokenGlassEffect ()
		{
				effect2DRenderer.activateBrokenGlassEffect ();

				if (ProfileManager.setttings.IsVibrate == true) {
						Handheld.Vibrate ();
				}
		}

		public void changeControl ()
		{
				playMenuRenderer.changeControl ();
		}

		public void setLastDrift ()
		{
				infoRenderer.setLastDrift ();
		}

		public void setLastFly ()
		{
				infoRenderer.setLastFly ();
		}

		public Texture getPowerUpImage (BasePowerUp powerUp)
		{
				if (powerUp != null) {
						switch (powerUp.getPowerUpType ()) {
						case BasePowerUp.POWER_UP_TYPE.ACCELERATION:
								switch (powerUp.PowerUpItemLevel) {
								case 0:
										return powerUpItem [0];

								case 1:
										return powerUpItem [1];

								case 2:
										return powerUpItem [2];

								case 3:
										return powerUpItem [3];

								case 4:
										return powerUpItem [4];

								default:
										return powerUpItem [0];
								}

						case BasePowerUp.POWER_UP_TYPE.HANDLING:
								switch (powerUp.PowerUpItemLevel) {
								case 0:
										return powerUpItem [5];
				
								case 1:
										return powerUpItem [6];
				
								case 2:
										return powerUpItem [7];
				
								case 3:
										return powerUpItem [8];
				
								case 4:
										return powerUpItem [9];
				
								default:
										return powerUpItem [0];
								}

						case BasePowerUp.POWER_UP_TYPE.NITRO_MULTIPLIER:
								switch (powerUp.PowerUpItemLevel) {
								case 0:
										return powerUpItem [10];
				
								case 1:
										return powerUpItem [11];
				
								case 2:
										return powerUpItem [12];
				
								case 3:
										return powerUpItem [13];
				
								case 4:
										return powerUpItem [14];
				
								default:
										return powerUpItem [0];
								}

						case BasePowerUp.POWER_UP_TYPE.NITRO_RATE:
								switch (powerUp.PowerUpItemLevel) {
								case 0:
										return powerUpItem [15];
				
								case 1:
										return powerUpItem [16];
				
								case 2:
										return powerUpItem [17];
				
								case 3:
										return powerUpItem [18];
				
								case 4:
										return powerUpItem [19];
				
								default:
										return powerUpItem [0];
								}

						case BasePowerUp.POWER_UP_TYPE.NITRO_TANK:
								switch (powerUp.PowerUpItemLevel) {
								case 0:
										return powerUpItem [20];
				
								case 1:
										return powerUpItem [21];
				
								case 2:
										return powerUpItem [22];
				
								case 3:
										return powerUpItem [23];
				
								case 4:
										return powerUpItem [24];
				
								default:
										return powerUpItem [0];
								}

						case BasePowerUp.POWER_UP_TYPE.POLICE_PREVENT:
								switch (powerUp.PowerUpItemLevel) {
								case 0:
										return powerUpItem [25];
				
								case 1:
										return powerUpItem [26];
				
								case 2:
										return powerUpItem [27];
				
								case 3:
										return powerUpItem [28];
				
								case 4:
										return powerUpItem [29];
				
								default:
										return powerUpItem [0];
								}

						default:
								return powerUpItem [0];
						}
				} else {
						return powerUpItem [0];
				}
		}

	public void ShowAds()
	{
		int count = PlayerPrefs.GetInt ("Adshow",1);
//		string Company = PlayerPrefs.GetString ("Company", "Admob");
		count++;
		
		if (count % 2 == 0) {
			ads.ShowInterstitial ();
			count = 0;
//			if (Company == "Admob") {
//				PlayerPrefs.SetString ("Company", "Chartboost");
//				ads.ShowInterstitial ();
//			} else {
//				PlayerPrefs.SetString ("Company", "Admob");
//				ads.ShowChartboost ();
//			}
		}
		PlayerPrefs.SetInt ("Adshow",count);
		PlayerPrefs.Save ();
		
	}
	
	public void requestAd(){
		int init = PlayerPrefs.GetInt ("Adshow",1);
		string Company = PlayerPrefs.GetString ("Company", "Admob");
		
		if (init % 2 == 1) {
			ads.RequestInterstitial ();
//			if (Company == "Admob") {
//				ads.RequestInterstitial ();
//			} else {
//				ads.RequestChartboost ();
//			}
		}
	}

}