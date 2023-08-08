using UnityEngine;
using System.Collections;

public class AchievementMenu : BaseHeaderMenu
{
		//
		public AudioSource audioSource;
		public AudioSource click;

		//
		public dfButton[] achievementTab;
		public dfTabContainer tabContainer;

		// 
		public AchievementRow[] carsAchievement;
		public AchievementRow[] challengesAchievement;
		public AchievementRow[] skillsAchievement;
		public AchievementRow[] starsAchievement;
		public TitleColumn[] titleList;

		// 
		public dfTweenFloat[] carsTween;
		public dfTweenFloat[] challengesTween;
		public dfTweenFloat[] skillsTween;
		public dfTweenFloat[] starsTween;

		//
		public dfLabel[] newAchievement;
		public dfPanel[] newAchievementPanel;

		//
		public CarAchivement carAchivement;
		public ChallengeAchivement challengeAchivement;
		public SkillAchivement skillAchivement;
		public StarAchivement starAchivement;

		//
		public dfScrollPanel titleAchivement;

		//
		public dfSprite upSprite;
		public dfSprite downSprite;
		public dfLabel titleTip;

		//
		int i;

		void Start ()
		{
				ProfileManager.init ();

				tabContainer.SelectedIndex = 0;
				achievementTab [0].IsEnabled = false;

				carAchivement = new CarAchivement (carsAchievement);
				carAchivement.updateCarsAchievement ();

				challengeAchivement = new ChallengeAchivement (challengesAchievement);
				challengeAchivement.updateChallengesAchievement ();

				skillAchivement = new SkillAchivement (skillsAchievement);
				skillAchivement.updateSkillsAchievement ();

				starAchivement = new StarAchivement (starsAchievement);
				starAchivement.updateStarsAchievement ();

				for (i=0; i<carsTween.Length; i++) {
						carsTween [i].Play ();
				}

				audioSource.volume = ProfileManager.setttings.MusicVolume / 100f;
				audioSource.Play ();

				click.volume = ProfileManager.setttings.SoundVolume / 100f;

				int titleID = RewardData.getTitleID (ProfileManager.userProfile.Score);

				for (i=0; i<titleID; i++) {
						titleList [i].frame.IsVisible = false;
						titleList [i].lightSprite.IsVisible = false;
						titleList [i].titleIcon.IsEnabled = true;
						titleList [i].description.Color = new Color32 (255, 108, 0, 1);
				}

				titleList [titleID].frame.IsVisible = true;
				titleList [titleID].lightSprite.IsVisible = true;
				titleList [titleID].titleIcon.IsEnabled = true;
				titleList [titleID].description.Color = new Color32 (255, 108, 0, 1);
		
				for (i=titleID+1; i<titleList.Length; i++) {
						titleList [i].frame.IsVisible = false;
						titleList [i].lightSprite.IsVisible = false;
						titleList [i].titleIcon.IsEnabled = false;
						titleList [i].description.Color = Color.red;
				}

				if (UserInfoScripts.isLoadingTitle) {
						changeToTitleTab ();
						UserInfoScripts.isLoadingTitle = false;
				} else {
						changeToCarTab ();
						UserInfoScripts.isLoadingTitle = false;
				}
		}

