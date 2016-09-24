using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ShootScript : MonoBehaviour {

    public Color newColor;


    public ShootingType shootType = ShootingType.LoveType;
    public Transform firePoint;


    void Start()
    {
        
    }


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
