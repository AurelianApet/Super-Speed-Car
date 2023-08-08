using UnityEngine;
using System.Collections;

public class MultiplayerListMenu : BaseMenu
{
		Rect idPos;
		Rect namePos;
		Rect carPos;
		Rect statusPos;

		//
		Rect background;
		int fontSize;
		Font tempFont;

		public MultiplayerListMenu (MenuRenderer menuRenderer, Game game):base(menuRenderer,game)
		{
				this.idPos = new Rect (50, 20, 100, 50);
				this.namePos = new Rect (150, 20, 200, 50);
				this.carPos = new Rect (350, 20, 250, 50);
				this.statusPos = new Rect (600, 20, 150, 50);

				this.background = new Rect (0, 0, 800, 480);
		}
	
		public override void render ()
		{
				if (GameData.isSinglePlayer == false) {
						GUI.color = Color.black;
						GUI.Box (background, string.Empty);
						GUI.color = Color.white;
			
						this.fontSize = GUI.skin.label.fontSize;
						this.tempFont = GUI.skin.label.font;
						GUI.skin.label.fontSize = 20;
						GUI.skin.label.font = menuRenderer.numberFont;

						GUI.contentColor = Color.green;
						GUI.Label (idPos, "ID");
						GUI.Label (namePos, "Name");
						GUI.Label (carPos, "Car");

						if (Network.peerType == NetworkPeerType.Server) {
								GUI.Label (statusPos, "Status");
						}
						GUI.contentColor = Color.white;

						int tempSize = GUI.skin.label.fontSize;
						GUI.skin.label.fontSize = 15;
						for (int i=0; i<BaseCarManager.carID.Length; i++) {
								GUI.Label (new Rect (idPos.x, idPos.y + (i + 1) * 50, idPos.width, idPos.height), (i + 1).ToString ());
								GUI.Label (new Rect (namePos.x, namePos.y + (i + 1) * 50, namePos.width, namePos.height), BaseCarManager.playerName [i]);
								GUI.Label (new Rect (carPos.x, carPos.y + (i + 1) * 50, carPos.width, carPos.height),
			           						GameData.getCarName (BaseCarManager.carID [i]).ToString ().Replace ("_", " "));

								if (GameData.isWifiMode == true) {
										if (Network.peerType == NetworkPeerType.Server) {
												if (BaseCarManager.isFinishedLoading [i] == true) {
														GUI.Label (new Rect (statusPos.x, statusPos.y + (i + 1) * 50, statusPos.width, statusPos.height), "Connected");
												} else {
														GUI.Label (new Rect (statusPos.x, statusPos.y + (i + 1) * 50, statusPos.width, statusPos.height), "Waiting");
												}
										}
								} else {
										if (PhotonNetwork.isMasterClient == true) {
												if (BaseCarManager.isFinishedLoading [i] == true) {
														GUI.Label (new Rect (statusPos.x, statusPos.y + (i + 1) * 50, statusPos.width, statusPos.height), "Connected");
												} else {
														GUI.Label (new Rect (statusPos.x, statusPos.y + (i + 1) * 50, statusPos.width, statusPos.height), "Waiting");
												}
										}
								}
						}
						GUI.skin.label.fontSize = tempSize;
		
						GUI.skin.label.fontStyle = FontStyle.Normal;
						GUI.skin.label.fontSize = fontSize;
						GUI.skin.label.font = tempFont;
				}
		}
}
