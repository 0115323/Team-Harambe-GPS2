using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class CameraScript : MonoBehaviour {

    Vector3 PlayerPOS;
    Vector3 direction;

    public Transform player;
    public Transform cameraObject;

    public List<Transform> _hideObjects;
    public List<Transform> _showOutsideObjects;

    public LayerMask layerMask;

    private bool isHit;
    private bool isRendering;

    public float renderRadius;

    public GameObject[] objectToHide;

    public List<Material> originalMaterial;
    public Material transparentMaterial;

    public float renderTime;
    void Awake()
    {

        objectToHide = GameObject.FindGameObjectsWithTag("Props");

        foreach (GameObject obj in objectToHide)
        {
            obj.GetComponent<Renderer>().enabled = false;
        }


        player = GameObject.Find("Player").transform;
        cameraObject = GameObject.Find("Main Camera").transform;

        if (!player)
            return;
        if (!cameraObject)
            return;

    }

	// Use this for initialization
	void Start () 
    {
        //I Initialize the list to hide
        _hideObjects = new List<Transform>();
        _showOutsideObjects = new List<Transform>();
        originalMaterial = new List<Material>();
        InvokeRepeating("renderObjects", 0.0f, renderTime);
        InvokeRepeating("transparentObjects", 0.0f, 0.35f);
	}


	void LateUpdate () 
    {
        //I This is just a simple code to simply make the camera follow the player.
        PlayerPOS = GameObject.FindGameObjectWithTag("Player").transform.transform.position;
        GameObject.Find("Main Camera").transform.position = new Vector3(PlayerPOS.x, PlayerPOS.y+150, PlayerPOS.z-100);
        GameObject.Find("Main Camera").transform.position = new Vector3(PlayerPOS.x, PlayerPOS.y + 100, PlayerPOS.z - 100);
	}


    private void transparentObjects()
    {
        direction = player.position - cameraObject.position;

        float distance = direction.magnitude;

        RaycastHit[] hits = Physics.RaycastAll(cameraObject.position, direction, distance, layerMask);

        //Debug.DrawRay(cameraObject.position, player.position, Color.green);
        //Debug.DrawLine(cameraObject.position, player.position, Color.blue);


        //I When the raycast from the camera hit something between the player, the object will be added to the array
        //I of raycast have hit for the object to hide
        for (int i = 0; i < hits.Length; i++)
        {
            Transform currentHit = hits[i].transform;
            //Debug.Log("SOME BUILDING IS BLOCKING!!");

            if (!_hideObjects.Contains(currentHit))
            {
                //I the object is added into the list and disabled the renderer
                //I --- WORK IN PROGRESS TO ACHIEVE THE TRANSPARENCY ---------
                _hideObjects.Add(currentHit);
                 originalMaterial.Add(currentHit.GetComponent<Renderer>().material);
                currentHit.GetComponent<Renderer>().material = transparentMaterial;
            }
        }

        for (int i = 0; i < _hideObjects.Count; i++)
        {
            isHit = false;
            for (int j = 0; j < hits.Length; j++)
            {
                if (hits[j].transform == _hideObjects[i])
                {
                    //Debug.Log("Raycast hit something");
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
                Material _materialOrigin = originalMaterial[i];

                wasHidden.GetComponent<Renderer>().material = _materialOrigin;

                originalMaterial.RemoveAt(i);
                _hideObjects.RemoveAt(i);
                i--;
            }
        }
    }

    //I To render objects when the player is near it
    private void renderObjects()
    {
        //I Creating an array of collider and converting it into physics spehere type
        Collider[] objectsToRender = Physics.OverlapSphere (player.transform.position, renderRadius, layerMask);



        for (int i = 0; i < objectsToRender.Length; i++)
        {
            //I Register all objects to render inside an array
            Transform shownObjects = objectsToRender[i].transform;

            if (!_showOutsideObjects.Contains(shownObjects))
            {
                //I Render all the objects hit by collider and enabled the renderer
                _showOutsideObjects.Add(shownObjects);
                shownObjects.GetComponent<Renderer>().enabled = true;
            }

        }

        for (int i = 0; i < _showOutsideObjects.Count; i++)
        {
            isRendering = false;
            for (int j = 0; j < objectsToRender.Length; j++)
            {
                if (objectsToRender[j].transform == _showOutsideObjects[i])
                {
                    isRendering = true;
                    break;
                }
            }

            if (isRendering == false)
            {
                Transform objectsWasHidden = _showOutsideObjects[i];
                objectsWasHidden.GetComponent<Renderer>().enabled = false;
                _showOutsideObjects.RemoveAt(i);
                i--;
            }

        }

    }


}
