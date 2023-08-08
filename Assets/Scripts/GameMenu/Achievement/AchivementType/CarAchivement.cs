using UnityEngine;
using System.Collections;

public class CarAchivement
{
		public AchievementRow[] carsAchievement;
		public int numberNewCarAchivement;

		public CarAchivement (AchievementRow[] achivement)
		{
				this.carsAchievement = achivement;
		}

		public void updateCarsAchievement ()
		{
				int numberCar = ProfileManager.userProfile.getNumberCar ();	
				int numberFullyUpgradeCars = ProfileManager.userProfile.getNumberFullyUpgradeCars ();
		
				if (numberCar > 1) {
						carsAchievement [0].progressIndicator.FillAmount = 1;
						carsAchievement [0].progressLabel.Text = "1/1";
						carsAchievement [0].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 0);
				} else {
						carsAchievement [0].progressIndicator.FillAmount = 0;
						carsAchievement [0].progressLabel.Text = "0/1";
						carsAchievement [0].receiveReward.IsVisible = false;
				}
		
				if (numberCar >= 5) {			
						carsAchievement [1].progressIndicator.FillAmount = 1;
						carsAchievement [1].progressLabel.Text = "5/5";
						carsAchievement [1].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 1);
				} else {	
						carsAchievement [1].progressIndicator.FillAmount = numberCar / 5f;
						carsAchievement [1].progressLabel.Text = numberCar + "/5";
						carsAchievement [1].receiveReward.IsVisible = false;
				}
		
				if (numberCar >= 10) {
						carsAchievement [2].progressIndicator.FillAmount = 1;
						carsAchievement [2].progressLabel.Text = "10/10";
						carsAchievement [2].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 2);
				} else {
						carsAchievement [2].progressIndicator.FillAmount = numberCar / 10f;
						carsAchievement [2].progressLabel.Text = numberCar + "/10";
						carsAchievement [2].receiveReward.IsVisible = false;
				}
		
				if (numberCar >= 15) {
						carsAchievement [3].progressIndicator.FillAmount = 1;
						carsAchievement [3].progressLabel.Text = "15/15";
						carsAchievement [3].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 3);
				} else {
						carsAchievement [3].progressIndicator.FillAmount = numberCar / 15f;
						carsAchievement [3].progressLabel.Text = numberCar + "/15";
						carsAchievement [3].receiveReward.IsVisible = false;
				}
		
				//--------------------------------------------------------------------------------	
				if (ProfileManager.achievementProfile.NumberFacebookShare >= 1) {
						carsAchievement [4].progressIndicator.FillAmount = 1;
						carsAchievement [4].progressLabel.Text = "1/1";
						carsAchievement [4].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 4);	
				} else {
						carsAchievement [4].progressIndicator.FillAmount = 0;
						carsAchievement [4].progressLabel.Text = "0/1";
						carsAchievement [4].receiveReward.IsVisible = false;			
				}
		
				if (ProfileManager.achievementProfile.NumberFacebookShare >= 3) {
						carsAchievement [5].progressIndicator.FillAmount = 1;
						carsAchievement [5].progressLabel.Text = "3/3";
						carsAchievement [5].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 5);	
				} else {
						carsAchievement [5].progressIndicator.FillAmount = ProfileManager.achievementProfile.NumberFacebookShare / 3f;
						carsAchievement [5].progressLabel.Text = ProfileManager.achievementProfile.NumberFacebookShare + "/3";
						carsAchievement [5].receiveReward.IsVisible = false;			
				}
		
				//--------------------------------------------------------------------------------	
				if (numberFullyUpgradeCars >= 1) {
						carsAchievement [6].progressIndicator.FillAmount = 1;
						carsAchievement [6].progressLabel.Text = "1/1";
						carsAchievement [6].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 6);
				} else {
						carsAchievement [6].progressIndicator.FillAmount = 0;
						carsAchievement [6].progressLabel.Text = "0/1";
						carsAchievement [6].receiveReward.IsVisible = false;			
				}
		
				if (numberFullyUpgradeCars >= 5) {
						carsAchievement [7].progressIndicator.FillAmount = 1;
						carsAchievement [7].progressLabel.Text = "5/5";
						carsAchievement [7].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 7);
				} else {
						carsAchievement [7].progressIndicator.FillAmount = numberFullyUpgradeCars / 5f;
						carsAchievement [7].progressLabel.Text = numberFullyUpgradeCars + "/5";
						carsAchievement [7].receiveReward.IsVisible = false;			
				}
		
				if (numberFullyUpgradeCars >= 10) {
						carsAchievement [8].progressIndicator.FillAmount = 1;
						carsAchievement [8].progressLabel.Text = "10/10";
						carsAchievement [8].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 8);
				} else {
						carsAchievement [8].progressIndicator.FillAmount = numberFullyUpgradeCars / 10f;
						carsAchievement [8].progressLabel.Text = numberFullyUpgradeCars + "/10";
						carsAchievement [8].receiveReward.IsVisible = false;			
				}
		
				if (numberFullyUpgradeCars >= 15) {
						carsAchievement [9].progressIndicator.FillAmount = 1;
						carsAchievement [9].progressLabel.Text = "15/15";
						carsAchievement [9].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 9);
				} else {
						carsAchievement [9].progressIndicator.FillAmount = numberFullyUpgradeCars / 15f;
						carsAchievement [9].progressLabel.Text = numberFullyUpgradeCars + "/15";
						carsAchievement [9].receiveReward.IsVisible = false;			
				}
		}

		public void updateNumberAchievement ()
		{				
				numberNewCarAchivement = 0;
		
				int numberCar = ProfileManager.userProfile.getNumberCar ();	
				int numberFullyUpgradeCars = ProfileManager.userProfile.getNumberFullyUpgradeCars ();
		
				if (numberCar > 1) {
						carsAchievement [0].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 0);
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 0) == false) {
								numberNewCarAchivement++;
						}
				} else {
						carsAchievement [0].disableRewardButton ();
				}
		
				if (numberCar >= 5) {
						carsAchievement [1].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 1);
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 1) == false) {
								numberNewCarAchivement++;
						}
				} else {	
						carsAchievement [1].disableRewardButton ();
				}
		
				if (numberCar >= 10) {
						carsAchievement [2].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 2);
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 2) == false) {
								numberNewCarAchivement++;
						}
				} else {
						carsAchievement [2].disableRewardButton ();
				}
		
				if (numberCar >= 15) {
						carsAchievement [3].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 3);
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 3) == false) {
								numberNewCarAchivement++;
						}
				} else {
						carsAchievement [3].disableRewardButton ();
				}
		
				//--------------------------------------------------------------------------------	
				if (ProfileManager.achievementProfile.NumberFacebookShare >= 1) {
						carsAchievement [4].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 4);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 4) == false) {
								numberNewCarAchivement++;
						}
				} else {
						carsAchievement [4].disableRewardButton ();		
				}
		
				if (ProfileManager.achievementProfile.NumberFacebookShare >= 3) {
						carsAchievement [5].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 5);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 5) == false) {
								numberNewCarAchivement++;
						}
				} else {
						carsAchievement [5].disableRewardButton ();	
				}
		
				//--------------------------------------------------------------------------------	
				if (numberFullyUpgradeCars >= 1) {
						carsAchievement [6].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 6);
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 6) == false) {
								numberNewCarAchivement++;
						}
				} else {
						carsAchievement [6].disableRewardButton ();
				}
		
				if (numberFullyUpgradeCars >= 5) {
						carsAchievement [7].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 7);
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 7) == false) {
								numberNewCarAchivement++;
						}
				} else {
						carsAchievement [7].disableRewardButton ();
				}
		
				if (numberFullyUpgradeCars >= 10) {
						carsAchievement [8].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 8);
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 8) == false) {
								numberNewCarAchivement++;
						}
				} else {
						carsAchievement [8].disableRewardButton ();
				}
		
				if (numberFullyUpgradeCars >= 15) {
						carsAchievement [9].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 9);
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CAR_ACHIEVEMENT, 9) == false) {
								numberNewCarAchivement++;
						}
				} else {
						carsAchievement [9].disableRewardButton ();		
				}
		}
}