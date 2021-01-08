using UnityEngine;
using System.Collections;

public class UserPrefs : MonoBehaviour 
{
	
	public static bool isTutorialStart = false;
	public static int TutorialStep = 0;
	public static bool isUpsightConfigured = false;
	public static  string remainingtTimeForCurrentLevel = "0";
	public static  float rpmValue= 0;
	public static  bool isAccelaratorPressed  = false; 
	public static int currentFontEpisode;
	public static int currentFontVehicle;
	
// constants
	public static int totalParkingLot = 0;
	public static bool isRestoreTransaction = false;
	public static int fuelBarPercentage = 100;
	public static int currentStoreMenuScreen = 1;
	public static bool isAmazonBuild = false;
	public static bool isIgnoreAds = false;
	public static int totalCoins = 4500;
	public static int[]  unlockLevelsArrays = {1,1,1};   // 10 shows 10 level are unlocked
	public static int currentEpisode = 1 ;  // episdoe start from 1
	public static int currentLevel = 1 ;  // level starts from 1
	public static int currentVehicle = 1;
	public static bool isAllVehiclesUnlock = false;
	public static bool isAllEpisdoesUnlock = false;
	public static bool [ ] vehicleUnlockArray   = { true , false , false  } ;
	public static bool [ ] episodeUnlockArray   = { true , false , false  } ;
	public static bool [ ] episodeCompletedArray   = { false, false , false  } ;
	public static bool isBackKeyPressed = false;//for svn
	public static bool isApplicationResume = false;
	public static int interstitialAdCount = 0;
	public static string _interstitialAdUnitId = "80ca11f68b234f54b8ea60a6af96dd7c";
	public static bool isPlayHavenAdsShowFirstTime = false;
	public static bool isHide = false;
	public static bool isFirstLaunchGoogle = true;
	public static bool signedInGoogle = false;
	public static bool isACHCall = false;
	public static bool isLBCall = false;
	public static bool isGooglePlayCenterAsGuest = true;
	public static bool isLevelComplete = false;
	public static int currentSelectedVehicle = 1;
	public static int currentCameraControl = 1;

	
	public static int accelerometerFactor = 2 ; 		// 0 for Steering, 1 for Accelerometer, 2 for ArrowLeft Right
	public static int selectedEpisode = 1;
// settings variables
	
	public static bool	isSound						= 	true ;
	public static bool	isMusic 					=	true ;

// free ride mode

//  Time for a level

	
	
	public static bool isSlide = false;
	// for FreeDrivingMode
	public static Vector3 [] parkinglotArray ;
		
	
	#region AchievementsVariables
		public static bool isRatesUS = false;
		public static bool isFbFan = false;
		public static bool isTwitterAnnouncer = false;
		public static bool isCoinsPurchsed = false;
	#endregion
	
	#region AchievementsStatus
		//Social Achievements
		public static bool isAcidFbFanCompleted = false;
		public static bool isAcidSupporterCompleted = false;
		public static bool isAcidTwitterAnnouncerCompleted = false;
		
		//Parking Achievements
		public static bool isAcidRiderCompleted = false;
		public static bool isAcidDriverCompleted = false;
		public static bool isAcidParkerCompleted = false;
		public static bool isAcidBusManCompleted = false;
		
		//Levels Achievements
		public static bool isAcidHonkerCompleted = false;
		public static bool isAcidLasherCompleted = false;
		public static bool isAcidChuffeurCompleted = false;
		public static bool isAcidCabbyCompleted = false;
		
		//Vehicles Achievements
		public static bool isAcidThrillLoverCompleted = false;
		public static bool isAcidMasterBlasterCompleted = false;
		public static bool isAcidTurnKeyCompleted  = false;
		
		//Environment Achievements
		public static bool isAcidExplorerCompleted = false;
		public static bool isAcidShoppingKingCompleted = false;
		public static bool isAcidAllOutCompleted = false;
		
		//Coins Achievement
		public static bool isAcidManOfMeansCompleted  = false;
	#endregion
	
	
	
	#region Leaderboard
		public static int coinsCollected = 0;
		public static int vehiclesParked = 0;
	#endregion
	
	public static bool isGoogleSignedIn = false;
	public static float parkingLotLoadingValue = 0;
#if UNITY_ANDROID
	public static GoogleGameCenter googleGameCenter;
#endif	
	public static void Save ( )
	{	
		PreviewLabs.PlayerPrefs.SetInt("accelerometerFactor",accelerometerFactor);
		PreviewLabs.PlayerPrefs.SetBool("isIgnoreAds",isIgnoreAds);
		for ( int i = 0 ; i < episodeUnlockArray.Length ; i ++ )
		{
			PreviewLabs.PlayerPrefs.SetBool		( "episodeUnlockArray"+i,episodeUnlockArray[i]);
		}
		for ( int i = 0 ; i < vehicleUnlockArray.Length ; i ++ )
		{
			PreviewLabs.PlayerPrefs.SetBool		( "vehicleUnlockArray"+i,vehicleUnlockArray[i]);
		}
		for ( int i = 0 ; i < unlockLevelsArrays.Length ; i ++ )
		{
			PreviewLabs.PlayerPrefs.SetInt( "unlockLevelsArrays"+i,unlockLevelsArrays[i]);	
		}
		
		PreviewLabs.PlayerPrefs.SetBool("isAllVehiclesUnlock",isAllVehiclesUnlock);
		PreviewLabs.PlayerPrefs.SetBool("isAllEpisdoesUnlock",isAllEpisdoesUnlock);
		PreviewLabs.PlayerPrefs.SetBool("isMusic",isMusic);
		PreviewLabs.PlayerPrefs.SetBool("isSound",isSound);
		PreviewLabs.PlayerPrefs.SetInt("totalCoins",totalCoins);
		PreviewLabs.PlayerPrefs.SetInt("currentCameraControl",currentCameraControl);
		PreviewLabs.PlayerPrefs.SetInt("selectedEpisode",selectedEpisode);
		PreviewLabs.PlayerPrefs.SetBool("isRatesUS",isRatesUS);
		PreviewLabs.PlayerPrefs.SetBool("isFbFan",isFbFan);
		PreviewLabs.PlayerPrefs.SetBool("isTwitterAnnouncer",isTwitterAnnouncer);
		PreviewLabs.PlayerPrefs.SetBool("isCoinsPurchsed",isCoinsPurchsed);
		PreviewLabs.PlayerPrefs.SetInt("coinsCollected",coinsCollected);
		PreviewLabs.PlayerPrefs.SetInt("vehiclesParked",vehiclesParked);
		PreviewLabs.PlayerPrefs.Flush ( ) ;
	}
	