		void Update ()
		{
				if (Input.GetKeyUp (KeyCode.Escape)) {
						AutoFade.LoadLevel ("MainMenu");

				} else {
						this.updateInfo ();

						carAchivement.updateNumberAchievement ();
						challengeAchivement.updateNumberAchievement ();
						skillAchivement.updateNumberAchievement ();
						starAchivement.updateNumberAchievement ();

						if (carAchivement.numberNewCarAchivement > 0) {
								newAchievement [0].Text = carAchivement.numberNewCarAchivement.ToString ();
								newAchievementPanel [0].IsVisible = true;
						} else {
								newAchievementPanel [0].IsVisible = false;
						}
			
						if (challengeAchivement.numberNewChallengeAchivement > 0) {
								newAchievement [1].Text = challengeAchivement.numberNewChallengeAchivement.ToString ();
								newAchievementPanel [1].IsVisible = true;
						} else {
								newAchievementPanel [1].IsVisible = false;
						}
			
						if (skillAchivement.numberNewSkillAchivement > 0) {
								newAchievement [2].Text = skillAchivement.numberNewSkillAchivement.ToString ();
								newAchievementPanel [2].IsVisible = true;
						} else {
								newAchievementPanel [2].IsVisible = false;
						}
			
						if (starAchivement.numberNewStarAchivement > 0) {
								newAchievement [3].Text = starAchivement.numberNewStarAchivement.ToString ();
								newAchievementPanel [3].IsVisible = true;
						} else {
								newAchievementPanel [3].IsVisible = false;
						}
				}
		}

		public void back ()
		{
				click.Play ();
				AutoFade.LoadLevel ("MainMenu");
		}

		void unfocusAll ()
		{
				for (i=0; i<achievementTab.Length; i++) {
						achievementTab [i].IsEnabled = true;
				}
		}

		public void changeToCarTab ()
		{
				click.Play ();

				this.unfocusAll ();
				tabContainer.SelectedIndex = 0;
				achievementTab [0].IsEnabled = false;

				for (i=0; i<carsTween.Length; i++) {
						if (carsTween [i].IsPlaying == false) {
								carsTween [i].Play ();
						}
				}

				upSprite.IsVisible = true;
				downSprite.IsVisible = true;
				titleTip.IsVisible = false;
		}

		public void changeToChallengesTab ()
		{
				click.Play ();

				this.unfocusAll ();
				tabContainer.SelectedIndex = 1;
				achievementTab [1].IsEnabled = false;
		
				for (i=0; i<challengesTween.Length; i++) {
						if (challengesTween [i].IsPlaying == false) {
								challengesTween [i].Play ();
						}
				}

				upSprite.IsVisible = true;
				downSprite.IsVisible = true;
				titleTip.IsVisible = false;
		}

		public void changeToSkillsTab ()
		{
				click.Play ();

				this.unfocusAll ();
				tabContainer.SelectedIndex = 2;
				achievementTab [2].IsEnabled = false;
		
				for (i=0; i<skillsTween.Length; i++) {
						if (skillsTween [i].IsPlaying == false) {
								skillsTween [i].Play ();
						}
				}

				upSprite.IsVisible = true;
				downSprite.IsVisible = true;
				titleTip.IsVisible = false;
		}

		public void changeToStarsTab ()
		{
				click.Play ();

				this.unfocusAll ();
				tabContainer.SelectedIndex = 3;
				achievementTab [3].IsEnabled = false;

				for (i=0; i<starsTween.Length; i++) {
						if (starsTween [i].IsPlaying == false) {
								starsTween [i].Play ();
						}
				}

				upSprite.IsVisible = true;
				downSprite.IsVisible = true;
				titleTip.IsVisible = false;
		}

		public void changeToTitleTab ()
		{
				click.Play ();
		
				this.unfocusAll ();
				tabContainer.SelectedIndex = 4;
				achievementTab [4].IsEnabled = false;

				upSprite.IsVisible = false;
				downSprite.IsVisible = false;
				titleTip.IsVisible = true;
		}
	
