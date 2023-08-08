using UnityEngine;
using System.Collections;
using com.dev.util.lib.Pathfinding;

public class VehicleController : CachingMonoBehaviour
{		
	public static float DISTANCE_TO_PLAYER = 30 * 30;
	public static float POWER = 2000.0f;

	//
	public Path path;

	//
	public float speed = 1;
	public int currentWaypoint = 0;
	public bool isReverse = false;
	public bool isBus = false;

	//
	public GameObject[] wheel;

	//
	Vector3 velocity;
	bool isCrash;

	void Start ()
	{
		Vector3 initialPosition = path.waypointList [currentWaypoint].waypointPos;
		initialPosition.y = this.transform.position.y;		

		this.transform.position = initialPosition;
		this.transform.rotation = Quaternion.LookRotation (path.waypointList [currentWaypoint].waypointPos - path.waypointList [path.getPreviousWaypoint (currentWaypoint)].waypointPos);
	}

	void FixedUpdate ()
	{
		if (path.isReachWaypoint (transform.position, currentWaypoint)) {	
			if (isReverse == false) {
				currentWaypoint = (currentWaypoint + 1) % path.waypointList.Length;		
			} else {
				currentWaypoint--;		
				if (currentWaypoint < 0) {
					currentWaypoint = path.waypointList.Length - 1;
				}
			}

		} else {			
			for (int i=0; i<wheel.Length; i++) {
				wheel [i].transform.Rotate (new Vector3 (speed * 40 * Time.deltaTime, 0, 0));
			}

			if (path.isValidWaypointIndex (currentWaypoint)) {
				velocity = (path.waypointList [currentWaypoint].waypointPos -
					transform.position).normalized * speed * Time.fixedDeltaTime;
				velocity.y = 0;		
						
				rigidbody.MovePosition (rigidbody.position + velocity);
				rigidbody.MoveRotation (Quaternion.RotateTowards (transform.rotation, Quaternion.LookRotation (velocity), 5f));
			}
		}
	}

	void OnCollisionEnter (Collision collision)
	{
		if (isBus == false) {
			if (collision.collider.gameObject.layer == LayerDefinition.PLAYER) {
				if (this.isCrash == false) {
					this.rigidbody.AddForceAtPosition (new Vector3 (0, POWER * this.rigidbody.mass, 0), ((BoxCollider)collider).bounds.max);	
					this.isCrash = true;

					StartCoroutine (resetPos (2, true));
				}
			} else if (collision.collider.gameObject.layer == LayerDefinition.ENEMY || collision.collider.gameObject.layer == LayerDefinition.POLICE) {
				if (this.isCrash == false) {
					this.isCrash = true;
					StartCoroutine (resetPos (1, false));
				}
			}
		}
	}

	IEnumerator resetPos (float waitTime, bool isPlayer)
	{
		yield return new WaitForSeconds (waitTime);
		this.isCrash = false;

		if (isPlayer == true) {
			Vector3 initialPosition = path.waypointList [currentWaypoint].waypointPos;
			initialPosition.y = this.transform.position.y;		

			this.transform.position = initialPosition;
			this.transform.rotation = Quaternion.LookRotation (path.waypointList [currentWaypoint].waypointPos - path.waypointList [path.getPreviousWaypoint (currentWaypoint)].waypointPos);
		}
	}
}