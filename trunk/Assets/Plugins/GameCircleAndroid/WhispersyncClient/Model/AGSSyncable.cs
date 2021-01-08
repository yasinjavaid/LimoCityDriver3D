using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


#if UNITY_ANDROID
/// <summary>
/// AGS syncable.
/// </summary>
public class AGSSyncable : IDisposable {

	
	protected AndroidJavaObjectFrameManagerWrapper javaObject;
	
	/// <summary>
	/// Initializes a new instance of the <see cref="AGSSyncable"/> class.
	/// </summary>
	/// <param name='jo'>
	/// Jo.
	/// </param>
	public AGSSyncable(AndroidJavaObject jo){
		javaObject = new AndroidJavaObjectFrameManagerWrapper();
		javaObject.setAndroidJavaObject(jo);		
	}
	
	
	/// <summary>
	/// try to enforce disposal references to AndrdoidJavaObjects
	/// upon completion
	/// </summary>
	public void Dispose(){
		if(javaObject != null){
			javaObject.Dispose();
		}
	}
	
	/// <summary>
	///  Helper method for creating a java HashMap from a c# dictionary
	/// </summary>
	/// <param name="dictionary">dictionary to use for HashMap creation</param>
	/// <returns>AndroidJovaObject referencing a java HashMap</returns>
	protected AndroidJavaObject DictionaryToAndroidHashMap(Dictionary<String,String> dictionary){
		
		AndroidJNI.PushLocalFrame(10);

		AndroidJavaObject javaHashMap = new AndroidJavaObject("java.util.HashMap");
		
		//revert to manual JNI calls due to apparent bug in calling put on a hashmap object
		//from the AndroidJavaObject class
		IntPtr putMethod = AndroidJNIHelper.GetMethodID(javaHashMap.GetRawClass(), "put",
            "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;");
      
		object[] keyValSet = new object[2];
				
        foreach(KeyValuePair<string, string> kv in dictionary){

            using(AndroidJavaObject key = new AndroidJavaObject("java.lang.String", kv.Key)){
                using(AndroidJavaObject value = new AndroidJavaObject("java.lang.String", kv.Value)){
                    keyValSet[0] = key;
                    keyValSet[1] = value;
					jvalue[] methodValues = AndroidJNIHelper.CreateJNIArgArray(keyValSet);
                    AndroidJNI.CallObjectMethod(javaHashMap.GetRawObject(),
                        putMethod, methodValues);
                }
            }
        }
		AndroidJNI.PopLocalFrame(System.IntPtr.Zero);
		return javaHashMap;
	}	
	
	
	/// <summary>
	/// Gets the AGS syncable.
	/// </summary>
	/// <returns>
	/// The AGS syncable.
	/// </returns>
	/// <param name='method'>
	/// Method.
	/// </param>
	/// <typeparam name='T'>
	/// The 1st type parameter.
	/// </typeparam>
	protected T GetAGSSyncable<T>(string method){
		return GetAGSSyncable<T>(method, null);
	}
	
	/// <summary>
	/// Gets the AGS syncable.
	/// </summary>
	/// <returns>
	/// The AGS syncable.
	/// </returns>
	/// <param name='method'>
	/// Method.
	/// </param>
	/// <param name='key'>
	/// Key.
	/// </param>
	/// <typeparam name='T'>
	/// The 1st type parameter.
	/// </typeparam>
	protected T GetAGSSyncable<T>(string method, string key){
		AndroidJavaObject jo;
		if(key != null){
			jo = javaObject.Call<AndroidJavaObject>( method, key );
		}else{
			jo = javaObject.Call<AndroidJavaObject>( method );	
		}
		if(jo != null){
			return (T)Activator.CreateInstance(typeof(T), new object[] { jo });
		}
		//return null or 0 as appropriate to the data type returned
		return default(T);	
	}
	
	/// <summary>
	/// Gets the hash set.
	/// </summary>
	/// <returns>
	/// The hash set.
	/// </returns>
	/// <param name='method'>
	/// Method.
	/// </param>
	protected HashSet<String> GetHashSet(string method){
		
		AndroidJNI.PushLocalFrame(10);
		//never return null
		HashSet<string> returnSet = new HashSet<string>();

		//get the string set
		AndroidJavaObject stringSet = javaObject.Call<AndroidJavaObject>( method );
		
		if(stringSet == null){
			return returnSet;
		}
		
		//get iterator from string set
		AndroidJavaObject iterator = stringSet.Call<AndroidJavaObject>( "iterator" );
		
		if(iterator == null){
			return returnSet;	
		}
		
		
		//iterate until it has been... iterated...
		while ( iterator.Call<bool>( "hasNext" ) ){		
			string key = iterator.Call<string>( "next" );
			returnSet.Add(key);
		}
		AndroidJNI.PopLocalFrame(System.IntPtr.Zero);

		return returnSet;	
	}	
	

}
#endif