using UnityEngine;
using System.Collections;
using System;

public class MultiplayerCarManager : BaseCarManager
{
		public static float WIFI_RPC_DELTA_TIME = 0.04f;
		public static float INTERNET_RPC_DELTA_TIME = 0.08f;
	
		//
		public float lastSendRPC;
		public Vector3[] position;
		public Quaternion[] rotation;
		public float[] lastReceivePostion;
	
		//
		public int numberFinish;
	
		public MultiplayerCarManager (Game game):base(game)
		{
				this.position = new Vector3[GameData.numberPlayers];
				for (int i=0; i<this.position.Length; i++) {
						this.position [i] = game.map.spawnPointsList [i].position;
				}
		
				this.rotation = new Quaternion[GameData.numberPlayers];
				for (int i=0; i<this.rotation.Length; i++) {
						this.rotation [i] = game.map.spawnPointsList [i].rotation;
				}
		
				this.lastReceivePostion = new float[GameData.numberPlayers];
		
				this.numberFinish = 0;
		}
	
		public override void preGameOver ()
		{
		}
	
		public override void postUpdate ()
		{
				carInfo [mainPlayerID].Update ();

				if (Game.gameState == Game.GAME_STATE.RUNNING) {
						for (int i=0; i<carInfo.Length; i++) {
								if (isHasID (carInfo [i].ID) == false) {
										if (carInfo [i].RemainingDistance < 0) {					
												if (BaseCarManager.mainPlayerID == carInfo [i].ID) {
														GameData.rank = getOrder (BaseCarManager.mainPlayerID);

														game.preGameOver ();						
												}
										}
								}
						}
				}
		}
	
		public void initPlayer (int index)
		{
				player [index] = (GameObject)GameObject.Instantiate (Resources.Load<GameObject> 
		                                                     (GameData.getCarPrefab (GameData.getCarName (carID [index]))),
		                                                     game.map.spawnPointsList [index].position, game.map.spawnPointsList [index].rotation);
		
				player [index].name = playerName [index];
				player [index].GetComponent<CarData> ().ID = index;
				player [index].rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ
						| RigidbodyConstraints.FreezeRotation;
		
				if (index == BaseCarManager.mainPlayerID) {
						game.autoCam.target = player [index];	
						game.handHeldCam.setTarget (player [index]);
				}
		
				if (index == GameData.numberPlayers - 1) {
						for (int i=0; i<carInfo.Length; i++) {
								carInfo [i] = new CarInfo (game, player [i]);
								carDistance [i] = new CarDistance (carInfo [i].ID, player [i]);
						}
				}
		}
	
		public bool isLoadingComplete ()
		{
				for (int i=0; i<BaseCarManager.isFinishedLoading.Length; i++) {
						if (BaseCarManager.isFinishedLoading [i] == false) {
								return false;
						}
				}
				return true;
		}
	
		bool isHasID (int id)
		{
				for (int i=0; i<orderInfo.Length; i++) {
						if (orderInfo [i] != null) {
								if (id == orderInfo [i].id) {
										return true;
								}
						}
				}
				return false;
		}
	
		public void initLastReceivePosition ()
		{
				for (int i=0; i<lastReceivePostion.Length; i++) {
						lastReceivePostion [i] = Time.timeSinceLevelLoad + 10;
				}
		}
}