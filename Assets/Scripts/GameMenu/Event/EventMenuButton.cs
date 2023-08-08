using UnityEngine;
using System.Collections;
using System;

public class EventMenuButton : MonoBehaviour
{
		public int id;

		//
		public dfButton eventButton;
		public dfLabel eventTitle;
		public dfLabel eventTime;
		public dfLabel orderLabel;
		public dfLabel claimRewardLabel;

		//
		public dfSprite[] mapSprite;
		public EventMenu eventMenu;

		public void raceEvent ()
		{		
				if (id > -1 && id < ProfileManager.eventProfile.eventProfileList.Count) {
						try {
								DateTime endTime = DateTime.Parse (ProfileManager.eventProfile.eventProfileList [id].end);
								if (DateTime.Compare (endTime, DateTime.Now) < 0 && ProfileManager.eventProfile.eventProfileList [id].finish > 0) {
										eventMenu.eventDialog.activate (EventDescription.getEventReward (ProfileManager.eventProfile.eventProfileList [id].id),
				                                ProfileManager.eventProfile.eventProfileList [id].finish, id);				

								} else {
										GameData.isSinglePlayer = true;
										GameData.selectedMap = EventDescription.getEventMap (ProfileManager.eventProfile.eventProfileList [id].id);
				
										GameData.numberRaces = 2;
										GameData.level = -1;
				
										GameData.numberPlayers = 6;
				
										GameData.selectedEvent = ProfileManager.eventProfile.eventProfileList [id].id;

										eventMenu.eventPrizeMenu.activate (ProfileManager.eventProfile.eventProfileList [id]);
								}
						} catch {
						}
				}
		}
}