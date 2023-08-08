using UnityEngine;
using System.Collections;

public class AchievementRow : MonoBehaviour
{
		public GameData.ACHIEVEMENT_TYPE achievementType;
		public int id;

		//
		public dfButton receiveReward;
		public dfLabel progressLabel;
		public dfSprite progressIndicator;
		public dfLabel rewardLabel;

		//
		int reward;
		AchievementMenu achivement;

		void Start ()
		{
				reward = RewardData.getAchievementReward (achievementType, id);
				rewardLabel.Text = string.Format ("{0:n00}", reward);

				achivement = FindObjectOfType<AchievementMenu> ();
		}

		public override string ToString ()
		{
				return receiveReward + "-" + progressLabel + "-" + progressIndicator;
		}

		public void receiveAchievementReward ()
		{
				achivement.click.Play ();

				ProfileManager.userProfile.Money += reward;
				ProfileManager.achievementProfile.saveGetRewardAchievement (achievementType, id);
				PlayerPrefs.Save ();
		}

		public void disableRewardButton ()
		{
				receiveReward.IsVisible = true;
				receiveReward.IsEnabled = false;
		}
}