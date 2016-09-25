using UnityEngine;
using System.Collections.Generic;

public class CameraScript : MonoBehaviour {

    Vector3 PlayerPOS;
    Vector3 direction;

    public Transform player;
    public Transform cameraObject;

    public List<Transform> _hideObjects;

    public LayerMask layerMask;

    public bool isHit;


	// Use this for initialization
	void Start () 
    {
        //I Initialize the list to hide
        _hideObjects = new List<Transform>();
	}
	
	void LateUpdate () 
    {

        //I This is just a simple code to simply make the camera follow the player.
        PlayerPOS = GameObject.FindGameObjectWithTag("Player").transform.transform.position;
        GameObject.Find("Main Camera").transform.position = new Vector3(PlayerPOS.x, PlayerPOS.y+15, PlayerPOS.z-14);

        direction = player.position - cameraObject.position;

        float distance = direction.magnitude;

        RaycastHit[] hits = Physics.RaycastAll(cameraObject.position, direction, distance, layerMask);

        Debug.DrawRay(cameraObject.position, player.position, Color.green);
        Debug.DrawLine(cameraObject.position, player.position, Color.blue);


        //I When the raycast from the camera hit something between the player, the object will be added to the array
        //I of raycast have hit for the object to hide
        for (int i = 0; i < hits.Length; i++)
        {
            Transform currentHit = hits[i].transform;
            Debug.Log("SOME BUILDING IS BLOCKING!!");

            if (!_hideObjects.Contains(currentHit))
            {
                //I the object is added into the list and disabled the renderer
                //I --- WORK IN PROGRESS TO ACHIEVE THE TRANSPARENCY ---------
                _hideObjects.Add(currentHit);
            }
        }

        //I 
        for (int i = 0; i < _hideObjects.Count; i++)
        {
            isHit = false;
            for (int j = 0; j < hits.Length; j++)
            {
                if (hits[j].transform == _hideObjects[i])
                {
                    Debug.Log("Raycast hit something");
                    isHit = true;
                    break;
                }
            }

            if (isHit == false)
            {
                //I remove the object was hidden from the array to render the object back when not in the way
                //I between the camera ray to the player
                //I the object is removed from the list and enabled the renderer
                Transform wasHidden = _hideObjects[i];

                Color newColor = new Color(1,1,1, 1f);
                wasHidden.GetComponent<Renderer>().material.color = newColor;
                _hideObjects.RemoveAt(i);
                i--;
            }
        }
	}

}
