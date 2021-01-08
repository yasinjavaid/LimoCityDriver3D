using UnityEngine;
using System.Collections;

public class ArrowsHandler : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
		if(GameObject.FindGameObjectWithTag("Thief")==null)
			gameObject.SetActive(false);
	}
	// Update is called once per frame
	void Update () {
		// 3D Arrow Handling	
		GameObject	parkingLotOrThief = GameObject.FindGameObjectWithTag("Thief");
		Vector3 dir = (parkingLotOrThief.transform.position - this.gameObject.transform.position).normalized;    
		Quaternion rotation = Quaternion.LookRotation(dir);
		this.gameObject.transform.eulerAngles=new Vector3(rotation.eulerAngles.x,rotation.eulerAngles.y+180,rotation.eulerAngles.z);
	}
}
