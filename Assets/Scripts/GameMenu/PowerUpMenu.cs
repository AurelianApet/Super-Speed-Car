using UnityEngine;
using System.Collections;

public class PowerUpMenu : BaseHeaderMenu
{
		public dfButton[] powerUp;
		public dfButton[] powerUpButton;
		public dfLabel[] powerUpMoneyLabel;

		//
		public dfSprite rightButton;
		public dfSprite leftButton;

		//
		public AudioSource audioSource;
		public AudioSource click;

		//
		public dfPanel[] powerUpPanel;
		public dfScrollPanel scrollPanel;
		public dfTweenVector2 scrollTween;

		void Start ()
		{
				ProfileManager.init ();
				checkPowerUp ();

				if (GameData.IsDoubleNitro == true) {
						powerUp [0].IsEnabled = false;
						powerUpButton [0].IsEnabled = false;
						powerUpMoneyLabel [0].IsVisible = false;
				}

				if (GameData.IsDoubleReward == true) {
						powerUp [1].IsEnabled = false;
						powerUpButton [1].IsEnabled = false;
						powerUpMoneyLabel [1].IsVisible = false;
				}

				if (GameData.IsNitroFull == true) {
						powerUp [2].IsEnabled = false;
						powerUpButton [2].IsEnabled = false;
						powerUpMoneyLabel [2].IsVisible = false;
				}

				if (GameData.IsTuningKit == true) {
						powerUp [3].IsEnabled = false;
						powerUpButton [3].IsEnabled = false;
						powerUpMoneyLabel [3].IsVisible = false;
				}

				if (GameData.IsStartFirst == true) {
						powerUp [4].IsEnabled = false;
						powerUpButton [4].IsEnabled = false;
						powerUpMoneyLabel [4].IsVisible = false;
				}
		
				if (GameData.IsAutoSteer == true) {
						powerUp [5].IsEnabled = false;
						powerUpButton [5].IsEnabled = false;
						powerUpMoneyLabel [5].IsVisible = false;
				}
		
				if (GameData.IsProtectedFromCrash == true) {
						powerUp [6].IsEnabled = false;
						powerUpButton [6].IsEnabled = false;
						powerUpMoneyLabel [6].IsVisible = false;
				}
		
				if (GameData.IsDoubleScore == true) {
						powerUp [7].IsEnabled = false;
						powerUpButton [7].IsEnabled = false;
						powerUpMoneyLabel [7].IsVisible = false;
				}

				audioSource.volume = ProfileManager.setttings.MusicVolume / 100f;
				audioSource.Play ();

				click.volume = ProfileManager.setttings.SoundVolume / 100f;
		
				if (GameData.isSinglePlayer == false) {
						rightButton.IsVisible = false;
						leftButton.IsVisible = false;
						powerUpPanel [1].IsVisible = false;
				}

				InternetGameMenu.fakePlayerName.Clear ();
		}

		void Update ()
		{
				if (Input.GetKeyUp (KeyCode.Escape)) {
						LevelLoader.isLoading = true;
						AutoFade.LoadLevel ("Load");
				} else {
						this.updateInfo ();
				}
		}

		public void leftButtonClick ()
		{
				if (scrollPanel.ScrollPosition.x > 100) {
						scrollTween.StartValue = scrollPanel.ScrollPosition;
						scrollTween.EndValue = new Vector2 (0, 0);
						scrollTween.Play ();
				} else {
						scrollTween.StartValue = scrollPanel.ScrollPosition;
						scrollTween.EndValue = new Vector2 (760, 0);
						scrollTween.Play ();
				}
		}

		public void rightButtonClick ()
		{
				if (scrollPanel.ScrollPosition.x > 660) {
						scrollTween.StartValue = scrollPanel.ScrollPosition;
						scrollTween.EndValue = new Vector2 (0, 0);
						scrollTween.Play ();
				} else {
						scrollTween.StartValue = scrollPanel.ScrollPosition;
						scrollTween.EndValue = new Vector2 (760, 0);
						scrollTween.Play ();
				}
		}

		public void selectDoubleNitro ()
		{
				click.Play ();
				if (ProfileManager.userProfile.Money >= 6000) {
						powerUp [0].IsEnabled = false;
						powerUpButton [0].IsEnabled = false;
						powerUpMoneyLabel [0].IsVisible = false;

						GameData.IsDoubleNitro = true;

						ProfileManager.userProfile.saveBoughtPowerUp (0);
						ProfileManager.userProfile.Money -= 6000;
						PlayerPrefs.Save ();
				} else {
						this.addMoney ();
				}
		}
	
		public void selectDoubleReward ()
		{
				click.Play ();
				if (ProfileManager.userProfile.Money >= 3000) {
						powerUp [1].IsEnabled = false;
						powerUpButton [1].IsEnabled = false;
						powerUpMoneyLabel [1].IsVisible = false;

						GameData.IsDoubleReward = true;

						ProfileManager.userProfile.saveBoughtPowerUp (1);
						ProfileManager.userProfile.Money -= 3000;
						PlayerPrefs.Save ();
				} else {
						this.addMoney ();
				}
		}
	