	public static void Load ( )
	{
		accelerometerFactor = PreviewLabs.PlayerPrefs.GetInt("accelerometerFactor",accelerometerFactor);
		isIgnoreAds = PreviewLabs.PlayerPrefs.GetBool("isIgnoreAds",isIgnoreAds);

		for ( int i = 0 ; i < vehicleUnlockArray.Length ; i ++ )
		{
			vehicleUnlockArray[i] = 		PreviewLabs.PlayerPrefs.GetBool( "vehicleUnlockArray"+i,vehicleUnlockArray[i]);	
		}
		
		for ( int i = 0 ; i < episodeUnlockArray.Length ; i ++ )
		{
			episodeUnlockArray[i] =PreviewLabs.PlayerPrefs.GetBool( "episodeUnlockArray"+i,episodeUnlockArray[i]);
		}
		
		for ( int i = 0 ; i < unlockLevelsArrays.Length ; i ++ )
		{
			unlockLevelsArrays[i] =PreviewLabs.PlayerPrefs.GetInt( "unlockLevelsArrays"+i,unlockLevelsArrays[i]);
		}
		isSound = PreviewLabs.PlayerPrefs.GetBool("isSound",isSound);
		isMusic = PreviewLabs.PlayerPrefs.GetBool("isMusic",isMusic);
		totalCoins = PreviewLabs.PlayerPrefs.GetInt("totalCoins",totalCoins);
		isAllVehiclesUnlock = PreviewLabs.PlayerPrefs.GetBool("isAllVehiclesUnlock",isAllVehiclesUnlock);
		isAllEpisdoesUnlock = PreviewLabs.PlayerPrefs.GetBool("isAllEpisdoesUnlock",isAllEpisdoesUnlock);
		currentCameraControl = PreviewLabs.PlayerPrefs.GetInt("currentCameraControl",currentCameraControl);
		selectedEpisode = PreviewLabs.PlayerPrefs.GetInt("selectedEpisode",selectedEpisode);
		isRatesUS = PreviewLabs.PlayerPrefs.GetBool("isRatesUS",isRatesUS);
		isFbFan = PreviewLabs.PlayerPrefs.GetBool("isFbFan",isFbFan);
		isTwitterAnnouncer = PreviewLabs.PlayerPrefs.GetBool("isTwitterAnnouncer",isTwitterAnnouncer);
		isCoinsPurchsed =PreviewLabs.PlayerPrefs.GetBool("isCoinsPurchsed",isCoinsPurchsed);
		coinsCollected = PreviewLabs.PlayerPrefs.GetInt("coinsCollected",coinsCollected);
		vehiclesParked = PreviewLabs.PlayerPrefs.GetInt("vehiclesParked",vehiclesParked);
		
		
	}
//#if UNITY_IPHONE

