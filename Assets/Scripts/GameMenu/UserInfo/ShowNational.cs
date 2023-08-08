using UnityEngine;
using System.Collections;

public class ShowNational : MonoBehaviour
{

		public Texture2D[] flagImage;
		public dfTextureSprite flagIcon;

		void Start ()
		{
				ProfileManager.init ();
				flagIcon.Texture = flagImage [ProfileManager.userProfile.Nation];
		}
}
