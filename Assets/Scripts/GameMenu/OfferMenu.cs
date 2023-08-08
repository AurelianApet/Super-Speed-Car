using UnityEngine;
using System.Collections;

public class OfferMenu : MonoBehaviour
{		
		public static string previousLevel = "MainMenu";

		//
		public AudioSource audioSource;
		public AudioSource click;

		//
		public OfferMenuItem[] offerPanelList;
		public dfScrollPanel scrollPanel;
		public dfTweenVector2 scrollAnimation;

		//
		int currentScrollID;
		int itemCount;
		bool isLoadLevel = false;
	
		void Start ()
		{
				ProfileManager.init ();
		
				audioSource.volume = ProfileManager.setttings.MusicVolume / 100f;
				audioSource.Play ();
		
				click.volume = ProfileManager.setttings.SoundVolume / 100f;		
		
				ProfileManager.offerProfile.generateOfferData ();
				ProfileManager.offerProfile.updateOfferProfileData ();

				LevelLoader.isLoading = true;
				MainMenu.isLoadingShop = true;
		}
	
		void Update ()
		{
				if (Input.GetKeyUp (KeyCode.Escape)) {
						AutoFade.LoadLevel (previousLevel);	

				} else {
						ProfileManager.offerProfile.updateOfferProfileData ();
			
						itemCount = 0;				
						for (int i=0; i<offerPanelList.Length; i++) {
								if (ProfileManager.offerProfile.isHasOfferID (i) == false) {
										offerPanelList [i].background.IsVisible = false;
								} else {
										itemCount++;
										offerPanelList [i].offerProfileData = ProfileManager.offerProfile.getOfferData (i);
								}
						}
						
						if (isLoadLevel == false) {
								if (ProfileManager.offerProfile.offerProfileList.Count == 0) {
										AutoFade.LoadLevel (previousLevel);	
										this.isLoadLevel = true;
								}
						}
				}
		}
	
		public void back ()
		{
				click.Play ();
				AutoFade.LoadLevel (previousLevel);	
		}

		public void prev ()
		{
				currentScrollID = Mathf.RoundToInt (scrollPanel.ScrollPosition.x / 800);
				currentScrollID--;
				if (currentScrollID < 0) {
						currentScrollID = itemCount - 1;
				}

				scrollAnimation.StartValue = scrollPanel.ScrollPosition;
				scrollAnimation.EndValue = new Vector2 (800 * currentScrollID, scrollPanel.ScrollPosition.y);
				scrollAnimation.Play ();
		}

		public void next ()
		{
				currentScrollID = Mathf.RoundToInt (scrollPanel.ScrollPosition.x / 800);
				currentScrollID = (currentScrollID + 1) % itemCount;
		
				scrollAnimation.StartValue = scrollPanel.ScrollPosition;
				scrollAnimation.EndValue = new Vector2 (800 * currentScrollID, scrollPanel.ScrollPosition.y);
				scrollAnimation.Play ();
		}
}