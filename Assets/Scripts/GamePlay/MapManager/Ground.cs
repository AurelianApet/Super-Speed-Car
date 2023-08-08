using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour
{
		Game game;

		void Start ()
		{
				game = GameObject.FindObjectOfType<Game> ();
		}

		void OnTriggerEnter (Collider other)
		{
				if (other.gameObject.layer == LayerDefinition.PLAYER || 
						other.gameObject.layer == LayerDefinition.ENEMY || other.gameObject.layer == LayerDefinition.POLICE) {
						CarData carData = other.gameObject.GetComponent<CarData> ();

						if (carData != null) {
								if (carData.ID == BaseCarManager.mainPlayerID) {
										game.carManager.respawnPlayerCar ();
								} else {
										game.carManager.respawnEnemyCar (carData.ID);
								}
						}
				}
		}
}
