using UnityEngine;
using System.Collections;

public class QuickRace : BaseHeaderMenu
{
		public dfSprite[] modeImage;
		public dfSprite[] mapImage;
		public dfLabel mapName;

		//
		public AudioSource audioSource;
		public AudioSource click;

		void Start ()
		{
				ProfileManager.init ();

				for (int i=0; i<modeImage.Length; i++) {
						modeImage [i].gameObject.SetActive (false);
				}
				modeImage [(int)GameData.selectedMode].gameObject.SetActive (true);

				for (int i=0; i<mapImage.Length; i++) {
						mapImage [i].gameObject.SetActive (false);
				}
				mapImage [(int)GameData.selectedMap].gameObject.SetActive (true);

				audioSource.volume = ProfileManager.setttings.MusicVolume / 100f;
				audioSource.Play ();

				click.volume = ProfileManager.setttings.SoundVolume / 100f;

				LevelLoader.isLoading = true;
		}

		void Update ()
		{
				if (Input.GetKeyUp (KeyCode.Escape)) {
						AutoFade.LoadLevel ("MainMenu");

				} else {
						this.updateInfo ();
				}

				mapName.Text = GameData.selectedMap.ToString ().ToUpper ().Replace ('_', ' ');
		}

		public void nextMode ()
		{
				click.Play ();

				modeImage [(int)GameData.selectedMode].gameObject.SetActive (false);

				int mode = (int)GameData.selectedMode;
				mode = (mode + 1) % 4;
				GameData.selectedMode = (GameData.GAME_MODE)mode;

				modeImage [(int)GameData.selectedMode].gameObject.SetActive (true);
		}
	
		public void prevMode ()
		{
				click.Play ();

				modeImage [(int)GameData.selectedMode].gameObject.SetActive (false);
		
				int mode = (int)GameData.selectedMode;
				mode--;
				if (mode < 0) {
						mode = 3;
				}
				GameData.selectedMode = (GameData.GAME_MODE)mode;
		
				modeImage [(int)GameData.selectedMode].gameObject.SetActive (true);
		}

		public void nextMap ()
		{
				click.Play ();

				mapImage [(int)GameData.selectedMap].gameObject.SetActive (false);
		
				int map = (int)GameData.selectedMap;
				map = (map + 1) % 8;
				GameData.selectedMap = (GameData.MAP_NAME)map;
		
				mapImage [(int)GameData.selectedMap].gameObject.SetActive (true);
		}

		public void prevMap ()
		{
				click.Play ();

				mapImage [(int)GameData.selectedMap].gameObject.SetActive (false);
		
				int map = (int)GameData.selectedMap;
				map--;
				if (map < 0) {
						map = 7;
				}
				GameData.selectedMap = (GameData.MAP_NAME)map;
		
				mapImage [(int)GameData.selectedMap].gameObject.SetActive (true);
		}

		public void back ()
		{
				click.Play ();
		
				AutoFade.LoadLevel ("MainMenu");
		}

		public void random ()
		{
				click.Play ();

				modeImage [(int)GameData.selectedMode].gameObject.SetActive (false);
				mapImage [(int)GameData.selectedMap].gameObject.SetActive (false);

				GameData.selectedMode = (GameData.GAME_MODE)Random.Range (0, 4);
				GameData.selectedMap = (GameData.MAP_NAME)Random.Range (0, 8);

				modeImage [(int)GameData.selectedMode].gameObject.SetActive (true);
				mapImage [(int)GameData.selectedMap].gameObject.SetActive (true);
		}

		public void raceNow ()
		{
				click.Play ();

				GameData.isSinglePlayer = true;
				GameData.level = -1;

				switch (GameData.selectedMode) {
				case GameData.GAME_MODE.CLASSIC:
						GameData.numberRaces = 2;
						GameData.numberPlayers = 6;
						break;

				case GameData.GAME_MODE.TIME_TRIAL:
						GameData.numberRaces = 1;
						GameData.numberPlayers = 1;

						if (GameData.selectedMap == GameData.MAP_NAME.INDIA) {
								GameData.durationFirst = 80;
								GameData.durationSecond = 100;
								GameData.durationThird = 120;
						} else {
								GameData.durationFirst = 60;
								GameData.durationSecond = 70;
								GameData.durationThird = 80;
						}
						break;

				case GameData.GAME_MODE.CHECK_POINT:
						GameData.numberRaces = 2;
						GameData.numberPlayers = 5;

						GameData.numberCheckpoints = 8;
						break;

				case GameData.GAME_MODE.ELIMINATION:
						GameData.numberRaces = 2;
						GameData.numberPlayers = 6;
						break;

				default:
						break;
				}

				GameData.selectedEvent = -1;
				AutoFade.LoadLevel ("Load");
		}
}