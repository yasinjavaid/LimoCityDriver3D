using UnityEngine;
using System.Collections;

public class GAManager : SingeltonBase<GAManager>  {

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}
	
	public void LogBusinessEvent(string eventName, string currency, int price){
		#if UNITY_IPHONE
			GA.API.Business.NewEvent(eventName, currency, price);// GA Business	
		#endif
		
		#if UNITY_ANDROID
		
			if(UserPrefs.isAmazonBuild){
			
			} else {
				GA.API.Business.NewEvent(eventName, currency, price);// GA Business
			}
				
		#endif
	}
	
	public void LogDesignEvent(string eventName){
		#if UNITY_IPHONE
			GA.API.Design.NewEvent(eventName);// GA_EVENT	
		#endif
		
		#if UNITY_ANDROID
			if(UserPrefs.isAmazonBuild){
			
			} else {
				GA.API.Design.NewEvent(eventName);// GA_EVENT
			}
		#endif
	}		
		
	/*
	 *  GA_Error.SeverityType --> critical , debug, error, info, warning	 * 
	 */
	
	public void LogErrorEvent(GA_Error.SeverityType serverityType,string error){
		#if UNITY_IPHONE
				
		#endif
		
		#if UNITY_ANDROID
			if(UserPrefs.isAmazonBuild){
			
			} else {
				GA.API.Error.NewEvent(serverityType,error);
			}	
		#endif
	}
}
