using UnityEngine;
using System.Collections;

public class QuestItem : MonoBehaviour
{
		public dfLabel questContent;
		public dfSprite questProgress;
		public dfLabel questProgressLabel;
		public dfLabel moneyReward;
		public dfLabel cashReward;
		public dfButton receiveButton;

		public void updateData (QuestProfileData data)
		{
				questContent.Text = QuestMenu.getQuestContent (data);
				questProgress.FillAmount = (float)data.progress / (float)data.aim;

				questProgressLabel.Text = data.progress + "/" + data.aim;

				moneyReward.Text = data.money.ToString ();
				cashReward.Text = data.cash.ToString ();

				if (data.progress < data.aim) {
						receiveButton.IsEnabled = false;
				} else {
						if (data.receive == false) {
								receiveButton.IsEnabled = true;
						} else {
								receiveButton.IsVisible = false;
						}
				}
		}
}