using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour {

    public Stat haremMeter;
    public Stat yaoiMeter;


    public int affectionPoints;

    public Text affectionPointsText;

	// Use this for initialization
	void Start () 
    {
        haremMeter.Initialize();
        yaoiMeter.Initialize();
	}
}
