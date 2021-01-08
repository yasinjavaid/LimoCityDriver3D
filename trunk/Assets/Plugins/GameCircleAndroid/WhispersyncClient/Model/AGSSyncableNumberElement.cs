using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;



/// <summary>
/// AGS syncable number element.
/// </summary>
/// 
/// 

#if UNITY_ANDROID
public class AGSSyncableNumberElement : AGSSyncableElement
{
	/// <summary>
	/// Initializes a new instance of the <see cref="AGSSyncableNumberElement"/> class.
	/// </summary>
	/// <param name='JavaObject'>
	/// Java object.
	/// </param>
	public AGSSyncableNumberElement(AndroidJavaObject javaObject) : base(javaObject){
		
	}	
    
	/// <summary>
	/// returns long represnation of this element
	/// </summary>
	/// <returns>
	/// The long.
	/// </returns>
	public long AsLong(){
		return javaObject.Call<long>("asLong");
	}

	/// <summary>
	/// returns double representation of this element
	/// </summary>
	/// <returns>
	/// The double.
	/// </returns>
	public double AsDouble(){
		return javaObject.Call<double>("asDouble");
	}


	/// <summary>
	/// returns int representation of this element
	/// </summary>
	/// <returns>
	/// The int.
	/// </returns>
	public int AsInt(){
		return javaObject.Call<int>("asInt");
	}	

   	/// <summary>
   	/// returns string representation of this element
   	/// </summary>
   	/// <returns>
   	/// The string.
   	/// </returns>
	public string AsString(){
		return javaObject.Call<string>("asString");
	}	
	
}
#endif