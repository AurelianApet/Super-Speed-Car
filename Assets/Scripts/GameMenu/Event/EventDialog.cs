using UnityEngine;
using System.Collections;

public class EventDialog : MonoBehaviour
{
		public dfPanel dialog;
		public dfLabel dialogMessage;

		//
		int reward;
		int id;

		public void activate (EventReward eventReward, int finishOrder, int id)
		{
				dialog.IsVisible = true;
				switch (finishOrder) {
				case 1:			
						reward = eventReward.firstReward;
						break;

				case 2:			
						reward = eventReward.secondReward;
						break;

				case 3:			
						reward = eventReward.thirdReward;
						break;

				default:
						break;
				}

				this.id = id;
				dialogMessage.Text = "You  have  received  " + string.Format ("{0:n00}", reward) + "  coins";
		}

		public void claimReward ()
		{
				dialog.IsVisible = false;

				ProfileManager.eventProfile.eventProfileList.Remove (ProfileManager.eventProfile.eventProfileList [id]);
				ProfileManager.eventProfile.saveEventProfileData ();

				ProfileManager.userProfile.Money += reward;
				PlayerPrefs.Save ();
		}
}