		public void selectNitroFull ()
		{
				click.Play ();
				if (ProfileManager.userProfile.Money >= 5000) {
						powerUp [2].IsEnabled = false;
						powerUpButton [2].IsEnabled = false;
						powerUpMoneyLabel [2].IsVisible = false;

						GameData.IsNitroFull = true;

						ProfileManager.userProfile.saveBoughtPowerUp (2);
						ProfileManager.userProfile.Money -= 5000;
						PlayerPrefs.Save ();
				} else {
						this.addMoney ();
				}
		}

		public void selectTuningKit ()
		{
				click.Play ();
				if (ProfileManager.userProfile.Money >= 10000) {
						powerUp [3].IsEnabled = false;
						powerUpButton [3].IsEnabled = false;
						powerUpMoneyLabel [3].IsVisible = false;

						GameData.IsTuningKit = true;

						ProfileManager.userProfile.saveBoughtPowerUp (3);
						ProfileManager.userProfile.Money -= 10000;
						PlayerPrefs.Save ();
				} else {
						this.addMoney ();
				}
		}

		public void selectStartFirst ()
		{
				click.Play ();
				if (ProfileManager.userProfile.Money >= 5000) {
						powerUp [4].IsEnabled = false;
						powerUpButton [4].IsEnabled = false;
						powerUpMoneyLabel [4].IsVisible = false;
			
						GameData.IsStartFirst = true;
			
						ProfileManager.userProfile.saveBoughtPowerUp (4);
						ProfileManager.userProfile.Money -= 5000;
						PlayerPrefs.Save ();
				} else {
						this.addMoney ();
				}
		}
	
		public void selectAutoSteer ()
		{
				click.Play ();
				if (ProfileManager.userProfile.Money >= 30000) {
						powerUp [5].IsEnabled = false;
						powerUpButton [5].IsEnabled = false;
						powerUpMoneyLabel [5].IsVisible = false;
			
						GameData.IsAutoSteer = true;
			
						ProfileManager.userProfile.saveBoughtPowerUp (5);
						ProfileManager.userProfile.Money -= 30000;
						PlayerPrefs.Save ();
				} else {
						this.addMoney ();
				}
		}
	
		public void selectProtectFromCrash ()
		{
				click.Play ();
				if (ProfileManager.userProfile.Money >= 10000) {
						powerUp [6].IsEnabled = false;
						powerUpButton [6].IsEnabled = false;
						powerUpMoneyLabel [6].IsVisible = false;
			
						GameData.IsProtectedFromCrash = true;
			
						ProfileManager.userProfile.saveBoughtPowerUp (6);
						ProfileManager.userProfile.Money -= 10000;
						PlayerPrefs.Save ();
				} else {
						this.addMoney ();
				}
		}
	
		public void selectDoubleScore ()
		{
				click.Play ();
				if (ProfileManager.userProfile.Money >= 10000) {
						powerUp [7].IsEnabled = false;
						powerUpButton [7].IsEnabled = false;
						powerUpMoneyLabel [7].IsVisible = false;
			
						GameData.IsDoubleScore = true;
			
						ProfileManager.userProfile.saveBoughtPowerUp (7);
						ProfileManager.userProfile.Money -= 10000;
						PlayerPrefs.Save ();
				} else {
						this.addMoney ();
				}
		}

		public void play ()
		{
				click.Play ();

				SceneLoader.scene = GameData.getMapPath (GameData.selectedMap);
				Application.LoadLevel ("Loading");
		}

		public void back ()
		{
				click.Play ();
				LevelLoader.isLoading = true;
				AutoFade.LoadLevel ("Load");
		}

		public static void checkPowerUp ()
		{
				if (ProfileManager.userProfile.isPowerUpBought (0) == true) {
						GameData.IsDoubleNitro = true;
				}

				if (ProfileManager.userProfile.isPowerUpBought (1) == true) {
						GameData.IsDoubleReward = true;
				}

				if (ProfileManager.userProfile.isPowerUpBought (2) == true) {
						GameData.IsNitroFull = true;
				}

				if (ProfileManager.userProfile.isPowerUpBought (3) == true) {
						GameData.IsTuningKit = true;
				}

				if (ProfileManager.userProfile.isPowerUpBought (4) == true) {
						GameData.IsStartFirst = true;
				}
		
				if (ProfileManager.userProfile.isPowerUpBought (5) == true) {
						GameData.IsAutoSteer = true;
				}
		
				if (ProfileManager.userProfile.isPowerUpBought (6) == true) {
						GameData.IsProtectedFromCrash = true;
				}
		
				if (ProfileManager.userProfile.isPowerUpBought (7) == true) {
						GameData.IsDoubleScore = true;
				}
		}
}