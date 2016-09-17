using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//I ========================= To Control The Shooting Mode ==============================
public enum ShootingType
{
    LoveType,
    HateType
}
//I ======================== End Of the Shooting Mode Enum ==============================


public class ShootScript : MonoBehaviour {

    public Button button;
    public Color newColor;


    public ShootingType shootType = ShootingType.LoveType;
    public Transform firePoint;




    public void Change()
    {
    if (shootType == ShootingType.LoveType)
    {
    shootType = ShootingType.HateType;
    }
    else if(shootType == ShootingType.HateType)
    {
    shootType = ShootingType.LoveType;
    }
    }
}
