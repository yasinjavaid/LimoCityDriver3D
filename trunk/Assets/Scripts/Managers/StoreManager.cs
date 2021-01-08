using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Globalization;
using System;
using MiniJSON;


public class StoreManager : SingeltonBase<StoreManager> {
	
	// Product identifiers array is for only IOS Because before performing any inapp you should get Product identifiers from store.
	# if UNITY_IPHONE
		string purchasedProductId;
		string [] productIdentifiers = {ConstantsNew.PACKAGE_1,ConstantsNew.PACKAGE_2,ConstantsNew.PACKAGE_3,ConstantsNew.PACKAGE_4,ConstantsNew.PACKAGE_5,ConstantsNew.PACKAGE_VGP,ConstantsNew.UNLOCKALLEPISODE, ConstantsNew.UNLOCKALLVEHICLE, ConstantsNew.UNLOCKALL };
		bool canMakePayments = false;	
	# endif
	# if UNITY_ANDROID
		string [] productIdentifiers = {ConstantsNew.PACKAGE_1,ConstantsNew.PACKAGE_2,ConstantsNew.PACKAGE_3,ConstantsNew.PACKAGE_4,ConstantsNew.PACKAGE_5,ConstantsNew.PACKAGE_VGP };
		string [] managedProductIdentifiers = {Constants.REMOVEADS,Constants.UNLOCKALLEPISODE, Constants.UNLOCKALLVEHICLE, Constants.UNLOCKALL  };  	
//		bool isRestoreTransaction = false;
	# endif
	

	// Used for Purchase from Store.
	public void PurchasePackage(string packageName){
		Debug.Log("buy one package of " + packageName);
		# if UNITY_IPHONE
			if(canMakePayments)
			{
		        StoreKitBinding.purchaseProduct(packageName,1);
	    	}
		# endif
		
		# if UNITY_ANDROID
			if(UserPrefs.isAmazonBuild){
				AmazonIAP.initiatePurchaseRequest(packageName);
			} else {
				if(!isNonConsumedItem(packageName)){
					GoogleIAB.consumeProduct(packageName);		
				}
			
				GoogleIAB.purchaseProduct(packageName);			  	
			}
		
		# endif
	}
	
	// Used for Restoring Transactions from Store.
	
	public void RestoreCompletedTransactions(){
		# if UNITY_IPHONE
			if(canMakePayments)
			{
				StoreKitBinding.restoreCompletedTransactions();
		        
	    	}
		# endif
		
		# if UNITY_ANDROID
			UserPrefs.isRestoreTransaction = true;			
			if(UserPrefs.isAmazonBuild){
//				AmazonIAP.initiateItemDataRequest(managedProductIdentifiers);
			} else {
		  		GoogleIAB.queryInventory(managedProductIdentifiers);
			}
		# endif
	}
	
	// Used for Getting Product Identifier from Store.
	
	private void RequestProductIdentifier(){
		
		# if UNITY_IPHONE
	 		Debug.Log("Before Calling can make payment");
			canMakePayments = StoreKitBinding.canMakePayments();
			if(canMakePayments){
				StoreKitBinding.requestProductData(productIdentifiers);
			}	
		# endif
			
		# if UNITY_ANDROID
			if(UserPrefs.isAmazonBuild){
				UserPrefs.isRestoreTransaction = true;	
				AmazonIAP.initiateItemDataRequest(productIdentifiers);
			} else {
	 			GoogleIAB.init(Constants.INAPP_KEY);
//				ConsumeProducts();
				Invoke("queryInventory", 2.0f);
			}
		# endif
	}
    
		void queryInventory()
	{
		UserPrefs.isRestoreTransaction = true;
//				GoogleIAB.queryInventory(productIdentifiers);
	}
	
	void Start(){
		this.RequestProductIdentifier();
	}
	
	# if UNITY_IPHONE
	
