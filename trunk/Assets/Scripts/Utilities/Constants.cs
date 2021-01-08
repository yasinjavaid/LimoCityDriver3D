using UnityEngine;
using System.Collections;

public class Constants {
	
	public const float SCREEN_WIDTH = 1024f;
	public const float SCREEN_HEIGHT = 768f;
	public static float XSCALE = 0f;
	#region InApp
	
	public const string INAPP_KEY = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAtbDYjztTmpu9sV5c5CqM0iFRBpnM/CLwt0YADE4Wzj+MJG2R3+QvCor2ksPN7g6eIdxkGrpViJVMYrYZffA78m3lqfjP+tgcIS0W91cebFnl8x46gShxLS9kS5LmnIt2gFH6VzOsMff33o9/kdYrUq7QPOD37u+Ko60ojjPybxZYHP+1Y9Q2D4NT1NAuWGIPs4Ae3+0GOgbWXSSj6R7WCz6AYAcUrbQRh63R6h09CV27+C0MNay/Rl8Dv/cAIIa86tDwHGYnhT7jTCrA2khvhciD/ehai7bD98VdANN5Q1Yrt/QW9gyst7YMxFBTboWDf/AglWi2EbuBA9LtYRkRjwIDAQAB";
									
	// Consumable In-apps. GN stand for Game Name
	
	public const string INAPP_CURRENCY = "USD";
	
	public const string PACKAGE_1  = "com.tapinator.ait.coins500"; 
	public const string PACKAGE_2 = "com.tapinator.ait.coins1100";
	public const string PACKAGE_3 = "com.tapinator.ait.coins1800";
	public const string PACKAGE_4 = "com.tapinator.ait.coins3500";
	
	
	public const int PACKAGE_1_AMOUNT = 500;
	public const int PACKAGE_2_AMOUNT = 1100;
	public const int PACKAGE_3_AMOUNT = 1800;
	public const int PACKAGE_4_AMOUNT = 3500;
	
	//Non Consumables In-apps. GN stand for Game Name
	public const string REMOVEADS = "com.tapinator.ait.removeads";
	public const string UNLOCKALLEPISODE = "com.tapinator.ait.unlockepi";
	public const string UNLOCKALLVEHICLE = "com.tapinator.ait.unlockveh";
	public const string UNLOCKALL = "com.tapinator.ait.unlockall";
	
	#endregion
	
	#region Achievements
	//ACID stand for Achievement ID
	
	//Social Achievements
	public const string ACIDFBFAN = "CgkIzNDu_-kQEAIQDA";
	public const string ACIDSUPPORTER = "CgkIzNDu_-kQEAIQDQ";
	public const string ACIDTWITTERANNOUNCER = "CgkIzNDu_-kQEAIQDg";
	
	//Parking Achievements
	public const string ACIDRIDER = "CgkIzNDu_-kQEAIQAQ";
	public const string ACIDDRIVER = "CgkIzNDu_-kQEAIQAg";
	public const string ACIDPARKER = "CgkIzNDu_-kQEAIQAw";
	public const string ACIDBUSMAN = "CgkIzNDu_-kQEAIQBA";
	
	//Levels Achievements
	public const string ACIDHONKER = "CgkIzNDu_-kQEAIQBQ";
	public const string ACIDLASHER = "CgkIzNDu_-kQEAIQBg";
	
	public const string ACIDCHAUFFEUR = "CgkIzNDu_-kQEAIQBw";
	public const string ACIDCABBY = "CgkIzNDu_-kQEAIQCA";
	
	//Vehicles Achievements
	public const string ACIDTHIRLLLOVER = "CgkIzNDu_-kQEAIQCg";
	public const string ACIDMASTERBLASTER = "";
	public const string ACIDTURNKEY  = "";
	
	//Environment Achievements
	public const string ACIDEXPLORER = "CgkIzNDu_-kQEAIQCQ";
	public const string ACIDSHOPPINGKING = "";
	public const string ACIDALLOUT = "";
	
	//Coins Achievement
	public const string ACIDMANOFMEANS  = "CgkIzNDu_-kQEAIQCw";
	
	#endregion
	
	#region Leaderboards
	
	//LID stands for Leaderboard ID.
	public const string LIDTHEBENEFACTOR  = "CgkIzNDu_-kQEAIQDw";
	public const string LIDMASTERBLASTER = "CgkIzNDu_-kQEAIQEA";
	
	#endregion
	
	
//	#region AdNetworks
//	
//	public const string INTERSTITIAL_ID_IOS = "0288d8aae44c479bbeae4dbbfe47c148";  // Mobup ID
//	public const string INTERSTITIAL_ID_ANDROID ="73f2746b0f0c40de8b5765868bb37da0";  // Mobup ID
//										   
//	#endregion
	
	#region MenuConstants
	// menus Constants
	public const string	GAME_NAME ="com.tapinator.limocitydriver3d";
	public const string FACEBOOK_LINK = "http://www.facebook.com/549519761779384" ;
	public const string TWITTER_LINK = "http://www.twitter.com/Tapinator" ;
	public const string AMAZON_RATEUS_LINK ="amzn://apps/android?p=com.tapinator.limocitydriver3d";
	public const string IOS_RATEUS_LINK ="";
	public const string ANDROID_RATEUS_LINK ="market://details?id=com.tapinator.limocitydriver3d";
	public const int    COINSTOSKIPLEVEL = 50;            // 50 coins to skip level.
	public const int 	LEVELCOMPLETEREWARD = 30;    // 30 coins
	public const string SCENE_EPISODE1 = "4_emergency_ENV_01";
	public const string SCENE_EPISODE2 = "4_emergency_ENV_02";
	public const string SCENE_EPISODE3 = "4_emergency_ENV_03";
	public const string SCENE_MENU ="MenusScene";
	public const int levelsPerEpisode = 4	;
	
