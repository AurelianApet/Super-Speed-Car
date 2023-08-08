using UnityEngine;
using System.Collections;

public class FreeCoin : BaseHeaderMenu
{
		public static string previousLevel = "MainMenu";
	
		//
		public dfLabel loadingLabel;
		bool isAdLoading = false;
	
		void Start ()
		{
				Vungle.init ("Andorid_App_Id","Ios_App_Id", "Wp_App_Id");
				//				Vungle.init ("com.prime31.Vungle");
		
				if (ProfileManager.setttings.MusicVolume == 0) {
						Vungle.setSoundEnabled (false);
				} else {
						Vungle.setSoundEnabled (true);
				}
		}
	
		void OnEnable ()
		{		
				GoogleAnalytics.LogScreen (Application.loadedLevelName);
				// Listen to all events for illustration purposes
				//Vungle.onAdStartedEvent += onAdStartEvent;
				Vungle.onAdEndedEvent += onAdEndEvent;
				//VungleManager.onCachedAdAvailableEvent += onCachedAdAvailableEvent;
				//VungleManager.onVideoViewEvent += onVideoViewEvent;
		}
	
		void OnDisable ()
		{
				// Remove all event handlers
				//Vungle.onAdStartedEvent -= onAdStartEvent;
				Vungle.onAdEndedEvent -= onAdEndEvent;
				//VungleManager.onCachedAdAvailableEvent -= onCachedAdAvailableEvent;
				//VungleManager.onVideoViewEvent -= onVideoViewEvent;
		}
	
		void Update ()
		{
				if (Input.GetKeyUp (KeyCode.Escape)) {
						AutoFade.LoadLevel (FreeCoin.previousLevel);
			
				} else {
						this.updateInfo ();
			
						if (isAdLoading == true) {
								loadingLabel.IsVisible = true;

                if (Vungle.isAdvertAvailable () == true) {
										isAdLoading = false;
								}
						} else {
								loadingLabel.IsVisible = false;
						}
				}
		}
	
		void OnApplicationPause (bool pauseStatus)
		{
				if (pauseStatus == true) {
						Vungle.onPause ();
				} else {
						Vungle.onResume ();
				}
		}
	
		public void back ()
		{		
				AutoFade.LoadLevel (FreeCoin.previousLevel);
		}
	
		public void VungleClick ()
		{
				Vungle.playAd ();
        if (Vungle.isAdvertAvailable () == true) {
						isAdLoading = false;
				} else {
						isAdLoading = true;
				}
		}
	
		void onAdStartEvent ()
		{
				Debug.Log ("onAdStartEvent");
		}
	
		void onAdEndEvent ()
		{
        ProfileManager.userProfile.Money += 200;
        PlayerPrefs.Save();
    }
	
		void onCachedAdAvailableEvent ()
		{
				Debug.Log ("onCachedAdAvailableEvent");
		}
	
		void onVideoViewEvent (double watched, double length)
		{
				Debug.Log ("onVideoViewEvent. watched: " + watched + ", length: " + length);
		
		}
}