		public static int getNumberAchivement ()
		{
				int numberNewAchivement = 0;
		
				int numberCar = ProfileManager.userProfile.getNumberCar ();	
				int numberFullyUpgradeCars = ProfileManager.userProfile.getNumberFullyUpgradeCars ();
		
				if (numberCar > 1) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 0) == false) {
								numberNewAchivement++;
						}
				}
		
				if (numberCar >= 5) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 1) == false) {
								numberNewAchivement++;
						}
				}
		
				if (numberCar >= 10) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 2) == false) {
								numberNewAchivement++;
						}
				}
		
				if (numberCar >= 15) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 3) == false) {
								numberNewAchivement++;
						}
				} 
		
				//--------------------------------------------------------------------------------	
				if (ProfileManager.achievementProfile.NumberFacebookShare >= 1) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 4) == false) {
								numberNewAchivement++;
						}
				}
		
				if (ProfileManager.achievementProfile.NumberFacebookShare >= 3) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 5) == false) {
								numberNewAchivement++;
						}
				} 
		
				//--------------------------------------------------------------------------------	
				if (numberFullyUpgradeCars >= 1) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 6) == false) {
								numberNewAchivement++;
						}
				}
		
				if (numberFullyUpgradeCars >= 5) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 7) == false) {
								numberNewAchivement++;
						}
				}
		
				if (numberFullyUpgradeCars >= 10) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 8) == false) {
								numberNewAchivement++;
						}
				} 
		
				if (numberFullyUpgradeCars >= 15) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 9) == false) {
								numberNewAchivement++;
						}
				} 
		
		
				if (ProfileManager.achievementProfile.NumberQuickRaceWin >= 1) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 0) == false) {
								numberNewAchivement++;
						}
				} 
		
				if (ProfileManager.achievementProfile.NumberQuickRaceWin >= 10) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 1) == false) {
								numberNewAchivement++;
						}
				} 
		
				if (ProfileManager.achievementProfile.NumberQuickRaceWin >= 50) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 2) == false) {
								numberNewAchivement++;
						}
				} 
		
				if (ProfileManager.achievementProfile.NumberQuickRaceWin >= 100) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 3) == false) {
								numberNewAchivement++;
						}
				}
		
				if (ProfileManager.achievementProfile.NumberQuickRaceWin >= 150) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 4) == false) {
								numberNewAchivement++;
						}
				} 
		
				//--------------------------------------------------------------------------------
		
				int playedMaps = ProfileManager.userProfile.getPlayedMapsBySeason (0);
				if (playedMaps >= 10) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 5) == false) {
								numberNewAchivement++;
						}
				} 
		
				playedMaps = ProfileManager.userProfile.getPlayedMapsBySeason (1);
				if (playedMaps >= 12) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 6) == false) {
								numberNewAchivement++;
						}
				}
		
				playedMaps = ProfileManager.userProfile.getPlayedMapsBySeason (2);
				if (playedMaps >= 14) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 7) == false) {
								numberNewAchivement++;
						}
				}
		
				playedMaps = ProfileManager.userProfile.getPlayedMapsBySeason (3);
				if (playedMaps >= 16) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 8) == false) {
								numberNewAchivement++;
						}
				}
		
				playedMaps = ProfileManager.userProfile.getPlayedMapsBySeason (4);
				if (playedMaps >= 18) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 9) == false) {
								numberNewAchivement++;
						}
				}
		
				playedMaps = ProfileManager.userProfile.getPlayedMapsBySeason (5);
				if (playedMaps >= 18) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 10) == false) {
								numberNewAchivement++;
						}
				}
		
				playedMaps = ProfileManager.userProfile.getPlayedMapsBySeason (6);
				if (playedMaps >= 18) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 11) == false) {
								numberNewAchivement++;
						}
				}		
		
				playedMaps = ProfileManager.userProfile.getPlayedMapsBySeason (7);
				if (playedMaps >= 18) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 12) == false) {
								numberNewAchivement++;
						}
				}
		
				if (ProfileManager.achievementProfile.MaxSpeedReach * 3.6f >= 300) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 0) == false) {
								numberNewAchivement++;
						}
				}
		
				if (ProfileManager.achievementProfile.MaxSpeedReach * 3.6f >= 400) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 1) == false) {
								numberNewAchivement++;
						}
				}
		
				if (ProfileManager.achievementProfile.MaxSpeedReach * 3.6f >= 500) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 2) == false) {
								numberNewAchivement++;
						}
				}
		
				//--------------------------------------------------------------------------------
				if (ProfileManager.achievementProfile.NumberDestroyedObstacles >= 200) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 3) == false) {
								numberNewAchivement++;
						}
				}
		
				if (ProfileManager.achievementProfile.NumberDestroyedObstacles >= 300) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 4) == false) {
								numberNewAchivement++;
						}
				}
		
				if (ProfileManager.achievementProfile.NumberDestroyedObstacles >= 500) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 5) == false) {
								numberNewAchivement++;
						}
				}
		
				//--------------------------------------------------------------------------------
				if (ProfileManager.achievementProfile.DollarEarned >= 5000) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 6) == false) {
								numberNewAchivement++;
						}
				}
		
				if (ProfileManager.achievementProfile.DollarEarned >= 10000) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 7) == false) {
								numberNewAchivement++;
						}
				}
		
				if (ProfileManager.achievementProfile.DollarEarned >= 15000) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 8) == false) {
								numberNewAchivement++;
						}
				}
		
				//--------------------------------------------------------------------------------
				if (ProfileManager.achievementProfile.DriftDuration >= 480) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 9) == false) {
								numberNewAchivement++;
						}
				}
		
				if (ProfileManager.achievementProfile.DriftDuration >= 600) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 10) == false) {
								numberNewAchivement++;
						}
				}
		
				if (ProfileManager.achievementProfile.DriftDuration >= 900) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 11) == false) {
								numberNewAchivement++;
						}
				}
		
				if (ProfileManager.achievementProfile.DriftDuration >= 1200) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 12) == false) {
								numberNewAchivement++;
						}
				}
		
				//--------------------------------------------------------------------------------
				if (ProfileManager.achievementProfile.FlyDuration >= 240) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 13) == false) {
								numberNewAchivement++;
						}
				} 
		
				if (ProfileManager.achievementProfile.FlyDuration >= 420) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 14) == false) {
								numberNewAchivement++;
						}
				}
		
				if (ProfileManager.achievementProfile.FlyDuration >= 540) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 15) == false) {
								numberNewAchivement++;
						}
				}
		
				if (ProfileManager.achievementProfile.FlyDuration >= 660) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 16) == false) {
								numberNewAchivement++;
						}
				}
		
				int numberStar = ProfileManager.userProfile.getNumberStar ();
		
				if (numberStar >= 1) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 0) == false) {
								numberNewAchivement++;
						}
				}
		
				if (numberStar >= 5) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 1) == false) {
								numberNewAchivement++;
						}
				}
		
				if (numberStar >= 10) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 2) == false) {
								numberNewAchivement++;
						}
				}
		
				if (numberStar >= 50) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 3) == false) {
								numberNewAchivement++;
						}
				}
		
				if (numberStar >= 100) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 4) == false) {
								numberNewAchivement++;
						}
				}
		
				if (numberStar >= 150) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 5) == false) {
								numberNewAchivement++;
						}
				}
		
				if (numberStar >= 200) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 6) == false) {
								numberNewAchivement++;
						}
				}
		
				if (numberStar >= 250) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 7) == false) {
								numberNewAchivement++;
						}
				}
		
				if (numberStar >= 300) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 8) == false) {
								numberNewAchivement++;
						}
				}
		
				if (numberStar >= 350) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 9) == false) {
								numberNewAchivement++;
						}
				}
		
				if (numberStar >= 400) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 10) == false) {
								numberNewAchivement++;
						}
				}
		
				if (numberStar >= 450) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 11) == false) {
								numberNewAchivement++;
						}
				}
		
				if (numberStar >= 500) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 12) == false) {
								numberNewAchivement++;
						}
				}
		
				if (numberStar >= 550) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 13) == false) {
								numberNewAchivement++;
						}
				}
		
				if (numberStar >= 600) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 14) == false) {
								numberNewAchivement++;
						}
				}
		
				if (numberStar >= 620) {
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 15) == false) {
								numberNewAchivement++;
						}
				}
		
				return numberNewAchivement;
		}
}