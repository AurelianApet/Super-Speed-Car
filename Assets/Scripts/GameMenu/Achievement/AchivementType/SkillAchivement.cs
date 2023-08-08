using UnityEngine;
using System.Collections;

public class SkillAchivement
{
		public AchievementRow[] skillsAchievement;
		public int numberNewSkillAchivement;

		public SkillAchivement (AchievementRow[] achivement)
		{
				this.skillsAchievement = achivement;
		}

		public void updateSkillsAchievement ()
		{
				if (ProfileManager.achievementProfile.MaxSpeedReach * 3.6f >= 300) {
						skillsAchievement [0].progressIndicator.FillAmount = 1;
						skillsAchievement [0].progressLabel.Text = "300/300";
						skillsAchievement [0].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 0);	
				} else {
						skillsAchievement [0].progressIndicator.FillAmount = ProfileManager.achievementProfile.MaxSpeedReach * 3.6f / 300f;
						skillsAchievement [0].progressLabel.Text = (int)(ProfileManager.achievementProfile.MaxSpeedReach * 3.6f) + "/300";
						skillsAchievement [0].receiveReward.IsVisible = false;			
				}
		
				if (ProfileManager.achievementProfile.MaxSpeedReach * 3.6f >= 400) {
						skillsAchievement [1].progressIndicator.FillAmount = 1;
						skillsAchievement [1].progressLabel.Text = "400/400";
						skillsAchievement [1].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 1);
				} else {
						skillsAchievement [1].progressIndicator.FillAmount = ProfileManager.achievementProfile.MaxSpeedReach * 3.6f / 400f;
						skillsAchievement [1].progressLabel.Text = (int)(ProfileManager.achievementProfile.MaxSpeedReach * 3.6f) + "/400";
						skillsAchievement [1].receiveReward.IsVisible = false;			
				}
		
				if (ProfileManager.achievementProfile.MaxSpeedReach * 3.6f >= 500) {
						skillsAchievement [2].progressIndicator.FillAmount = 1;
						skillsAchievement [2].progressLabel.Text = "500/500";
						skillsAchievement [2].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 2);	
				} else {
						skillsAchievement [2].progressIndicator.FillAmount = ProfileManager.achievementProfile.MaxSpeedReach * 3.6f / 500f;
						skillsAchievement [2].progressLabel.Text = (int)(ProfileManager.achievementProfile.MaxSpeedReach * 3.6f) + "/500";
						skillsAchievement [2].receiveReward.IsVisible = false;			
				}
		
				//--------------------------------------------------------------------------------
				if (ProfileManager.achievementProfile.NumberDestroyedObstacles >= 200) {
						skillsAchievement [3].progressIndicator.FillAmount = 1;
						skillsAchievement [3].progressLabel.Text = "200/200";
						skillsAchievement [3].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 3);	
				} else {
						skillsAchievement [3].progressIndicator.FillAmount = ProfileManager.achievementProfile.NumberDestroyedObstacles / 200f;
						skillsAchievement [3].progressLabel.Text = ProfileManager.achievementProfile.NumberDestroyedObstacles + "/200";
						skillsAchievement [3].receiveReward.IsVisible = false;			
				}
		
				if (ProfileManager.achievementProfile.NumberDestroyedObstacles >= 300) {
						skillsAchievement [4].progressIndicator.FillAmount = 1;
						skillsAchievement [4].progressLabel.Text = "300/300";
						skillsAchievement [4].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 4);
				} else {
						skillsAchievement [4].progressIndicator.FillAmount = ProfileManager.achievementProfile.NumberDestroyedObstacles / 300f;
						skillsAchievement [4].progressLabel.Text = ProfileManager.achievementProfile.NumberDestroyedObstacles + "/300";
						skillsAchievement [4].receiveReward.IsVisible = false;			
				}
		
				if (ProfileManager.achievementProfile.NumberDestroyedObstacles >= 500) {
						skillsAchievement [5].progressIndicator.FillAmount = 1;
						skillsAchievement [5].progressLabel.Text = "500/500";
						skillsAchievement [5].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 5);
				} else {
						skillsAchievement [5].progressIndicator.FillAmount = ProfileManager.achievementProfile.NumberDestroyedObstacles / 500f;
						skillsAchievement [5].progressLabel.Text = ProfileManager.achievementProfile.NumberDestroyedObstacles + "/500";
						skillsAchievement [5].receiveReward.IsVisible = false;			
				}
		
				//--------------------------------------------------------------------------------
				if (ProfileManager.achievementProfile.DollarEarned >= 5000) {
						skillsAchievement [6].progressIndicator.FillAmount = 1;
						skillsAchievement [6].progressLabel.Text = "5000/5000";
						skillsAchievement [6].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 6);	
				} else {
						skillsAchievement [6].progressIndicator.FillAmount = ProfileManager.achievementProfile.DollarEarned / 5000f;
						skillsAchievement [6].progressLabel.Text = ProfileManager.achievementProfile.DollarEarned + "/5000";
						skillsAchievement [6].receiveReward.IsVisible = false;			
				}
		
				if (ProfileManager.achievementProfile.DollarEarned >= 10000) {
						skillsAchievement [7].progressIndicator.FillAmount = 1;
						skillsAchievement [7].progressLabel.Text = "10000/10000";
						skillsAchievement [7].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 7);
				} else {
						skillsAchievement [7].progressIndicator.FillAmount = ProfileManager.achievementProfile.DollarEarned / 10000f;
						skillsAchievement [7].progressLabel.Text = ProfileManager.achievementProfile.DollarEarned + "/10000";
						skillsAchievement [7].receiveReward.IsVisible = false;			
				}
		
				if (ProfileManager.achievementProfile.DollarEarned >= 15000) {
						skillsAchievement [8].progressIndicator.FillAmount = 1;
						skillsAchievement [8].progressLabel.Text = "15000/15000";
						skillsAchievement [8].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 8);
				} else {
						skillsAchievement [8].progressIndicator.FillAmount = ProfileManager.achievementProfile.DollarEarned / 15000f;
						skillsAchievement [8].progressLabel.Text = ProfileManager.achievementProfile.DollarEarned + "/15000";
						skillsAchievement [8].receiveReward.IsVisible = false;			
				}
		
				//--------------------------------------------------------------------------------
				if (ProfileManager.achievementProfile.DriftDuration >= 480) {
						skillsAchievement [9].progressIndicator.FillAmount = 1;
						skillsAchievement [9].progressLabel.Text = "480/480";
						skillsAchievement [9].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 9);	
				} else {
						skillsAchievement [9].progressIndicator.FillAmount = ProfileManager.achievementProfile.DriftDuration / 480f;
						skillsAchievement [9].progressLabel.Text = (int)ProfileManager.achievementProfile.DriftDuration + "/480";
						skillsAchievement [9].receiveReward.IsVisible = false;			
				}
		
				if (ProfileManager.achievementProfile.DriftDuration >= 600) {
						skillsAchievement [10].progressIndicator.FillAmount = 1;
						skillsAchievement [10].progressLabel.Text = "600/600";
						skillsAchievement [10].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 10);	
				} else {
						skillsAchievement [10].progressIndicator.FillAmount = ProfileManager.achievementProfile.DriftDuration / 600f;
						skillsAchievement [10].progressLabel.Text = (int)ProfileManager.achievementProfile.DriftDuration + "/600";
						skillsAchievement [10].receiveReward.IsVisible = false;			
				}
		
				if (ProfileManager.achievementProfile.DriftDuration >= 900) {
						skillsAchievement [11].progressIndicator.FillAmount = 1;
						skillsAchievement [11].progressLabel.Text = "900/900";
						skillsAchievement [11].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 11);	
				} else {
						skillsAchievement [11].progressIndicator.FillAmount = ProfileManager.achievementProfile.DriftDuration / 900f;
						skillsAchievement [11].progressLabel.Text = (int)ProfileManager.achievementProfile.DriftDuration + "/900";
						skillsAchievement [11].receiveReward.IsVisible = false;			
				}
		
				if (ProfileManager.achievementProfile.DriftDuration >= 1200) {
						skillsAchievement [12].progressIndicator.FillAmount = 1;
						skillsAchievement [12].progressLabel.Text = "1200/1200";
						skillsAchievement [12].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 12);	
				} else {
						skillsAchievement [12].progressIndicator.FillAmount = ProfileManager.achievementProfile.DriftDuration / 1200f;
						skillsAchievement [12].progressLabel.Text = (int)ProfileManager.achievementProfile.DriftDuration + "/1200";
						skillsAchievement [12].receiveReward.IsVisible = false;			
				}
		
				//--------------------------------------------------------------------------------
				if (ProfileManager.achievementProfile.FlyDuration >= 240) {
						skillsAchievement [13].progressIndicator.FillAmount = 1;
						skillsAchievement [13].progressLabel.Text = "240/240";
						skillsAchievement [13].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 13);
				} else {
						skillsAchievement [13].progressIndicator.FillAmount = ProfileManager.achievementProfile.FlyDuration / 240f;
						skillsAchievement [13].progressLabel.Text = (int)ProfileManager.achievementProfile.FlyDuration + "/240";
						skillsAchievement [13].receiveReward.IsVisible = false;			
				}
		
				if (ProfileManager.achievementProfile.FlyDuration >= 420) {
						skillsAchievement [14].progressIndicator.FillAmount = 1;
						skillsAchievement [14].progressLabel.Text = "420/420";
						skillsAchievement [14].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 14);
				} else {
						skillsAchievement [14].progressIndicator.FillAmount = ProfileManager.achievementProfile.FlyDuration / 420f;
						skillsAchievement [14].progressLabel.Text = (int)ProfileManager.achievementProfile.FlyDuration + "/420";
						skillsAchievement [14].receiveReward.IsVisible = false;			
				}
		
				if (ProfileManager.achievementProfile.FlyDuration >= 540) {
						skillsAchievement [15].progressIndicator.FillAmount = 1;
						skillsAchievement [15].progressLabel.Text = "540/540";
						skillsAchievement [15].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 15);	
				} else {
						skillsAchievement [15].progressIndicator.FillAmount = ProfileManager.achievementProfile.FlyDuration / 540f;
						skillsAchievement [15].progressLabel.Text = (int)ProfileManager.achievementProfile.FlyDuration + "/540";
						skillsAchievement [15].receiveReward.IsVisible = false;			
				}
		
				if (ProfileManager.achievementProfile.FlyDuration >= 660) {
						skillsAchievement [16].progressIndicator.FillAmount = 1;
						skillsAchievement [16].progressLabel.Text = "660/660";
						skillsAchievement [16].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 16);	
				} else {
						skillsAchievement [16].progressIndicator.FillAmount = ProfileManager.achievementProfile.FlyDuration / 660f;
						skillsAchievement [16].progressLabel.Text = (int)ProfileManager.achievementProfile.FlyDuration + "/660";
						skillsAchievement [16].receiveReward.IsVisible = false;			
				}
		}

		public void updateNumberAchievement ()
		{					
				numberNewSkillAchivement = 0;

				if (ProfileManager.achievementProfile.MaxSpeedReach * 3.6f >= 300) {
						skillsAchievement [0].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 0);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 0) == false) {
								numberNewSkillAchivement++;
						}
				} else {
						skillsAchievement [0].disableRewardButton ();			
				}
		
				if (ProfileManager.achievementProfile.MaxSpeedReach * 3.6f >= 400) {
						skillsAchievement [1].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 1);
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 1) == false) {
								numberNewSkillAchivement++;
						}
				} else {
						skillsAchievement [1].disableRewardButton ();		
				}
		
				if (ProfileManager.achievementProfile.MaxSpeedReach * 3.6f >= 500) {
						skillsAchievement [2].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 2);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 2) == false) {
								numberNewSkillAchivement++;
						}
				} else {
						skillsAchievement [2].disableRewardButton ();			
				}
		
				//--------------------------------------------------------------------------------
				if (ProfileManager.achievementProfile.NumberDestroyedObstacles >= 200) {
						skillsAchievement [3].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 3);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 3) == false) {
								numberNewSkillAchivement++;
						}
				} else {
						skillsAchievement [3].disableRewardButton ();			
				}
		
				if (ProfileManager.achievementProfile.NumberDestroyedObstacles >= 300) {
						skillsAchievement [4].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 4);
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 4) == false) {
								numberNewSkillAchivement++;
						}
				} else {
						skillsAchievement [4].disableRewardButton ();				
				}
		
				if (ProfileManager.achievementProfile.NumberDestroyedObstacles >= 500) {
						skillsAchievement [5].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 5);
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 5) == false) {
								numberNewSkillAchivement++;
						}
				} else {
						skillsAchievement [5].disableRewardButton ();			
				}
		
				//--------------------------------------------------------------------------------
				if (ProfileManager.achievementProfile.DollarEarned >= 5000) {
						skillsAchievement [6].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 6);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 6) == false) {
								numberNewSkillAchivement++;
						}
				} else {
						skillsAchievement [6].disableRewardButton ();			
				}
		
				if (ProfileManager.achievementProfile.DollarEarned >= 10000) {
						skillsAchievement [7].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 7);
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 7) == false) {
								numberNewSkillAchivement++;
						}
				} else {
						skillsAchievement [7].disableRewardButton ();			
				}
		
				if (ProfileManager.achievementProfile.DollarEarned >= 15000) {
						skillsAchievement [8].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 8);
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 8) == false) {
								numberNewSkillAchivement++;
						}
				} else {
						skillsAchievement [8].disableRewardButton ();			
				}
		
				//--------------------------------------------------------------------------------
				if (ProfileManager.achievementProfile.DriftDuration >= 480) {
						skillsAchievement [9].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 9);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 9) == false) {
								numberNewSkillAchivement++;
						}
				} else {
						skillsAchievement [9].disableRewardButton ();			
				}
		
				if (ProfileManager.achievementProfile.DriftDuration >= 600) {
						skillsAchievement [10].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 10);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 10) == false) {
								numberNewSkillAchivement++;
						}
				} else {
						skillsAchievement [10].disableRewardButton ();			
				}
		
				if (ProfileManager.achievementProfile.DriftDuration >= 900) {
						skillsAchievement [11].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 11);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 11) == false) {
								numberNewSkillAchivement++;
						}
				} else {
						skillsAchievement [11].disableRewardButton ();		
				}
		
				if (ProfileManager.achievementProfile.DriftDuration >= 1200) {
						skillsAchievement [12].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 12);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 12) == false) {
								numberNewSkillAchivement++;
						}
				} else {
						skillsAchievement [12].disableRewardButton ();			
				}
		
				//--------------------------------------------------------------------------------
				if (ProfileManager.achievementProfile.FlyDuration >= 240) {
						skillsAchievement [13].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 13);
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 13) == false) {
								numberNewSkillAchivement++;
						}
				} else {
						skillsAchievement [13].disableRewardButton ();			
				}
		
				if (ProfileManager.achievementProfile.FlyDuration >= 420) {
						skillsAchievement [14].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 14);
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 14) == false) {
								numberNewSkillAchivement++;
						}
				} else {
						skillsAchievement [14].disableRewardButton ();			
				}
		
				if (ProfileManager.achievementProfile.FlyDuration >= 540) {
						skillsAchievement [15].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 15);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 15) == false) {
								numberNewSkillAchivement++;
						}
				} else {
						skillsAchievement [15].disableRewardButton ();			
				}
		
				if (ProfileManager.achievementProfile.FlyDuration >= 660) {
						skillsAchievement [16].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 16);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.SKILL_ACHIEVEMENT, 16) == false) {
								numberNewSkillAchivement++;
						}
				} else {
						skillsAchievement [16].disableRewardButton ();			
				}
		}
}