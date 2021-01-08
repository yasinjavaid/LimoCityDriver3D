using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


#if UNITY_ANDROID
/// <summary>
/// GameDataMap for accessing syncable data
/// </summary>
/// <remarks>
/// An in-memory representation of the current state of a game's 
/// Whispersync data. This data structure is organized as a map of strings 
/// to containers where each container is a specific syncable type. The 
/// syncable types that are supported are: highest number, lowest number, 
/// latest number, highest number list, lowest number list, accumulating 
/// number, latest string, latest string list, string set, and game data
/// maps (for nested maps). When the GameDataMap is populated or updated 
/// with a new value of each syncable type, that value is automatically 
/// synchronized with data stored locally on the device and in the cloud.
/// </remarks>
public class AGSGameDataMap : AGSSyncable{
	
	/// <summary>
	/// Initializes a new instance of the <see cref="AGSGameDataMap"/> class.
	/// </summary>
	/// <param name='javaObject'>
	/// Java object.
	/// </param>
	public AGSGameDataMap(AndroidJavaObject javaObject) : base(javaObject){
	}

	/// <summary>
	/// get a syncable high number 
	/// </summary>
	/// <remarks>
    /// Retrieves the highest number associated with the given name. 
    /// If such a number does not exist, an empty SyncableNumber 
    /// container is returned which can be set. Once set, that value is 
    /// inserted into the map and automatically synchronized.	
    /// </remarks>
	/// <param name="name">The name of the highest number to return. This cannot be null or empty.</param>
	/// <returns>The highest number associated with the given name</returns>
	public AGSSyncableNumber GetHighestNumber(string name){
		return GetAGSSyncable<AGSSyncableNumber>("getHighestNumber", name);
	}
	
	/// <summary>
	/// Retrieves a collection of keys associated with a highest number.
	/// </summary>
	/// <returns>a collection of keys associated with a highest number.</returns>	
     public HashSet<string> GetHighestNumberKeys(){
		return GetHashSet("getHighestNumberKeys");
	 }

	/// <summary>
	/// Retrieves the lowest number associated with the given name.
	/// </summary>
	/// <remarks>
    /// If such a number does not exist, an empty SyncableNumber 
    /// container is returned which can be set. Once set, that value is 
    /// inserted into the map and automatically synchronized.	
    /// </remarks>
	/// <param name="name">The name of the lowest number to return. This cannot be null or empty.</param>
	/// <returns>The lowest number associated with the given name</returns>	
    public AGSSyncableNumber GetLowestNumber(string name){
		return GetAGSSyncable<AGSSyncableNumber>("getLowestNumber", name);
	}
    

	/// <summary>
	/// Retrieves a collection of keys associated with a lowest number.
	/// </summary>
	/// <returns>a collection of keys associated with a highest number.</returns>		
    public HashSet<string> GetLowestNumberKeys(){
			return GetHashSet("getLowestNumberKeys");
	}

	/// <summary>
	/// Retrieves the latest number associated with the given name.
	/// </summary>
	/// <remarks>
	/// If such a number does not exist, an empty AGSSyncableNumber 
    /// container is returned which can be set. Once set, that value is 
    /// inserted into the map and automatically synchronized.	
    /// </remarks>
	/// <param name="name">The name of the latest number to return.  This cannot be null or empty.</param>
	/// <returns>The latest number associated with the given name.</returns>		
    public AGSSyncableNumber GetLatestNumber(string name){
		return GetAGSSyncable<AGSSyncableNumber>("getLatestNumber", name);	
	}

	/// <summary>
	/// Retrieves a collection of keys associated with a latest number.
	/// </summary>
	/// <returns>a collection of keys associated with a latest number.</returns>	
    public HashSet<string> GetLatestNumberKeys(){
		return GetHashSet("getLatestNumberKeys");
	}

	/// <summary>
    /// Retrieves the high number list associated with the given name. 
    /// </summary> 
    /// <remarks> 
    /// High number lists are sorted in decreasing order by value.
    /// If such a list does not exist, an empty AGSSyncableNumberList 
    /// container is returned which can be set. Once set, that list is 
    /// inserted into the map and automatically synchronized.		
    /// </remarks>
	/// <param name="name">The name of the high number list to return.  This cannot be null or empty.</param>
	/// <returns>The high number list associated with the given name.</returns>		
    public AGSSyncableNumberList GetHighNumberList(string name){
		return GetAGSSyncable<AGSSyncableNumberList>("getHighNumberList",name);
	}


	/// <summary>
	/// Retrieves a collection of keys associated with a high number list.
	/// </summary>
	/// <returns>a collection of keys associated with a high number list.</returns>	
    public HashSet<String> GetHighNumberListKeys(){
		return GetHashSet("getHighNumberListKeys");

	}

	/// <summary>
    /// Retrieves the low number list associated with the given name.
    /// </summary>
	/// <remarks>
    /// Low number lists are sorted in increasing order by value.
    /// If such a list does not exist, an empty AGSSyncableNumberList 
    /// container is returned which can be set. Once set, that list is 
    /// inserted into the map and automatically synchronized.
    /// </remarks>
	/// <param name="name">The name of the low number list to return.  This cannot be null or empty.</param>
	/// <returns>The low number list associated with the given name.</returns>			
    public AGSSyncableNumberList GetLowNumberList(string name){
		return GetAGSSyncable<AGSSyncableNumberList>("getLowNumberList",name);
	}

	
	/// <summary>
	/// Retrieves a collection of keys associated with a low number list.
	/// </summary>
	/// <returns>a collection of keys associated with a low number list.</returns>		
    public HashSet<String> GetLowNumberListKeys(){
		return GetHashSet("getLowNumberListKeys");
	}

