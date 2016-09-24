using UnityEngine;
using System.Collections;



namespace Cameras
{
    public class CameraScript : MonoBehaviour {

        // Use this for initialization
        void Start () {

        }

        void LateUpdate () 
        {
            //I This is just a simple code to simply make the camera follow the player.
            Vector3 PlayerPOS = GameObject.FindGameObjectWithTag("Player").transform.transform.position;
            GameObject.Find("Main Camera").transform.position = new Vector3(PlayerPOS.x, PlayerPOS.y+14.1f, PlayerPOS.z-13);
        }
    }
}

