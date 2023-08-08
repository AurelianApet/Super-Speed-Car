using UnityEngine;
using System.Collections;

public class EditNational : BaseHeaderMenu
{

		public Texture2D[] titleImage;
		public dfTextureSprite titleIcon;
		public dfProgressBar titleValue;
//		public Texture2D[] flagImage;
		public dfButton[] chooseFlag;
		public dfLabel titleScore;

		void Start ()
		{
				titleIcon.Texture = titleImage [RewardData.getTitleID (ProfileManager.userProfile.Score)];
				titleValue.Value = RewardData.getTitleProgress (ProfileManager.userProfile.Score);
				this.titleScore.Text = ProfileManager.userProfile.Score + "/" + RewardData.getTitleLevel (ProfileManager.userProfile.Score);
				for (int i =0; i<chooseFlag.Length; i++) {
						if (i == ProfileManager.userProfile.Nation)
								chooseFlag [i].IsEnabled = true;
						else 
								chooseFlag [i].IsEnabled = false;
				}
		}
	
		void Update ()
		{
				chooseFlag [ProfileManager.userProfile.Nation].IsEnabled = true;
				if (Input.GetKeyUp (KeyCode.Escape))
						AutoFade.LoadLevel ("UserInfo");
				else 
						this.updateInfo ();
				for (int i =0; i<chooseFlag.Length; i++) {
						if (i == ProfileManager.userProfile.Nation)
								chooseFlag [i].IsEnabled = true;
						else 
								chooseFlag [i].IsEnabled = false;
				}
		}

		public void titleOnClick ()
		{
				AutoFade.LoadLevel ("Achievement");
				UserInfoScripts.isLoadingTitle = true;
		}

