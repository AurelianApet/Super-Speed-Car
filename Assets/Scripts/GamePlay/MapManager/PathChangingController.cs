using UnityEngine;
using System.Collections;
using com.dev.util.lib.Pathfinding;

public class PathChangingController : MonoBehaviour
{
	public int mainPathID;
	public int subPathID;
	public int inWaypointID;
	public int outWaypointID;
	//
	Game game;
	Vector3 direction;
	
	void Start ()
	{
		game = GameObject.FindObjectOfType<Game> ();
		
		Path subPath = game.map.path [subPathID];
		
		if (inWaypointID < outWaypointID) {
			direction = subPath.waypointList [1].waypointPos - subPath.waypointList [0].waypointPos;
		} else {
			direction = subPath.waypointList [subPath.waypointList.Length - 1].waypointPos 
				- subPath.waypointList [subPath.waypointList.Length - 2].waypointPos;
		}

		direction = direction.normalized;
	}
	
	void OnTriggerExit (Collider other)
	{
		if (other.transform.root.gameObject.layer == LayerDefinition.PLAYER) {
			CarData carData = other.gameObject.GetComponent<CarData> ();

			if (carData != null) {
				if (carData.ID == BaseCarManager.mainPlayerID) {
					if (inWaypointID < outWaypointID) {
						if (Vector3.Dot (carData.rigidbody.velocity.normalized, direction) > -0.1f) {

							GameData.isGoShortCut = true;
							GameData.numberGoShortCut++;

							game.carManager.changePath (GameData.PATH_CHANGER_DIRECTION.OUT_IN, this, carData.ID);
//										Debug.Log ("out-in");
						} else {
							game.carManager.changePath (GameData.PATH_CHANGER_DIRECTION.OUT_OUT, this, carData.ID);
//										Debug.Log ("out-out");
						}
					} else {
						if (Vector3.Dot (carData.rigidbody.velocity.normalized, direction) > -0.1f) {	
							game.carManager.changePath (GameData.PATH_CHANGER_DIRECTION.IN_OUT, this, carData.ID);
//										Debug.Log ("in-out");
						} else {
							game.carManager.changePath (GameData.PATH_CHANGER_DIRECTION.IN_IN, this, carData.ID);
//										Debug.Log ("in-in");
						}
					}
				}
			}
		} else if (other.transform.root.gameObject.layer == LayerDefinition.ENEMY) {
			CarData carData = other.gameObject.GetComponent<CarData> ();

			StartCoroutine (resetEnemyCar (carData.ID));
		}
	}

	IEnumerator resetEnemyCar (int id)
	{			
		yield return new WaitForSeconds (2f);
		game.carManager.respawnEnemyCar (id);
	}
}