	public const int totalLevels = 12;
//	public const float TIMEPERLEVEL = 100.0f;
	public static string [ ] vehicleNameArray = { "kkkkV" , "kkkk","vehicle", "vehiclea" ,"vehicle " , "monster vehicle" } ;
	public static int	[ ] vehicleSpeedArray 		= {1, 5 ,	15  } ;			// 1 - 15
	public static int	[ ] vehicleHandlingArray	= { 4, 8 ,	15   } ;			// 1 - 15
	public static int	[ ] vehicleBrakingArray 	= {3, 8 ,	15  } ;			// 1 - 15
	public static int	[ ] vehicleResistanceArray	= { 2, 9 ,	15  } ;			// 1 - 15
	public static int [ ] vehicleAccelerationArray  =  {3, 12 , 15 } ;   // 1 s- 15
	public static float [ ] vehicleSelectionArray   = {0.441f, 0.583f,1f };   //  {0.17f, 0.37f, 0.50f,  0.68f, 0.85f , 1f}
 	public static int [ ] vehicleFuelArray    = {3, 3 , 7 , 9 , 15,15 } ;   // 1 - 15
 	public static int [ ] vehicleStrengthArray  = { 5, 5 , 7 , 8 , 15,15 } ;   // 1 - 15
 	public static int [ ] vehiclePriceArray   = { 0 ,  1000 , 1400 , 2500, 4000 , 6000 } ;
	public static int [ ] episodePriceArray   = { 0 ,  1000 , 1400 , 2400 } ;
	public static string [ ] episodeNameArray =       { "Episode 1" , "Episode 2","Episode 3", "Episode 4" } ;
	public static int[,] totalParkingLot = new int[3,levelsPerEpisode]{{2,2,2,2},{2,2,2,2}, {2,2,2,2}};
	public static float[,] timePerLevel = new float[3,levelsPerEpisode]{{85.0f,95.0f,120.0f,110.0f}, {110.0f,110.0f,110.0f,110.0f}, {150.0f,150.0f,150.0f,150.0f}};
	
	#endregion
	
	#region AchievementsRewards
	
	//Social Achievements Rewards
	public const int ACIDFBFANCOMPLETEDREWARD = 10;
	public const int ACIDSUPPORTERCOMPLETEDREWARD =10;
	public const int ACIDTWITTERANNOUNCERCOMPLETEDREWARD = 10;
	
	//Parking Achievements Rewards
	public const int ACIDRIDERCOMPLETEDREWARD = 5;
	public const int ACIDDRIVERCOMPLETEDREWARD = 10;
	public const int ACIDPARKERCOMPLETEDREWARD = 20;
	public const int ACIDBUSMANCOMPLETEDREWARD = 40;
	
	//Levels Achievements Rewards
	public const int ACIDHONKERCOMPLETEDREWARD = 5;
	public const int ACIDLASHERCOMPLETEDREWARD = 10;
	public const int ACIDCHAUFFEURCOMPLETEDREWARD = 15;
	public const int ACIDCABBYCOMPLETEDREWARD = 20;
	
	//Vehicles Achievements Rewards
	public const int ACIDTHIRLLLOVERCOMPLETEDREWARD = 25;
	public const int ACIDMASTERBLASTERCOMPLETEDREWARD = 50;
	public const int ACIDTURNKEYCOMPLETEDREWARD  = 75;
	
	//Environment Achievements Rewards
	public const int ACIDEXPLORERCOMPLETEDREWARD = 25;
	public const int ACIDSHOPPINGKINGCOMPLETEDREWARD = 50;
	public const int ACIDALLOUTCOMPLETEDREWARD = 75;
	
	//Coins Achievement Rewards
	public const int ACIDMANOFMEANSCOMPLETEDREWARD  = 25;
	
	#endregion

	#region AdNetworks
	
	// MoPub Keys
	
	public const string INTERSTITIAL_ID_ANDROID = "8175b70af3924c58b27467eab458321e";  // Mobup FullScreen Ad ID
	public const string BANNER_ID_ANDROID = "58c11feab09b446f8901afa3bbea958f";  // Mobup Banner ID
	
	public const string INTERSTITIAL_ID_IOS = "fb632f9ff4d3430da8f40c6dbb8200e9";  // Mobup FullScreen Ad ID
	public const string BANNER_ID_IOS = "9cb7c325a8bd4c558a1e2714ad175ae4";  // Mobup Banner ID
	
	
	// PlayHaven Keys
	
	public const string AndroidAppTokenPlayHaven = "278e2b55a2cf476c81e7079c9c7bb8c8";
	public const string AndroidAppSecretPlayHaven = "81ec12e084f940d58b50e814eea62a4d";

	public const string iOSAppTokenPlayHaven = "02c029bb105a4d05b59f766531ab9098";
	public const string iOSAppSecretPlayHaven = "98ae56ebf0344af984574d7891cb3152";
	
	public const string PUBLISHER_ID = "6bd06b98f1a55b1b2f4df12b50869820";
	#endregion
}