		public void ChooseNation (dfControl control, dfMouseEventArgs mouseEvent)
		{
				if (control.name == "Panel 1") {
						ProfileManager.userProfile.Nation = 0;
				} else 	if (control.name == "Panel 2") {
						ProfileManager.userProfile.Nation = 1;
		
				} else 	if (control.name == "Panel 3") {
						ProfileManager.userProfile.Nation = 2;
				} else 	if (control.name == "Panel 4") {
						ProfileManager.userProfile.Nation = 3;
				} else 	if (control.name == "Panel 5") {
						ProfileManager.userProfile.Nation = 4;
							
				} else 	if (control.name == "Panel 6") {
						ProfileManager.userProfile.Nation = 5;
							
				} else 	if (control.name == "Panel 7") {
						ProfileManager.userProfile.Nation = 6;
							
				} else 	if (control.name == "Panel 8") {
						ProfileManager.userProfile.Nation = 7;
							
				} else 	if (control.name == "Panel 9") {
						ProfileManager.userProfile.Nation = 8;
							
				} else 	if (control.name == "Panel 10") {
						ProfileManager.userProfile.Nation = 9;
							
				} else 	if (control.name == "Panel 11") {
						ProfileManager.userProfile.Nation = 10;
							
				} else 	if (control.name == "Panel 12") {
						ProfileManager.userProfile.Nation = 11;
							
				} else 	if (control.name == "Panel 13") {
						ProfileManager.userProfile.Nation = 12;
							
				} else 	if (control.name == "Panel 14") {
						ProfileManager.userProfile.Nation = 13;
							
				} else 	if (control.name == "Panel 15") {
						ProfileManager.userProfile.Nation = 14;
							
				} else 	if (control.name == "Panel 16") {
						ProfileManager.userProfile.Nation = 15;
							
				} else 	if (control.name == "Panel 17") {
						ProfileManager.userProfile.Nation = 16;
							
				} else 	if (control.name == "Panel 18") {
						ProfileManager.userProfile.Nation = 17;
							
				} else 	if (control.name == "Panel 19") {
						ProfileManager.userProfile.Nation = 18;
							
				} else 	if (control.name == "Panel 20") {
						ProfileManager.userProfile.Nation = 19;
							
				} else 	if (control.name == "Panel 21") {
						ProfileManager.userProfile.Nation = 20;
							
				} else 	if (control.name == "Panel 22") {
						ProfileManager.userProfile.Nation = 21;
							
				} else 	if (control.name == "Panel 23") {
						ProfileManager.userProfile.Nation = 22;
							
				} else 	if (control.name == "Panel 24") {
						ProfileManager.userProfile.Nation = 23;
							
				} else 	if (control.name == "Panel 25") {
						ProfileManager.userProfile.Nation = 24;
							
				} else 	if (control.name == "Panel 26") {
						ProfileManager.userProfile.Nation = 25;
							
				} else 	if (control.name == "Panel 27") {
						ProfileManager.userProfile.Nation = 26;
							
				} else 	if (control.name == "Panel 28") {
						ProfileManager.userProfile.Nation = 27;
							
				} else 	if (control.name == "Panel 29") {
						ProfileManager.userProfile.Nation = 28;
							
				} else 	if (control.name == "Panel 30") {
						ProfileManager.userProfile.Nation = 29;
							
				} else 	if (control.name == "Panel 31") {
						ProfileManager.userProfile.Nation = 30;
							
				} else 	if (control.name == "Panel 32") {
						ProfileManager.userProfile.Nation = 31;
							
				} else 	if (control.name == "Panel 33") {
						ProfileManager.userProfile.Nation = 32;
							
				} else 	if (control.name == "Panel 34") {
						ProfileManager.userProfile.Nation = 33;
							
				} else 	if (control.name == "Panel 35") {
						ProfileManager.userProfile.Nation = 34;
							
				} else 	if (control.name == "Panel 36") {
						ProfileManager.userProfile.Nation = 35;
							
				} else 	if (control.name == "Panel 37") {
						ProfileManager.userProfile.Nation = 36;
							
				} else 	if (control.name == "Panel 38") {
						ProfileManager.userProfile.Nation = 37;
							
				} else 	if (control.name == "Panel 39") {
						ProfileManager.userProfile.Nation = 38;
							
				} else 	if (control.name == "Panel 40") {
						ProfileManager.userProfile.Nation = 39;
							
				} else 	if (control.name == "Panel 41") {
						ProfileManager.userProfile.Nation = 40;
							
				} else 	if (control.name == "Panel 42") {
						ProfileManager.userProfile.Nation = 41;
							
				} else 	if (control.name == "Panel 43") {
						ProfileManager.userProfile.Nation = 42;
							
				} else 	if (control.name == "Panel 44") {
						ProfileManager.userProfile.Nation = 43;
							
				} else 	if (control.name == "Panel 45") {
						ProfileManager.userProfile.Nation = 44;
							
				} else 	if (control.name == "Panel 46") {
						ProfileManager.userProfile.Nation = 45;
							
				} else 	if (control.name == "Panel 47") {
						ProfileManager.userProfile.Nation = 46;
							
				} else 	if (control.name == "Panel 48") {
						ProfileManager.userProfile.Nation = 47;
							
				} else 	if (control.name == "Panel 49") {
						ProfileManager.userProfile.Nation = 48;
							
				} else 	if (control.name == "Panel 50") {
						ProfileManager.userProfile.Nation = 49;
							
				} else 	if (control.name == "Panel 51") {
						ProfileManager.userProfile.Nation = 50;
							
				} else 	if (control.name == "Panel 52") {
						ProfileManager.userProfile.Nation = 51;
							
				} else 	if (control.name == "Panel 53") {
						ProfileManager.userProfile.Nation = 52;
							
				} else 	if (control.name == "Panel 54") {
						ProfileManager.userProfile.Nation = 53;
							
				} else 	if (control.name == "Panel 55") {
						ProfileManager.userProfile.Nation = 54;
							
				} else 	if (control.name == "Panel 56") {
						ProfileManager.userProfile.Nation = 55;
							
				} else 	if (control.name == "Panel 57") {
						ProfileManager.userProfile.Nation = 56;
							
				} else 	if (control.name == "Panel 58") {
						ProfileManager.userProfile.Nation = 57;
							
				} else 	if (control.name == "Panel 59") {
						ProfileManager.userProfile.Nation = 58;
							
				} else 	if (control.name == "Panel 60") {
						ProfileManager.userProfile.Nation = 59;
							
				} else 	if (control.name == "Panel 61") {
						ProfileManager.userProfile.Nation = 60;
							
				} else 	if (control.name == "Panel 62") {
						ProfileManager.userProfile.Nation = 61;
							
				} else 	if (control.name == "Panel 63") {
						ProfileManager.userProfile.Nation = 62;
							
				} else 	if (control.name == "Panel 64") {
						ProfileManager.userProfile.Nation = 63;
							
				} else 	if (control.name == "Panel 65") {
						ProfileManager.userProfile.Nation = 64;
							
				} else 	if (control.name == "Panel 66") {
						ProfileManager.userProfile.Nation = 65;
							
				} else 	if (control.name == "Panel 67") {
						ProfileManager.userProfile.Nation = 66;
							
				} else 	if (control.name == "Panel 68") {
						ProfileManager.userProfile.Nation = 67;
							
				} else 	if (control.name == "Panel 69") {
						ProfileManager.userProfile.Nation = 68;
							
				} else 	if (control.name == "Panel 70") {
						ProfileManager.userProfile.Nation = 69;
							
				} else 	if (control.name == "Panel 71") {
						ProfileManager.userProfile.Nation = 70;
							
				} else 	if (control.name == "Panel 72") {
						ProfileManager.userProfile.Nation = 71;
							
				} else 	if (control.name == "Panel 73") {
						ProfileManager.userProfile.Nation = 72;
							
				} else 	if (control.name == "Panel 74") {
						ProfileManager.userProfile.Nation = 73;
							
				} else 	if (control.name == "Panel 75") {
						ProfileManager.userProfile.Nation = 74;
							
				} else 	if (control.name == "Panel 76") {
						ProfileManager.userProfile.Nation = 75;
							
				} else 	if (control.name == "Panel 77") {
						ProfileManager.userProfile.Nation = 76;
							
				} else 	if (control.name == "Panel 78") {
						ProfileManager.userProfile.Nation = 77;
							
				} else 	if (control.name == "Panel 79") {
						ProfileManager.userProfile.Nation = 78;
							
				} else 	if (control.name == "Panel 80") {
						ProfileManager.userProfile.Nation = 79;
							
				} else 	if (control.name == "Panel 81") {
						ProfileManager.userProfile.Nation = 80;
							
				} else 	if (control.name == "Panel 82") {
						ProfileManager.userProfile.Nation = 81;
							
				} else 	if (control.name == "Panel 83") {
						ProfileManager.userProfile.Nation = 82;
							
				} else 	if (control.name == "Panel 84") {
						ProfileManager.userProfile.Nation = 83;
							
				} else 	if (control.name == "Panel 85") {
						ProfileManager.userProfile.Nation = 84;
							
				} else 	if (control.name == "Panel 86") {
						ProfileManager.userProfile.Nation = 85;
				}
				PlayerPrefs.Save();
		}
		public void Back ()
		{
				AutoFade.LoadLevel ("UserInfo");
		}
}
