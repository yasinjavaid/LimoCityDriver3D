using UnityEngine;
using System.Collections;

public class VehicleSwitch : MonoBehaviour {
	public Texture vehicle1Texture;
	public Texture vehicle2Texture;
	public Texture vehicle3Texture;
	public Texture vehicle4Texture;
	public Texture vehicle5Texture;
	public Texture vehicle6Texture;
	// Use this for initialization
	void Start () {
		switch (UserPrefs.currentVehicle)
		{
	    case 1:
			renderer.material.mainTexture = vehicle1Texture;
	        break;
	    case 2:
			renderer.material.mainTexture = vehicle2Texture;
	        break;
		case 3:
			renderer.material.mainTexture = vehicle3Texture;
	    	break;
		case 4:
			renderer.material.mainTexture = vehicle4Texture;
	        break;
			
		case 5:
			renderer.material.mainTexture = vehicle5Texture;
	        break;
		case 6:
			renderer.material.mainTexture = vehicle6Texture;
	        break;
		default:
			renderer.material.mainTexture = vehicle1Texture;
	        break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
