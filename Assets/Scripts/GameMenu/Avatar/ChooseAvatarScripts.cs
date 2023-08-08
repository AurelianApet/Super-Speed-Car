using UnityEngine;
using System.Collections;

public class ChooseAvatarScripts : BaseHeaderMenu
{	
		public dfTextureSprite avatarIcon;
		public dfButton[] btnSelected;
		public dfButton[] btnBuy;
		public Texture2D[] titleImage;
		public dfTextureSprite title;
		public dfLabel LabelTitle, LabelError, titleScores;
		public dfProgressBar titleValue;
		public MainMenuSound sound;
		public dfPanel panelError;
		public dfTweenVector3 panelErrorFly;
	
		void Start ()
		{
				ProfileManager.init ();
				if (sound.mainMusic.isPlaying)
						sound.mainMusic.volume = ProfileManager.setttings.MusicVolume / 100f;
				sound.mainMusic.Play ();
		
				LabelTitle.Text = RewardData.getTitleText (RewardData.getTitleID (ProfileManager.userProfile.Score));
				title.Texture = titleImage [RewardData.getTitleID (ProfileManager.userProfile.Score)];
				this.titleScores.Text = ProfileManager.userProfile.Score + "/" + RewardData.getTitleLevel (ProfileManager.userProfile.Score);
				for (int i=0; i<btnSelected.Length; i++) {
						if (i == ProfileManager.userProfile.AvatarID)
								btnSelected [i].IsVisible = true;
						else
								btnSelected [i].IsVisible = false;
				}
				titleValue.Value = RewardData.getTitleProgress (ProfileManager.userProfile.Score);
				Bought ();
		
		}

		void Update ()
		{
				for (int i=0; i<btnSelected.Length; i++) {
						if (i == ProfileManager.userProfile.AvatarID)
								btnSelected [i].IsVisible = true;
						else
								btnSelected [i].IsVisible = false;
				}
		
				if (Input.GetKeyUp (KeyCode.Escape))
						AutoFade.LoadLevel ("UserInfo");
				else 
						this.updateInfo ();
				if (sound.mainMusic.isPlaying)
						sound.mainMusic.volume = ProfileManager.setttings.MusicVolume / 100f;
		}
	
