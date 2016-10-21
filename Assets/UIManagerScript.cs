using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour {

	public Slider volumeSlider;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void OnVolumeSliderChange()
	{
		BgmManagerScript.Instance.SetBGMVolume(volumeSlider.value);

	}
		
}
