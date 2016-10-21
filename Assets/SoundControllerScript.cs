using UnityEngine;
using System.Collections;

public class SoundControllerScript : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		BgmManagerScript.Instance.PlayLoopingBGM(AudioClipID.BGM_MAIN_MENU);
		//SFXManagerScript.Instance.PlayLoopingSFX(SFXClipID.SFX_POWERUP);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
