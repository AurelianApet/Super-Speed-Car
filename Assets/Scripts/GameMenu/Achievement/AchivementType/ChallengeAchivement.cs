using UnityEngine;
using System.Collections;

public class ChallengeAchivement
{
		public AchievementRow[] challengesAchievement;
		public int numberNewChallengeAchivement;

		public ChallengeAchivement (AchievementRow[] achivement)
		{
				this.challengesAchievement = achivement;
		}

		public void updateChallengesAchievement ()
		{
				if (ProfileManager.achievementProfile.NumberQuickRaceWin >= 1) {
						challengesAchievement [0].progressIndicator.FillAmount = 1;
						challengesAchievement [0].progressLabel.Text = "1/1";
						challengesAchievement [0].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 0);
				} else {
						challengesAchievement [0].progressIndicator.FillAmount = 0;
						challengesAchievement [0].progressLabel.Text = "0/1";
						challengesAchievement [0].receiveReward.IsVisible = false;			
				}
		
				if (ProfileManager.achievementProfile.NumberQuickRaceWin >= 10) {
						challengesAchievement [1].progressIndicator.FillAmount = 1;
						challengesAchievement [1].progressLabel.Text = "10/10";
						challengesAchievement [1].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 1);	
				} else {
						challengesAchievement [1].progressIndicator.FillAmount = ProfileManager.achievementProfile.NumberQuickRaceWin / 10f;
						challengesAchievement [1].progressLabel.Text = ProfileManager.achievementProfile.NumberQuickRaceWin + "/10";
						challengesAchievement [1].receiveReward.IsVisible = false;			
				}
		
				if (ProfileManager.achievementProfile.NumberQuickRaceWin >= 50) {
						challengesAchievement [2].progressIndicator.FillAmount = 1;
						challengesAchievement [2].progressLabel.Text = "50/50";
						challengesAchievement [2].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 2);
				} else {
						challengesAchievement [2].progressIndicator.FillAmount = ProfileManager.achievementProfile.NumberQuickRaceWin / 50f;
						challengesAchievement [2].progressLabel.Text = ProfileManager.achievementProfile.NumberQuickRaceWin + "/50";
						challengesAchievement [2].receiveReward.IsVisible = false;			
				}
		
				if (ProfileManager.achievementProfile.NumberQuickRaceWin >= 100) {
						challengesAchievement [3].progressIndicator.FillAmount = 1;
						challengesAchievement [3].progressLabel.Text = "100/100";
						challengesAchievement [3].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 3);
				} else {
						challengesAchievement [3].progressIndicator.FillAmount = ProfileManager.achievementProfile.NumberQuickRaceWin / 100f;
						challengesAchievement [3].progressLabel.Text = ProfileManager.achievementProfile.NumberQuickRaceWin + "/100";
						challengesAchievement [3].receiveReward.IsVisible = false;			
				}
		
				if (ProfileManager.achievementProfile.NumberQuickRaceWin >= 150) {
						challengesAchievement [4].progressIndicator.FillAmount = 1;
						challengesAchievement [4].progressLabel.Text = "150/150";
						challengesAchievement [4].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 4);
				} else {
						challengesAchievement [4].progressIndicator.FillAmount = ProfileManager.achievementProfile.NumberQuickRaceWin / 150f;
						challengesAchievement [4].progressLabel.Text = ProfileManager.achievementProfile.NumberQuickRaceWin + "/150";
						challengesAchievement [4].receiveReward.IsVisible = false;			
				}
		
				//--------------------------------------------------------------------------------
		
				int playedMaps = ProfileManager.userProfile.getPlayedMapsBySeason (0);
				if (playedMaps >= 10) {
						challengesAchievement [5].progressIndicator.FillAmount = 1;
						challengesAchievement [5].progressLabel.Text = "10/10";
						challengesAchievement [5].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 5);
				} else {
						challengesAchievement [5].progressIndicator.FillAmount = playedMaps / 10f;
						challengesAchievement [5].progressLabel.Text = playedMaps + "/10";
						challengesAchievement [5].receiveReward.IsVisible = false;			
				}
		
				playedMaps = ProfileManager.userProfile.getPlayedMapsBySeason (1);
				if (playedMaps >= 12) {
						challengesAchievement [6].progressIndicator.FillAmount = 1;
						challengesAchievement [6].progressLabel.Text = "12/12";
						challengesAchievement [6].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 6);	
				} else {
						challengesAchievement [6].progressIndicator.FillAmount = playedMaps / 12f;
						challengesAchievement [6].progressLabel.Text = playedMaps + "/12";
						challengesAchievement [6].receiveReward.IsVisible = false;			
				}
		
				playedMaps = ProfileManager.userProfile.getPlayedMapsBySeason (2);
				if (playedMaps >= 14) {
						challengesAchievement [7].progressIndicator.FillAmount = 1;
						challengesAchievement [7].progressLabel.Text = "14/14";
						challengesAchievement [7].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 7);	
				} else {
						challengesAchievement [7].progressIndicator.FillAmount = playedMaps / 14f;
						challengesAchievement [7].progressLabel.Text = playedMaps + "/14";
						challengesAchievement [7].receiveReward.IsVisible = false;			
				}
		
				playedMaps = ProfileManager.userProfile.getPlayedMapsBySeason (3);
				if (playedMaps >= 16) {
						challengesAchievement [8].progressIndicator.FillAmount = 1;
						challengesAchievement [8].progressLabel.Text = "16/16";
						challengesAchievement [8].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 8);	
				} else {
						challengesAchievement [8].progressIndicator.FillAmount = playedMaps / 16f;
						challengesAchievement [8].progressLabel.Text = playedMaps + "/16";
						challengesAchievement [8].receiveReward.IsVisible = false;			
				}
		
				playedMaps = ProfileManager.userProfile.getPlayedMapsBySeason (4);
				if (playedMaps >= 18) {
						challengesAchievement [9].progressIndicator.FillAmount = 1;
						challengesAchievement [9].progressLabel.Text = "18/18";
						challengesAchievement [9].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 9);
				} else {
						challengesAchievement [9].progressIndicator.FillAmount = playedMaps / 18f;
						challengesAchievement [9].progressLabel.Text = playedMaps + "/18";
						challengesAchievement [9].receiveReward.IsVisible = false;			
				}
		
				playedMaps = ProfileManager.userProfile.getPlayedMapsBySeason (5);
				if (playedMaps >= 18) {
						challengesAchievement [10].progressIndicator.FillAmount = 1;
						challengesAchievement [10].progressLabel.Text = "18/18";
						challengesAchievement [10].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 10);	
				} else {
						challengesAchievement [10].progressIndicator.FillAmount = playedMaps / 18f;
						challengesAchievement [10].progressLabel.Text = playedMaps + "/18";
						challengesAchievement [10].receiveReward.IsVisible = false;			
				}
		
				playedMaps = ProfileManager.userProfile.getPlayedMapsBySeason (6);
				if (playedMaps >= 18) {
						challengesAchievement [11].progressIndicator.FillAmount = 1;
						challengesAchievement [11].progressLabel.Text = "18/18";
						challengesAchievement [11].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 11);	
				} else {
						challengesAchievement [11].progressIndicator.FillAmount = playedMaps / 18f;
						challengesAchievement [11].progressLabel.Text = playedMaps + "/18";
						challengesAchievement [11].receiveReward.IsVisible = false;			
				}
		
				playedMaps = ProfileManager.userProfile.getPlayedMapsBySeason (7);
				if (playedMaps >= 18) {
						challengesAchievement [12].progressIndicator.FillAmount = 1;
						challengesAchievement [12].progressLabel.Text = "18/18";
						challengesAchievement [12].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 12);	
				} else {
						challengesAchievement [12].progressIndicator.FillAmount = playedMaps / 18f;
						challengesAchievement [12].progressLabel.Text = playedMaps + "/18";
						challengesAchievement [12].receiveReward.IsVisible = false;			
				}
		}

		public void updateNumberAchievement ()
		{					
				numberNewChallengeAchivement = 0;

				if (ProfileManager.achievementProfile.NumberQuickRaceWin >= 1) {
						challengesAchievement [0].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 0);
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 0) == false) {
								numberNewChallengeAchivement++;
						}
				} else {
						challengesAchievement [0].disableRewardButton ();			
				}
		
				if (ProfileManager.achievementProfile.NumberQuickRaceWin >= 10) {
						challengesAchievement [1].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 1);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 1) == false) {
								numberNewChallengeAchivement++;
						}
				} else {
						challengesAchievement [1].disableRewardButton ();			
				}
		
				if (ProfileManager.achievementProfile.NumberQuickRaceWin >= 50) {
						challengesAchievement [2].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 2);
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 2) == false) {
								numberNewChallengeAchivement++;
						}
				} else {
						challengesAchievement [2].disableRewardButton ();			
				}
		
				if (ProfileManager.achievementProfile.NumberQuickRaceWin >= 100) {
						challengesAchievement [3].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 3);
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 3) == false) {
								numberNewChallengeAchivement++;
						}
				} else {
						challengesAchievement [3].disableRewardButton ();			
				}
		
				if (ProfileManager.achievementProfile.NumberQuickRaceWin >= 150) {
						challengesAchievement [4].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 4);
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 4) == false) {
								numberNewChallengeAchivement++;
						}
				} else {
						challengesAchievement [4].disableRewardButton ();			
				}
		
				//--------------------------------------------------------------------------------
		
				int playedMaps = ProfileManager.userProfile.getPlayedMapsBySeason (0);
				if (playedMaps >= 10) {
						challengesAchievement [5].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 5);
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 5) == false) {
								numberNewChallengeAchivement++;
						}
				} else {
						challengesAchievement [5].disableRewardButton ();			
				}
		
				playedMaps = ProfileManager.userProfile.getPlayedMapsBySeason (1);
				if (playedMaps >= 12) {
						challengesAchievement [6].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 6);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 6) == false) {
								numberNewChallengeAchivement++;
						}
				} else {
						challengesAchievement [6].disableRewardButton ();			
				}
		
				playedMaps = ProfileManager.userProfile.getPlayedMapsBySeason (2);
				if (playedMaps >= 14) {
						challengesAchievement [7].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 7);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 7) == false) {
								numberNewChallengeAchivement++;
						}
				} else {
						challengesAchievement [7].disableRewardButton ();			
				}
		
				playedMaps = ProfileManager.userProfile.getPlayedMapsBySeason (3);
				if (playedMaps >= 16) {
						challengesAchievement [8].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 8);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 8) == false) {
								numberNewChallengeAchivement++;
						}
				} else {
						challengesAchievement [8].disableRewardButton ();				
				}
		
				playedMaps = ProfileManager.userProfile.getPlayedMapsBySeason (4);
				if (playedMaps >= 18) {
						challengesAchievement [9].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 9);
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 9) == false) {
								numberNewChallengeAchivement++;
						}
				} else {
						challengesAchievement [9].disableRewardButton ();			
				}
		
				playedMaps = ProfileManager.userProfile.getPlayedMapsBySeason (5);
				if (playedMaps >= 18) {
						challengesAchievement [10].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 10);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 10) == false) {
								numberNewChallengeAchivement++;
						}
				} else {
						challengesAchievement [10].disableRewardButton ();			
				}
		
				playedMaps = ProfileManager.userProfile.getPlayedMapsBySeason (6);
				if (playedMaps >= 18) {
						challengesAchievement [11].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 11);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 11) == false) {
								numberNewChallengeAchivement++;
						}
				} else {
						challengesAchievement [11].disableRewardButton ();			
				}
		
				playedMaps = ProfileManager.userProfile.getPlayedMapsBySeason (7);
				if (playedMaps >= 18) {
						challengesAchievement [12].receiveReward.IsVisible = !ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 12);	
						if (ProfileManager.achievementProfile.isGetReward (GameData.ACHIEVEMENT_TYPE.CHALLENGE_ACHIEVEMENT, 12) == false) {
								numberNewChallengeAchivement++;
						}
				} else {
						challengesAchievement [12].disableRewardButton ();				
				}
		}
}