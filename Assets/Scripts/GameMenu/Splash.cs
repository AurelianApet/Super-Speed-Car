using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Splash : MonoBehaviour
{
	public KORChat korChat;

	void Start ()
	{
		Application.runInBackground = true;
		Screen.SetResolution (800, 480, true);
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Application.targetFrameRate = 30;

		ProfileManager.init ();

//				StartCoroutine (PlayMovie ());

		korChat.init ();

		if (ProfileManager.userProfile.IsHasName == true) {
//			KORChat.connect ();
		}

		TimeSpan timeSpan = new TimeSpan (DateTime.Now.Ticks - ProfileManager.dailyBonusProfile.LastLogin.Ticks);
		if (timeSpan.TotalHours <= 24) {
			Application.LoadLevelAsync ("MainMenu");
		} else {
			Application.LoadLevelAsync ("DailyLogin");
		}
	}
	
//		protected IEnumerator PlayMovie ()
//		{
//				Handheld.PlayFullScreenMovie ("Movies/Splay.mp4", Color.clear, FullScreenMovieControlMode.CancelOnInput, FullScreenMovieScalingMode.Fill);
//				yield return new WaitForSeconds (0.01f);
//		
//				GameData.SCALE = new Vector2 (800f / Screen.width, 480f / Screen.height);
//				GameData.MATRIX_SCALING = Matrix4x4.TRS (Vector3.zero, Quaternion.identity,
//		                                         new Vector3 (Screen.width / 800f, Screen.height / 480f, 1f));
//
//				TimeSpan timeSpan = new TimeSpan (DateTime.Now.Ticks - ProfileManager.dailyBonusProfile.LastLogin.Ticks);
//				if (timeSpan.TotalHours <= 24) {
//						Application.LoadLevel ("DailyLogin");
//				} else {
//						Application.LoadLevel ("MainMenu");
//				}
//		}
}