	    void OnEnable()
	    {
	        // Listens to all the StoreKit events.  All event listeners MUST be removed before this object is disposed!
			StoreKitManager.purchaseSuccessfulEvent += purchaseSuccessful;
			StoreKitManager.purchaseCancelledEvent += purchaseCancelled;
			StoreKitManager.purchaseFailedEvent += purchaseFailed;
	    }
	    
	    
	    void OnDisable()
	    {
	        // Remove all the event handlers
	        StoreKitManager.purchaseSuccessfulEvent -= purchaseSuccessful;
			StoreKitManager.purchaseCancelledEvent -= purchaseCancelled;
			StoreKitManager.purchaseFailedEvent -= purchaseFailed;
	    }
	
	   	void purchaseFailed( string error )
		{
			Debug.Log( "purchase failed with error: " + error );
			GameManager.Instance.PurchaseProductResult(error, false);
		}
	
		void purchaseCancelled( string error )
		{
			GameManager.Instance.PurchaseProductResult("Purchased Canceled", false);
			Debug.Log( "purchase cancelled with error: " + error );
		}
		
		void restoreTransactionsFailed( string error )
		{
			Debug.Log( "restoreTransactionsFailed: " + error );
		}
		
		void restoreTransactionsFinished()
		{
			Debug.Log( "restoreTransactionsFinished" );
		}
	
		void purchaseSuccessful( StoreKitTransaction transaction )
		{
			purchasedProductId =  transaction.productIdentifier;
			verifyReceipt(ConstantsNew.receiptVerifySandboxURL,transaction);
		}
	
		public WWW verifyReceipt(string url, StoreKitTransaction transaction)
    	{	
			string jsonString = String.Format("{{ \"receipt-data\" : \"{0}\"}}", transaction.base64EncodedTransactionReceipt);
			Hashtable postHeader = new Hashtable();
			postHeader.Add("Content-Type", "application/json");		
			System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
       	 	WWW www = new WWW(url,encoding.GetBytes(jsonString),postHeader);
	   	 	StartCoroutine(WaitForRequest(www));
    		return www; 
    	}
	

		private IEnumerator WaitForRequest(WWW www)
    	{
     	   	yield return www;
      	  	if (www.error == null)
       		{
				string response = www.text; 
				IDictionary search = (IDictionary) Json.Deserialize(response);
				IDictionary receiptDic = (IDictionary) search["receipt"];
				DateTime transDate = DateTime.SpecifyKind(DateTime.Parse(receiptDic["purchase_date"].ToString().Replace("\"", "").Replace("Etc/GMT", "")), DateTimeKind.Utc);
				TimeSpan delay = DateTime.UtcNow - transDate;	
			
				if((search["status"].ToString().Equals("0")) && (receiptDic["bvrs"].ToString().Equals(ConstantsNew.bundleVersion))
					&& (receiptDic["bid"].ToString().Equals(ConstantsNew.BundleID))
					&& (delay.TotalHours < 4) && (receiptDic["product_id"].ToString().Equals(purchasedProductId)))
				{		
					GameManager.Instance.PurchaseProductResult(receiptDic["product_id"].ToString(), true);
					purchasedProductId = "";
				}
				else
				{
					GAManager.Instance.LogDesignEvent("User Made a fake purchase");
				}	
        	} 
			else 
			{
			Debug.Log("error:"+www.error);		
        	}    
    	}
	    
	# endif
	

	#if UNITY_ANDROID
	
