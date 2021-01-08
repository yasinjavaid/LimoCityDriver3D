using UnityEngine;
using System.Collections;

public class TraficManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision coll)
	{
		if(coll.gameObject.tag.Contains("Trafic"))
		{
			coll.gameObject.transform.position=coll.gameObject.GetComponent<TraficCarControls>().startingPoint.position;
			coll.gameObject.transform.eulerAngles=coll.gameObject.GetComponent<TraficCarControls>().startingPoint.eulerAngles;
		}
	}
}