	#region Bought
		void Bought ()
		{
				if (ProfileManager.userProfile.isAvatarBought (10)) {
						btnBuy [0].IsVisible = false;
				} else {
						btnBuy [0].IsVisible = true;
				}
		
				if (ProfileManager.userProfile.isAvatarBought (11)) {
						btnBuy [1].IsVisible = false;
				} else {
						btnBuy [1].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (12)) {
						btnBuy [2].IsVisible = false;
				} else {
						btnBuy [2].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (13)) {
						btnBuy [3].IsVisible = false;
				} else {
						btnBuy [3].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (14)) {
						btnBuy [4].IsVisible = false;
				} else {
						btnBuy [4].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (15)) {
						btnBuy [5].IsVisible = false;
				} else {
						btnBuy [5].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (16)) {
						btnBuy [6].IsVisible = false;
				} else {
			
						btnBuy [6].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (17)) {
						btnBuy [7].IsVisible = false;
				} else {
						btnBuy [7].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (18)) {
						btnBuy [8].IsVisible = false;
				} else {
						btnBuy [8].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (19)) {
						btnBuy [9].IsVisible = false;
				} else {
						btnBuy [9].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (20)) {
						btnBuy [10].IsVisible = false;
				} else {
						btnBuy [10].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (21)) {
						btnBuy [11].IsVisible = false;
				} else {
						btnBuy [11].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (22)) {
						btnBuy [12].IsVisible = false;
				} else {
						btnBuy [12].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (23)) {
						btnBuy [13].IsVisible = false;
				} else {
						btnBuy [13].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (24)) {
						btnBuy [14].IsVisible = false;
				} else {
						btnBuy [14].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (25)) {
						btnBuy [15].IsVisible = false;
				} else {
						btnBuy [15].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (26)) {
						btnBuy [16].IsVisible = false;
				} else {
						btnBuy [16].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (27)) {
						btnBuy [17].IsVisible = false;
				} else {
						btnBuy [17].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (28)) {
						btnBuy [18].IsVisible = false;
				} else {
						btnBuy [18].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (29)) {
						btnBuy [19].IsVisible = false;
				} else {
						btnBuy [19].IsVisible = true;
				}
		
				if (ProfileManager.userProfile.isAvatarBought (30)) {
						btnBuy [20].IsVisible = false;
				} else {
						btnBuy [20].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (31)) {
						btnBuy [21].IsVisible = false;
				} else {
						btnBuy [21].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (32)) {
						btnBuy [22].IsVisible = false;
				} else {
						btnBuy [22].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (33)) {
						btnBuy [23].IsVisible = false;
				} else {
						btnBuy [23].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (34)) {
						btnBuy [24].IsVisible = false;
				} else {
						btnBuy [24].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (35)) {
						btnBuy [25].IsVisible = false;
				} else {
						btnBuy [25].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (36)) {
						btnBuy [26].IsVisible = false;
				} else {
						btnBuy [26].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (37)) {
						btnBuy [27].IsVisible = false;
				} else {
						btnBuy [27].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (38)) {
						btnBuy [28].IsVisible = false;
				} else {
						btnBuy [28].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (39)) {
						btnBuy [29].IsVisible = false;
				} else {
						btnBuy [29].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (40)) {
						btnBuy [30].IsVisible = false;
				} else {
						btnBuy [30].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (41)) {
						btnBuy [31].IsVisible = false;
				} else {
						btnBuy [31].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (42)) {
						btnBuy [32].IsVisible = false;
				} else {
						btnBuy [32].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (43)) {
						btnBuy [33].IsVisible = false;
				} else {
						btnBuy [33].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (44)) {
						btnBuy [34].IsVisible = false;
				} else {
						btnBuy [34].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (45)) {
						btnBuy [35].IsVisible = false;
				} else {
						btnBuy [35].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (46)) {
						btnBuy [36].IsVisible = false;
				} else {
						btnBuy [36].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (47)) {
						btnBuy [37].IsVisible = false;
				} else {
						btnBuy [37].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (48)) {
						btnBuy [38].IsVisible = false;
				} else {
						btnBuy [38].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (49)) {
						btnBuy [39].IsVisible = false;
				} else {
						btnBuy [39].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (50)) {
						btnBuy [40].IsVisible = false;
				} else {
						btnBuy [40].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (51)) {
						btnBuy [41].IsVisible = false;
				} else {
						btnBuy [41].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (52)) {
						btnBuy [42].IsVisible = false;
				} else {
						btnBuy [42].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (53)) {
						btnBuy [43].IsVisible = false;
				} else {
						btnBuy [43].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (54)) {
						btnBuy [44].IsVisible = false;
				} else {
						btnBuy [44].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (55)) {
						btnBuy [45].IsVisible = false;
				} else {
						btnBuy [45].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (56)) {
						btnBuy [46].IsVisible = false;
				} else {
						btnBuy [46].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (57)) {
						btnBuy [47].IsVisible = false;
				} else {
						btnBuy [47].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (58)) {
						btnBuy [48].IsVisible = false;
				} else {
						btnBuy [48].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (59)) {
						btnBuy [49].IsVisible = false;
				} else {
						btnBuy [49].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (60)) {
						btnBuy [50].IsVisible = false;
				} else {
						btnBuy [50].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (61)) {
						btnBuy [51].IsVisible = false;
				} else {
						btnBuy [51].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (62)) {
						btnBuy [52].IsVisible = false;
				} else {
						btnBuy [52].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (63)) {
						btnBuy [53].IsVisible = false;
				} else {
						btnBuy [53].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (64)) {
						btnBuy [54].IsVisible = false;
				} else {
						btnBuy [54].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (65)) {
						btnBuy [55].IsVisible = false;
				} else {
						btnBuy [55].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (66)) {
						btnBuy [56].IsVisible = false;
				} else {
						btnBuy [56].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (67)) {
						btnBuy [57].IsVisible = false;
				} else {
						btnBuy [57].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (68)) {
						btnBuy [58].IsVisible = false;
				} else {
						btnBuy [58].IsVisible = true;
				}
				if (ProfileManager.userProfile.isAvatarBought (69)) {
						btnBuy [59].IsVisible = false;
				} else {
						btnBuy [59].IsVisible = true;
				}
		}
	#endregion

		public void titleOnClick ()
		{
				AutoFade.LoadLevel ("Achievement");
				UserInfoScripts.isLoadingTitle = true;
		}
	
		void ShowError ()
		{
				panelErrorFly.Play ();
				panelError.IsVisible = true;
		}
	
