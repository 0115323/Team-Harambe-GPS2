using UnityEngine;
using System.Collections;

public class SoundControllerScript : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad(this.gameObject);
		BgmManagerScript.Instance.PlayLoopingBGM(AudioClipID.BGM_MAIN_MENU);
		//SFXManagerScript.Instance.PlayLoopingSFX(SFXClipID.SFX_POWERUP);
	}


	void OnLevelWasLoaded( int level ) 
	{
		switch ( level ) 
		{

		case 0: break;
		case 1: BgmManagerScript.Instance.StopLoopingBGM(AudioClipID.BGM_MAIN_MENU); BgmManagerScript.Instance.PlayLoopingBGM(AudioClipID.BGM_BATTLE); break;

		}
	}
		
}
