using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void FixedUpdate () {
        //I Distance Away = Centering the camera to the player object
        //I This is just a simple code to simple make the camera follow the player.
        Vector3 PlayerPOS = GameObject.FindGameObjectWithTag("Player").transform.transform.position;
        GameObject.Find("Main Camera").transform.position = new Vector3(PlayerPOS.x, PlayerPOS.y+14.1f, PlayerPOS.z-13);
	}
}
