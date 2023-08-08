using UnityEngine;
using System.Collections;

public class ChangeCarColor : MonoBehaviour
{
	public Color[] colors;
	public Material[] mediumMaterial;
	public Material[] lowMaterial;

	void Start ()
	{
		mediumMaterial [ProfileManager.userProfile.SelectedCar].SetColor ("_Color",
		                                                                  colors [ProfileManager.userProfile.CarProfile [ProfileManager.userProfile.SelectedCar].Color]);
		lowMaterial [ProfileManager.userProfile.SelectedCar].SetColor ("_Color",
		                                                               colors [ProfileManager.userProfile.CarProfile [ProfileManager.userProfile.SelectedCar].Color]);
	}
}