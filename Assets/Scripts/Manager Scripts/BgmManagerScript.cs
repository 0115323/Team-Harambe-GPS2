using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum AudioClipID
{
	BGM_MAIN_MENU = 0,
	BGM_BATTLE = 1,
	BGM_GAMEOVER = 2,


	TOTAL = 9001
}

[System.Serializable]
public class AudioClipInfo
{
	public AudioClipID audioClipID;
	public AudioClip audioClip;
}


public class BgmManagerScript : MonoBehaviour 
{

	/*void Start() 
	{
		DontDestroyOnLoad(this.gameObject);	
	}*/

	/*void OnLevelWasLoaded( int level ) 
	{
		switch ( level ) 
		{

		case 0: PlayBGM(0);break;
		case 1: StopBGM();break;
			
		}
	}*/

	private static BgmManagerScript mInstance;
	
	public static BgmManagerScript Instance
	{
		get
		{
			if(mInstance == null)
			{
				if(GameObject.FindWithTag("BgmManager") != null)
				{
					mInstance = GameObject.FindWithTag("BgmManager").GetComponent<BgmManagerScript>();
				}
				else 
				{
					GameObject obj = new GameObject("_BgmManager");
					mInstance = obj.AddComponent<BgmManagerScript>();
				}
				//!DontDestroyOnLoad(obj);
			}
			return mInstance;
		}
	}

	public float bgmVolume;

	
	public List<AudioClipInfo> audioClipInfoList = new List<AudioClipInfo>();
	
	public AudioSource bgmAudioSource;

	public List<AudioSource> bgmAudioSourceList = new List<AudioSource>();

	// Use this for initialization
	void Awake () 
	{
		AudioSource[] audioSourceList = this.GetComponentsInChildren<AudioSource>();
		
		if(audioSourceList[0].gameObject.name == "BGMAudioSource")
		{
			bgmAudioSource = audioSourceList[0];
		}
			
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	AudioClip FindAudioClip(AudioClipID audioClipID)
	{
		for(int i=0; i<audioClipInfoList.Count; i++)
		{
			if(audioClipInfoList[i].audioClipID == audioClipID)
			{
				return audioClipInfoList[i].audioClip;
			}
		}

		Debug.LogError("Cannot Find Audio Clip : " + audioClipID);

		return null;
	}
	
	//! BACKGROUND MUSIC (BGM)
	public void PlayBGM(AudioClipID audioClipID)
	{
		bgmAudioSource.clip = FindAudioClip(audioClipID);
		Debug.Log (audioClipID);
		bgmAudioSource.volume = bgmVolume;
		bgmAudioSource.loop = true;
		bgmAudioSource.Play();
	}
	
	public void PauseBGM()
	{
		if(bgmAudioSource.isPlaying)
		{
			bgmAudioSource.Pause();
		}
	}
	
	public void StopBGM()
	{
		if(bgmAudioSource.isPlaying)
		{
			bgmAudioSource.Stop();
		}
	}

	public void PlayLoopingBGM(AudioClipID audioClipID)
	{
		AudioClip clipToPlay = FindAudioClip(audioClipID);

		for(int i=0; i<bgmAudioSourceList.Count; i++)
		{
			if(bgmAudioSourceList[i].clip == clipToPlay)
			{
				if(bgmAudioSourceList[i].isPlaying)
				{
					return;
				}

				bgmAudioSourceList[i].volume = bgmVolume;
				bgmAudioSourceList[i].Play();
				return;
			}
		}

		AudioSource newInstance = gameObject.AddComponent<AudioSource>();
		newInstance.clip = clipToPlay;
		newInstance.volume = bgmVolume;
		newInstance.loop = true;
		newInstance.Play();
		bgmAudioSourceList.Add(newInstance);
	}

	public void PauseLoopingBGM(AudioClipID audioClipID)
	{
		AudioClip clipToPause = FindAudioClip(audioClipID);

		for(int i=0; i<bgmAudioSourceList.Count; i++)
		{
			if(bgmAudioSourceList[i].clip == clipToPause)
			{
				bgmAudioSourceList[i].Pause();
				return;
			}
		}
	}


	public void StopLoopingBGM(AudioClipID audioClipID)
	{
		AudioClip clipToStop = FindAudioClip(audioClipID);

		for(int i=0; i<bgmAudioSourceList.Count; i++)
		{
			if(bgmAudioSourceList[i].clip == clipToStop)
			{
				bgmAudioSourceList[i].Stop();
				return;
			}
		}
	}
		
	
	public void SetBGMVolume(float value)
	{
		bgmVolume = value;

		for(int i=0; i<bgmAudioSourceList.Count; i++)
		{
			bgmAudioSourceList[i].volume = bgmVolume;
		}
	}

	/*public void volumeControl()
	{
		bgmAudioSource.volume = bgmVolume;
	}*/
		
}