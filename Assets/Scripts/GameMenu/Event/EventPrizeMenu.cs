using UnityEngine;
using System.Collections;
using System;

public class EventPrizeMenu : MonoBehaviour
{
		public dfPanel eventPrizeDialog;
		public dfLabel eventTitle;
		public dfLabel eventTime;

		//
		public dfLabel[] prizeLabel;
		public dfSprite[] mapEvent;

		//
		EventProfileData eventProfileData;

		void Update ()
		{
				if (eventPrizeDialog.IsVisible == true) {
						try {
								DateTime endTime = DateTime.Parse (eventProfileData.end);

								TimeSpan timeSpan = new TimeSpan (endTime.Ticks - DateTime.Now.Ticks);

								eventTime.Text = timeSpan.Days + "d " + timeSpan.Hours + "h " 
										+ timeSpan.Minutes + "m " + timeSpan.Seconds + "s";
						} catch {
						}
				}
		}

		public void activate (EventProfileData eventProfileData)
		{
				this.eventProfileData = eventProfileData;

				eventPrizeDialog.IsVisible = true;

				EventReward eventReward = EventDescription.getEventReward (eventProfileData.id);

				prizeLabel [0].Text = eventReward.firstReward.ToString ();
				prizeLabel [1].Text = eventReward.secondReward.ToString ();
				prizeLabel [2].Text = eventReward.thirdReward.ToString ();

				for (int i=0; i<mapEvent.Length; i++) {
						mapEvent [i].IsVisible = false;
				}

				mapEvent [(int)EventDescription.getEventMap (eventProfileData.id)].IsVisible = true;
				eventTitle.Text = EventDescription.getEventName (eventProfileData.id);
		}

		public void race ()
		{
				AutoFade.LoadLevel ("Load");
		}

		public void quit ()
		{
				eventPrizeDialog.IsVisible = false;
		}
}