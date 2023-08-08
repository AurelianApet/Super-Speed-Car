using UnityEngine;
using System.Collections;
using System;

public class EventMenu : BaseHeaderMenu
{
		//
		public AudioSource audioSource;
		public AudioSource click;

		//
		public GameObject eventPanel;
		public EventDialog eventDialog;
		public EventPrizeMenu eventPrizeMenu;

		//
		EventMenuButton[] eventButtonList;

		void Start ()
		{
				ProfileManager.init ();

				audioSource.volume = ProfileManager.setttings.MusicVolume / 100f;
				audioSource.Play ();
		
				click.volume = ProfileManager.setttings.SoundVolume / 100f;

				ProfileManager.eventProfile.updateEventProfileData ();

				eventButtonList = eventPanel.GetComponentsInChildren<EventMenuButton> ();
		}

		void Update ()
		{
				if (Input.GetKeyUp (KeyCode.Escape)) {
						AutoFade.LoadLevel ("MainMenu");
			
				} else {
						this.updateInfo ();
				}

				for (int i=0; i<ProfileManager.eventProfile.eventProfileList.Count; i++) {
						if (i > -1 && i < eventButtonList.Length) {
								eventButtonList [i].eventButton.IsVisible = true;
								eventButtonList [i].id = i;

								for (int k=0; k<eventButtonList [i].mapSprite.Length; k++) {
										eventButtonList [i].mapSprite [k].IsVisible = false;
								}

								eventButtonList [i].mapSprite [(int)EventDescription.getEventMap (ProfileManager.eventProfile.eventProfileList [i].id)].IsVisible = true;
								eventButtonList [i].eventTitle.Text = EventDescription.getEventName (ProfileManager.eventProfile.eventProfileList [i].id);

								try {
										DateTime endTime = DateTime.Parse (ProfileManager.eventProfile.eventProfileList [i].end);
				
										eventButtonList [i].claimRewardLabel.IsVisible = false;

										if (ProfileManager.eventProfile.eventProfileList [i].finish == 0) {
												eventButtonList [i].orderLabel.Text = string.Empty;
						
										} else {
												switch (ProfileManager.eventProfile.eventProfileList [i].finish) {
												case 1:
														eventButtonList [i].orderLabel.Text = "1st";
														break;
							
												case 2:
														eventButtonList [i].orderLabel.Text = "2nd";
														break;
							
												case 3:
														eventButtonList [i].orderLabel.Text = "3rd";
														break;
							
												default:
														eventButtonList [i].orderLabel.Text = string.Empty;
														break;
												}
										}

										if (DateTime.Compare (endTime, DateTime.Now) < 0) {
												if (ProfileManager.eventProfile.eventProfileList [i].finish == 0) {
														eventButtonList [i].eventTime.Text = "Not joined";
												} else {
														eventButtonList [i].eventTime.Text = "Completed";
														eventButtonList [i].claimRewardLabel.IsVisible = true;
												}

												
										} else {
												TimeSpan timeSpan = new TimeSpan (endTime.Ticks - DateTime.Now.Ticks);

												eventButtonList [i].eventTime.Text = timeSpan.Days + "d " + timeSpan.Hours + "h " 
														+ timeSpan.Minutes + "m " + timeSpan.Seconds + "s";
										}
								} catch {
								}
						}
				}

				for (int i=ProfileManager.eventProfile.eventProfileList.Count; i<eventButtonList.Length; i++) {
						eventButtonList [i].eventButton.IsVisible = false;
				}
		}

		public void back ()
		{
				click.Play ();
		
				AutoFade.LoadLevel ("MainMenu");
		}
}