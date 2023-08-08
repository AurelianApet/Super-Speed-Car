using UnityEngine;
using System.Collections;

public class ChangeAvatar : MonoBehaviour
{
		public dfTextureSprite avatarIcon;
		public Texture2D[] icon;

		void Start ()
		{
				ProfileManager.init ();
		}

		void Update ()
		{		
				if (ProfileManager.userProfile.UseFacebookAvatar == false) {
						avatarIcon.Texture = icon [ProfileManager.userProfile.AvatarID];

				} else {
            //if (FB.IsLoggedIn == true)
            //{
            //    this.loadAvatar();
            //}
            //else {
                avatarIcon.Texture = icon [ProfileManager.userProfile.AvatarID];
						//}
				}
		}
	
		public void loadAvatar ()
		{
				//if (BaseHeaderMenu.avatar == null) {
				//		BaseHeaderMenu.avatar = getAvatar (FB.UserId.ToString ());
				//}
		
				if (BaseHeaderMenu.avatar.isError == false) {
						if (BaseHeaderMenu.avatar.isAvatarLoaded == true) {
								avatarIcon.Texture = BaseHeaderMenu.avatar.avatar;
						} 
				}
		}
	
		public FacebookAvatar getAvatar (string facebookID)
		{		
				FacebookAvatar fbAvatar = new FacebookAvatar (facebookID, null);
				this.loadFacebookAvatar (fbAvatar);
				fbAvatar.isStartLoading = true;
		
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
}