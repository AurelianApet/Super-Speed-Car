using UnityEngine;
using System.Collections;
using com.dev.util.lib.Pathfinding;

public class Map : MonoBehaviour
{
		public static int NUMBER_SPAWN_POINTS = 6;

		//
		public Transform[] spawnPointsList;
		public Transform[] cameraPoint;

		//
		public Transform origin;
		public Transform worldEnd;

		//
		public Path[] path;
		public Transform[] checkPointList;

		//
		public FinishTextController[] finishTextController;
		bool isActivate = false;
	
		void Start ()
		{
				if (GameData.selectedMode != GameData.GAME_MODE.CHECK_POINT) {
						for (int i=0; i<checkPointList.Length; i++) {
								checkPointList [i].gameObject.SetActive (false);
						}
				}

				for (int i=0; i<finishTextController.Length; i++) {
						finishTextController [i].gameObject.SetActive (false);
				}
		}
	
		public void resetCheckPoint ()
		{
				if (GameData.selectedMode == GameData.GAME_MODE.CHECK_POINT) {
						for (int i=0; i<checkPointList.Length; i++) {
								checkPointList [i].gameObject.SetActive (true);
						}
				}
		}

		public void activateFinishText ()
		{
				if (this.isActivate == false) {
						this.isActivate = true;
						for (int i=0; i<finishTextController.Length; i++) {
								finishTextController [i].gameObject.SetActive (true);
						}
				}
		}
}