using UnityEngine;
using System.Collections;

public class MainMenuSound : MonoBehaviour
{
		public AudioSource mainMusic;
		public AudioSource buttonClick;
		public AudioSource backSound;
		
		public void BackSound ()
		{
				backSound.Stop ();
				backSound.volume = ProfileManager.setttings.SoundVolume / 100f;
				backSound.Play ();
		}

		public void ButtonClick ()
		{
				buttonClick.Stop ();
				buttonClick.volume = ProfileManager.setttings.SoundVolume / 100f;
				buttonClick.Play ();
		}
}