		public void ChooseAvatar (dfControl control, dfMouseEventArgs mouseEvent)
		{
				if (control.name == "Avatar 1") {
						ProfileManager.userProfile.AvatarID = 0;
						sound.ButtonClick ();
				} else if (control.name == "Avatar 2") {
						ProfileManager.userProfile.AvatarID = 1;
						sound.ButtonClick ();
				} else if (control.name == "Avatar 3") {
						ProfileManager.userProfile.AvatarID = 2;
						sound.ButtonClick ();
				} else if (control.name == "Avatar 4") {
						ProfileManager.userProfile.AvatarID = 3;
						sound.ButtonClick ();
				} else if (control.name == "Avatar 5") {
						ProfileManager.userProfile.AvatarID = 4;
						sound.ButtonClick ();
				} else if (control.name == "Avatar 6") {
						ProfileManager.userProfile.AvatarID = 5;
						sound.ButtonClick ();
				} else if (control.name == "Avatar 7") {
						ProfileManager.userProfile.AvatarID = 6;
						sound.ButtonClick ();
				} else if (control.name == "Avatar 8") {
						ProfileManager.userProfile.AvatarID = 7;
						sound.ButtonClick ();
				} else if (control.name == "Avatar 9") {
						ProfileManager.userProfile.AvatarID = 8;
						sound.ButtonClick ();
				} else if (control.name == "Avatar 10") {
						ProfileManager.userProfile.AvatarID = 9;
						sound.ButtonClick ();
				} else if (control.name == "Avatar 11") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (10) == false) {
								if (ProfileManager.userProfile.Money >= 750) {
										ProfileManager.userProfile.AvatarID = 10;
										ProfileManager.userProfile.Money -= 750;
										ProfileManager.userProfile.boughtAvatar (10);
										btnBuy [0].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (750 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 10;
								btnBuy [0].IsVisible = false;
						}
				} else if (control.name == "Avatar 12") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (11) == false) {
								if (ProfileManager.userProfile.Money >= 750) {
										ProfileManager.userProfile.AvatarID = 11;
										ProfileManager.userProfile.Money -= 750;
										ProfileManager.userProfile.boughtAvatar (11);
										btnBuy [1].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (750 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 11;
								btnBuy [1].IsVisible = false;
						}
				} else if (control.name == "Avatar 13") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (12) == false) {
								if (ProfileManager.userProfile.Money >= 750) {
										ProfileManager.userProfile.AvatarID = 12;
										ProfileManager.userProfile.Money -= 750;
										ProfileManager.userProfile.boughtAvatar (12);
										btnBuy [2].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (750 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 12;
								btnBuy [2].IsVisible = false;
						}
				} else if (control.name == "Avatar 14") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (13) == false) {
								if (ProfileManager.userProfile.Money >= 750) {
										ProfileManager.userProfile.AvatarID = 13;
										ProfileManager.userProfile.Money -= 750;
										ProfileManager.userProfile.boughtAvatar (13);
										btnBuy [3].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (750 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 13;
								btnBuy [3].IsVisible = false;
						}
				} else if (control.name == "Avatar 15") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (14) == false) {
								if (ProfileManager.userProfile.Money >= 750) {
										ProfileManager.userProfile.AvatarID = 14;
										ProfileManager.userProfile.Money -= 750;
										ProfileManager.userProfile.boughtAvatar (14);
										btnBuy [4].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (750 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 14;
								btnBuy [4].IsVisible = false;
						}
				} else if (control.name == "Avatar 16") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (15) == false) {
								if (ProfileManager.userProfile.Money >= 750) {
										ProfileManager.userProfile.AvatarID = 15;
										ProfileManager.userProfile.Money -= 750;
										ProfileManager.userProfile.boughtAvatar (15);
										btnBuy [5].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (750 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 15;
								btnBuy [5].IsVisible = false;
						}
				} else if (control.name == "Avatar 17") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (16) == false) {
								if (ProfileManager.userProfile.Money >= 750) {
										ProfileManager.userProfile.AvatarID = 16;
										ProfileManager.userProfile.Money -= 750;
										ProfileManager.userProfile.boughtAvatar (16);
										btnBuy [6].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (750 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 16;
								btnBuy [6].IsVisible = false;
						}
				} else if (control.name == "Avatar 18") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (17) == false) {
								if (ProfileManager.userProfile.Money >= 750) {
										ProfileManager.userProfile.AvatarID = 17;
										ProfileManager.userProfile.Money -= 750;
										ProfileManager.userProfile.boughtAvatar (17);
										btnBuy [7].IsVisible = false;
								} else {
										ShowError ();
								}
						} else {
								ProfileManager.userProfile.AvatarID = 17;
								btnBuy [7].IsVisible = false;
						}
				} else if (control.name == "Avatar 19") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (18) == false) {
								if (ProfileManager.userProfile.Money >= 750) {
										ProfileManager.userProfile.AvatarID = 18;
										ProfileManager.userProfile.Money -= 750;
										ProfileManager.userProfile.boughtAvatar (18);
										btnBuy [8].IsVisible = false;
								} else {
										ShowError ();
					
										LabelError.Text = "You need " + string.Format ("{0:n00}", (750 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 18;
								btnBuy [8].IsVisible = false;
						}
				} else if (control.name == "Avatar 20") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (19) == false) {
								if (ProfileManager.userProfile.Money >= 750) {
										ProfileManager.userProfile.AvatarID = 19;
										ProfileManager.userProfile.Money -= 750;
										ProfileManager.userProfile.boughtAvatar (19);
										btnBuy [9].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (750 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 19;
								btnBuy [9].IsVisible = false;
						}
				} else if (control.name == "Avatar 21") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (20) == false) {
								if (ProfileManager.userProfile.Money >= 750) {
										ProfileManager.userProfile.AvatarID = 20;
										ProfileManager.userProfile.Money -= 750;
										ProfileManager.userProfile.boughtAvatar (20);
										btnBuy [10].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (750 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 20;
								btnBuy [10].IsVisible = false;
						}
				} else if (control.name == "Avatar 22") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (21) == false) {
								if (ProfileManager.userProfile.Money >= 750) {
										ProfileManager.userProfile.AvatarID = 21;
										ProfileManager.userProfile.Money -= 750;
										ProfileManager.userProfile.boughtAvatar (21);
										btnBuy [11].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (750 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 21;
								btnBuy [11].IsVisible = false;
						}
				} else if (control.name == "Avatar 23") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (22) == false) {
								if (ProfileManager.userProfile.Money >= 750) {
										ProfileManager.userProfile.AvatarID = 22;
										ProfileManager.userProfile.Money -= 750;
										ProfileManager.userProfile.boughtAvatar (22);
										btnBuy [12].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (750 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 22;
								btnBuy [12].IsVisible = false;
						}
				} else if (control.name == "Avatar 24") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (23) == false) {
								if (ProfileManager.userProfile.Money >= 750) {
										ProfileManager.userProfile.AvatarID = 23;
										ProfileManager.userProfile.Money -= 750;
										ProfileManager.userProfile.boughtAvatar (23);
										btnBuy [13].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (750 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 23;
								btnBuy [13].IsVisible = false;
						}
				} else if (control.name == "Avatar 25") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (24) == false) {
								if (ProfileManager.userProfile.Money >= 750) {
										ProfileManager.userProfile.AvatarID = 24;
										ProfileManager.userProfile.Money -= 750;
										ProfileManager.userProfile.boughtAvatar (24);
										btnBuy [14].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (750 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 24;
								btnBuy [14].IsVisible = false;
						}
				} else if (control.name == "Avatar 26") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (25) == false) {
								if (ProfileManager.userProfile.Money >= 2000) {
										ProfileManager.userProfile.AvatarID = 25;
										ProfileManager.userProfile.Money -= 2000;
										ProfileManager.userProfile.boughtAvatar (25);
										btnBuy [15].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2000 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 25;
								btnBuy [15].IsVisible = false;
						}
				} else if (control.name == "Avatar 27") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (26) == false) {
								if (ProfileManager.userProfile.Money >= 2000) {
										ProfileManager.userProfile.AvatarID = 26;
										ProfileManager.userProfile.Money -= 2000;
										ProfileManager.userProfile.boughtAvatar (26);
										btnBuy [16].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2000 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 26;
								btnBuy [16].IsVisible = false;
						}
				} else if (control.name == "Avatar 28") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (27) == false) {
								if (ProfileManager.userProfile.Money >= 2000) {
										ProfileManager.userProfile.AvatarID = 27;
										ProfileManager.userProfile.Money -= 2000;
										ProfileManager.userProfile.boughtAvatar (27);
										btnBuy [17].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2000 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 27;
								btnBuy [17].IsVisible = false;
						}
				} else if (control.name == "Avatar 29") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (28) == false) {
								if (ProfileManager.userProfile.Money >= 2000) {
										ProfileManager.userProfile.AvatarID = 28;
										ProfileManager.userProfile.Money -= 2000;
										ProfileManager.userProfile.boughtAvatar (28);
										btnBuy [18].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2000 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 28;
								btnBuy [18].IsVisible = false;
						}
				} else if (control.name == "Avatar 30") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (29) == false) {
								if (ProfileManager.userProfile.Money >= 2000) {
										ProfileManager.userProfile.AvatarID = 29;
										ProfileManager.userProfile.Money -= 2000;
										ProfileManager.userProfile.boughtAvatar (29);
										btnBuy [19].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2000 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 29;
								btnBuy [19].IsVisible = false;
						}
				} else if (control.name == "Avatar 31") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (30) == false) {
								if (ProfileManager.userProfile.Money >= 2000) {
										ProfileManager.userProfile.AvatarID = 30;
										ProfileManager.userProfile.Money -= 2000;
										ProfileManager.userProfile.boughtAvatar (30);
										btnBuy [20].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2000 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 30;
								btnBuy [20].IsVisible = false;
						}
				} else if (control.name == "Avatar 32") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (31) == false) {
								if (ProfileManager.userProfile.Money >= 2000) {
										ProfileManager.userProfile.AvatarID = 31;
										ProfileManager.userProfile.Money -= 2000;
										ProfileManager.userProfile.boughtAvatar (31);
										btnBuy [21].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2000 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 31;
								btnBuy [21].IsVisible = false;
						}
				} else if (control.name == "Avatar 33") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (32) == false) {
								if (ProfileManager.userProfile.Money >= 2000) {
										ProfileManager.userProfile.AvatarID = 32;
										ProfileManager.userProfile.Money -= 2000;
										ProfileManager.userProfile.boughtAvatar (32);
										btnBuy [22].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2000 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 32;
								btnBuy [22].IsVisible = false;
						}
				} else if (control.name == "Avatar 34") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (33) == false) {
								if (ProfileManager.userProfile.Money >= 2000) {
										ProfileManager.userProfile.AvatarID = 33;
										ProfileManager.userProfile.Money -= 2000;
										ProfileManager.userProfile.boughtAvatar (33);
										btnBuy [23].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2000 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 33;
								btnBuy [23].IsVisible = false;
						}
				} else if (control.name == "Avatar 35") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (34) == false) {
								if (ProfileManager.userProfile.Money >= 2000) {
										ProfileManager.userProfile.AvatarID = 34;
										ProfileManager.userProfile.Money -= 2000;
										ProfileManager.userProfile.boughtAvatar (34);
										btnBuy [24].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2000 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 34;
								btnBuy [24].IsVisible = false;
						}
				} else if (control.name == "Avatar 36") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (35) == false) {
								if (ProfileManager.userProfile.Money >= 2000) {
										ProfileManager.userProfile.AvatarID = 35;
										ProfileManager.userProfile.Money -= 2000;
										ProfileManager.userProfile.boughtAvatar (35);
										btnBuy [25].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2000 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 35;
								btnBuy [25].IsVisible = false;
						}
				} else if (control.name == "Avatar 37") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (36) == false) {
								if (ProfileManager.userProfile.Money >= 2000) {
										ProfileManager.userProfile.AvatarID = 36;
										ProfileManager.userProfile.Money -= 2000;
										ProfileManager.userProfile.boughtAvatar (36);
										btnBuy [26].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2000 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 36;
								btnBuy [26].IsVisible = false;
						}
				} else if (control.name == "Avatar 38") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (37) == false) {
								if (ProfileManager.userProfile.Money >= 2000) {
										ProfileManager.userProfile.AvatarID = 37;
										ProfileManager.userProfile.Money -= 2000;
										ProfileManager.userProfile.boughtAvatar (37);
										btnBuy [27].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2000 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 36;
								btnBuy [27].IsVisible = false;
						}
				} else if (control.name == "Avatar 39") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (38) == false) {
								if (ProfileManager.userProfile.Money >= 2000) {
										ProfileManager.userProfile.AvatarID = 38;
										ProfileManager.userProfile.Money -= 2000;
										ProfileManager.userProfile.boughtAvatar (38);
										btnBuy [28].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2000 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 38;
								btnBuy [28].IsVisible = false;
						}
				} else if (control.name == "Avatar 40") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (39) == false) {
								if (ProfileManager.userProfile.Money >= 2000) {
										ProfileManager.userProfile.AvatarID = 39;
										ProfileManager.userProfile.Money -= 2000;
										ProfileManager.userProfile.boughtAvatar (39);
										btnBuy [29].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2000 - ProfileManager.userProfile.Money) + " coin more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 39;
								btnBuy [29].IsVisible = false;
						}
				} else if (control.name == "Avatar 41") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (40) == false) {
								if (ProfileManager.userProfile.Diamond >= 2) {
										ProfileManager.userProfile.AvatarID = 40;
										ProfileManager.userProfile.Diamond -= 2;
										ProfileManager.userProfile.boughtAvatar (40);
										btnBuy [30].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 40;
								btnBuy [30].IsVisible = false;
						}
				} else if (control.name == "Avatar 42") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (41) == false) {
								if (ProfileManager.userProfile.Diamond >= 2) {
										ProfileManager.userProfile.AvatarID = 41;
										ProfileManager.userProfile.Diamond -= 2;
										ProfileManager.userProfile.boughtAvatar (41);
										btnBuy [31].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 41;
								btnBuy [31].IsVisible = false;
						}
				} else if (control.name == "Avatar 43") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (42) == false) {
								if (ProfileManager.userProfile.Diamond >= 2) {
										ProfileManager.userProfile.AvatarID = 42;
										ProfileManager.userProfile.Diamond -= 2;
										ProfileManager.userProfile.boughtAvatar (42);
										btnBuy [32].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 42;
								btnBuy [32].IsVisible = false;
						}
				} else if (control.name == "Avatar 44") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (43) == false) {
								if (ProfileManager.userProfile.Diamond >= 2) {
										ProfileManager.userProfile.AvatarID = 43;
										ProfileManager.userProfile.Diamond -= 2;
										ProfileManager.userProfile.boughtAvatar (43);
										btnBuy [33].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 43;
								btnBuy [33].IsVisible = false;
						}
				} else if (control.name == "Avatar 45") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (44) == false) {
								if (ProfileManager.userProfile.Diamond >= 2) {
										ProfileManager.userProfile.AvatarID = 44;
										ProfileManager.userProfile.Diamond -= 2;
										ProfileManager.userProfile.boughtAvatar (44);
										btnBuy [34].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 44;
								btnBuy [34].IsVisible = false;
						}
				} else if (control.name == "Avatar 46") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (45) == false) {
								if (ProfileManager.userProfile.Diamond >= 2) {
										ProfileManager.userProfile.AvatarID = 45;
										ProfileManager.userProfile.Diamond -= 2;
										ProfileManager.userProfile.boughtAvatar (45);
										btnBuy [35].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 45;
								btnBuy [35].IsVisible = false;
						}
				} else if (control.name == "Avatar 47") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (46) == false) {
								if (ProfileManager.userProfile.Diamond >= 2) {
										ProfileManager.userProfile.AvatarID = 46;
										ProfileManager.userProfile.Diamond -= 2;
										ProfileManager.userProfile.boughtAvatar (46);
										btnBuy [36].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 46;
								btnBuy [36].IsVisible = false;
						}
				} else if (control.name == "Avatar 48") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (47) == false) {
								if (ProfileManager.userProfile.Diamond >= 2) {
										ProfileManager.userProfile.AvatarID = 47;
										ProfileManager.userProfile.Diamond -= 2;
										ProfileManager.userProfile.boughtAvatar (47);
										btnBuy [37].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 47;
								btnBuy [37].IsVisible = false;
						}
				} else if (control.name == "Avatar 49") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (48) == false) {
								if (ProfileManager.userProfile.Diamond >= 2) {
										ProfileManager.userProfile.AvatarID = 48;
										ProfileManager.userProfile.Diamond -= 2;
										ProfileManager.userProfile.boughtAvatar (48);
										btnBuy [38].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 48;
								btnBuy [38].IsVisible = false;
						}
				} else if (control.name == "Avatar 50") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (49) == false) {
								if (ProfileManager.userProfile.Diamond >= 2) {
										ProfileManager.userProfile.AvatarID = 49;
										ProfileManager.userProfile.Diamond -= 2;
										ProfileManager.userProfile.boughtAvatar (49);
										btnBuy [39].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 49;
								btnBuy [39].IsVisible = false;
						}
				} else if (control.name == "Avatar 51") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (50) == false) {
								if (ProfileManager.userProfile.Diamond >= 2) {
										ProfileManager.userProfile.AvatarID = 50;
										ProfileManager.userProfile.Diamond -= 2;
										ProfileManager.userProfile.boughtAvatar (50);
										btnBuy [40].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 50;
								btnBuy [40].IsVisible = false;
						}
				} else if (control.name == "Avatar 52") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (51) == false) {
								if (ProfileManager.userProfile.Diamond >= 2) {
										ProfileManager.userProfile.AvatarID = 51;
										ProfileManager.userProfile.Diamond -= 2;
										ProfileManager.userProfile.boughtAvatar (51);
										btnBuy [41].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 51;
								btnBuy [41].IsVisible = false;
						}
				} else if (control.name == "Avatar 53") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (52) == false) {
								if (ProfileManager.userProfile.Diamond >= 2) {
										ProfileManager.userProfile.AvatarID = 52;
										ProfileManager.userProfile.Diamond -= 2;
										ProfileManager.userProfile.boughtAvatar (52);
										btnBuy [42].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 52;
								btnBuy [42].IsVisible = false;
						}
				} else if (control.name == "Avatar 54") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (53) == false) {
								if (ProfileManager.userProfile.Diamond >= 2) {
										ProfileManager.userProfile.AvatarID = 53;
										ProfileManager.userProfile.Diamond -= 2;
										ProfileManager.userProfile.boughtAvatar (53);
										btnBuy [43].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 53;
								btnBuy [43].IsVisible = false;
						}
				} else if (control.name == "Avatar 55") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (54) == false) {
								if (ProfileManager.userProfile.Diamond >= 2) {
										ProfileManager.userProfile.AvatarID = 54;
										ProfileManager.userProfile.Diamond -= 2;
										ProfileManager.userProfile.boughtAvatar (54);
										btnBuy [44].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (2 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 54;
								btnBuy [44].IsVisible = false;
						}
				} else if (control.name == "Avatar 56") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (55) == false) {
								if (ProfileManager.userProfile.Diamond >= 5) {
										ProfileManager.userProfile.AvatarID = 55;
										ProfileManager.userProfile.Diamond -= 5;
										ProfileManager.userProfile.boughtAvatar (55);
										btnBuy [45].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (5 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 55;
								btnBuy [45].IsVisible = false;
						}
				} else if (control.name == "Avatar 57") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (56) == false) {
								if (ProfileManager.userProfile.Diamond >= 5) {
										ProfileManager.userProfile.AvatarID = 56;
										ProfileManager.userProfile.Diamond -= 5;
										ProfileManager.userProfile.boughtAvatar (56);
										btnBuy [46].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (5 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 56;
								btnBuy [46].IsVisible = false;
						}
				} else if (control.name == "Avatar 58") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (57) == false) {
								if (ProfileManager.userProfile.Diamond >= 5) {
										ProfileManager.userProfile.AvatarID = 57;
										ProfileManager.userProfile.Diamond -= 5;
										ProfileManager.userProfile.boughtAvatar (57);
										btnBuy [47].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (5 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 57;
								btnBuy [47].IsVisible = false;
						}
				} else if (control.name == "Avatar 59") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (58) == false) {
								if (ProfileManager.userProfile.Diamond >= 5) {
										ProfileManager.userProfile.AvatarID = 58;
										ProfileManager.userProfile.Diamond -= 5;
										ProfileManager.userProfile.boughtAvatar (58);
										btnBuy [48].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (5 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 58;
								btnBuy [48].IsVisible = false;
						}
				} else if (control.name == "Avatar 60") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (59) == false) {
								if (ProfileManager.userProfile.Diamond >= 5) {
										ProfileManager.userProfile.AvatarID = 59;
										ProfileManager.userProfile.Diamond -= 5;
										ProfileManager.userProfile.boughtAvatar (59);
										btnBuy [49].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (5 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 59;
								btnBuy [49].IsVisible = false;
						}
				} else if (control.name == "Avatar 61") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (60) == false) {
								if (ProfileManager.userProfile.Diamond >= 5) {
										ProfileManager.userProfile.AvatarID = 60;
										ProfileManager.userProfile.Diamond -= 5;
										ProfileManager.userProfile.boughtAvatar (60);
										btnBuy [50].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (5 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 60;
								btnBuy [50].IsVisible = false;
						}
				} else if (control.name == "Avatar 62") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (61) == false) {
								if (ProfileManager.userProfile.Diamond >= 5) {
										ProfileManager.userProfile.AvatarID = 61;
										ProfileManager.userProfile.Diamond -= 5;
										ProfileManager.userProfile.boughtAvatar (61);
										btnBuy [51].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (5 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 61;
								btnBuy [51].IsVisible = false;
						}
				} else if (control.name == "Avatar 63") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (62) == false) {
								if (ProfileManager.userProfile.Diamond >= 5) {
										ProfileManager.userProfile.AvatarID = 62;
										ProfileManager.userProfile.Diamond -= 5;
										ProfileManager.userProfile.boughtAvatar (62);
										btnBuy [52].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (5 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 62;
								btnBuy [52].IsVisible = false;
						}
				} else if (control.name == "Avatar 64") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (63) == false) {
								if (ProfileManager.userProfile.Diamond >= 5) {
										ProfileManager.userProfile.AvatarID = 63;
										ProfileManager.userProfile.Diamond -= 5;
										ProfileManager.userProfile.boughtAvatar (63);
										btnBuy [53].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (5 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 63;
								btnBuy [53].IsVisible = false;
						}
				} else if (control.name == "Avatar 65") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (64) == false) {
								if (ProfileManager.userProfile.Diamond >= 5) {
										ProfileManager.userProfile.AvatarID = 64;
										ProfileManager.userProfile.Diamond -= 5;
										ProfileManager.userProfile.boughtAvatar (64);
										btnBuy [54].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (5 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 64;
								btnBuy [54].IsVisible = false;
						}
				} else if (control.name == "Avatar 66") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (65) == false) {
								if (ProfileManager.userProfile.Diamond >= 5) {
										ProfileManager.userProfile.AvatarID = 65;
										ProfileManager.userProfile.Diamond -= 5;
										ProfileManager.userProfile.boughtAvatar (65);
										btnBuy [55].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (5 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 65;
								btnBuy [55].IsVisible = false;
						}
				} else if (control.name == "Avatar 67") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (66) == false) {
								if (ProfileManager.userProfile.Diamond >= 5) {
										ProfileManager.userProfile.AvatarID = 66;
										ProfileManager.userProfile.Diamond -= 5;
										ProfileManager.userProfile.boughtAvatar (66);
										btnBuy [56].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (5 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 66;
								btnBuy [56].IsVisible = false;
						}
				} else if (control.name == "Avatar 68") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (67) == false) {
								if (ProfileManager.userProfile.Diamond >= 5) {
										ProfileManager.userProfile.AvatarID = 67;
										ProfileManager.userProfile.Diamond -= 5;
										ProfileManager.userProfile.boughtAvatar (67);
										btnBuy [57].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (5 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 67;
								btnBuy [57].IsVisible = false;
						}
				} else if (control.name == "Avatar 69") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (68) == false) {
								if (ProfileManager.userProfile.Diamond >= 5) {
										ProfileManager.userProfile.AvatarID = 68;
										ProfileManager.userProfile.Diamond -= 5;
										ProfileManager.userProfile.boughtAvatar (68);
										btnBuy [58].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (5 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 68;
								btnBuy [58].IsVisible = false;
						}
				} else if (control.name == "Avatar 70") {
						sound.ButtonClick ();
						if (ProfileManager.userProfile.isAvatarBought (69) == false) {
								if (ProfileManager.userProfile.Diamond >= 5) {
										ProfileManager.userProfile.AvatarID = 69;
										ProfileManager.userProfile.Diamond -= 5;
										ProfileManager.userProfile.boughtAvatar (69);
										btnBuy [59].IsVisible = false;
								} else {
										ShowError ();
										LabelError.Text = "You need " + string.Format ("{0:n00}", (5 - ProfileManager.userProfile.Diamond) + " cash more.");
								}
						} else {
								ProfileManager.userProfile.AvatarID = 69;
								btnBuy [59].IsVisible = false;
						}
				} 
				PlayerPrefs.Save ();
		}
	
		public void CloseError ()
		{
				panelError.IsVisible = false;
		}
	
		public void Back ()
		{
				sound.BackSound ();
				AutoFade.LoadLevel ("UserInfo");
		}
}