	#region Common InApp
	void OnEnable()
	{
		if(UserPrefs.isAmazonBuild){
			// Listen to all events for illustration purposes
			AmazonIAPManager.itemDataRequestFailedEvent += itemDataRequestFailedEvent;
			AmazonIAPManager.itemDataRequestFinishedEvent += itemDataRequestFinishedEvent;
			AmazonIAPManager.purchaseFailedEvent += purchaseFailedEvent;
			AmazonIAPManager.purchaseSuccessfulEvent += purchaseSuccessfulEvent;
			AmazonIAPManager.purchaseUpdatesRequestFailedEvent += purchaseUpdatesRequestFailedEvent;
			AmazonIAPManager.purchaseUpdatesRequestSuccessfulEvent += purchaseUpdatesRequestSuccessfulEvent;
			AmazonIAPManager.onSdkAvailableEvent += onSdkAvailableEvent;
			AmazonIAPManager.onGetUserIdResponseEvent += onGetUserIdResponseEvent;
		} else {
			// Listen to all events for illustration purposes
			GoogleIABManager.billingSupportedEvent += billingSupportedEvent;
			GoogleIABManager.billingNotSupportedEvent += billingNotSupportedEvent;
			GoogleIABManager.queryInventorySucceededEvent += queryInventorySucceededEvent;
			GoogleIABManager.queryInventoryFailedEvent += queryInventoryFailedEvent;
			GoogleIABManager.purchaseCompleteAwaitingVerificationEvent += purchaseCompleteAwaitingVerificationEvent;
			GoogleIABManager.purchaseSucceededEvent += purchaseSucceededEvent;
			GoogleIABManager.purchaseFailedEvent += purchaseFailedEvent;
			GoogleIABManager.consumePurchaseSucceededEvent += consumePurchaseSucceededEvent;
			GoogleIABManager.consumePurchaseFailedEvent += consumePurchaseFailedEvent;
		}
	}


	void OnDisable()
	{
		if(UserPrefs.isAmazonBuild){
			// Remove all event handlers
			AmazonIAPManager.itemDataRequestFailedEvent -= itemDataRequestFailedEvent;
			AmazonIAPManager.itemDataRequestFinishedEvent -= itemDataRequestFinishedEvent;
			AmazonIAPManager.purchaseFailedEvent -= purchaseFailedEvent;
			AmazonIAPManager.purchaseSuccessfulEvent -= purchaseSuccessfulEvent;
			AmazonIAPManager.purchaseUpdatesRequestFailedEvent -= purchaseUpdatesRequestFailedEvent;
			AmazonIAPManager.purchaseUpdatesRequestSuccessfulEvent -= purchaseUpdatesRequestSuccessfulEvent;
			AmazonIAPManager.onSdkAvailableEvent -= onSdkAvailableEvent;
			AmazonIAPManager.onGetUserIdResponseEvent -= onGetUserIdResponseEvent;
		} else {
			// Remove all event handlers
			GoogleIABManager.billingSupportedEvent -= billingSupportedEvent;
			GoogleIABManager.billingNotSupportedEvent -= billingNotSupportedEvent;
			GoogleIABManager.queryInventorySucceededEvent -= queryInventorySucceededEvent;
			GoogleIABManager.queryInventoryFailedEvent -= queryInventoryFailedEvent;
			GoogleIABManager.purchaseCompleteAwaitingVerificationEvent += purchaseCompleteAwaitingVerificationEvent;
			GoogleIABManager.purchaseSucceededEvent -= purchaseSucceededEvent;
			GoogleIABManager.purchaseFailedEvent -= purchaseFailedEvent;
			GoogleIABManager.consumePurchaseSucceededEvent -= consumePurchaseSucceededEvent;
			GoogleIABManager.consumePurchaseFailedEvent -= consumePurchaseFailedEvent;
		}
	}

	void purchaseFailedEvent( string error )
	{
		Debug.Log( "purchaseFailedEvent: " + error );
		
		GameManager.Instance.PurchaseProductResult(error, false);
	}
	
	bool isNonConsumedItem(string packageName)
	{
		bool isNonConsumed = false;
		
		for(int i = 0; i < managedProductIdentifiers.Length; i++){
			if(managedProductIdentifiers[i] == packageName ){
				isNonConsumed = true;
				break;
			}
		}
		
		return isNonConsumed;
	}
	void ConsumeProducts()
	{
		for(int i = 0; i < productIdentifiers.Length; i++){
			if(!isNonConsumedItem(productIdentifiers[i]))
			{
				GoogleIAB.consumeProduct(productIdentifiers[i]);
			}
		}
	}
	
	#endregion
	
	#region Google InApp
	void billingSupportedEvent()
	{
		Debug.Log( "billingSupportedEvent" );
	}


