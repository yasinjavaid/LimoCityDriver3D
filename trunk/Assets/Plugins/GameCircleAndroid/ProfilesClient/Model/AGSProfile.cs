using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;


/// <summary>
/// AGS profile.
/// </summary>
public class AGSProfile{
	/// <summary>
	/// player alias.
	/// </summary>
	public string alias;
	/// <summary>
	/// The player identifier.
	/// </summary>
	public string playerId;
	
	
	/// <summary>
	/// creates object from hashtable
	/// </summary>
	/// <returns>
	/// The hashtable.
	/// </returns>
	/// <param name='ht'>
	/// Ht.
	/// </param>
	public static AGSProfile fromHashtable( Hashtable ht ){
		var profile = new AGSProfile();
		profile.alias = getStringValue(ht,"alias");
		profile.playerId = getStringValue(ht,"playerId");
		return profile;
	}
	
	private static String getStringValue(Hashtable ht, String key){
		if(ht.Contains(key)){
			return ht[key].ToString();
		}
		return null;
	}		
			
	public override string ToString(){
		return string.Format( "alias: {0}, playerId: {1}",
			alias, playerId);
	}
	
}
