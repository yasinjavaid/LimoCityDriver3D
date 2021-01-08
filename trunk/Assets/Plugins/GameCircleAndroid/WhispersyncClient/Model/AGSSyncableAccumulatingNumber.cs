using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


#if UNITY_ANDROID
/// <summary>
/// AGS syncable accumulating number.
/// </summary>
public class AGSSyncableAccumulatingNumber : AGSSyncable
{
	/// <summary>
	/// Initializes a new instance of the <see cref="AGSSyncableAccumulatingNumber"/> class.
	/// </summary>
	/// <param name='javaObject'>
	/// Java object.
	/// </param>
	public AGSSyncableAccumulatingNumber(AndroidJavaObject javaObject) : base(javaObject){
		
	}
	
	/// <summary>
	/// Set the specified val.
	/// </summary>
	/// <param name='val'>
	/// Value.
	/// </param>
	public void Set(long val){
		javaObject.Call( "set", val );
	}
	
    /// <summary>
    /// Increment by the specified delta.
    /// </summary>
    /// <param name='delta'>
    /// Delta.
    /// </param>
	public void Increment(long delta){
		javaObject.Call ("increment", delta);
	}
    
	/// <summary>
	/// Increment by the specified delta.
	/// </summary>
	/// <param name='delta'>
	/// Delta.
	/// </param>
    public void Increment(double delta){
		javaObject.Call ("increment", delta);	
	}
    
	/// <summary>
	/// Increment by the specified delta.
	/// </summary>
	/// <param name='delta'>
	/// Delta.
	/// </param>
    public void Increment(int delta){
		javaObject.Call ("increment", delta);
	}
    
	/// <summary>
	/// Increment by the specified delta.
	/// </summary>
	/// <param name='delta'>
	/// Delta.
	/// </param>
    public void Increment(String delta){
		javaObject.Call ("increment", delta);		
	}
    
	/// <summary>
	/// Decrement by the specified delta.
	/// </summary>
	/// <param name='delta'>
	/// Delta.
	/// </param>
    public void Decrement(long delta){
		javaObject.Call ("decrement", delta);

	}
    
	/// <summary>
	/// Decrement by the specified delta.
	/// </summary>
	/// <param name='delta'>
	/// Delta.
	/// </param>
    public void Decrement(double delta){
		javaObject.Call ("decrement", delta);

	}
    
	/// <summary>
	/// Decrement by the specified delta.
	/// </summary>
	/// <param name='delta'>
	/// Delta.
	/// </param>
    public void Decrement(int delta){
		javaObject.Call ("decrement", delta);
	}
    
	/// <summary>
	/// Decrement by the specified delta.
	/// </summary>
	/// <param name='delta'>
	/// Delta.
	/// </param>
    public void Decrement(String delta){
		javaObject.Call ("decrement", delta);
	}
 
	/// <summary>
	///  gets current value as a long
	/// </summary>
	/// <returns>
	///  long value
	/// </returns>
	public long AsLong(){
		return javaObject.Call<long>("asLong");
	}

	
	/// <summary>
	///  gets current value as a double
	/// </summary>
	/// <returns>
	///  double value
	/// </returns>	
	public double AsDouble(){
		return javaObject.Call<double>("asDouble");
	}

	/// <summary>
	///  gets current value as an int
	/// </summary>
	/// <returns>
	///  int value
	/// </returns>
	public int AsInt(){
		return javaObject.Call<int>("asInt");
	}	

 	/// <summary>
	///  gets current value as a string
	/// </summary>
	/// <returns>
	///  string value
	/// </returns>
	public string AsString(){
		return javaObject.Call<string>("asString");
	}		
}
#endif