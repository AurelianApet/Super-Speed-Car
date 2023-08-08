using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseMultiplayerGameMenu : BaseHeaderMenu
{
		public static int MAX_CHAT_MESSAGE_SHOW = 10;

		public enum SERVER_STATE
		{
				NOT_START,
				STARTING,
				READY
		}

		//
		public static List<FacebookAvatar> facebookAvatarList;

		//
		protected int maxConnections;
		protected string connectionDetails;
		protected float stateTime;
		protected SERVER_STATE serverState;

		void Awake ()
		{
				Application.runInBackground = true;
				ProfileManager.init ();

				facebookAvatarList = new List<FacebookAvatar> ();
		
				GameData.selectedMode = GameData.GAME_MODE.CLASSIC;
				GameData.numberRaces = 2;
				GameData.level = -1;
				GameData.selectedEvent = -1;
		}
	
		protected void logErrorMessage (string error)
		{
				connectionDetails = error;
//				Debug.Log (connectionDetails);
		}

		public FacebookAvatar getAvatar (string facebookID)
		{
				foreach (FacebookAvatar avatar in facebookAvatarList) {
						if (avatar.facebookID == facebookID) {
								return avatar;
						}
				}
		
				FacebookAvatar fbAvatar = new FacebookAvatar (facebookID, null);
				this.loadFacebookAvatar (fbAvatar);
				fbAvatar.isStartLoading = true;
		
				facebookAvatarList.Add (fbAvatar);
		
				return fbAvatar;
		}
	
		protected void loadFacebookAvatar (FacebookAvatar facebookAvatar)
		{
				StartCoroutine (getProfileImage (facebookAvatar));
		}
	
		IEnumerator getProfileImage (FacebookAvatar facebookAvatar)
		{		
				WWW webRequest = new WWW ("https://graph.facebook.com/" + facebookAvatar.facebookID + "/picture?type=large"); //+ "?access_token=" + FB.AccessToken);
		
				Texture2D avatar = new Texture2D (128, 128, TextureFormat.DXT1, false); //TextureFormat must be DXT1 or DXT5
		
				yield return webRequest;

				if (webRequest.text != null) {	
						if (webRequest.text.ToLower ().Contains ("error")) {
								facebookAvatar.isError = true;

						} else {
								if (webRequest.error == null || webRequest.error == string.Empty) {
										webRequest.LoadImageIntoTexture (avatar);
										facebookAvatar.avatar = avatar;
										facebookAvatar.isAvatarLoaded = true;
								} else {
										facebookAvatar.isError = true;
								}
						}

				} else {		
						if (webRequest.error == null || webRequest.error == string.Empty) {
								webRequest.LoadImageIntoTexture (avatar);
								facebookAvatar.avatar = avatar;
								facebookAvatar.isAvatarLoaded = true;

						} else {
								facebookAvatar.isError = true;
						}
				}
		}

		public int getNumberRaces ()
		{
				switch (GameData.selectedMap) {
				case GameData.MAP_NAME.EGYPT:
						return 2;

				case GameData.MAP_NAME.INDIA:
						return 2;

				case GameData.MAP_NAME.BRAZIL:
						return 2;

				case GameData.MAP_NAME.CHINA:
						return 3;

				case GameData.MAP_NAME.VIET_NAM:
						return 3;

				case GameData.MAP_NAME.PHILIPPINES:
						return 2;

				case GameData.MAP_NAME.THAILAND:
						return 2;

				case GameData.MAP_NAME.USA:
						return 2;

				default:
						return 2;
				}
//				return 1;
		}
}