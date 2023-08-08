using UnityEngine;
using System.Collections;

public class PlayerCarController : BaseCarController
{
	public static float MIN_RAYCAST_DISTANCE = 20;
	
	//
	int nextWaypoint;
	Vector3 direction;
	float signedAngle;
	
	//
	float distanceRaycast;
	RaycastHit hit;
	ObstacleInfo obstacleInfo;
	ObstacleInfo.ObstacleAvoidance obstacleAvoidance;

	public PlayerCarController (CarData carData):base(carData)
	{
		this.obstacleInfo = new ObstacleInfo ();
	}

	public override void getHandlingInput ()
	{
		if (GameData.IsAutoSteer == false) {
			if (Application.isEditor != true) {
				if (ProfileManager.setttings.ControllerTilt == true) {
					if (Input.acceleration.x > 0.1f || Input.acceleration.x < -0.1f) {
						handlingInfo.steer = Input.acceleration.x * (ProfileManager.setttings.Sensitivity + 100) / 100;
					} else {
						handlingInfo.steer = 0;
					}
				} 
			} else {
				if (ProfileManager.setttings.ControllerTilt == true) {
					handlingInfo.steer = Input.GetAxis ("Horizontal") * (ProfileManager.setttings.Sensitivity + 100) / 100;
				}
			}
		} else {
			if (game.map.path [0].isReachWaypoint (carData.transform.position, nextWaypoint)) {			
				nextWaypoint = (nextWaypoint + 1) % game.map.path [0].waypointList.Length;								
			} 
			
			distanceRaycast = carData.VelocityMagnitude;
			
			if (distanceRaycast < MIN_RAYCAST_DISTANCE) {
				distanceRaycast = MIN_RAYCAST_DISTANCE;
			}
			
			Debug.DrawRay (carData.transform.position, carData.transform.forward * distanceRaycast, Color.green);
			Debug.DrawRay (carData.transform.position, (carData.transform.forward + carData.transform.right / 2) * distanceRaycast, Color.green);
			Debug.DrawRay (carData.transform.position, (carData.transform.forward - carData.transform.right / 2) * distanceRaycast, Color.green);
			
			if (Physics.Raycast (carData.transform.position, carData.transform.forward * distanceRaycast, out hit, distanceRaycast)) {
				obstacleInfo.calculateAvoidancePriority (hit.collider.gameObject.layer, hit.distance, ObstacleInfo.ObstacleAvoidance.STRAIGHT);
			} else {
				obstacleInfo.calculateAvoidancePriority (0, 0, ObstacleInfo.ObstacleAvoidance.STRAIGHT);
			}
			
			if (Physics.Raycast (carData.transform.position, (carData.transform.forward + carData.transform.right / 2) * distanceRaycast, out hit, distanceRaycast)) {
				obstacleInfo.calculateAvoidancePriority (hit.collider.gameObject.layer, hit.distance, ObstacleInfo.ObstacleAvoidance.RIGHT);
			} else {
				obstacleInfo.calculateAvoidancePriority (0, 0, ObstacleInfo.ObstacleAvoidance.RIGHT);
			}
			
			if (Physics.Raycast (carData.transform.position, (carData.transform.forward - carData.transform.right / 2) * distanceRaycast, out hit, distanceRaycast)) {
				obstacleInfo.calculateAvoidancePriority (hit.collider.gameObject.layer, hit.distance, ObstacleInfo.ObstacleAvoidance.LEFT);
			} else {
				obstacleInfo.calculateAvoidancePriority (0, 0, ObstacleInfo.ObstacleAvoidance.LEFT);
			}
			
			obstacleAvoidance = obstacleInfo.getAvoidanceDirection ();

			if (game.map.path [0].isValidWaypointIndex (nextWaypoint)) {		
				direction = (game.map.path [0].waypointList [nextWaypoint].waypointPos -
					carData.transform.position);
				this.signedAngle = SignedAngleBetween (direction, carData.transform.forward, Vector3.up);
				
				if (this.signedAngle <= 360 && this.signedAngle > 270) {
					this.handlingInfo.steer = Mathf.Lerp (this.handlingInfo.steer,
					                                      (360 - this.signedAngle) / 180, Time.deltaTime * 20);
					
				} else if (this.signedAngle >= 0 && this.signedAngle < 90) {
					this.handlingInfo.steer = Mathf.Lerp (this.handlingInfo.steer,
					                                      0 - (90 - this.signedAngle) / 180, Time.deltaTime * 20);						
				} 
			}
			
			switch (obstacleAvoidance) {
			case ObstacleInfo.ObstacleAvoidance.STRAIGHT:								
				break;
				
			case ObstacleInfo.ObstacleAvoidance.LEFT:
				handlingInfo.steer += -0.2f;
				break;
				
			case ObstacleInfo.ObstacleAvoidance.RIGHT:
				handlingInfo.steer += 0.2f;
				break;
				
			default:
				break;
			}
		}
	}
}