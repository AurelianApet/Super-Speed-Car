using UnityEngine;
using System.Collections;

//using GooglePlayGames;

public class LevelPanel : MonoBehaviour
{
	public MainMenuSound mainMenuSound;		

	//
	public Texture sunny;
	public Texture rainy;
	public Texture[] mapPreviewImage;
	public dfTextureSprite weatherSprite;
	public dfTextureSprite mapSprite;
	public dfSprite[] seasonImage;

	//
	public dfPanel levelPanel;
	public dfScrollPanel worldMap;

	//
	public dfTextureSprite raceMode;
	public dfSprite[] star;
	public dfButton nextLevel;
	public dfButton prevLevel;
	public dfButton nextSeasonButton;
	public dfButton prevSeasonButton;

	//
	public dfLabel raceInfo;
	public dfLabel mapName;
	public dfLabel levelName;
	public dfLabel levelModeLabel;
	public dfLabel mission_1;
	public dfLabel mission_2;

	//
	public dfLabel unlockText;
	public dfButton playButton;

	//
	public dfTweenVector2 levelTweenAnimation;

	//
	int level = 1;
	int selectedSeason;
	bool isCanPlay;

	//
	bool isLoadingLevel;

	public void Start ()
	{
		StartCoroutine (updatePos ());
	}

	IEnumerator updatePos ()
	{			
		yield return new WaitForSeconds (0.1f);

		level = ProfileManager.userProfile.SelectedLevel;
			
		selectedSeason = SeasonDescription.getSeason (level + 1);
		seasonImage [selectedSeason - 1].IsVisible = true;
		
		this.updateMap (true);
	}

	public void next ()
	{
		if (isLoadingLevel == false) {
			mainMenuSound.ButtonClick ();

			int firstLevel = SeasonDescription.getFirstLevelInSeason (selectedSeason);
			level++;
			if (level >= firstLevel + SeasonDescription.getNumberLevelBySeason (selectedSeason)) {
				level = firstLevel;
			}

			this.updateMap (ProfileManager.userProfile.isLevelUnlocked (level));
		}
	}

	public void prev ()
	{
		if (isLoadingLevel == false) {
			mainMenuSound.ButtonClick ();

			int firstLevel = SeasonDescription.getFirstLevelInSeason (selectedSeason);
			level--;
			if (level < firstLevel) {
				level = firstLevel + SeasonDescription.getNumberLevelBySeason (selectedSeason) - 1;
			}
				
			this.updateMap (ProfileManager.userProfile.isLevelUnlocked (level));
		}
	}
	
	public void nextSeason ()
	{		
		if (isLoadingLevel == false) {
			mainMenuSound.ButtonClick ();

			selectedSeason++;
			if (selectedSeason > 8) {
				selectedSeason = 1;
			}

			level = ProfileManager.userProfile.getLastSelectedLevelInSeason (selectedSeason);

			if (ProfileManager.userProfile.isLevelUnlocked (level) == true &&
				ProfileManager.userProfile.isSeasonUnlocked (selectedSeason) == true) {
				this.updateMap (true);

			} else {
				this.updateMap (false);
			}

			for (int index=0; index<seasonImage.Length; index++) {
				seasonImage [index].IsVisible = false;
			}
			seasonImage [selectedSeason - 1].IsVisible = true;
		}
	}

	public void prevSeason ()
	{
		if (isLoadingLevel == false) {
			mainMenuSound.ButtonClick ();
		
			selectedSeason--;
			if (selectedSeason < 1) {
				selectedSeason = 8;
			}
		
			level = ProfileManager.userProfile.getLastSelectedLevelInSeason (selectedSeason);
		
			if (ProfileManager.userProfile.isLevelUnlocked (level) == true &&
				ProfileManager.userProfile.isSeasonUnlocked (selectedSeason) == true) {
				this.updateMap (true);
			
			} else {
				this.updateMap (false);
			}

			for (int index=0; index<seasonImage.Length; index++) {
				seasonImage [index].IsVisible = false;
			}
			seasonImage [selectedSeason - 1].IsVisible = true;
		}
	}

	public void play ()
	{
		mainMenuSound.ButtonClick ();

		if (isCanPlay == true) {
			GameData.isSinglePlayer = true;

			isLoadingLevel = true;
			AutoFade.LoadLevel ("Load");
		}
	}

