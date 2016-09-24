using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

    public Stat haremMeter;
    public Stat yaoiMeter;

	// Use this for initialization
	void Start () 
    {
        haremMeter.Initialize();
        yaoiMeter.Initialize();
	}

}
