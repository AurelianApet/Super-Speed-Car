using UnityEngine;
using System.Collections;

public class Settings : Profile
{
		static string SOUND = "sound";
		static string MUSIC = "music";
		static string SENSITIVITY = "sensitivity";
		static string VIBRATE = "vibrate";
		static string CONTROLLER = "controllerTilt";
		static string QUALITY = "quality";

		//
		private float soundVolume;
	
		public float SoundVolume {
				get {
						return soundVolume;
				}
				set {
						this.soundVolume = value;
						this.setFloat (SOUND, soundVolume);
				}
		}
	
		private float musicVolume;
	
		public float MusicVolume {
				get {
						return musicVolume;
				}
				set {
						this.musicVolume = value;
						this.setFloat (MUSIC, musicVolume);
				}
		}
	
		private float sensitivity;
	
		public float Sensitivity {
				get {
						return sensitivity;
				}
				set {
						this.sensitivity = value;
						this.setFloat (SENSITIVITY, sensitivity);
				}
		}
	
		private bool isVibrate;
	
		public bool IsVibrate {
				get {
						return isVibrate;
				}
				set {
						this.isVibrate = value;
						this.setBool (VIBRATE, isVibrate);
				}
		}

		private bool controllerTilt;
	
		public bool ControllerTilt {
				get {
						return controllerTilt;
				}
				set {
						this.controllerTilt = value;
						this.setBool (CONTROLLER, controllerTilt);
				}
		}

		private int quality;
	
		public int Quality {
				get {
						return quality;
				}
				set {
						this.quality = value;
						this.setInt (QUALITY, quality);
				}
		}

		public override void saveDefaultValue ()
		{
				this.SoundVolume = 100f;
				this.MusicVolume = 100f;
				this.Sensitivity = 75f;

				this.IsVibrate = true;		
				this.ControllerTilt = true;
				this.Quality = 1;
		}
	
		public override void load ()
		{
				this.soundVolume = this.getFloat (SOUND);
				this.musicVolume = this.getFloat (MUSIC);
				this.sensitivity = this.getFloat (SENSITIVITY);
				this.isVibrate = this.getBool (VIBRATE);
				this.controllerTilt = this.getBool (CONTROLLER);
				this.quality = this.getInt (QUALITY);
		}
}