	void billingNotSupportedEvent( string error )
	{
		Debug.Log( "billingNotSupportedEvent: " + error );
	}


	void queryInventorySucceededEvent( List<GooglePurchase> purchases, List<GoogleSkuInfo> skus )
	{
		Debug.Log( string.Format( "queryInventorySucceededEvent. total purchases: {0}, total skus: {1}", purchases.Count, skus.Count ) );
		Prime31.Utils.logObject( purchases );
		Prime31.Utils.logObject( skus );
		
		if(UserPrefs.isRestoreTransaction && purchases != null){
			
			for(int i=0; i<purchases.Count; i++){					
				Debug.Log("<<>>SkuPurchases:"+purchases[i].productId);
				if(isNonConsumedItem(purchases[i].productId)){
					purchaseSucceededEvent(purchases[i]);
					UserPrefs.isRestoreTransaction = false;
				}						
			}
			
			UserPrefs.isRestoreTransaction = false;
			
		}
	}


	void queryInventoryFailedEvent( string error )
	{
		UserPrefs.isRestoreTransaction = false;
		Debug.Log( "queryInventoryFailedEvent: " + error );
	}


	void purchaseCompleteAwaitingVerificationEvent( string purchaseData, string signature )
	{
		Debug.Log( "purchaseCompleteAwaitingVerificationEvent. purchaseData: " + purchaseData + ", signature: " + signature );
	}
	

	void purchaseSucceededEvent( GooglePurchase purchase )
	{
		Debug.Log( "purchaseSucceededEvent: " + purchase );
		
		if(!UserPrefs.isAmazonBuild && !isNonConsumedItem(purchase.productId)){
			GoogleIAB.consumeProduct(purchase.productId);
		}
		
		GameManager.Instance.PurchaseProductResult(purchase.productId, true);
	}

	void consumePurchaseSucceededEvent( GooglePurchase purchase )
	{
		Debug.Log( "consumePurchaseSucceededEvent: " + purchase );
	}


	void consumePurchaseFailedEvent( string error )
	{
		Debug.Log( "consumePurchaseFailedEvent: " + error );
	}
	
	#endregion
	
	#region Amazon InApp
	
	void itemDataRequestFailedEvent()
	{
		Debug.Log( "itemDataRequestFailedEvent" );
	}


	void itemDataRequestFinishedEvent( List<string> unavailableSkus, List<AmazonItem> availableItems )
	{
		Debug.Log( "itemDataRequestFinishedEvent. unavailable skus: " + unavailableSkus.Count + ", avaiable items: " + availableItems.Count );
	}

	void purchaseSuccessfulEvent( AmazonReceipt receipt )
	{
		Debug.Log( "purchaseSuccessfulEvent: " + receipt );
		
		GameManager.Instance.PurchaseProductResult(receipt.sku, true);
	}


	void purchaseUpdatesRequestFailedEvent()
	{
		Debug.Log( "purchaseUpdatesRequestFailedEvent" );
		UserPrefs.isRestoreTransaction = false;
	}
	
	void purchaseUpdatesRequestSuccessfulEvent( List<string> revokedSkus, List<AmazonReceipt> receipts )
	{
		Debug.Log( "purchaseUpdatesRequestSuccessfulEvent. revoked skus: " + revokedSkus.Count );
		if(UserPrefs.isRestoreTransaction && receipts != null){			
		
			foreach( AmazonReceipt receipt in receipts ){
				Debug.Log("<<>>SkuPurchases:"+receipt.sku);
				if(isNonConsumedItem(receipt.sku)){
					purchaseSuccessfulEvent( receipt );
					UserPrefs.isRestoreTransaction = false;
				} 
			}
			
			UserPrefs.isRestoreTransaction = false;
		}
	}


	void onSdkAvailableEvent( bool isTestMode )
	{
		Debug.Log( "onSdkAvailableEvent. isTestMode: " + isTestMode );
	}


	void onGetUserIdResponseEvent( string userId )
	{
		Debug.Log( "onGetUserIdResponseEvent: " + userId );
	}
	#endregion
	
	#endif
        
}
