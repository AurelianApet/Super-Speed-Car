using UnityEngine;
using System.Collections;

public class ItemController : CachingMonoBehaviour
{
		GameData.ITEM_TYPE itemType;

		void Start ()
		{
				if (this.gameObject.name == "BlueNitro") {
						itemType = GameData.ITEM_TYPE.BLUE_NITRO;

				} else if (this.gameObject.name == "RedNitro") {
						itemType = GameData.ITEM_TYPE.RED_NITRO;

				} else if (this.gameObject.name == "GreenDollar") {		
						itemType = GameData.ITEM_TYPE.GREEN_DOLLAR;

				} else if (this.gameObject.name == "GoldDollar") {
						itemType = GameData.ITEM_TYPE.GOLD_DOLLAR;
				}
		}

		void OnTriggerEnter (Collider other)
		{
				if (Game.gameState == Game.GAME_STATE.RUNNING) {
						if (other.transform.root.gameObject.layer == LayerDefinition.PLAYER || other.transform.root.gameObject.layer == LayerDefinition.ENEMY) {
								CarData carData = other.gameObject.GetComponent<CarData> ();
								if (carData != null) {
										if (carData.ID == BaseCarManager.mainPlayerID) {
												switch (itemType) {
												case GameData.ITEM_TYPE.BLUE_NITRO:
														carData.lightBlastController.activateLightBlast ();
														carData.CarController.game.soundManager.playItem ();
					
														carData.LastNitroEarned = 20 * (GameData.IsDoubleNitro == true ? 2 : 1);
														carData.NitroBar += carData.LastNitroEarned;
														carData.NitroEarned += carData.LastNitroEarned;
														carData.LastNitroEarnedTime = Time.timeSinceLevelLoad;
														break;

												case GameData.ITEM_TYPE.RED_NITRO:
														carData.lightBlastController.activateLightBlast ();					
														carData.CarController.game.soundManager.playItem ();
					
														carData.LastNitroEarned = 40 * (GameData.IsDoubleNitro == true ? 2 : 1);
														carData.NitroBar += carData.LastNitroEarned;
														carData.NitroEarned += carData.LastNitroEarned;
														carData.LastNitroEarnedTime = Time.timeSinceLevelLoad;
														break;

												case GameData.ITEM_TYPE.GREEN_DOLLAR:		
														carData.lightBlastController.activateLightBlast ();
														carData.CarController.game.soundManager.playItem ();

														carData.LastDollarEarned = 50 * (GameData.IsDoubleReward == true ? 2 : 1);
														carData.TotalDollarEarned += carData.LastDollarEarned;
														carData.LastDollarEarnedTime = Time.timeSinceLevelLoad;
														break;

												case GameData.ITEM_TYPE.GOLD_DOLLAR:
														carData.lightBlastController.activateLightBlast ();
														carData.CarController.game.soundManager.playItem ();
					
														carData.LastDollarEarned = 100 * (GameData.IsDoubleReward == true ? 2 : 1);
														carData.TotalDollarEarned += carData.LastDollarEarned;
														carData.LastDollarEarnedTime = Time.timeSinceLevelLoad;
														break;

												default:
														break;
												}
										} else {
												if (ProfileManager.setttings.Quality > 0) {
														carData.lightBlastController.activateLightBlast ();
												}
										}

										this.renderer.enabled = false;
										this.collider.enabled = false;
										StartCoroutine (resetItem ());
								}
						}
				}
		}

		IEnumerator resetItem ()
		{
				yield return new WaitForSeconds (1);

				this.renderer.enabled = true;
				this.collider.enabled = true;
		}
}
