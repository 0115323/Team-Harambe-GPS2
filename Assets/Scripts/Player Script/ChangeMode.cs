using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ChangeMode : MonoBehaviour {

    private GameManager gameManager;

    public Color newColor;


    public GameObject shop;

    private PlayerMovement player;

    public ShootingType shootType = ShootingType.LoveType;
    public Transform firePoint;
	//K the declaration for the button
	public GunType gunType;
	int buttonPress = 0;

    public Button gunBtn;
    public Button changeBulletbtn;

    public Color originalColor;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        gameManager = GameObject.Find("UI").GetComponent<GameManager>();
        originalColor = changeBulletbtn.image.color;
    }

    public void ChangeBullet()
    {
    if (shootType == ShootingType.LoveType)
    {
            changeBulletbtn.image.color = Color.black;
            shootType = ShootingType.HateType;
    }
    else if(shootType == ShootingType.HateType)
    {
            changeBulletbtn.image.color = originalColor;
            shootType = ShootingType.LoveType;
    }
    }

	//K this line of code is used for the gun change.
	//K the button can cycle through the weapons with each press
	public void ChangeGun()
	{

		buttonPress +=1;
		if(buttonPress == 1)
		{
			gunType = GunType.Rifle;
            //gunBtn.GetComponentInChildren<Text>().text ="Rifle";

			//Debug.Log("Rifle");
		}
		if(buttonPress == 2)
		{
			gunType = GunType.Shotgun;
            //gunBtn.GetComponentInChildren<Text>().text ="Shotgun";
			//Debug.Log("Shotgun");
		}

		if(buttonPress > 2)
		{
			buttonPress = 0;
			gunType =  GunType.Pistol;
            //gunBtn.GetComponentInChildren<Text>().text ="Pistol";
			//Debug.Log("Pistol");
		}
	}

    public void UnlockShotgun()
    {
        buttonPress += 1;
        if (buttonPress == 1)
        {
            gunBtn.GetComponent<Button>().interactable = true;
        }
    }


    public void OpenShop()
    {
        gameManager.gunShopInterface.gameObject.SetActive(true);
        player.shop.gameObject.SetActive(false);
        Time.timeScale = 0;

    }

    public void CloseShop()
    {
        gameManager.gunShopInterface.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

}
