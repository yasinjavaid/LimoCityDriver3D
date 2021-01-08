using UnityEngine;
using System;

#if UNITY_ANDROID
public class AndroidJavaObjectFrameManagerWrapper : System.IDisposable{
	
	AndroidJavaObject jo;
	
	public AndroidJavaObjectFrameManagerWrapper(){
		
	}
	
	public AndroidJavaObjectFrameManagerWrapper(AndroidJavaObject jo){
		this.jo = jo;
		
	}
	
	public AndroidJavaObject getJavaObject(){
		return jo;	
	}
	
	public void setAndroidJavaObject(AndroidJavaObject jo){
		this.jo = jo;	
	}
	
	public IntPtr GetRawObject(){
		if(Application.platform == RuntimePlatform.Android){
			return jo.GetRawObject();
		}else{
			return default(IntPtr);	
		}
	}

	public IntPtr GetRawClass(){
		if(Application.platform == RuntimePlatform.Android){
			return jo.GetRawClass();
		}else{
			return default(IntPtr);	
		}
	}
	
	public void Set<FieldType>(string fieldName, FieldType type) {
		if(Application.platform == RuntimePlatform.Android){
			jo.Set<FieldType>(fieldName,type);
		}
	}
	
	public FieldType Get<FieldType>(string fieldName){
		if(Application.platform == RuntimePlatform.Android){
			return jo.Get<FieldType>(fieldName);
		}else{
			return default(FieldType);	
		}
	}
	
	public void SetStatic<FieldType>(string fieldName, FieldType type) {
		if(Application.platform == RuntimePlatform.Android){	
			jo.SetStatic<FieldType>(fieldName,type);
		}
	}
	
	public FieldType GetStatic<FieldType>(string fieldName){
		if(Application.platform == RuntimePlatform.Android){	
			return jo.GetStatic<FieldType>(fieldName);
		}else{
			return default(FieldType);
		}
	}
	
	public void CallStatic(string method, params object[] args){
		if(Application.platform == RuntimePlatform.Android){	
			AndroidJNI.PushLocalFrame(args.Length+1);
			jo.CallStatic(method, args);
			AndroidJNI.PopLocalFrame(System.IntPtr.Zero);
		}
		
	}	
	
	public void Call(string method, params object[] args){
		if(Application.platform == RuntimePlatform.Android){
			AndroidJNI.PushLocalFrame(args.Length+1);
			jo.Call(method, args);
			AndroidJNI.PopLocalFrame(System.IntPtr.Zero);
		}
		
	}	
	
	public ReturnType CallStatic<ReturnType>(string method, params object[] args){
		if(Application.platform == RuntimePlatform.Android){
			AndroidJNI.PushLocalFrame(args.Length+1);
			ReturnType retVal = jo.CallStatic<ReturnType>(method, args);
			AndroidJNI.PopLocalFrame(System.IntPtr.Zero);		
			return retVal;
		}else{
			return default(ReturnType);	
		}
	}	
	
	public ReturnType Call<ReturnType>(string method, params object[] args){
		if(Application.platform == RuntimePlatform.Android){
			AndroidJNI.PushLocalFrame(args.Length+1);
			ReturnType retVal = jo.Call<ReturnType>(method, args);
			AndroidJNI.PopLocalFrame(System.IntPtr.Zero);		
			return retVal;
		}else{
			return default(ReturnType); 	
		}
	}
	
	public void Dispose(){
		if(jo != null){
			jo.Dispose();
		}
	}	
	
}
#endif