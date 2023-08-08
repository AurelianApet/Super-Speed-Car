using UnityEngine;
using System.Collections;

public class ProfileManager
{
		public static Settings setttings;
		public static UserProfile userProfile;

		//
		public static AchievementProfile achievementProfile;
		public static DailyBonusProfile dailyBonusProfile;

		//
		public static EventProfile eventProfile;
		public static QuestProfile questProfile;
		public static OfferProfile offerProfile;

		public static void init ()
		{
				if (setttings == null || userProfile == null || achievementProfile == null 
						|| dailyBonusProfile == null || eventProfile == null || questProfile == null || offerProfile == null) {

						setttings = new Settings ();
						userProfile = new UserProfile ();

						achievementProfile = new AchievementProfile ();
						dailyBonusProfile = new DailyBonusProfile ();

						eventProfile = new EventProfile ();
						questProfile = new QuestProfile ();
						offerProfile = new OfferProfile ();

						if (Profile.isFirstTime () == true) {
								setttings.saveDefaultValue ();
								userProfile.saveDefaultValue ();

								achievementProfile.saveDefaultValue ();
								dailyBonusProfile.saveDefaultValue ();

								eventProfile.saveDefaultValue ();
								questProfile.saveDefaultValue ();
								offerProfile.saveDefaultValue ();
				
								Profile.saveFirstTime (false);
						} else {
								setttings.load ();
								userProfile.load ();

								achievementProfile.load ();
								dailyBonusProfile.load ();

								eventProfile.load ();
								questProfile.load ();
								offerProfile.load ();
						}
				}
		}
	
		public static void saveAll ()
		{
				PlayerPrefs.Save ();
		}
}