	public void updateMap (bool isLevelCanSelected)
	{
		GameData.level = level;	
		LevelDescription.configLevel (level);		

		if (isLevelCanSelected == true) {
			ProfileManager.userProfile.SelectedLevel = level;

			playButton.NormalBackgroundColor = new Color (1, 1, 1, 0);
			unlockText.Text = string.Empty;
			this.isCanPlay = true;

			ProfileManager.userProfile.saveLastSelectedLevelInSeason (selectedSeason, GameData.level);

		} else {
			this.isCanPlay = false;

			if (ProfileManager.userProfile.isSeasonUnlocked (SeasonDescription.getSeason (GameData.level + 1)) == false) {
				playButton.NormalBackgroundColor = new Color (0, 0, 0, 0.5f);
				unlockText.Text = SeasonDescription.getNumberStarsToUnlock (SeasonDescription.getSeason (GameData.level + 1)) + "  stars  to  unlock";
			} else {
				playButton.NormalBackgroundColor = new Color (0, 0, 0, 0.5f);
				unlockText.Text = "Finish  previous  level  to  unlock";
			}
		}
		
		levelPanel.Position = getLocationPosition (GameData.selectedMap);
		levelTweenAnimation.StartValue = new Vector2 (worldMap.ScrollPosition.x, worldMap.ScrollPosition.y);		
		levelTweenAnimation.EndValue = getScrollPosition (GameData.selectedMap);
		levelTweenAnimation.Play ();
		
		mapName.Text = GameData.selectedMap.ToString ().ToUpper ().Replace ("_", " ");

		levelName.Text = (level + 1).ToString ();
		levelModeLabel.Text = GameData.selectedMode.ToString ().ToUpper ().Replace ("_", " ");

		int numberStar = ProfileManager.userProfile.MapProfile [level].MainMission;

		for (int index=0; index<numberStar; index++) {
			star [index].IsVisible = true;
		}

		for (int index=numberStar; index<3; index++) {
			star [index].IsVisible = false;
		}

		if (ProfileManager.userProfile.MapProfile [level].FirstMission == true) {
			star [3].IsVisible = true;
		} else {
			star [3].IsVisible = false;
		}

		if (ProfileManager.userProfile.MapProfile [level].SecondMission == true) {
			star [4].IsVisible = true;
		} else {
			star [4].IsVisible = false;
		}

		switch (GameData.selectedMode) {
		case GameData.GAME_MODE.CLASSIC:
			raceInfo.Text = GameData.numberRaces + " lap(s)";
			break;

		case GameData.GAME_MODE.TIME_TRIAL:
			raceInfo.Text = GameData.durationFirst + " sec";
			break;

		case GameData.GAME_MODE.CHECK_POINT:
			raceInfo.Text = GameData.numberCheckpoints + " points";
			break;

		case GameData.GAME_MODE.ELIMINATION:
			raceInfo.Text = GameData.numberPlayers + " NPCs";
			break;

		default:
			break;
		}

		mission_1.Text = MissionDescription.getFirstMission (level);
		mission_2.Text = MissionDescription.getSecondMission (level);

		if (GameData.selectedMap == GameData.MAP_NAME.CHINA || GameData.selectedMap == GameData.MAP_NAME.EGYPT) {
			weatherSprite.Texture = rainy;
		} else {
			weatherSprite.Texture = sunny;
		}

		mapSprite.Texture = mapPreviewImage [(int)GameData.selectedMap];
	}

	public static Vector3 getLocationPosition (GameData.MAP_NAME mapName)
	{
		switch (mapName) {
		case GameData.MAP_NAME.EGYPT:
			return new Vector3 (675, -136, 0);
			
		case GameData.MAP_NAME.BRAZIL:
			return new Vector3 (270, -361, 0);
			
		case GameData.MAP_NAME.CHINA:
			return new Vector3 (1049, -88, 0);
			
		case GameData.MAP_NAME.VIET_NAM:
			return new Vector3 (1070, -190, 0);
			
		case GameData.MAP_NAME.INDIA:
			return new Vector3 (932, -209, 0);
			
		case GameData.MAP_NAME.PHILIPPINES:
			return new Vector3 (1150, -216, 0);
			
		case GameData.MAP_NAME.THAILAND:
			return new Vector3 (1055, -214, 0);
			
		case GameData.MAP_NAME.USA:
			return new Vector3 (40, -74, 0);
			
		default:
			return Vector3.zero;
		}
	}
	
	public static Vector2 getScrollPosition (GameData.MAP_NAME mapName)
	{
		switch (mapName) {
		case GameData.MAP_NAME.EGYPT:
			return new Vector2 (517, 75);
			
		case GameData.MAP_NAME.BRAZIL:
			return new Vector2 (60, 286);
			
		case GameData.MAP_NAME.CHINA:
			return new Vector2 (800, 0);
			
		case GameData.MAP_NAME.VIET_NAM:
			return new Vector2 (800, 107);
			
		case GameData.MAP_NAME.INDIA:
			return new Vector2 (733, 141);
			
		case GameData.MAP_NAME.PHILIPPINES:
			return new Vector2 (800, 100);
			
		case GameData.MAP_NAME.THAILAND:
			return new Vector2 (800, 109);
			
		case GameData.MAP_NAME.USA:
			return new Vector2 (0, 0);
			
		default:
			return Vector2.zero;
		}
	}
}