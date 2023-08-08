using UnityEngine;
using System.Collections;

public class FinishTextController : MonoBehaviour
{
		public static float RADIUS = 30.0F;
		public static float POWER = 2000.0F;
	
		//
		bool isCollision = false;
	
		void OnCollisionEnter (Collision collision)
		{
				if (this.isCollision == false) {
						if (collision.gameObject.layer == LayerDefinition.PLAYER) {
								this.isCollision = true;

								Vector3 explosionPos = transform.position;
								Collider[] colliders = Physics.OverlapSphere (explosionPos, RADIUS);
								foreach (Collider hit in colliders) {
										if (hit && hit.rigidbody)
												hit.rigidbody.AddExplosionForce (POWER * this.rigidbody.mass, explosionPos, RADIUS, 10.0F);
					
								}
				
								StartCoroutine (selfDestruct ());

						} else if (collision.gameObject.layer != LayerDefinition.MAP) {
								this.isCollision = true;
				
								StartCoroutine (selfDestruct ());
						}
				}
		}
	
		IEnumerator selfDestruct ()
		{
				yield return new WaitForSeconds (3);
				Destroy (this.gameObject);
		}
}
