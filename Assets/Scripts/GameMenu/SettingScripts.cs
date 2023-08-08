using UnityEngine;
using System.Collections;

public class SettingScripts : MonoBehaviour
{
	public MainMenuSound mainMenuSound;

	//
	public dfButton lowQualityButton;
	public dfButton mediumQualityButton;
	public dfButton highQualityButton; 

	//
	public dfButton touchButton;
	public dfButton tiltButton; 

	//
	public dfButton vibrateOn;
	public dfButton vibrateOff;

	//
	public dfSlider musicBar;
	public dfSlider soundBar;
	public dfSlider handlingBar;

	void Start ()
	{
		switch (ProfileManager.setttings.Quality) {
		case 0:
			this.lowQualityButton.IsEnabled = false;
			this.mediumQualityButton.IsEnabled = true;
			this.highQualityButton.IsEnabled = true;
			break;

		case 1:
			this.lowQualityButton.IsEnabled = true;
			this.mediumQualityButton.IsEnabled = false;
			this.highQualityButton.IsEnabled = true;
			break;

		case 2:
			this.lowQualityButton.IsEnabled = true;
			this.mediumQualityButton.IsEnabled = true;
			this.highQualityButton.IsEnabled = false;
			break;

		default:
			break;
		}

		if (ProfileManager.setttings.ControllerTilt == true) {
			this.touchButton.IsEnabled = true;
			this.tiltButton.IsEnabled = false;
		} else {
			this.touchButton.IsEnabled = false;
			this.tiltButton.IsEnabled = true;
		}

		if (ProfileManager.setttings.IsVibrate == true) {
			this.vibrateOn.IsEnabled = false;
			this.vibrateOff.IsEnabled = true;
		} else {
			this.vibrateOn.IsEnabled = true;
			this.vibrateOff.IsEnabled = false;
		}

		musicBar.Value = ProfileManager.setttings.MusicVolume;
		soundBar.Value = ProfileManager.setttings.SoundVolume;
		handlingBar.Value = ProfileManager.setttings.Sensitivity;

		mainMenuSound.mainMusic.volume = ProfileManager.setttings.MusicVolume / 100f;
		mainMenuSound.mainMusic.Play ();
	}

	void Update ()
	{
		if (ProfileManager.setttings.MusicVolume != musicBar.Value) {
			ProfileManager.setttings.MusicVolume = musicBar.Value;
		}

		if (ProfileManager.setttings.SoundVolume != soundBar.Value) {
			ProfileManager.setttings.SoundVolume = soundBar.Value;
		}

		if (ProfileManager.setttings.Sensitivity != handlingBar.Value) {
			ProfileManager.setttings.Sensitivity = handlingBar.Value;
		}

		mainMenuSound.mainMusic.volume = ProfileManager.setttings.MusicVolume / 100f;
	}

	public void lowQualityOnClick ()
	{
		mainMenuSound.ButtonClick ();

		this.lowQualityButton.IsEnabled = false;
		this.mediumQualityButton.IsEnabled = true;
		this.highQualityButton.IsEnabled = true;

		ProfileManager.setttings.Quality = 0;
		PlayerPrefs.Save ();
	}

	public void mediumQualityOnClick ()
	{
		mainMenuSound.ButtonClick ();

		this.lowQualityButton.IsEnabled = true;
		this.mediumQualityButton.IsEnabled = false;
		this.highQualityButton.IsEnabled = true;

		ProfileManager.setttings.Quality = 1;
		PlayerPrefs.Save ();
	}

	public void highQualityOnClick ()
	{
		mainMenuSound.ButtonClick ();

		this.lowQualityButton.IsEnabled = true;
		this.mediumQualityButton.IsEnabled = true;
		this.highQualityButton.IsEnabled = false;

		ProfileManager.setttings.Quality = 2;
		PlayerPrefs.Save ();
	}

	public void touchOnClick ()
	{
		mainMenuSound.ButtonClick ();

		this.touchButton.IsEnabled = false;
		this.tiltButton.IsEnabled = true;
		
		ProfileManager.setttings.ControllerTilt = false;
		PlayerPrefs.Save ();
	}

	public void tiltOnClick ()
	{
		mainMenuSound.ButtonClick ();

		this.touchButton.IsEnabled = true;
		this.tiltButton.IsEnabled = false;
		
		ProfileManager.setttings.ControllerTilt = true;
		PlayerPrefs.Save ();
	}

	public void vibrateOnClick ()
	{
		mainMenuSound.ButtonClick ();

		this.vibrateOn.IsEnabled = false;
		this.vibrateOff.IsEnabled = true;
		
		ProfileManager.setttings.IsVibrate = true;
		PlayerPrefs.Save ();
	}

	public void vibrateOffClick ()
	{
		mainMenuSound.ButtonClick ();

		this.vibrateOn.IsEnabled = true;
		this.vibrateOff.IsEnabled = false;
		
		ProfileManager.setttings.IsVibrate = false;
		PlayerPrefs.Save ();
	}

	public void feedBack ()
	{
		string email = "kor2@sunnet.vn";
		string subject = MyEscapeURL ("Feedback for product King Of Racing 2: reborn");
		string body = MyEscapeURL ("I am " + ProfileManager.userProfile.PlayerName + ". \nHow do you feel about this game?\nTell us:\nRate game: 5/4/3/2/1 star");
		
		Application.OpenURL ("mailto:" + email + "?subject=" + subject + "&body=" + body);
	}

	string MyEscapeURL (string url)
	{
		return WWW.EscapeURL (url).Replace ("+", "%20");
	}
}