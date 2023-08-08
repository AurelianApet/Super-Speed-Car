using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class OfferProfile : Profile
{
		public static int NUMBER_OFFER = 10;
		public static string OFFER_DATA = "offerData";
	
		//
		private string offerProfileData;
		public List<OfferProfileData> offerProfileList;
	
		public OfferProfile ()
		{
				this.offerProfileList = new List<OfferProfileData> ();
		}
	
		public override void saveDefaultValue ()
		{
				this.saveOfferProfileData ();
		}
	
		public override void load ()
		{
				this.offerProfileData = this.getString (OFFER_DATA);
				try {
						this.offerProfileList = JsonConvert.DeserializeObject<List<OfferProfileData>> (offerProfileData);
				} catch (Exception e) {
						Debug.LogException (e);
						this.offerProfileList = new List<OfferProfileData> ();
				}
		}
	
		public void saveOfferProfileData ()
		{
				try {
						this.offerProfileData = JsonConvert.SerializeObject (offerProfileList);
				} catch (Exception e) {
						Debug.LogException (e);
						this.offerProfileList = new List<OfferProfileData> ();
				}
				this.setString (OFFER_DATA, this.offerProfileData);
		}
	
		public void generateOfferData ()
		{
				if (offerProfileList.Count < 3) {
						int numberOfferNeedGenerated = 3 - offerProfileList.Count;
			
						ID_Pool iDPool = new ID_Pool ();
						this.addCarOfferID (iDPool);
			
						for (int i=0; i<numberOfferNeedGenerated; i++) {
								OfferProfileData offerData = new OfferProfileData ();
								offerData.id = iDPool.allocateID ();
								if (offerData.id != ID_Pool.EMPTY) {
										DateTime time = DateTime.Now;
										offerData.start = time.ToString ();
										offerData.end = time.AddHours (UnityEngine.Random.Range (24, 120)).ToString ();
					
										offerProfileList.Add (offerData);
								}
						}
			
						this.saveOfferProfileData ();
						PlayerPrefs.Save ();
				}
		}
	
		public void addCarOfferID (ID_Pool iDPool)
		{
				int numberOfferCanGenerated = getNumberOfferCanGenerated ();
		
				ID_Pool carIDList = new ID_Pool ();
				carIDList.customInit (numberOfferCanGenerated);
		
				if (ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.BUGATTI_VEYRON].IsBought == false) {
						carIDList.customAdd ((int)GameData.CAR_NAME.BUGATTI_VEYRON);
				}
		
				if (ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.PAGANI_ZONDA].IsBought == false) {
						carIDList.customAdd ((int)GameData.CAR_NAME.PAGANI_ZONDA);
				}
		
				if (ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.LAMBORGHINI_VENENO].IsBought == false) {
						carIDList.customAdd ((int)GameData.CAR_NAME.LAMBORGHINI_VENENO);
				}
		
				if (ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.LAMBORGHINI_LP560].IsBought == false) {
						carIDList.customAdd ((int)GameData.CAR_NAME.LAMBORGHINI_LP560);
				}
		
				if (ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.LAMBORGHINI_SESTO_ELEMENTO].IsBought == false) {
						carIDList.customAdd ((int)GameData.CAR_NAME.LAMBORGHINI_SESTO_ELEMENTO);
				}
		
				if (ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.MERCEDES_BENZ_SLS].IsBought == false) {
						carIDList.customAdd ((int)GameData.CAR_NAME.MERCEDES_BENZ_SLS);
				}
		
				if (ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.PORSCHE_911].IsBought == false) {
						carIDList.customAdd ((int)GameData.CAR_NAME.PORSCHE_911);
				}
		
				if (ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.FERRARI_458_ITALIA].IsBought == false) {
						carIDList.customAdd ((int)GameData.CAR_NAME.FERRARI_458_ITALIA);
				}
		
				if (ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.MASERATI_GRAN_TURISMO].IsBought == false) {
						carIDList.customAdd ((int)GameData.CAR_NAME.MASERATI_GRAN_TURISMO);
				}
		
				if (ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.FERRARI_FXX].IsBought == false) {
						carIDList.customAdd ((int)GameData.CAR_NAME.FERRARI_FXX);
				}
		
				iDPool.customInit (numberOfferCanGenerated);
		
				for (int i=0; i<NUMBER_OFFER; i++) {
						if (i < numberOfferCanGenerated) {
								iDPool.customAdd (carIDList.allocateID ());
						}
				}
		}
	
		public int getNumberOfferCanGenerated ()
		{
				int result = 0;
		
				if (ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.BUGATTI_VEYRON].IsBought == false) {
						result++;
				}
		
				if (ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.PAGANI_ZONDA].IsBought == false) {
						result++;
				}
		
				if (ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.LAMBORGHINI_VENENO].IsBought == false) {
						result++;
				}
		
				if (ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.LAMBORGHINI_LP560].IsBought == false) {
						result++;
				}
		
				if (ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.LAMBORGHINI_SESTO_ELEMENTO].IsBought == false) {
						result++;
				}
		
				if (ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.MERCEDES_BENZ_SLS].IsBought == false) {
						result++;
				}
		
				if (ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.PORSCHE_911].IsBought == false) {
						result++;
				}
		
				if (ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.FERRARI_458_ITALIA].IsBought == false) {
						result++;
				}
		
				if (ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.MASERATI_GRAN_TURISMO].IsBought == false) {
						result++;
				}
		
				if (ProfileManager.userProfile.CarProfile [(int)GameData.CAR_NAME.FERRARI_FXX].IsBought == false) {
						result++;
				}
		
				return result;
		}
	
		public int convertIntToCarID (int id)
		{
				switch (id) {
				case 0:
						return (int)GameData.CAR_NAME.BUGATTI_VEYRON;
			
				case 1:
						return (int)GameData.CAR_NAME.PAGANI_ZONDA;
			
				case 2:
						return (int)GameData.CAR_NAME.LAMBORGHINI_VENENO;
			
				case 3:
						return (int)GameData.CAR_NAME.LAMBORGHINI_LP560;
			
				case 4:
						return (int)GameData.CAR_NAME.LAMBORGHINI_SESTO_ELEMENTO;
			
				case 5:
						return (int)GameData.CAR_NAME.MERCEDES_BENZ_SLS;
			
				case 6:
						return (int)GameData.CAR_NAME.PORSCHE_911;
			
				case 7:
						return (int)GameData.CAR_NAME.FERRARI_458_ITALIA;
			
				case 8:
						return (int)GameData.CAR_NAME.MASERATI_GRAN_TURISMO;
			
				case 9:
						return (int)GameData.CAR_NAME.FERRARI_FXX;
			
				default:
						return (int)GameData.CAR_NAME.BUGATTI_VEYRON;
				}
		}
	
		public int convertCarIDtoInt (int offerID)
		{
				GameData.CAR_NAME carName = (GameData.CAR_NAME)offerID;
		
				switch (carName) {
				case GameData.CAR_NAME.BUGATTI_VEYRON:
						return 0;
			
				case GameData.CAR_NAME.PAGANI_ZONDA:
						return 1;
			
				case GameData.CAR_NAME.LAMBORGHINI_VENENO:
						return 2;
			
				case GameData.CAR_NAME.LAMBORGHINI_LP560:
						return 3;
			
				case GameData.CAR_NAME.LAMBORGHINI_SESTO_ELEMENTO:
						return 4;
			
				case GameData.CAR_NAME.MERCEDES_BENZ_SLS:
						return 5;
			
				case GameData.CAR_NAME.PORSCHE_911:
						return 6;
			
				case GameData.CAR_NAME.FERRARI_458_ITALIA:
						return 7;
			
				case GameData.CAR_NAME.MASERATI_GRAN_TURISMO:
						return 8;
			
				case GameData.CAR_NAME.FERRARI_FXX:
						return 9;
			
				default:
						return 0;
				}
		}
	
		public void updateOfferProfileData ()
		{
				List<OfferProfileData> removedOfferProfileList = new List<OfferProfileData> ();
		
				for (int i=0; i<offerProfileList.Count; i++) {
						try {
								DateTime endTime = DateTime.Parse (ProfileManager.offerProfile.offerProfileList [i].end);
				
								if (DateTime.Compare (endTime, DateTime.Now) < 0) {
										removedOfferProfileList.Add (ProfileManager.offerProfile.offerProfileList [i]);
								}
						} catch {
						}
				}
		
				foreach (OfferProfileData offerProfileData in removedOfferProfileList) {
						offerProfileList.Remove (offerProfileData);
				}
		
				for (int i=0; i<10; i++) {
						if (ProfileManager.userProfile.CarProfile [convertIntToCarID (i)].IsBought == true) {
								for (int j=0; j<offerProfileList.Count; j++) {
										if (offerProfileList [j].id == convertIntToCarID (i)) {
												offerProfileList.Remove (offerProfileList [j]);
												break;
										}
								}
						}
				}
		
				saveOfferProfileData ();
				PlayerPrefs.Save ();
		}
	
		public bool isHasOfferID (int id)
		{
				int offerID = convertIntToCarID (id);
		
				foreach (OfferProfileData offerData in offerProfileList) {
						if (offerData.id == offerID) {
								return true;
						}
				}
		
				return false;
		}
	
		public OfferProfileData getOfferData (int id)
		{
				int offerID = convertIntToCarID (id);
		
				foreach (OfferProfileData offerData in offerProfileList) {
						if (offerData.id == offerID) {
								return offerData;
						}
				}
		
				return null;
		}
}