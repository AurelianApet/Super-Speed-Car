using UnityEngine;
using System.Collections;

public class SlopeController : MonoBehaviour
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
				carData.IsFly = true;

				if (carData.ID == BaseCarManager.mainPlayerID) {
					carData.CarController.useNitro (false);
					game.carManager.MainPlayer.carData.WantedBar += 3;

					game.autoCam.changePivot (new Vector3 (0, 2, -1));
					game.soundManager.playCarFly ();
				}
			}
		}
	}
}
