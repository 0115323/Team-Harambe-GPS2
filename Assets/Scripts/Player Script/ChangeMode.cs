using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ChangeMode : MonoBehaviour {

    public Color newColor;


    public ShootingType shootType = ShootingType.LoveType;
    public Transform firePoint;
	//K the declaration for the button
	public GunType gunType;
	int buttonPress = 0;


    public void ChangeToLove()
    {
    if (shootType == ShootingType.LoveType)
    {
            shootType = ShootingType.LoveType;
    }
    else if(shootType == ShootingType.HateType)
    {
            shootType = ShootingType.LoveType;
    }
    }



    public void ChangeToHate()
    {
        if (shootType == ShootingType.LoveType)
        {
            shootType = ShootingType.HateType;
        }
        else if(shootType == ShootingType.HateType)
        {
            shootType = ShootingType.HateType;
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
			Debug.Log("Rifle");
		}
		else if(buttonPress == 2)
		{
			gunType = GunType.Shotgun;
			Debug.Log("Shotgun");
		}

		if(buttonPress > 2)
		{
			buttonPress = 0;
			gunType =  GunType.Pistol;
			Debug.Log("Pistol");
		}
	}

}
