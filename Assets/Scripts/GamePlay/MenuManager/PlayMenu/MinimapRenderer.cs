using UnityEngine;
using System.Collections;

public class MinimapRenderer:BaseMenu
{
		Rect playerPos;
		Rect enemyPos;
		Rect policePos;
		Rect minimapBackgroundPos;

		//
		Rect miniMapClipSize;
		Rect miniMapPos;
		float deltaX;
		float deltaY;

		//
		int i;
		GameObject player;
		float widthRate;
		float heightRate;

		//
		float lastTransparent;
		Color nitroColor;

		public MinimapRenderer (MenuRenderer menuRenderer, Game game):base(menuRenderer,game)
		{	
				playerPos = new Rect (75, 105, 12, 12);
				enemyPos = new Rect (0, 0, 8, 8);
				policePos = new Rect (0, 0, 12, 12);

				miniMapPos = new Rect (0, 0, menuRenderer.miniMap.width, menuRenderer.miniMap.height);
				minimapBackgroundPos = new Rect (1, 33, menuRenderer.minimapBackground.width, menuRenderer.minimapBackground.height);

				miniMapClipSize = new Rect (0, 0, 90, 110);
				miniMapClipSize.x = playerPos.x - miniMapClipSize.width / 2;
				miniMapClipSize.y = playerPos.y - miniMapClipSize.height / 2;

				deltaX = playerPos.x - miniMapClipSize.x;
				deltaY = playerPos.y - miniMapClipSize.y;
		
				widthRate = miniMapPos.width / game.map.worldEnd.transform.position.x;
				heightRate = miniMapPos.height / game.map.worldEnd.transform.position.z;

				this.nitroColor = new Color (1, 1, 1, 1);
		}

		public override void render ()
		{		
				if (player == null) {
						player = game.carManager.getPlayer ();

				} else {
						GUI.DrawTexture (minimapBackgroundPos, menuRenderer.minimapBackground);	

						miniMapPos.x = deltaX - player.transform.position.x * widthRate + 6;
						miniMapPos.y = deltaY + player.transform.position.z * heightRate + 6 - miniMapPos.height;
			
						GUI.BeginGroup (miniMapClipSize);
			
						GUI.DrawTexture (miniMapPos, menuRenderer.miniMap);	
						for (i=0; i<game.carManager.player.Length; i++) {
								if (i != BaseCarManager.mainPlayerID) {
										if (game.carManager.player [i] != null) {
												if (game.carManager.player [i].activeInHierarchy == true) {
														enemyPos.x = game.carManager.player [i].transform.position.x * widthRate - 4 + miniMapPos.x;
														enemyPos.y = miniMapPos.height - game.carManager.player [i].transform.position.z * heightRate - 4 + miniMapPos.y;
						
														GUI.DrawTexture (enemyPos, menuRenderer.enemyIndicator);
												}
										}
								}
						}

						if (game.carManager.police != null) {
								policePos.x = game.carManager.police.transform.position.x * widthRate - 6 + miniMapPos.x;
								policePos.y = miniMapPos.height - game.carManager.police.transform.position.z * heightRate - 6 + miniMapPos.y;

								nitroColor.a = lastTransparent;
								GUI.color = nitroColor;
								GUI.DrawTexture (policePos, menuRenderer.policeIndicator);

								lastTransparent -= Time.deltaTime * 2;
								if (lastTransparent < 0) {
										lastTransparent = 1;
								}
								GUI.color = Color.white;
						}
			
						GUI.EndGroup ();
			
						GUI.DrawTexture (playerPos, menuRenderer.playerIndicator);
				}
		}
}
