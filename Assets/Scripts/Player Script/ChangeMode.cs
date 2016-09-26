using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ChangeMode : MonoBehaviour {

    public Color newColor;


    public ShootingType shootType = ShootingType.LoveType;
    public Transform firePoint;

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
}
