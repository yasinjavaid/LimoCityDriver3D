using UnityEngine;
using System.Collections;

public class LevelSpawing : MonoBehaviour {
	public Transform [] levelsArray = new Transform[Constants.levelsPerEpisode];
	// Use this for initialization
	void Start () {
		this.LoadCurrentLevel();
		Debug.Log("UserPrefs.currentLevel" +UserPrefs.currentLevel);
	}
	
	// Update is called once per frame
	void Update () {
//	Debug.Log("car posti called. -----------------------" +UserPrefs.currentLevel);
	}
	
	private void LoadCurrentLevel(){
		
	//	Debug.Log("UserPrefs.currentLevel= "+UserPrefs.currentLevel);
			
		if(UserPrefs.currentEpisode==1)
		{
 			Instantiate(levelsArray[UserPrefs.currentLevel-1], new Vector3(0, 0, 0), Quaternion.identity);
		}
		else if(UserPrefs.currentEpisode==2)
		{
			Instantiate(levelsArray[UserPrefs.currentLevel-1], new Vector3(0, 0, 0), Quaternion.identity);
		}
		
//		else if(UserPrefs.currentEpisode==1)
//		{
//			Instantiate(levelsArray[1], new Vector3(0, 0, 0), Quaternion.identity);
//		switch(UserPrefs.currentLevel)
//		{
//		case 1:
//			Debug.LogError("-------------------Current level is 1 --------------------------");
//			Instantiate(levelsArray[UserPrefs.currentLevel-1], new Vector3(19.85672f, 5.190227f, 23.91462f), Quaternion.identity);
////			Instantiate(levelsArray[UserPrefs.currentLevel-1], new Vector3(0, 0, 0), Quaternion.identity);
//			break;
//	
//		case 2:
//			Debug.LogError("-------------------Current level is 3 --------------------------");
//			Instantiate(levelsArray[UserPrefs.currentLevel-1], new Vector3(-10.5563f, 0, -11.95123f), Quaternion.identity);
//			break;
//		case 3:
//			Debug.LogError("-------------------Current level is 4 --------------------------");
//			Instantiate(levelsArray[UserPrefs.currentLevel-1], new Vector3(0, 0, 0), Quaternion.identity);
//			break;
//	
//		case 4:
//			Debug.LogError("-------------------Current level is 7 --------------------------");
//			Instantiate(levelsArray[UserPrefs.currentLevel-1], new Vector3(-4.653595f, -2.036087f,-58.19358f), Quaternion.identity);
//			break;
//		case 5:
//			Debug.LogError("-------------------Current level is 8 --------------------------");
//			Instantiate(levelsArray[UserPrefs.currentLevel-1], new Vector3(-4.653595f, -2.036087f, -58.19358f), Quaternion.identity);
//			break;
//		case 6:
//			Debug.LogError("-------------------Current level is 9 --------------------------");
//			Instantiate(levelsArray[UserPrefs.currentLevel-1], new Vector3(-7.40906f,-2.036087f, -15.34221f),Quaternion.Euler(0f,-77.80002f,0f));
//			break;
//		case 7:
//			Debug.LogError("-------------------Current level is 10 --------------------------");
//			Instantiate(levelsArray[UserPrefs.currentLevel-1], new Vector3(-7.394689f,-2.036087f,-11.16325f),Quaternion.identity);
//			break;
//		case 8:
//			Debug.LogError("-------------------Current level is 11 --------------------------");
//			Instantiate(levelsArray[UserPrefs.currentLevel-1], new Vector3(-4.653595f, -2.036087f,-58.19358f), Quaternion.identity);
//		
//			break;
//		
//			
//		default:
//			Debug.LogError("-------------------Current level is default --------------------------");
//			break;
//		}
//		}
//		
//		
		
		else if(UserPrefs.currentEpisode==3)
		{
			Instantiate(levelsArray[UserPrefs.currentLevel-1], new Vector3(0, 0, 0), Quaternion.identity);
//			switch(UserPrefs.currentLevel)
//			{
//			case 1:
//				Debug.LogError("-------------------Current level is 2 --------------------------");
//				Instantiate(levelsArray[UserPrefs.currentLevel-1], new Vector3(0, 0, 0), Quaternion.identity);
//				break;
//			case 2:
//				Debug.LogError("-------------------Current level is 5 --------------------------");
//				Instantiate(levelsArray[UserPrefs.currentLevel-1], new Vector3(-41.11f, 0, -7.2f),Quaternion.Euler(0f,94.19999f,0f));
//				break;
//			case 3:
//				Debug.LogError("-------------------Current level is 6 --------------------------");
//				Instantiate(levelsArray[UserPrefs.currentLevel-1], new Vector3(9.217167f, 0, 53.57715f),Quaternion.Euler(0f,95.68f,0f));
//				break;
//			case 7:
//				Debug.LogError("-------------------Current level is 12 --------------------------");
//				Instantiate(levelsArray[UserPrefs.currentLevel-1], new Vector3(-41.11f, 0, -7.2f),Quaternion.Euler(0f,94.19999f,0f));
//				
//				break;
//				
//			default:
//				Instantiate(levelsArray[UserPrefs.currentLevel-1], new Vector3(0, 0, 0), Quaternion.identity);
//				break;
//			}
		}
	}
}
