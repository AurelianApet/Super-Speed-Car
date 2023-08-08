using UnityEngine;
using System.Collections;

public class OrderNumberController : MonoBehaviour
{
		public GameObject[] orderNumber;
		int i;

		public void activateNumber (int order)
		{
				for (i=0; i<orderNumber.Length; i++) {
						orderNumber [i].SetActive (false);
				}

				orderNumber [order].SetActive (true);
		}

		public void deactivateAllNumber ()
		{
				for (i=0; i<orderNumber.Length; i++) {
						orderNumber [i].SetActive (false);
				}
		}
}
