using UnityEngine;
using System.Collections;
using com.dev.util.lib.Pathfinding;

public class CarInfo
{
	Game game;
	Transform car;
	int id;

	public int ID {
		get {
			return id;
		}
	}

	//
	int numberRaces;

	public int NumberRaces {
		get {
			return numberRaces;
		}
	}
	
	//
	Vector3 direction;

	public Vector3 Direction {
		get {
			return direction;
		}
	}

	//
	float remainingDistance;

	public float RemainingDistance {
		get {
			return remainingDistance;
		}
		set {
			remainingDistance = value;
		}
	}
		
	//
	int nextWaypoint;

	public int NextWaypoint {
		get {
			return nextWaypoint;
		}
		set {
			nextWaypoint = value;
		}
	}
	
	//
	public CarData carData;	

	//
	Path[] pathList;
	PathChangingController pathChanger;

	public PathChangingController PathChanger {
		get {
			return pathChanger;
		}
		set {
			pathChanger = value;
		}
	}

	public CarInfo (Game game, GameObject carObject)
	{
		this.game = game;
		this.car = carObject.transform;

		this.carData = carObject.GetComponent<CarData> ();
		this.id = carData.ID;

		this.remainingDistance = 0;
		this.nextWaypoint = 0;
		this.numberRaces = GameData.numberRaces;
		
		this.pathList = game.map.path;
	}

	public void Update ()
	{
		if (pathChanger != null) {
			if (pathList [pathChanger.subPathID].isReachWaypoint (car.transform.position, nextWaypoint)) {
				nextWaypoint = pathList [pathChanger.subPathID].getNextWaypoint (nextWaypoint);
			}
			
			remainingDistance = Vector3.Distance (car.transform.position,
			                                      pathList [pathChanger.subPathID].waypointList [nextWaypoint].waypointPos)
				+ pathList [pathChanger.subPathID].fastGetDistance (nextWaypoint, 
				                                                    pathList [pathChanger.subPathID].waypointList.Length - 1, 0)
				+ pathList [0].fastGetDistance (pathChanger.outWaypointID, 0, numberRaces);
			
			direction = pathList [pathChanger.subPathID].waypointList [nextWaypoint].waypointPos - 
				pathList [pathChanger.subPathID].waypointList [pathList [pathChanger.subPathID].getPreviousWaypoint (nextWaypoint)].waypointPos;
			
		} else {
			if (pathList [0].isReachWaypoint (car.transform.position, nextWaypoint)) {
				if (nextWaypoint == 0) {
					numberRaces--;
					if (this.id == BaseCarManager.mainPlayerID) {
						game.map.resetCheckPoint ();
					}
				}
				
				nextWaypoint = pathList [0].getNextWaypoint (nextWaypoint);
			}
			
			remainingDistance = Vector3.Distance (car.transform.position, pathList [0].waypointList [nextWaypoint].waypointPos)
				+ pathList [0].fastGetDistance (nextWaypoint, 0, numberRaces);
			
			direction = pathList [0].waypointList [nextWaypoint].waypointPos - 
				pathList [0].waypointList [pathList [0].getPreviousWaypoint (nextWaypoint)].waypointPos;
		}		
		
		if (id == BaseCarManager.mainPlayerID) {
			if (remainingDistance <= 200) {
				if (GameData.selectedMode != GameData.GAME_MODE.ELIMINATION) {
					game.map.activateFinishText ();
				}
			}
		}
	}

	public Vector3 getNextWaypointPos ()
	{
		if (pathChanger == null) {
			return pathList [0].waypointList [nextWaypoint].waypointPos;
		} else {
			return pathList [pathChanger.subPathID].waypointList [nextWaypoint].waypointPos;
		}
	}
	
	public Vector3 getCurrentWaypointPos ()
	{
		if (pathChanger == null) {
			return pathList [0].waypointList [pathList [0].getPreviousWaypoint (nextWaypoint)].waypointPos;
		} else {
			return pathList [pathChanger.subPathID].waypointList [pathList [pathChanger.subPathID].getPreviousWaypoint (nextWaypoint)].waypointPos;
		}
	}

	public Vector3 getPreviousWaypointPos (int offset)
	{
		if (pathChanger == null) {
			return pathList [0].waypointList [pathList [0].getPreviousWaypoint (nextWaypoint, offset)].waypointPos;
		} else {
			return pathList [pathChanger.subPathID].waypointList [pathList [pathChanger.subPathID].getPreviousWaypoint (nextWaypoint, offset)].waypointPos;
		}
	}
	
	public bool isWrongWay ()
	{
//		if (GameData.isSinglePlayer == true) {
//			if (Vector3.Dot (direction.normalized, car.transform.forward.normalized) < -0.5f) {
//				return true;
//			} else {
//				return false;
//			}
//		} else {
//			if (id == game.carManager.MainPlayer.carData.ID) {
//				if (Vector3.Dot (direction.normalized, car.transform.forward.normalized) < -0.5f) {
//					return true;
//				} else {
//					return false;
//				}
//			} else {
				return false;
//			}
//		}
	}
}