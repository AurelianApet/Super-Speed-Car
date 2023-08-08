using UnityEngine;
using System.Collections;

public class ChooseOnlineMode : BaseHeaderMenu
{
	public AudioSource audioSource;
	public AudioSource click;

	//
	public dfTextureSprite kingEventIcon;

	public void Start ()
	{
		ProfileManager.init ();

		audioSource.volume = ProfileManager.setttings.MusicVolume / 100f;
		audioSource.Play ();

		click.volume = ProfileManager.setttings.SoundVolume / 100f;
	}

	public void Update ()
	{
		if (Input.GetKeyUp (KeyCode.Escape)) {
			AutoFade.LoadLevel ("MainMenu");

		} else {
			this.updateInfo ();

			if (InternetGameMenu.isInKingOfDayEvent () == true) {
				kingEventIcon.IsVisible = true;
			} else {
				kingEventIcon.IsVisible = false;
			}
		}
	}

	public void chooseWifiMode ()
	{
		click.Play ();
		AutoFade.LoadLevel ("WifiGameMenu");
	}

	public void chooseInternetMode ()
	{				
		isJoinInvitedRoom = false;

		click.Play ();
		AutoFade.LoadLevel ("InternetGameMenu");
	}

	public void quit ()
	{
		click.Play ();
		AutoFade.LoadLevel ("MainMenu");
	}
}