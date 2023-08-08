using UnityEngine;
using System.Collections;
using System.Reflection;

public class PoliceLightEffectController : MonoBehaviour
{
		public Material redLight;
		public Material blueLight;

		//
		public GameObject redHalo;
		public GameObject blueHalo;

		//
		Color redLightColor;
		Color blueLightColor;

		void Start ()
		{
				redLightColor = new Color (0.7f, 0, 0, 1);
				blueLightColor = new Color (0, 0, 1, 1);
		}

		void Update ()
		{
				redLightColor.r -= Time.deltaTime;

				if (redLightColor.r < 0.7f) {
						redHalo.SetActive (false);
						if (redLightColor.r < 0.4f) {
								redLightColor.r = 1;
						}
				} else {
						redHalo.SetActive (true);
				}

				redLight.SetColor ("_Color", redLightColor);

				blueLightColor.b -= Time.deltaTime;
				if (blueLightColor.b < 0.7f) {
						blueHalo.SetActive (false);
						if (blueLightColor.b < 0.4f) {
								blueLightColor.b = 1;
						}
				} else {
						blueHalo.SetActive (true);
				}
				blueLight.SetColor ("_Color", blueLightColor);
		}
}
