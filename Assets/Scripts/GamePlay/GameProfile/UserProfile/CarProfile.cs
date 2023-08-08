using UnityEngine;
using System.Collections;
using Newtonsoft.Json;
using System;

public class CarProfile : Profile
{
		public static string CAR_TAG = "carStatus_";
		
		//
		private int ID;

		public bool IsBought {
				get {
						if (carProfileData.b == 1) {
								return true;
						} else {
								return false;
						}
				}
				set {
						if (value == true) {
								carProfileData.b = 1;
						} else {
								carProfileData.b = 0;
						}
						this.save ();
				}
		}
		
		public int Acceleration {
				get {
						return carProfileData.a;
				}
				set {
						this.carProfileData.a = value;
						this.save ();
				}
		}
	
		public int Speed {
				get {
						return carProfileData.s;
				}
				set {
						this.carProfileData.s = value;
						this.save ();
				}
		}
		
		public int Handling {
				get {
						return carProfileData.h;
				}
				set {
						this.carProfileData.h = value;
						this.save ();
				}
		}
		
		public int Nitro {
				get {
						return carProfileData.n;
				}
				set {
						this.carProfileData.n = value;
						this.save ();
				}
		}
		
		public int Color {
				get {
						return carProfileData.c;
				}
				set {
						this.carProfileData.c = value;
						this.save ();
				}
		}

//		public DateTime UpgradeTime_1 {
//				get {
//						return DateTime.Parse (carProfileData.u1);
//				}
//				set {
//						carProfileData.u1 = value.ToString ();
//						this.save ();
//				}
//		}
//
//		public DateTime UpgradeTime_2 {
//				get {
//						return DateTime.Parse (carProfileData.u2);
//				}
//				set {
//						carProfileData.u2 = value.ToString ();
//						this.save ();
//				}
//		}
//
//		public DateTime UpgradeTime_3 {
//				get {
//						return DateTime.Parse (carProfileData.u3);
//				}
//				set {
//						carProfileData.u3 = value.ToString ();
//						this.save ();
//				}
//		}
//
//		public DateTime UpgradeTime_4 {
//				get {
//						return DateTime.Parse (carProfileData.u4);
//				}
//				set {
//						carProfileData.u4 = value.ToString ();
//						this.save ();
//				}
//		}
	
		private CarProfileData carProfileData;
	
		public CarProfile (int id)
		{
				this.ID = id;
				this.carProfileData = new CarProfileData ();
		}
	
		public override void saveDefaultValue ()
		{
				carProfileData.saveDefaultValue (ID);
				this.save ();
		}
	
		public override void load ()
		{
				try {
						carProfileData = JsonConvert.DeserializeObject<CarProfileData> (this.getString (CAR_TAG + ID));		
				} catch (Exception e) {
						Debug.LogException (e);
						carProfileData.saveDefaultValue (ID);
						this.save ();
				}
		}

		private void save ()
		{
				try {
						this.setString (CAR_TAG + ID, JsonConvert.SerializeObject (carProfileData));
				} catch (Exception e) {
						Debug.LogException (e);
				}
		}

		public bool isColorBought (int colorID)
		{
				if ((this.carProfileData.bc & (1 << colorID)) != 0) {
						return true;
				} else {
						return false;
				}
		}

		public void boughtColor (int colorID)
		{
				this.carProfileData.bc = this.carProfileData.bc | (1 << colorID);
		}
}