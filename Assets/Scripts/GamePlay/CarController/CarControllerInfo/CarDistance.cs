using UnityEngine;
using System.Collections;

public class CarDistance
{
	int id;
	
	public int ID {
		get {
			return id;
		}
		set {
			id = value;
		}
	}
	
	float distance;
	
	public float Distance {
		get {
			return distance;
		}
		set {
			distance = value;
		}
	}

	public CarData carData;
	
	public CarDistance (int id, GameObject carObject)
	{
		this.id = id;

		if (carObject != null) {
			this.carData = carObject.GetComponent<CarData> ();
		}
	}

	public void setOrder (int order)
	{
		if (id != BaseCarManager.mainPlayerID) {
			carData.OrderNumberController.activateNumber (order);
		}
	}
}
