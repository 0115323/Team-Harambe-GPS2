using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour {

	public Transform mainMenu, optionMenu;

	public Slider volumeSlider;

	public void ChangeScene()
	{
		SceneManager.LoadScene("Level01");
	}

	public void OnVolumeSliderChange()
	{
		BgmManagerScript.Instance.SetBGMVolume(volumeSlider.value);

	}

	public void OptionMenu(bool clicked)
	{
		if(clicked == true)
		{
			optionMenu.gameObject.SetActive(clicked);
			mainMenu.gameObject.SetActive(false);
		}
		else
		{
			optionMenu.gameObject.SetActive(clicked);
			mainMenu.gameObject.SetActive(true);
		}
	}
		
}
