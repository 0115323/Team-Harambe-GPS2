using UnityEngine;
using System.Collections;

public class NPCScript : MonoBehaviour 
{

    public Stat haremMeter;
    public Stat yaoiMeter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.CompareTag("LoveBullet"))
        {
            haremMeter.CurrentVal += 1;
        }
    }
}
