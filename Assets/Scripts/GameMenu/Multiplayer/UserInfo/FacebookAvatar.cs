using UnityEngine;
using System.Collections;

public class FacebookAvatar
{
		public Texture2D avatar;
		public string facebookID;
		public bool isAvatarLoaded;
		public bool isStartLoading;
		public bool isError;

		public FacebookAvatar (string userID, Texture2D avatar)
		{
				this.facebookID = userID;
				this.avatar = avatar;
				this.isAvatarLoaded = false;
				this.isStartLoading = false;
				this.isError = false;
		}
}
