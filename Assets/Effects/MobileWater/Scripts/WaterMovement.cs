using UnityEngine;
using System.Collections;

public class WaterMovement : MonoBehaviour
{
		// speed of water
		public float speed = 0.7f;
		// transparency of water.  
		// 0 is transparent 
		// 1 is opaque
		public float alpha = 1;
		// size of wave texture
		public float waveScaleX = 3;
		public float waveScaleY = 3;
		public float moveWater = 0;
		public float limitPingPong = 1.5f;
		public bool pingPong = false;
		private bool flag = false;
	
		void Update ()
		{
				if (pingPong == false) {
						moveWater += Time.deltaTime * speed;
				} else {
						if (flag == false) {
								moveWater = Mathf.Lerp (moveWater, limitPingPong, 0.3f * Time.deltaTime);
								if (moveWater >= limitPingPong - 0.5f)
										flag = true;
						} else {
								moveWater = Mathf.Lerp (moveWater, 0, 0.3f * Time.deltaTime);
								if (moveWater <= 0.5f)
										flag = false;
						}
				}
				gameObject.renderer.material.mainTextureOffset = new  Vector2 (0, moveWater);	
				gameObject.renderer.material.color = new Color (gameObject.renderer.material.color.r,
		                                                 gameObject.renderer.material.color.g, gameObject.renderer.material.color.b, alpha);
				gameObject.renderer.material.mainTextureScale = new Vector2 (waveScaleX, waveScaleY);
		}
}