	/// <summary>
    /// Retrieves the latest number list associated with the given name. 
    /// </summary>
	/// <remarks>
    /// Latest number lists are sorted in order of the most recently set 
    /// values first, where ties resolve in order of increasing value.  If 
    /// such a list does not exist, an empty AGSSyncableNumberList container 
    /// is returned which can be set. Once set, that list is inserted into
    /// the map and automatically synchronized.
    /// </remarks>
	/// <param name="name">The name of the latest number list to return.  This cannot be null or empty.</param>
	/// <returns>The latest number list associated with the given name.</returns>		
    public AGSSyncableNumberList GetLatestNumberList(string name){
		return GetAGSSyncable<AGSSyncableNumberList>("getLatestNumberList",name);
	}

	/// <summary>
	/// Retrieves a collection of keys associated with a latest number list.
	/// </summary>
	/// <returns>a collection of keys associated with a latest number list.</returns>	
    public HashSet<String> GetLatestNumberListKeys(){
		return GetHashSet("getLatestNumberListKeys");
	}

	/// <summary>
    /// Retrieves the accumulating number associated with the given name. 
    /// </summary>
	/// <remarks>
    /// If such a number does not exist, an empty SyncableAccumulatingNumber 
    /// container is returned which can be set. Once set, that value is 
    /// inserted into the map and automatically synchronized.
    /// </remarks>
	/// <param name="name">The name of the accumulating number to return.  This cannot be null or empty.</param>
	/// <returns>The accumulating number associated with the given name.</returns>	
    public AGSSyncableAccumulatingNumber GetAccumulatingNumber(string name){
		return GetAGSSyncable<AGSSyncableAccumulatingNumber>("getAccumulatingNumber",name);
	}

	/// <summary>
	/// Retrieves a collection of keys associated with an accumulating number..
	/// </summary>
	/// <returns>a collection of keys associated with an accumulating number.</returns>		
    public HashSet<String> GetAccumulatingNumberKeys(){
		return GetHashSet("getAccumulatingNumberKeys");
	}
	
	/// <summary>
    /// Retrieves the latest string associated with the given name. 
    /// </summary>
	/// <remarks>
    /// If such a string does not exist, an empty SyncableString 
    /// container is returned which can be set. Once set, that value is 
    /// inserted into the map and automatically synchronized.
    /// </remarks>
	/// <param name="name"> The name of the latest string to return.  This cannot be null or empty.</param>
	/// <returns>The latest string associated with the given name.</returns>		
    public AGSSyncableString GetLatestString(string name){
		return GetAGSSyncable<AGSSyncableString>("getLatestString",name);
	}

	/// <summary>
	/// Retrieves a collection of keys associated with a latest string.
	/// </summary>
	/// <returns>a collection of keys associated with a latest string.</returns>		
    public HashSet<String> GetLatestStringKeys(){
		return GetHashSet("getLatestStringKeys");
	}

	/// <summary>
    /// Retrieves the latest string list associated with the given name.  
    /// </summary>
	/// <remarks>
    /// Latest string lists are sorted in order of the most recently set 
    /// values first, where ties resolve in alphabetical order by value.  
    /// If such a list does not exist, an empty SyncableStringList container 
    /// is returned which can be set. Once set, that list is inserted into 
    /// the map and automatically synchronized.
    /// </remarks>
	/// <param name="name">The name of the latest string list to return.  This be null or empty.</param>
	/// <returns>The latest string list associated with the given name</returns>	
     public AGSSyncableStringList GetLatestStringList(string name){
		return GetAGSSyncable<AGSSyncableStringList>("getLatestStringList", name);
	 }

	/// <summary>
	/// Retrieves a collection of keys associated with a latest string list.
	/// </summary>
	/// <returns>a collection of keys associated with a latest string list.</returns>	
    public HashSet<string> GetLatestStringListKeys(){
		return GetHashSet("getLatestStringListKeys");
	}

	/// <summary>
    /// Retrieves the string set associated with the given name. 
    /// </summary>
	/// <remarks>
    /// If such a set does not exist, an empty SyncableStringHashSet 
    /// container is returned which can be set. Once set, that set is 
    /// inserted into the map and automatically synchronized.
    /// </remarks>
	/// <param name="name">This cannot be null or empty.</param>
	/// <returns>The latest string set associated with the given name</returns>		
    public AGSSyncableStringSet GetStringSet(string name){
		return GetAGSSyncable<AGSSyncableStringSet>("getStringSet", name);
	}

	/// <summary>
	/// Retrieves a collection of keys associated with the string set.
	/// </summary>
	/// <returns>a collection of keys associated with the string set.</returns>		
    public HashSet<String> GetStringSetKeys(){
		return GetHashSet("getStringSetKeys");
	}

	/// <summary>
    /// Retrieves the nested-map associated with the given name. 
    /// </summary>
	/// <remarks>
    /// If such a map does not exist, an empty GameDataMap 
    /// container is returned which can be set. Once set, that nested-map is 
    /// inserted into the map and automatically synchronized.
    /// </remarks>
	/// <param name="name"> The name of the nested-map to return.  This cannot be null or empty.</param>
	/// <returns>The nested-map associated with the given name.</returns>		
    public AGSGameDataMap GetMap(string name){
		return GetAGSSyncable<AGSGameDataMap>("getMap");

	}

	/// <summary>
	/// Retrieves a collection of keys associated with a nested-map.
	/// </summary>
	/// <returns>a collection of keys associated with a nested-map.</returns>	
    public HashSet<string> GetMapKeys(){
		return GetHashSet("getMapKeys");
	}	

}
#endif