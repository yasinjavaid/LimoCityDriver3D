using UnityEngine;
using System.Collections;

public class UpdateCoins : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<UILabel>().text = UserPrefs.totalCoins.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
