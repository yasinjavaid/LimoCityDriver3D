using UnityEngine;
using System.Collections;

public class LocalizableString : MonoBehaviour {

	#region StoreMeunLocalization
	public const string INAPP_CURRENCY = "$";
	public const string GetMore_Coins = "Get More Coins";
	public const string Settings = "Settings";
	public const string Back = "Back";
	
	
	#endregion
	
	#region upgradeMenuStrings
	

	public const string  Next  = "Next"; 
	public const string  START  = "START"; 
	public const string  Coins = "Coins";
	public const string  SelectLevel = "Select Level";
	public const string  GetCoins  ="Get Coins";
	public const string  Of = "OF";
	
	
	public const string  CostEngine = "Cost";
	public const string  EngineCurrentUpgradeCost = "1";
	public const string  Engine ="Engine";
	public const string  EngineCurrentUpgradeValue = "1";
	public const string  EngineTotalUpgradeValue  = "of 10";
	public const string  EngineUpgrade  = "Upgrade";
	public const string  titleEngine = "Engine";
	

	public const string  CostTires  ="COST";
	public const string  TiresCurrentUpgradeCost  ="1";
	public const string  Tires  ="Fuel";
	public const string  Fuel  ="Fuel";
	public const string  TiresCurrentUpgradeValue  ="3";
	public const string  TiresTotalUpgradeValue  ="OF 10";
	public const string  TiresUpgrade  ="UPGRADE";
	public const string  titleTires  ="Fuel";
	
	
	
	public const string  CostSteering  ="COST";
	public const string  SteeringCurrentUpgradeCost  ="1";
	public const string  Steering  ="STEERING";
	public const string  SteeringCurrentUpgradeValue  ="1";
	public const string  SteeringTotalUpgradeValue  ="OF 10";
	public const string  SteeringUpgrade  ="UPGRADE";
	public const string  titleSteering  ="STEERING";
	
	
	public const string  CostBrakes  ="COST";
	public const string  BrakesCurrentUpgradeCost  ="1";
	public const string  Brakes  ="BRAKES";
	public const string  BrakesCurrentUpgradeValue  ="2";
	public const string  BrakesTotalUpgradeValue  ="OF 10";
	public const string  BrakesUpgrade  ="UPGRADE";
	public const string  titleBrakes  ="BRAKES";

	#endregion
	
	
	#region EpisodeMenuLocaliztion
//	public const string SELECT_LEVEL = "Select Level";
	public const string VEHICLE = "Vehicle";
//	public const string NEXT = "Next";
//	public const string GET_COINS = "Get Coins";
	
	#endregion
	
	
	
	#region hudMenuStrings
	
	public const string Episode_1_Name = "Dump Snap";
	public const string Episode_2_Name = "Work At Par";
	public const string Episode_3_Name = "Stiff Drive";

	public const string  lbCoveredDistance  ="4";
	public const string  lbDistance1  ="M / ";
	public const string  lbDistance2  ="M";
	public const string  lbTotalDistance  ="200";
	public const string  lbSpot  ="6";
	public const string  lbTime  ="S To SPOT";
	public const string  lbTimeRemaining  ="4";

	
	// wil be updted from preference
	
	public const string Episode_1_BESTDistance = "1,000";
	public const string Episode_2_BESTDistance = "1,100";
	public const string Episode_3_BESTDistance = "900";
	
	public const string Episode_BESTWORD = "BEST";
	public const string Episode_SPOTWORD = "SPOT";
	
	#endregion
	
	#region VehicleMenuLocaliztion
	
//	public const string SELECT_VEHICLE = "Select VEHICLE";
//	public const string Vehicle_1_Name = "Truck";
//	public const string Vehicle_2_Name = "Dump Truck";
//	public const string Vehicle_3_Name = "Semi-Trailer";

