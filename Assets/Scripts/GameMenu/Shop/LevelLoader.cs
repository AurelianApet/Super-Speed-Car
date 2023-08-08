using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
		public static bool isLoading = true;
		public static string levelName = "CarShop";
		public static string mainMenu = "MainMenu";
		public dfLabel tipLabel;
		private AsyncOperation async;
	
		void Start ()
		{
				if (isLoading) {
						Application.LoadLevelAsync (levelName);
				} else {
						Application.LoadLevelAsync (mainMenu);
				}
		
				tipLabel.Text = SceneLoader.getTip ();
		}
}