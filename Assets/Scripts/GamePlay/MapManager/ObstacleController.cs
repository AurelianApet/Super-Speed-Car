using UnityEngine;
using System.Collections;

public class ObstacleController : CachingMonoBehaviour
{
		public static float RADIUS = 5.0F;
		public static float POWER = 2500.0F;

		//
		bool isCollision = false;
		Game game;

		void Start ()
		{
				game = GameObject.FindObjectOfType<Game> ();
		}

		void OnCollisionEnter (Collision collision)
		{
				if (this.isCollision == false) {
						if (collision.gameObject.layer == LayerDefinition.PLAYER || 
								collision.gameObject.layer == LayerDefinition.ENEMY || collision.gameObject.layer == LayerDefinition.POLICE) {
								this.isCollision = true;

								Vector3 explosionPos = transform.position;
								Collider[] colliders = Physics.OverlapSphere (explosionPos, RADIUS);
								foreach (Collider hit in colliders) {
										if (hit && hit.rigidbody)
												hit.rigidbody.AddExplosionForce (POWER * this.rigidbody.mass, explosionPos, RADIUS, 10.0F);
					
								}

								CarData carData = collision.gameObject.GetComponent<CarData> ();
								if (carData != null) {
										if (carData.ID == BaseCarManager.mainPlayerID) {
												game.carManager.MainPlayer.carData.TotalObstacleCollision += 1;
												game.carManager.MainPlayer.carData.WantedBar += 3;
										}
								}

								StartCoroutine (selfDestruct (3));
						} else if (collision.gameObject.layer != LayerDefinition.MAP) {
								this.isCollision = true;

								StartCoroutine (selfDestruct (1));
						}
				}
		}

		IEnumerator selfDestruct (float time)
		{
				yield return new WaitForSeconds (time);
				Destroy (this.gameObject);
		}
}