	//achievement's id's
/*	
	public static string gettingStarted_ID = "com.tapinator.gettingStarted";
	public static string limoSurvivor_ID = "com.tapinator.parkInTime";
	public static string upToTheBrim_ID = "com.tapinator.park5Cars";
	public static string limoCollector_ID = "com.tapinator.park10Cars";
	public static string shareTheLove_ID = "com.tapinator.rateUs";
	public static string thatWasEasy_ID = "com.tapinator.3carsParkInBroadWay";
	public static string raisingTheBar_ID = "com.tapinator.5carsParkInLombard";
	public static string youGottaBeDriving_ID = "com.tapinator.15carsParkInLasVegus";
	public static string limousineSharpShooter_ID = "com.tapinator.5carsWithoutDamage";
	public static string fastDriver_ID = "com.tapinator.3CarsParkInAnyLevel";
	public static string rookie_ID = "com.tapinator.complete5Levels";
	public static string gettingInTheGame_ID = "com.tapinator.complete10Levels";
	public static string challengeMaster_ID = "com.tapinator.complete30Levels";
	public static string takingItOldSchool_ID = "com.tapinator.earn300Coins";
	public static string oldSchoolDrive_ID = "com.tapinator.earn800Coins";
	public static string amateurDriver_ID = "com.tapinator.completeBroadWay";
	public static string proDriver_ID = "com.tapinator.completeLombard";
	public static string legendaryDiver_ID = "com.tapinator.completeLasVegas";
	public static string aroundTheWorldIn80Drives_ID = "com.tapinator.unlockAllEpisodes";
	public static string piggyBank_ID = "com.tapinator.purchase50Coins";
	public static string makingItDrive_ID = "com.tapinator.purchase120Coins";
	public static string leadDriver_ID = "com.tapinator.purchase300Coins";
	
	// app store id's
	public static string coinsPackage50 = "com.tapinator.50coins";
	public static string coinsPackage120 = "com.tapinator.120coins";
	public static string coinsPackage300 = "com.tapinator.300coins";
	public static string coinsPackage540 = "com.tapinator.540coins";
	public static string coinsPackage950 = "com.tapinator.950coins";
	public static string coinsPackage2100 = "com.tapinator.2100coins";
	public static string lasVegas = "com.tapinator.lasVagas";
	public static string lombard = "com.tapinator.lombard";
	public static string LambardGCID = "com.tapinator.lambard";
	public static string broadWayGCID = "com.tapinator.broadWay";
	public static string LasVagasGCID = "com.tapinator.lasVagas";

#endif

#if UNITY_ANDROID
	
	//achievement's id's
	
	public static string gettingStarted_ID = "CgkI-qzs95IDEAIQAA";
	public static string limoSurvivor_ID = "CgkI-qzs95IDEAIQAQ";
	public static string upToTheBrim_ID = "CgkI-qzs95IDEAIQAg";
	public static string limoCollector_ID = "CgkI-qzs95IDEAIQAw";
	public static string shareTheLove_ID = "CgkI-qzs95IDEAIQBA";
	public static string thatWasEasy_ID = "CgkI-qzs95IDEAIQBQ";
	public static string raisingTheBar_ID = "CgkI-qzs95IDEAIQBg";
	public static string youGottaBeDriving_ID = "CgkI-qzs95IDEAIQBw";
	public static string limousineSharpShooter_ID = "CgkI-qzs95IDEAIQCA";
	public static string fastDriver_ID = "CgkI-qzs95IDEAIQCQ";
	public static string rookie_ID = "CgkI-qzs95IDEAIQCg";
	public static string gettingInTheGame_ID = "CgkI-qzs95IDEAIQCw";
	public static string challengeMaster_ID = "CgkI-qzs95IDEAIQDA";
	public static string takingItOldSchool_ID = "CgkI-qzs95IDEAIQDQ";
	public static string oldSchoolDrive_ID = "CgkI-qzs95IDEAIQDg";
	public static string amateurDriver_ID = "CgkI-qzs95IDEAIQDw";
	public static string proDriver_ID = "CgkI-qzs95IDEAIQEA";
	public static string legendaryDiver_ID = "CgkI-qzs95IDEAIQEQ";
	public static string aroundTheWorldIn80Drives_ID = "CgkI-qzs95IDEAIQEg";
	public static string piggyBank_ID = "CgkI-qzs95IDEAIQEw";
	public static string makingItDrive_ID = "CgkI-qzs95IDEAIQFA";
	public static string leadDriver_ID = "CgkI-qzs95IDEAIQFQ";
	
	// app store id's
	public static string coinsPackage50 = "com.tapinator.50coins";
	public static string coinsPackage120 = "com.tapinator.120coins";
	public static string coinsPackage300 = "com.tapinator.300coins";
	public static string coinsPackage540 = "com.tapinator.540coins";
	public static string coinsPackage950 = "com.tapinator.950coins";
	public static string coinsPackage2100 = "com.tapinator.2100coins";
	public static string lasVegas = "com.tapinator.lasvagas";
	public static string lombard = "com.tapinator.lombard";
	
	public static string LambardGCID = "CgkI-qzs95IDEAIQFw";
	public static string broadWayGCID = "CgkI-qzs95IDEAIQFg";
	public static string LasVagasGCID = "CgkI-qzs95IDEAIQGA";
	
//	public static GPSManager gPSManager;
	
#endif
	
//	public static bool isGooglePlayCenterAsGuest = true;
	
	public static void initializeAttributes () {
		//if(isFreeDrivingMode){
/*			setFreeDrivingMode();
		//}
		totalCoins = 100;
		
		noOfCarsParkedinBroadWay = 0;
		noOfCarsParkedinLombard = 0;
		noOfCarsParkedinLasVegas = 0;
		noOfCoinsEarned = 0;
		noOfCarsParkedWithoutDamage = 0; 
		
		starsArray = new int [totalLevels+1];
		timesArray = new int [totalLevels+1];
		carsOrder = new int [totalLevels+1,6];
		
		// Set the ordering of cars for Episode#1
		setCarOrderingForEpisode1();
		
		// Set the ordering of cars for Episode#2
		setCarOrderingForEpisode2();
		
		// Set the ordering of cars for Episode#3
		setCarOrderingForEpisode3();
		
		parkingLotLoadingValue = 0;
		carsCountArray = new int [totalLevels+1];
		
		for(int i = 1; i < totalLevels+1; i++){
			if(i<=24){
				setCarCountInLevelsForEpisode1(i);				
			} else if(i<=48){
				setCarCountInLevelsForEpisode2(i);				
			}else {
				setCarCountInLevelsForEpisode3(i);				
			}
			
		}
		for(int i = 0; i< totalLevels+1 ; i++){
			timesArray[i] = 200;
		}
*/	//}
	
//	public static void Save()
//	{
	//	Debug.Log("Save()");
//		PreviewLabs.PlayerPrefs.SetInt("totalLevels",totalLevels);
//		PreviewLabs.PlayerPrefs.SetInt("levelsPerEpisode",levelsPerEpisode);
//		PreviewLabs.PlayerPrefs.SetBool("isFirstLaunch",isFirstLaunch);
	//	PreviewLabs.PlayerPrefs.SetInt("totalCoins",totalCoins);	
//		PreviewLabs.PlayerPrefs.SetInt("unlockedLevels",unlockedLevels);
//		PreviewLabs.PlayerPrefs.SetBool("unlockAllCheck",unlockAllCheck);
//		PreviewLabs.PlayerPrefs.SetBool("isIgnoreAds",isIgnoreAds);
//		PreviewLabs.PlayerPrefs.SetBool("episode02unlock",episode02unlock);
//		
//		for ( int i = 0; i < 72 ; i++ )
//		{
//			string starTemp  = "starsArray"+i;
//			PreviewLabs.PlayerPrefs.SetInt(""+starTemp+"", starsArray[i]);
//		}	
//		for ( int i = 0; i < 7 ; i++ )
//		{
//			string busTemp  = "busUnlockArray"+i;
//			PreviewLabs.PlayerPrefs.SetBool(""+busTemp+"", busUnlockArray[i]);
//		}
//								
//		PreviewLabs.PlayerPrefs.SetBool("isHonker",isHonker);
//		PreviewLabs.PlayerPrefs.SetBool("islasher",islasher);
//		PreviewLabs.PlayerPrefs.SetBool("ischauffeur",ischauffeur);
//		PreviewLabs.PlayerPrefs.SetBool("ismotorist",ismotorist);
//		
//		PreviewLabs.PlayerPrefs.SetBool("ispark5BusesinMuseum",ispark5BusesinMuseum);
//		PreviewLabs.PlayerPrefs.SetBool("ispark10BusesinMuseum",ispark10BusesinMuseum);
//		PreviewLabs.PlayerPrefs.SetBool("ispark20BusesinMuseum",ispark20BusesinMuseum);
//		PreviewLabs.PlayerPrefs.SetBool("ispark40BusesinMuseum",ispark40BusesinMuseum);
//		
//		PreviewLabs.PlayerPrefs.SetBool("ispark5BusesinSchool",ispark5BusesinSchool);
//		PreviewLabs.PlayerPrefs.SetBool("ispark10BusesinSchool",ispark10BusesinSchool);
//		PreviewLabs.PlayerPrefs.SetBool("ispark20BusesinSchool",ispark20BusesinSchool);
//		PreviewLabs.PlayerPrefs.SetBool("ispark40BusesinSchool",ispark40BusesinSchool);
//		
//		PreviewLabs.PlayerPrefs.SetBool("isunlockEpisode",isunlockEpisode);
//		PreviewLabs.PlayerPrefs.SetBool("isunlock1Bus",isunlock1Bus);
//		PreviewLabs.PlayerPrefs.SetBool("isunlock3Bus",isunlock3Bus);
//		PreviewLabs.PlayerPrefs.SetBool("isunlock5Bus",isunlock5Bus);
//		
//		PreviewLabs.PlayerPrefs.SetBool("ismanofMeans",ismanofMeans);
//		PreviewLabs.PlayerPrefs.SetBool("isfbFan",isfbFan);
//		PreviewLabs.PlayerPrefs.SetBool("israteus",israteus);
//		PreviewLabs.PlayerPrefs.SetBool("istwitter",istwitter);
//	
//		PreviewLabs.PlayerPrefs.SetBool("isInappPurchased",isInappPurchased);
//			
//		PreviewLabs.PlayerPrefs.SetBool("isSound",isSound);
//		PreviewLabs.PlayerPrefs.SetBool("isMusic",isMusic);
//		PreviewLabs.PlayerPrefs.SetInt("sensitivity",sensitivity);
//		PreviewLabs.PlayerPrefs.SetBool("isCameraMove",isCameraMove);
//		PreviewLabs.PlayerPrefs.SetBool("isFrontCamera",isFrontCamera);
//		PreviewLabs.PlayerPrefs.SetInt("currentCameraControl",currentCameraControl);
//		PreviewLabs.PlayerPrefs.SetBool("isCameraControlSelected",isCameraControlSelected);
//		PreviewLabs.PlayerPrefs.SetInt("currentFrontCameraCount",currentFrontCameraCount);
//		PreviewLabs.PlayerPrefs.SetBool("mainCamera",mainCamera);
//		PreviewLabs.PlayerPrefs.SetBool("isRated",isRated);
//
//		PreviewLabs.PlayerPrefs.SetInt("noOfBusesParked",noOfBusesParked);
//		PreviewLabs.PlayerPrefs.SetInt("userBestinMeusum",userBestinMeusum);
//		PreviewLabs.PlayerPrefs.SetInt("userBestinSchool",userBestinSchool);
////		PreviewLabs.PlayerPrefs.SetBool("isFreeRideMode",isFreeRideMode);
//		
//		PreviewLabs.PlayerPrefs.SetBool("isGooglePlayCenterAsGuest", isGooglePlayCenterAsGuest);
//		PreviewLabs.PlayerPrefs.SetBool("signedInGoogle", signedInGoogle);
//		PreviewLabs.PlayerPrefs.SetBool("isFirstLaunchGoogle", isFirstLaunchGoogle);
//		
//		PreviewLabs.PlayerPrefs.SetInt("accelerometerFactor",accelerometerFactor);
/*		Debug.Log("Saving Data");
		PreviewLabs.PlayerPrefs.SetInt("currentLevel", currentLevel);
		PreviewLabs.PlayerPrefs.SetInt("maxUnlockLevel", maxUnlockLevel);
		PreviewLabs.PlayerPrefs.SetBool("rateUsCheck", rateUsCheck);
		PreviewLabs.PlayerPrefs.SetBool("open2ndEpisode", open2ndEpisode);
		PreviewLabs.PlayerPrefs.SetBool("open3rdEpisode", open3rdEpisode);
		PreviewLabs.PlayerPrefs.SetInt("totalCoins",totalCoins);
		PreviewLabs.PlayerPrefs.SetInt("broadwayHighScore",broadwayHighScore);
		PreviewLabs.PlayerPrefs.SetInt("LambardHighScore",LambardHighScore);
		PreviewLabs.PlayerPrefs.SetInt("LasVagusHighScore",LasVagusHighScore);
		
		// for achievementProgress
		PreviewLabs.PlayerPrefs.SetInt("noOfCarsParkedinBroadWay",noOfCarsParkedinBroadWay);
		PreviewLabs.PlayerPrefs.SetInt("noOfCarsParkedinLombard",noOfCarsParkedinLombard);
		PreviewLabs.PlayerPrefs.SetInt("noOfCarsParkedinLasVegas",noOfCarsParkedinLasVegas);
		PreviewLabs.PlayerPrefs.SetInt("noOfCoinsEarned",noOfCoinsEarned);
		PreviewLabs.PlayerPrefs.SetInt("noOfCarsParkedWithoutDamage",noOfCarsParkedWithoutDamage);
		
		
		// for achievement Complete or Not
		PreviewLabs.PlayerPrefs.SetBool("isGettingStarted", isGettingStarted);
		PreviewLabs.PlayerPrefs.SetBool("isLimoSurvivor", isLimoSurvivor);
		PreviewLabs.PlayerPrefs.SetBool("isUpToTheBrim", isUpToTheBrim);
		PreviewLabs.PlayerPrefs.SetBool("isLimoCollector", isLimoCollector);
		PreviewLabs.PlayerPrefs.SetBool("isShareTheLove", isShareTheLove);
		PreviewLabs.PlayerPrefs.SetBool("isThatWasEasy", isThatWasEasy);
		PreviewLabs.PlayerPrefs.SetBool("isRaisingTheBar", isRaisingTheBar);
		PreviewLabs.PlayerPrefs.SetBool("isYouGottaBeDriving", isYouGottaBeDriving);
		PreviewLabs.PlayerPrefs.SetBool("isLimousineSharpShooter", isLimousineSharpShooter);
		PreviewLabs.PlayerPrefs.SetBool("isFastDriver", isFastDriver);
		PreviewLabs.PlayerPrefs.SetBool("isRookie", isRookie);
		PreviewLabs.PlayerPrefs.SetBool("isGettingInTheGame", isGettingInTheGame);
		PreviewLabs.PlayerPrefs.SetBool("isChallengeMaster", isChallengeMaster);
		PreviewLabs.PlayerPrefs.SetBool("isTakingItOldSchool", isTakingItOldSchool);
		PreviewLabs.PlayerPrefs.SetBool("isOldSchoolDrive", isOldSchoolDrive);
		PreviewLabs.PlayerPrefs.SetBool("isAmateurDriver", isAmateurDriver);
		PreviewLabs.PlayerPrefs.SetBool("isProDriver", isProDriver);
		PreviewLabs.PlayerPrefs.SetBool("isLegendaryDiver", isLegendaryDiver);
		PreviewLabs.PlayerPrefs.SetBool("isAroundTheWorldIn80Drives", isAroundTheWorldIn80Drives);
		PreviewLabs.PlayerPrefs.SetBool("isPiggyBank", isPiggyBank);
		PreviewLabs.PlayerPrefs.SetBool("isMakingItDrive", isMakingItDrive);
		PreviewLabs.PlayerPrefs.SetBool("isLeadDriver", isLeadDriver);

	
		for(var i = 1; i< totalLevels ; i++){
			string starTemp  = "starsArray"+i;
			PreviewLabs.PlayerPrefs.SetInt(""+starTemp+"", starsArray[i]);
		}	
*/		
//		PreviewLabs.PlayerPrefs.Flush();
	
//	}
	
//	public static void Load ( )
//	{
///		Debug.Log("Load()");
	//	totalCoins = PreviewLabs.PlayerPrefs.GetInt("totalCoins",totalCoins);
//		totalLevels = PreviewLabs.PlayerPrefs.GetInt("totalLevels");
//		if ( totalLevels == 0 ) // or file not found 
//		{
////			levelsPerEpisode = PreviewLabs.PlayerPrefs.GetInt("levelsPerEpisode",levelsPerEpisode);
//			isFirstLaunch = PreviewLabs.PlayerPrefs.GetBool("isFirstLaunch",isFirstLaunch);
//			totalCoins = PreviewLabs.PlayerPrefs.GetInt("totalCoins",totalCoins);
//			unlockedLevels = PreviewLabs.PlayerPrefs.GetInt("unlockedLevels",unlockedLevels);
//			unlockAllCheck = PreviewLabs.PlayerPrefs.GetBool("unlockAllCheck",unlockAllCheck);
//			isIgnoreAds = PreviewLabs.PlayerPrefs.GetBool("isIgnoreAds",isIgnoreAds);
//			episode02unlock = PreviewLabs.PlayerPrefs.GetBool("episode02unlock",episode02unlock);
//		
//			for ( int i = 0; i < 72 ; i++ )
//			{
//				string starTemp  = "starsArray"+i;
//				starsArray[i] = PreviewLabs.PlayerPrefs.GetInt(""+starTemp+"",starsArray[i]);
//			}	
//			for ( int i = 0; i < 7 ; i++ )
//			{
//				string busTemp  = "busUnlockArray"+i;
//				busUnlockArray[i] = PreviewLabs.PlayerPrefs.GetBool(""+busTemp+"" , busUnlockArray[i]);
//			}
//			
//			isHonker = PreviewLabs.PlayerPrefs.GetBool("isHonker",isHonker);
//			islasher = PreviewLabs.PlayerPrefs.GetBool("islasher",islasher);
//			ischauffeur = PreviewLabs.PlayerPrefs.GetBool("ischauffeur",ischauffeur);
//			ismotorist = PreviewLabs.PlayerPrefs.GetBool("ismotorist",ismotorist);
//		
//			ispark5BusesinMuseum = PreviewLabs.PlayerPrefs.GetBool("ispark5BusesinMuseum",ispark5BusesinMuseum);
//			ispark10BusesinMuseum = PreviewLabs.PlayerPrefs.GetBool("ispark10BusesinMuseum",ispark10BusesinMuseum);
//			ispark20BusesinMuseum = PreviewLabs.PlayerPrefs.GetBool("ispark20BusesinMuseum",ispark20BusesinMuseum);
//			ispark40BusesinMuseum = PreviewLabs.PlayerPrefs.GetBool("ispark40BusesinMuseum",ispark40BusesinMuseum);
//		
//			ispark5BusesinSchool = PreviewLabs.PlayerPrefs.GetBool("ispark5BusesinSchool",ispark5BusesinSchool);
//			ispark10BusesinSchool = PreviewLabs.PlayerPrefs.GetBool("ispark10BusesinSchool",ispark10BusesinSchool);
//			ispark20BusesinSchool = PreviewLabs.PlayerPrefs.GetBool("ispark20BusesinSchool",ispark20BusesinSchool);
//			ispark40BusesinSchool = PreviewLabs.PlayerPrefs.GetBool("ispark40BusesinSchool",ispark40BusesinSchool);
//		
//			isunlockEpisode = PreviewLabs.PlayerPrefs.GetBool("isunlockEpisode",isunlockEpisode);
//			isunlock1Bus = PreviewLabs.PlayerPrefs.GetBool("isunlock1Bus",isunlock1Bus);
//			isunlock3Bus = PreviewLabs.PlayerPrefs.GetBool("isunlock3Bus",isunlock3Bus);
//			isunlock5Bus = PreviewLabs.PlayerPrefs.GetBool("isunlock5Bus",isunlock5Bus);
//		
//			ismanofMeans = PreviewLabs.PlayerPrefs.GetBool("ismanofMeans",ismanofMeans);
//			isfbFan = PreviewLabs.PlayerPrefs.GetBool("isfbFan",isfbFan);
//			israteus = PreviewLabs.PlayerPrefs.GetBool("israteus",israteus);
//			istwitter = PreviewLabs.PlayerPrefs.GetBool("istwitter",istwitter);
//	
//			isInappPurchased = PreviewLabs.PlayerPrefs.GetBool("isInappPurchased",isInappPurchased);
//			
//			isSound = PreviewLabs.PlayerPrefs.GetBool("isSound",isSound);
//			isMusic = PreviewLabs.PlayerPrefs.GetBool("isMusic",isMusic);
//			sensitivity = PreviewLabs.PlayerPrefs.GetInt("sensitivity",sensitivity);
//			isCameraMove = PreviewLabs.PlayerPrefs.GetBool("isCameraMove",isCameraMove);
//			isFrontCamera = PreviewLabs.PlayerPrefs.GetBool("isFrontCamera",isFrontCamera);
//			currentCameraControl = PreviewLabs.PlayerPrefs.GetInt("currentCameraControl",currentCameraControl);
//			isCameraControlSelected = PreviewLabs.PlayerPrefs.GetBool("isCameraControlSelected",isCameraControlSelected);
//			currentFrontCameraCount = PreviewLabs.PlayerPrefs.GetInt("currentFrontCameraCount",currentFrontCameraCount);
//			mainCamera = PreviewLabs.PlayerPrefs.GetBool("mainCamera",mainCamera);
//			isRated = PreviewLabs.PlayerPrefs.GetBool("isRated",isRated);
//
//			noOfBusesParked = PreviewLabs.PlayerPrefs.GetInt("noOfBusesParked",noOfBusesParked);
//			userBestinMeusum = PreviewLabs.PlayerPrefs.GetInt("userBestinMeusum",userBestinMeusum);
//			userBestinSchool = PreviewLabs.PlayerPrefs.GetInt("userBestinSchool",userBestinSchool);
////			isFreeRideMode = PreviewLabs.PlayerPrefs.GetBool("isFreeRideMode",isFreeRideMode);
//			
//			isGooglePlayCenterAsGuest = PreviewLabs.PlayerPrefs.GetBool("isGooglePlayCenterAsGuest", isGooglePlayCenterAsGuest); 
//			signedInGoogle = PreviewLabs.PlayerPrefs.GetBool("signedInGoogle", signedInGoogle);
//			isFirstLaunchGoogle = PreviewLabs.PlayerPrefs.GetBool("isFirstLaunchGoogle", isFirstLaunchGoogle);
//			
//			accelerometerFactor = PreviewLabs.PlayerPrefs.GetInt("accelerometerFactor",accelerometerFactor);
//			
//			
//		}
//		else
//		{
////			levelsPerEpisode = PreviewLabs.PlayerPrefs.GetInt("levelsPerEpisode",levelsPerEpisode);
//			isFirstLaunch = PreviewLabs.PlayerPrefs.GetBool("isFirstLaunch",isFirstLaunch);
//			totalCoins = PreviewLabs.PlayerPrefs.GetInt("totalCoins",totalCoins);
//			unlockedLevels = PreviewLabs.PlayerPrefs.GetInt("unlockedLevels",unlockedLevels);
//			unlockAllCheck = PreviewLabs.PlayerPrefs.GetBool("unlockAllCheck",unlockAllCheck);
//			isIgnoreAds = PreviewLabs.PlayerPrefs.GetBool("isIgnoreAds",isIgnoreAds);
//			episode02unlock = PreviewLabs.PlayerPrefs.GetBool("episode02unlock",episode02unlock);
//		
//			for ( int i = 0; i < 72 ; i++ )
//			{
//				string starTemp  = "starsArray"+i;
//				starsArray[i] = PreviewLabs.PlayerPrefs.GetInt(""+starTemp+"",starsArray[i]);
//			}	
//			for ( int i = 0; i < 7 ; i++ )
//			{
//				string busTemp  = "busUnlockArray"+i;
//				busUnlockArray[i] = PreviewLabs.PlayerPrefs.GetBool(""+busTemp+"" , busUnlockArray[i]);
//			}
//			
//			isHonker = PreviewLabs.PlayerPrefs.GetBool("isHonker",isHonker);
//			islasher = PreviewLabs.PlayerPrefs.GetBool("islasher",islasher);
//			ischauffeur = PreviewLabs.PlayerPrefs.GetBool("ischauffeur",ischauffeur);
//			ismotorist = PreviewLabs.PlayerPrefs.GetBool("ismotorist",ismotorist);
//		
//			ispark5BusesinMuseum = PreviewLabs.PlayerPrefs.GetBool("ispark5BusesinMuseum",ispark5BusesinMuseum);
//			ispark10BusesinMuseum = PreviewLabs.PlayerPrefs.GetBool("ispark10BusesinMuseum",ispark10BusesinMuseum);
//			ispark20BusesinMuseum = PreviewLabs.PlayerPrefs.GetBool("ispark20BusesinMuseum",ispark20BusesinMuseum);
//			ispark40BusesinMuseum = PreviewLabs.PlayerPrefs.GetBool("ispark40BusesinMuseum",ispark40BusesinMuseum);
//		
//			ispark5BusesinSchool = PreviewLabs.PlayerPrefs.GetBool("ispark5BusesinSchool",ispark5BusesinSchool);
//			ispark10BusesinSchool = PreviewLabs.PlayerPrefs.GetBool("ispark10BusesinSchool",ispark10BusesinSchool);
//			ispark20BusesinSchool = PreviewLabs.PlayerPrefs.GetBool("ispark20BusesinSchool",ispark20BusesinSchool);
//			ispark40BusesinSchool = PreviewLabs.PlayerPrefs.GetBool("ispark40BusesinSchool",ispark40BusesinSchool);
//		
//			isunlockEpisode = PreviewLabs.PlayerPrefs.GetBool("isunlockEpisode",isunlockEpisode);
//			isunlock1Bus = PreviewLabs.PlayerPrefs.GetBool("isunlock1Bus",isunlock1Bus);
//			isunlock3Bus = PreviewLabs.PlayerPrefs.GetBool("isunlock3Bus",isunlock3Bus);
//			isunlock5Bus = PreviewLabs.PlayerPrefs.GetBool("isunlock5Bus",isunlock5Bus);
//		
//			ismanofMeans = PreviewLabs.PlayerPrefs.GetBool("ismanofMeans",ismanofMeans);
//			isfbFan = PreviewLabs.PlayerPrefs.GetBool("isfbFan",isfbFan);
//			israteus = PreviewLabs.PlayerPrefs.GetBool("israteus",israteus);
//			istwitter = PreviewLabs.PlayerPrefs.GetBool("istwitter",istwitter);
//	
//			isInappPurchased = PreviewLabs.PlayerPrefs.GetBool("isInappPurchased",isInappPurchased);
//			
//			isSound = PreviewLabs.PlayerPrefs.GetBool("isSound",isSound);
//			isMusic = PreviewLabs.PlayerPrefs.GetBool("isMusic",isMusic);
//			sensitivity = PreviewLabs.PlayerPrefs.GetInt("sensitivity",sensitivity);
//			isCameraMove = PreviewLabs.PlayerPrefs.GetBool("isCameraMove",isCameraMove);
//			isFrontCamera = PreviewLabs.PlayerPrefs.GetBool("isFrontCamera",isFrontCamera);
//			currentCameraControl = PreviewLabs.PlayerPrefs.GetInt("currentCameraControl",currentCameraControl);
//			isCameraControlSelected = PreviewLabs.PlayerPrefs.GetBool("isCameraControlSelected",isCameraControlSelected);
//			currentFrontCameraCount = PreviewLabs.PlayerPrefs.GetInt("currentFrontCameraCount",currentFrontCameraCount);
//			mainCamera = PreviewLabs.PlayerPrefs.GetBool("mainCamera",mainCamera);
//			isRated = PreviewLabs.PlayerPrefs.GetBool("isRated",isRated);
//
//			noOfBusesParked = PreviewLabs.PlayerPrefs.GetInt("noOfBusesParked",noOfBusesParked);
//			userBestinMeusum = PreviewLabs.PlayerPrefs.GetInt("userBestinMeusum",userBestinMeusum);
//			userBestinSchool = PreviewLabs.PlayerPrefs.GetInt("userBestinSchool",userBestinSchool);
////			isFreeRideMode = PreviewLabs.PlayerPrefs.GetBool("isFreeRideMode",isFreeRideMode);
//			
//			isGooglePlayCenterAsGuest = PreviewLabs.PlayerPrefs.GetBool("isGooglePlayCenterAsGuest");
//			signedInGoogle = PreviewLabs.PlayerPrefs.GetBool("signedInGoogle");
//			isFirstLaunchGoogle = PreviewLabs.PlayerPrefs.GetBool("isFirstLaunchGoogle");
//			
//			accelerometerFactor = PreviewLabs.PlayerPrefs.GetInt("accelerometerFactor",accelerometerFactor);
//		}
		
/*		if(PlayerPrefs.GetInt("currentLevel") == 0){
		Debug.Log("loading Data default");
			for(var i = 1; i< starsArray.Length ; i++){
				string starTemp  = "starsArray"+i;
				starsArray[i]=PreviewLabs.PlayerPrefs.GetInt(starTemp, 0);
			}	
			currentLevel = PreviewLabs.PlayerPrefs.GetInt("currentLevel",currentLevel);
			maxUnlockLevel = PreviewLabs.PlayerPrefs.GetInt("maxUnlockLevel",maxUnlockLevel);
			rateUsCheck = PreviewLabs.PlayerPrefs.GetBool("rateUsCheck",rateUsCheck);
			open2ndEpisode = PreviewLabs.PlayerPrefs.GetBool("open2ndEpisode", open2ndEpisode);
			open3rdEpisode = PreviewLabs.PlayerPrefs.GetBool("open3rdEpisode", open3rdEpisode);
			totalCoins = PreviewLabs.PlayerPrefs.GetInt("totalCoins",totalCoins);
			broadwayHighScore = PreviewLabs.PlayerPrefs.GetInt("broadwayHighScore",broadwayHighScore);
			LambardHighScore = PreviewLabs.PlayerPrefs.GetInt("LambardHighScore",LambardHighScore);
			LasVagusHighScore =PreviewLabs.PlayerPrefs.GetInt("LasVagusHighScore",LasVagusHighScore);
			
			//for achievement progress
			noOfCarsParkedinBroadWay = PreviewLabs.PlayerPrefs.GetInt("noOfCarsParkedinBroadWay",noOfCarsParkedinBroadWay);
			noOfCarsParkedinLombard = PreviewLabs.PlayerPrefs.GetInt("noOfCarsParkedinLombard",noOfCarsParkedinLombard);
			noOfCarsParkedinLasVegas = PreviewLabs.PlayerPrefs.GetInt("noOfCarsParkedinLasVegas",noOfCarsParkedinLasVegas);
			noOfCoinsEarned = PreviewLabs.PlayerPrefs.GetInt("noOfCoinsEarned",noOfCoinsEarned);
			noOfCarsParkedWithoutDamage = PreviewLabs.PlayerPrefs.GetInt("noOfCarsParkedWithoutDamage",noOfCarsParkedWithoutDamage);
			
			// for achievement Complete or Not
			isGettingStarted = PreviewLabs.PlayerPrefs.GetBool("isGettingStarted", isGettingStarted);
			isLimoSurvivor = PreviewLabs.PlayerPrefs.GetBool("isLimoSurvivor", isLimoSurvivor);
			isUpToTheBrim = PreviewLabs.PlayerPrefs.GetBool("isUpToTheBrim", isUpToTheBrim);
			isLimoCollector = PreviewLabs.PlayerPrefs.GetBool("isLimoCollector", isLimoCollector);
			isShareTheLove = PreviewLabs.PlayerPrefs.GetBool("isShareTheLove", isShareTheLove);
			isThatWasEasy = PreviewLabs.PlayerPrefs.GetBool("isThatWasEasy", isThatWasEasy);
			isRaisingTheBar = PreviewLabs.PlayerPrefs.GetBool("isRaisingTheBar", isRaisingTheBar);
			isYouGottaBeDriving = PreviewLabs.PlayerPrefs.GetBool("isYouGottaBeDriving", isYouGottaBeDriving);
			isLimousineSharpShooter = PreviewLabs.PlayerPrefs.GetBool("isLimousineSharpShooter", isLimousineSharpShooter);
			isFastDriver = PreviewLabs.PlayerPrefs.GetBool("isFastDriver", isFastDriver);
			isRookie = PreviewLabs.PlayerPrefs.GetBool("isRookie", isRookie);
			isGettingInTheGame = PreviewLabs.PlayerPrefs.GetBool("isGettingInTheGame", isGettingInTheGame);
			isChallengeMaster = PreviewLabs.PlayerPrefs.GetBool("isChallengeMaster", isChallengeMaster);
			isTakingItOldSchool = PreviewLabs.PlayerPrefs.GetBool("isTakingItOldSchool", isTakingItOldSchool);
			isOldSchoolDrive = PreviewLabs.PlayerPrefs.GetBool("isOldSchoolDrive", isOldSchoolDrive);
			isAmateurDriver = PreviewLabs.PlayerPrefs.GetBool("isAmateurDriver", isAmateurDriver);
			isProDriver = PreviewLabs.PlayerPrefs.GetBool("isProDriver", isProDriver);
			isLegendaryDiver = PreviewLabs.PlayerPrefs.GetBool("isLegendaryDiver", isLegendaryDiver);
			isAroundTheWorldIn80Drives = PreviewLabs.PlayerPrefs.GetBool("isAroundTheWorldIn80Drives", isAroundTheWorldIn80Drives);
			isPiggyBank = PreviewLabs.PlayerPrefs.GetBool("isPiggyBank", isPiggyBank);
			isMakingItDrive = PreviewLabs.PlayerPrefs.GetBool("isMakingItDrive", isMakingItDrive);
			isLeadDriver = PreviewLabs.PlayerPrefs.GetBool("isLeadDriver", isLeadDriver);
		 
		}
		else
		{
			Debug.Log("loading Data from file");
			
			for(var j = 1; j< starsArray.Length ; j++){
				string starTemp1  = "starsArray"+j;
				starsArray[j]=PreviewLabs.PlayerPrefs.GetInt(starTemp1);
			}
			currentLevel = PreviewLabs.PlayerPrefs.GetInt("currentLevel");
			accelerometerFactor = PreviewLabs.PlayerPrefs.GetInt("accelerometerFactor");
			maxUnlockLevel = PreviewLabs.PlayerPrefs.GetInt("maxUnlockLevel");
			rateUsCheck = PreviewLabs.PlayerPrefs.GetBool("rateUsCheck");
			open2ndEpisode = PreviewLabs.PlayerPrefs.GetBool("open2ndEpisode");
			open3rdEpisode = PreviewLabs.PlayerPrefs.GetBool("open3rdEpisode");
			totalCoins = PreviewLabs.PlayerPrefs.GetInt("totalCoins");
			broadwayHighScore = PreviewLabs.PlayerPrefs.GetInt("broadwayHighScore");
			LambardHighScore = PreviewLabs.PlayerPrefs.GetInt("LambardHighScore");
			LasVagusHighScore =PreviewLabs.PlayerPrefs.GetInt("LasVagusHighScore");
			
			//for achievement progress
			noOfCarsParkedinBroadWay = PreviewLabs.PlayerPrefs.GetInt("noOfCarsParkedinBroadWay");
			noOfCarsParkedinLombard = PreviewLabs.PlayerPrefs.GetInt("noOfCarsParkedinLombard");
			noOfCarsParkedinLasVegas = PreviewLabs.PlayerPrefs.GetInt("noOfCarsParkedinLasVegas");
			noOfCoinsEarned = PreviewLabs.PlayerPrefs.GetInt("noOfCoinsEarned");
			noOfCarsParkedWithoutDamage = PreviewLabs.PlayerPrefs.GetInt("noOfCarsParkedWithoutDamage");
			
			// for achievement Complete or Not
			isGettingStarted = PreviewLabs.PlayerPrefs.GetBool("isGettingStarted");
			isLimoSurvivor = PreviewLabs.PlayerPrefs.GetBool("isLimoSurvivor");
			isUpToTheBrim = PreviewLabs.PlayerPrefs.GetBool("isUpToTheBrim");
			isLimoCollector = PreviewLabs.PlayerPrefs.GetBool("isLimoCollector");
			isShareTheLove = PreviewLabs.PlayerPrefs.GetBool("isShareTheLove");
			isThatWasEasy = PreviewLabs.PlayerPrefs.GetBool("isThatWasEasy");
			isRaisingTheBar = PreviewLabs.PlayerPrefs.GetBool("isRaisingTheBar");
			isYouGottaBeDriving = PreviewLabs.PlayerPrefs.GetBool("isYouGottaBeDriving");
			isLimousineSharpShooter = PreviewLabs.PlayerPrefs.GetBool("isLimousineSharpShooter");
			isFastDriver = PreviewLabs.PlayerPrefs.GetBool("isFastDriver");
			isRookie = PreviewLabs.PlayerPrefs.GetBool("isRookie");
			isGettingInTheGame = PreviewLabs.PlayerPrefs.GetBool("isGettingInTheGame");
			isChallengeMaster = PreviewLabs.PlayerPrefs.GetBool("isChallengeMaster");
			isTakingItOldSchool = PreviewLabs.PlayerPrefs.GetBool("isTakingItOldSchool");
			isOldSchoolDrive = PreviewLabs.PlayerPrefs.GetBool("isOldSchoolDrive");
			isAmateurDriver = PreviewLabs.PlayerPrefs.GetBool("isAmateurDriver");
			isProDriver = PreviewLabs.PlayerPrefs.GetBool("isProDriver");
			isLegendaryDiver = PreviewLabs.PlayerPrefs.GetBool("isLegendaryDiver");
			isAroundTheWorldIn80Drives = PreviewLabs.PlayerPrefs.GetBool("isAroundTheWorldIn80Drives");
			isPiggyBank = PreviewLabs.PlayerPrefs.GetBool("isPiggyBank");
			isMakingItDrive = PreviewLabs.PlayerPrefs.GetBool("isMakingItDrive");
			isLeadDriver = PreviewLabs.PlayerPrefs.GetBool("isLeadDriver");
		}
*/	
//	}

	
	
	
	
	

}
