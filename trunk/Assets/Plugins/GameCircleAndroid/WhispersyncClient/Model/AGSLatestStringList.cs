using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

#if UNITY_ANDROID
/// <summary>
/// AGS latest string list.
/// </summary>
public class AGSLatestStringList : AGSSyncableStringList{
	
	/// <summary>
	/// Initializes a new instance of the <see cref="AGSLatestStringList"/> class.
	/// </summary>
	/// <param name='javaObject'>
	/// Java object.
	/// </param>
	public AGSLatestStringList(AndroidJavaObject javaObject) : base(javaObject){}
	
}
#endif