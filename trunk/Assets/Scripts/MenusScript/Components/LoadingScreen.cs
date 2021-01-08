using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {
	
	
//	public GameObject hint;
	AsyncOperation async;
	
	// Use this for initialization
	IEnumerator Start () {
		

	//	async = Application.LoadLevelAsync("MainMenu");
		
		yield return async;
	//	Destroy(GameObject.FindGameObjectWithTag("MainMenu"));		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
