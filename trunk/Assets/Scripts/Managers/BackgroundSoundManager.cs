using UnityEngine;
using System.Collections;

public class BackgroundSoundManager :SingeltonBase<BackgroundSoundManager> {
	
	
	 public AudioSource backgrpundmusicSource;
	public AudioClip backgroundMusicClip;
	// Use this for initialization
	
	void Start () {
		DontDestroyOnLoad(gameObject);
		backgrpundmusicSource = gameObject.GetComponent<AudioSource>();
		Debug.LogError(backgrpundmusicSource+"abc"+UserPrefs.isMusic);
		
		if(!UserPrefs.isMusic)
		{
			backgrpundmusicSource.Stop();
		}
		else{
			Debug.LogError("Playing");
			backgrpundmusicSource.audio.clip = backgroundMusicClip;
			backgrpundmusicSource.Play();
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
	public void playOrStopMusic(){
		
		if(!UserPrefs.isMusic)
		{
			backgrpundmusicSource.Stop();
		}
		else{
			backgrpundmusicSource.audio.clip = backgroundMusicClip;
			backgrpundmusicSource.Play();
		}
	} 
}
