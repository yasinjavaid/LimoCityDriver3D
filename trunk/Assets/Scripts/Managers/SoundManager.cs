using UnityEngine;
using System.Collections;

public class SoundManager : SingeltonBase<SoundManager>{

	// Use this for initialization
	public AudioClip levelFailSound;
	public AudioClip levelSuccessSound;
	public AudioClip buttonClickSound;
	public AudioClip popupsSound;
	public AudioClip vehicleCrashSound;
	public AudioClip vehicleStartSound;
	public AudioClip menuBGSound;
	public AudioClip gamePlayBGSound;
	public AudioClip vehicleEngineSound;
	public AudioSource gamePlayEffectsSource;
	public AudioSource vehicleEngineSoundSource;
	public AudioClip applauseSound;
	public bool isDualSound = false;
	private bool isGamePlaySound = false;

	void Start () {
//		DontDestroyOnLoad(this);
		vehicleEngineSoundSource.clip = vehicleEngineSound;
		if(isDualSound)
		{
			this.audio.clip = menuBGSound;
			isGamePlaySound = false;
		}
		else
		{
			this.audio.clip = gamePlayBGSound;
			isGamePlaySound = true;
		}
		if(!UserPrefs.isSound)
		{
			this.audio.mute = true;
			gamePlayEffectsSource.mute = true;
			vehicleEngineSoundSource.mute = true;
		}
		if(!this.audio.isPlaying)
		{
			this.audio.Play();
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void PlaySound()
	{
	  switch(GameManager.Instance.GetSoundState())
	  {
	   case GameManager.SoundState.VEHICLECRASHSOUND:
			this.VehicleCrashSound();
	    	break;
	   case GameManager.SoundState.LEVELFAILSOUND:
			this.LevelFailSound();
	    	break;
	   case GameManager.SoundState.LEVELSUCCESSSOUND:
			this.LevelSuccessSound();
	    	break;
	   case GameManager.SoundState.POPUPSOUND:
			this.PopupsSound();
	   		break;
	   case GameManager.SoundState.BUTTONCLICKSOUND:
			this.ButtonClickSound();
	    	break;
	   case GameManager.SoundState.VEHICLESTARTSOUND:
			this.VehicleStartAndEngineSound();
	    	break;
	   case GameManager.SoundState.APPLAUSESOUND:
			this.ApplauseSound();
	    	break;
	   case GameManager.SoundState.MUTESOUND:
			this.MuteSound();
	    	break;
	    case GameManager.SoundState.UNMUTESOUND:
			this.UnMuteSound();
	    	break;

		}
		if(isDualSound)
		{
			if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.MAINMENU || GameManager.Instance.GetCurrentGameState() == GameManager.GameState.EPISODEMENU || GameManager.Instance.GetCurrentGameState() == GameManager.GameState.VEHICLESELECTIONMENU || GameManager.Instance.GetCurrentGameState() == GameManager.GameState.LEVELSELECTIONMENU || GameManager.Instance.GetCurrentGameState() == GameManager.GameState.INTRO)
			{
				if(vehicleEngineSoundSource.isPlaying)
					vehicleEngineSoundSource.Stop();
				if(isGamePlaySound)
				{
					this.audio.clip = menuBGSound;
					isGamePlaySound = false;
					this.audio.Play();
				}
			}
			else if(!isGamePlaySound)
			{
				this.audio.clip = gamePlayBGSound;
				isGamePlaySound = true;
				this.audio.Play();
			}
		}
		else
		{
			if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.MAINMENU || GameManager.Instance.GetCurrentGameState() == GameManager.GameState.EPISODEMENU || GameManager.Instance.GetCurrentGameState() == GameManager.GameState.VEHICLESELECTIONMENU || GameManager.Instance.GetCurrentGameState() == GameManager.GameState.LEVELSELECTIONMENU || GameManager.Instance.GetCurrentGameState() == GameManager.GameState.INTRO)
			{
				if(vehicleEngineSoundSource.isPlaying)
					vehicleEngineSoundSource.Stop();
			}
		}
		
 	 }
	private void ApplauseSound()
	{
		gamePlayEffectsSource.PlayOneShot(applauseSound);
	}
	
	private void VehicleCrashSound()
	{
		if(vehicleEngineSoundSource.isPlaying)
			vehicleEngineSoundSource.Stop();
		gamePlayEffectsSource.PlayOneShot(vehicleCrashSound);
		//StartCoroutine(WaitForEngineSound(levelFailSound.length));
		//gamePlayEffectsSource.PlayOneShot(levelFailSound);
	}
	private void LevelFailSound()
	{
		gamePlayEffectsSource.PlayOneShot(levelFailSound);
	}
	private void LevelSuccessSound()
	{
		if(vehicleEngineSoundSource.isPlaying)
			vehicleEngineSoundSource.Stop();
		gamePlayEffectsSource.PlayOneShot(levelSuccessSound);
	}
	private void ButtonClickSound()
	{
		gamePlayEffectsSource.PlayOneShot(buttonClickSound);
	}
	private void PopupsSound()
	{
		gamePlayEffectsSource.PlayOneShot(popupsSound);
	}
	private void VehicleStartAndEngineSound()
	{
		Debug.Log(">>>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<<<<");
		gamePlayEffectsSource.PlayOneShot(vehicleStartSound);
		StartCoroutine(WaitForEngineSound(vehicleStartSound.length));
		vehicleEngineSoundSource.Play();
	}
	private void MuteSound()
	{
		audio.mute = true;
		vehicleEngineSoundSource.mute = true;
		gamePlayEffectsSource.mute = true;
	}
	private void UnMuteSound()
	{
		audio.mute = false;
		vehicleEngineSoundSource.mute = false;
		gamePlayEffectsSource.mute = false;
	}
	IEnumerator WaitForEngineSound(float clipLength)
	{
		yield return new WaitForSeconds(clipLength);
	}
	
	
}