	#endregion
	
//	public class SettingsMenuNew
//	{
//	
//	public const string Music = "MUSIC";
//	public const string Sound = "SOUND";
//	
//	}
	
//	public class PauseMenu
//	{
//	
//	public const string LblBtnResume = "Resume";
//	public const string LblBtnRestart = "Restart";
//	public const string LblBtnExit = "Exit";
//	
//	}
	
//	public class LevelCrashMenuNew
//	{
//		public const string LblCrashedTitle = "You Crashed";
//		public const string LblBtnContinue = "Continue";
//		public const string LblCoinsText = "Coins";
//		public const string LblEarnedCoins = "+60";
//		public const string LblMilesCleared = "2";
//		public const string LblMilestext = "M";
//		public const string LblMilesWithSlash = "M / ";
//		public const string LblProgress = "Progress:";
//		public const string LblSpotsPassed = "5";
//		public const string LblSpotsPassedText = "SPOTS PASSED";
//		public const string LblTotaloutOfMiles = "1221";
//	}
	
	
	
	
	
//	public class UpgradeBreaks
//	{
//	
//	public const string LblBtnUnlockText = "Unlock";
//	public const string LblCoinsRequiredText = "Unlocked Cost:";
//	public const string LblDescription = "asd asd asd asd asd asd asd asd";
//	public const string LblEnoughCoinsText = "You need ";
//	public const string LblMoreCoinsRequired = "5000 more coins!";
//	public const string LblRequiredCoins = "10000 Coins";
//	public const string LblBreaksTitle = "UPGRADE BREAKS";
//	
//	}
	
//	public class UpgradeTyres
//	{
//	
//	public const string LblBtnUnlockText = "Unlock";
//	public const string LblCoinsRequiredText = "Unlocked Cost:";
//	public const string LblDescription = "asd asd asd asd asd asd asd asd";
//	public const string LblEnoughCoinsText = "You need ";
//	public const string LblMoreCoinsRequired = "5000 more coins!";
//	public const string LblRequiredCoins = "10000 Coins";
//	public const string LblTyresTitle = "UPGRADE Tyres";
//	
//	}
	
//	public class UpgradeEngine
//	{
//	
//	public const string LblBtnUnlockText = "Unlock";
//	public const string LblCoinsRequiredText = "Unlocked Cost:";
//	public const string LblDescription = "asd asd asd asd asd asd asd asd";
//	public const string LblEnoughCoinsText = "You need ";
//	public const string LblMoreCoinsRequired = "5000 more coins!";
//	public const string LblRequiredCoins = "10000 Coins";
//	public const string LblEngineTitle = "UPGRADE Engine";
//	
//	}
	
//	public class UpgradeSteering
//	{
//	
//	public const string LblBtnUnlockText = "Unlock";
//	public const string LblCoinsRequiredText = "Unlocked Cost:";
//	public const string LblDescription = "asd asd asd asd asd asd asd asd";
//	public const string LblEnoughCoinsText = "You need ";
//	public const string LblMoreCoinsRequired = "5000 more coins!";
//	public const string LblRequiredCoins = "10000 Coins";
//	public const string LblSteeringTitle = "UPGRADE Steering";
//	
//	}
	
//	public class UnlockVehicleMenuLocalize
//	{
//	
//	public const string LblBtnUnlockText = "Unlock";
//	public const string LblCoinsRequiredText = "Unlocked Cost:";
//	public const string LblDescription = "asd asd asd asd asd asd asd asd";
//	public const string LblEnoughCoinsText = "You have enough coins!";
//	
//	public const string LblRequiredCoins = "10000 Coins";
//	public const string LblVehicleTitle = "UNLOCK CRANE TRUCK?";
//	
//	}
//	public class UnlockLevelMenuLocalize
//	{
//	
//	public const string LblBtnUnlockText = "Unlock";
//	public const string LblCoinsRequiredText = "Unlocked Cost:";
//	public const string LblDescription = "asd asd asd asd asd asd asd asd";
//	public const string LblEnoughCoinsText = "You have enough coins!";
//	
//	public const string LblRequiredCoins = "10000 Coins";
//	public const string LblLevelUnlockTitle = "UNLOCK CRANE Level?";
//	
//	}
	
}
