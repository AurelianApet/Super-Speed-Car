using UnityEngine;
using System.Collections;

public class StarAchivement
{
		public AchievementRow[] starsAchievement;
		public int numberNewStarAchivement;

		public StarAchivement (AchievementRow[] achivement)
		{
				this.starsAchievement = achivement;
		}

		public void updateStarsAchievement ()
		{
				int numberStar = ProfileManager.userProfile.getNumberStar ();
		
				if (numberStar >= 1) {
						starsAchievement [0].progressIndicator.FillAmount = 1;
						starsAchievement [0].progressLabel.Text = "1/1";
						starsAchievement [0].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 0);
				} else {
						starsAchievement [0].progressIndicator.FillAmount = 0;
						starsAchievement [0].progressLabel.Text = "0/1";
						starsAchievement [0].receiveReward.IsVisible = false;			
				}
		
				if (numberStar >= 5) {
						starsAchievement [1].progressIndicator.FillAmount = 1;
						starsAchievement [1].progressLabel.Text = "5/5";
						starsAchievement [1].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 1);	
				} else {
						starsAchievement [1].progressIndicator.FillAmount = numberStar / 5f;
						starsAchievement [1].progressLabel.Text = numberStar + "/5";
						starsAchievement [1].receiveReward.IsVisible = false;			
				}
		
				if (numberStar >= 10) {
						starsAchievement [2].progressIndicator.FillAmount = 1;
						starsAchievement [2].progressLabel.Text = "10/10";
						starsAchievement [2].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 2);
				} else {
						starsAchievement [2].progressIndicator.FillAmount = numberStar / 10f;
						starsAchievement [2].progressLabel.Text = numberStar + "/10";
						starsAchievement [2].receiveReward.IsVisible = false;			
				}
		
				if (numberStar >= 50) {
						starsAchievement [3].progressIndicator.FillAmount = 1;
						starsAchievement [3].progressLabel.Text = "50/50";
						starsAchievement [3].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 3);	
				} else {
						starsAchievement [3].progressIndicator.FillAmount = numberStar / 50f;
						starsAchievement [3].progressLabel.Text = numberStar + "/50";
						starsAchievement [3].receiveReward.IsVisible = false;			
				}
		
				if (numberStar >= 100) {
						starsAchievement [4].progressIndicator.FillAmount = 1;
						starsAchievement [4].progressLabel.Text = "100/100";
						starsAchievement [4].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 4);
				} else {
						starsAchievement [4].progressIndicator.FillAmount = numberStar / 100f;
						starsAchievement [4].progressLabel.Text = numberStar + "/100";
						starsAchievement [4].receiveReward.IsVisible = false;			
				}
		
				if (numberStar >= 150) {
						starsAchievement [5].progressIndicator.FillAmount = 1;
						starsAchievement [5].progressLabel.Text = "150/150";
						starsAchievement [5].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 5);	
				} else {
						starsAchievement [5].progressIndicator.FillAmount = numberStar / 150f;
						starsAchievement [5].progressLabel.Text = numberStar + "/150";
						starsAchievement [5].receiveReward.IsVisible = false;			
				}
		
				if (numberStar >= 200) {
						starsAchievement [6].progressIndicator.FillAmount = 1;
						starsAchievement [6].progressLabel.Text = "200/200";
						starsAchievement [6].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 6);	
				} else {
						starsAchievement [6].progressIndicator.FillAmount = numberStar / 200f;
						starsAchievement [6].progressLabel.Text = numberStar + "/200";
						starsAchievement [6].receiveReward.IsVisible = false;			
				}
		
				if (numberStar >= 250) {
						starsAchievement [7].progressIndicator.FillAmount = 1;
						starsAchievement [7].progressLabel.Text = "250/250";
						starsAchievement [7].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 7);
				} else {
						starsAchievement [7].progressIndicator.FillAmount = numberStar / 250f;
						starsAchievement [7].progressLabel.Text = numberStar + "/250";
						starsAchievement [7].receiveReward.IsVisible = false;			
				}
		
				if (numberStar >= 300) {
						starsAchievement [8].progressIndicator.FillAmount = 1;
						starsAchievement [8].progressLabel.Text = "300/300";
						starsAchievement [8].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 8);	
				} else {
						starsAchievement [8].progressIndicator.FillAmount = numberStar / 300f;
						starsAchievement [8].progressLabel.Text = numberStar + "/300";
						starsAchievement [8].receiveReward.IsVisible = false;			
				}
		
				if (numberStar >= 350) {
						starsAchievement [9].progressIndicator.FillAmount = 1;
						starsAchievement [9].progressLabel.Text = "350/350";
						starsAchievement [9].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 9);	
				} else {
						starsAchievement [9].progressIndicator.FillAmount = numberStar / 350f;
						starsAchievement [9].progressLabel.Text = numberStar + "/350";
						starsAchievement [9].receiveReward.IsVisible = false;			
				}
		
				if (numberStar >= 400) {
						starsAchievement [10].progressIndicator.FillAmount = 1;
						starsAchievement [10].progressLabel.Text = "400/400";
						starsAchievement [10].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 10);	
				} else {
						starsAchievement [10].progressIndicator.FillAmount = numberStar / 400f;
						starsAchievement [10].progressLabel.Text = numberStar + "/400";
						starsAchievement [10].receiveReward.IsVisible = false;			
				}
		
				if (numberStar >= 450) {
						starsAchievement [11].progressIndicator.FillAmount = 1;
						starsAchievement [11].progressLabel.Text = "450/450";
						starsAchievement [11].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 11);	
				} else {
						starsAchievement [11].progressIndicator.FillAmount = numberStar / 450f;
						starsAchievement [11].progressLabel.Text = numberStar + "/450";
						starsAchievement [11].receiveReward.IsVisible = false;			
				}
		
				if (numberStar >= 500) {
						starsAchievement [12].progressIndicator.FillAmount = 1;
						starsAchievement [12].progressLabel.Text = "500/500";
						starsAchievement [12].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 12);
				} else {
						starsAchievement [12].progressIndicator.FillAmount = numberStar / 500f;
						starsAchievement [12].progressLabel.Text = numberStar + "/500";
						starsAchievement [12].receiveReward.IsVisible = false;			
				}
		
				if (numberStar >= 550) {
						starsAchievement [13].progressIndicator.FillAmount = 1;
						starsAchievement [13].progressLabel.Text = "550/550";
						starsAchievement [13].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 13);	
				} else {
						starsAchievement [13].progressIndicator.FillAmount = numberStar / 550f;
						starsAchievement [13].progressLabel.Text = numberStar + "/550";
						starsAchievement [13].receiveReward.IsVisible = false;			
				}
		
				if (numberStar >= 600) {
						starsAchievement [14].progressIndicator.FillAmount = 1;
						starsAchievement [14].progressLabel.Text = "600/600";
						starsAchievement [14].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 14);	
				} else {
						starsAchievement [14].progressIndicator.FillAmount = numberStar / 600f;
						starsAchievement [14].progressLabel.Text = numberStar + "/600";
						starsAchievement [14].receiveReward.IsVisible = false;			
				}
		
				if (numberStar >= 620) {
						starsAchievement [15].progressIndicator.FillAmount = 1;
						starsAchievement [15].progressLabel.Text = "620/620";
						starsAchievement [15].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 15);
				} else {
						starsAchievement [15].progressIndicator.FillAmount = numberStar / 620f;
						starsAchievement [15].progressLabel.Text = numberStar + "/620";
						starsAchievement [15].receiveReward.IsVisible = false;			
				}
		}

		public void updateNumberAchievement ()
		{					
				numberNewStarAchivement = 0;

				int numberStar = ProfileManager.userProfile.getNumberStar ();
		
				if (numberStar >= 1) {
						starsAchievement [0].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 0);
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 0) == false) {
								numberNewStarAchivement++;
						}
				} else {
						starsAchievement [0].disableRewardButton ();			
				}
		
				if (numberStar >= 5) {
						starsAchievement [1].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 1);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 1) == false) {
								numberNewStarAchivement++;
						}
				} else {
						starsAchievement [1].disableRewardButton ();		
				}
		
				if (numberStar >= 10) {
						starsAchievement [2].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 2);
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 2) == false) {
								numberNewStarAchivement++;
						}
				} else {
						starsAchievement [2].disableRewardButton ();			
				}
		
				if (numberStar >= 50) {
						starsAchievement [3].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 3);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 3) == false) {
								numberNewStarAchivement++;
						}
				} else {
						starsAchievement [3].disableRewardButton ();				
				}
		
				if (numberStar >= 100) {
						starsAchievement [4].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 4);
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 4) == false) {
								numberNewStarAchivement++;
						}
				} else {
						starsAchievement [4].disableRewardButton ();			
				}
		
				if (numberStar >= 150) {
						starsAchievement [5].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 5);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 5) == false) {
								numberNewStarAchivement++;
						}
				} else {
						starsAchievement [5].disableRewardButton ();				
				}
		
				if (numberStar >= 200) {
						starsAchievement [6].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 6);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 6) == false) {
								numberNewStarAchivement++;
						}
				} else {
						starsAchievement [6].disableRewardButton ();			
				}
		
				if (numberStar >= 250) {
						starsAchievement [7].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 7);
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 7) == false) {
								numberNewStarAchivement++;
						}
				} else {
						starsAchievement [7].disableRewardButton ();			
				}
		
				if (numberStar >= 300) {
						starsAchievement [8].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 8);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 8) == false) {
								numberNewStarAchivement++;
						}
				} else {
						starsAchievement [8].disableRewardButton ();			
				}
		
				if (numberStar >= 350) {
						starsAchievement [9].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 9);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 9) == false) {
								numberNewStarAchivement++;
						}
				} else {
						starsAchievement [9].disableRewardButton ();				
				}
		
				if (numberStar >= 400) {
						starsAchievement [10].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 10);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 10) == false) {
								numberNewStarAchivement++;
						}
				} else {
						starsAchievement [10].disableRewardButton ();			
				}
		
				if (numberStar >= 450) {
						starsAchievement [11].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 11);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 11) == false) {
								numberNewStarAchivement++;
						}
				} else {
						starsAchievement [11].disableRewardButton ();			
				}
		
				if (numberStar >= 500) {
						starsAchievement [12].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 12);
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 12) == false) {
								numberNewStarAchivement++;
						}
				} else {
						starsAchievement [12].disableRewardButton ();				
				}
		
				if (numberStar >= 550) {
						starsAchievement [13].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 13);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 13) == false) {
								numberNewStarAchivement++;
						}
				} else {
						starsAchievement [13].disableRewardButton ();			
				}
		
				if (numberStar >= 600) {
						starsAchievement [14].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 14);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 14) == false) {
								numberNewStarAchivement++;
						}
				} else {
						starsAchievement [14].disableRewardButton ();			
				}
		
				if (numberStar >= 620) {
						starsAchievement [15].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 15);
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.STAR_ACHIEVEMENT, 15) == false) {
								numberNewStarAchivement++;
						}
				} else {
						starsAchievement [15].disableRewardButton ();			
				}
		}
}