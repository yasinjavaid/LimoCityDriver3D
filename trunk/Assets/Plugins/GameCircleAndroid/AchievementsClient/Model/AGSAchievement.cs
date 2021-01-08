using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;


/// <summary>
/// AGS achievement.
/// </summary>
public class AGSAchievement{
	public string title;
	public string id;
	public int pointValue;
	public bool isHidden;
	public bool isUnlocked;
	public float progress;
	public int position;
	public string decription;
	public DateTime dateUnlocked;
	
	
	/// <summary>
	/// creates object from hashtable
	/// </summary>
	/// <returns>
	/// The hashtable.
	/// </returns>
	/// <param name='ht'>
	/// Ht.
	/// </param>
	public static AGSAchievement fromHashtable( Hashtable ht ){
		var achievement = new AGSAchievement();
		achievement.title = getStringValue(ht,"title");
		achievement.id = getStringValue(ht,"id");
		achievement.decription = getStringValue (ht, "description");
		try{
			string str = getStringValue(ht,"pointValue");
			achievement.pointValue = int.Parse(str);
		}catch(FormatException e){
			Debug.Log("Unable to parse pointValue from achievement " + e.Message);
		}catch(ArgumentNullException e){
			Debug.Log("pointValue not found  " + e.Message);
		}
		
		try{			
			string str = getStringValue(ht,"position");
			achievement.position = int.Parse(str);
		}catch(FormatException e){
			Debug.Log("Unable to parse position from achievement " + e.Message);
		}catch(ArgumentNullException e){
			Debug.Log("position not found " + e.Message);
		}
		
		try{			
			string str = getStringValue(ht,"progress");
			achievement.progress = float.Parse(str);
		}catch(FormatException e){
			Debug.Log("Unable to parse progress from achievement " + e.Message);
		}catch(ArgumentNullException e){
			Debug.Log("progress not found " + e.Message);
		}		
	
		try{
			string str = getStringValue(ht,"hidden");
			achievement.isHidden = bool.Parse(str);
		}catch(FormatException e){
			Debug.Log("Unable to parse isHidden from achievement " + e.Message);
		}catch(ArgumentNullException e){
			Debug.Log("isHidden not found " + e.Message);
		}
		
		try{
			string str = getStringValue(ht,"unlocked");
			achievement.isUnlocked = bool.Parse(str);
		}catch(FormatException e){
			Debug.Log("Unable to parse isUnlocked from achievement " + e.Message);
		}catch(ArgumentNullException e){
			Debug.Log("isUnlocked not found " + e.Message);
		}		
		
		try{
			string str = getStringValue(ht,"dateUnlocked");
			long epochTimeMillis = long.Parse(str);
			achievement.dateUnlocked = getTimefromEpochTime(epochTimeMillis);
		}catch(FormatException e){
			Debug.Log("Unable to parse dateUnlocked from achievement " + e.Message);
		}catch(ArgumentNullException e){
			Debug.Log("dateUnlocked not found " + e.Message);
		}	
							
		return achievement;
	}
	
	
	private static DateTime getTimefromEpochTime(double javaTimeStamp){
 		DateTime dateTime = new DateTime(1970,1,1,0,0,0,0);
    	dateTime = dateTime.AddSeconds(Math.Round(javaTimeStamp / 1000)).ToLocalTime();
		return dateTime;	
	}

	private static String getStringValue(Hashtable ht, String key){
		if(ht.Contains(key)){
			return ht[key].ToString();
		}
		return null;
	}
	
	
	public override string ToString(){
		return string.Format( "title: {0}, id: {1}, pointValue: {2}, hidden: {3}, unlocked: {4}, progress: {5}, position: {6}, date: {7} ", 
			title, id, pointValue, isHidden, isUnlocked, progress, position, dateUnlocked);
	}
	
}
