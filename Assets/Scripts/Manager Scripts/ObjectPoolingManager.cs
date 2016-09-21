using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class ObjectPoolingManager : MonoBehaviour {

    public static ObjectPoolingManager objPoolManager;

    public int bulletPooledAmount;


    List<GameObject> loveBullets;
    List<GameObject> hateBullets;


    private int maxPooledLoveBullets = 5;
    private int maxPooledHateBullets = 5;


    public GameObject loveBullet;
    public GameObject hateBullet;

    public bool willGrow = true;


    //I All THIS SCRIPT WILL BE COMMENTED LATER ON. STILL WATCHING THE TUTORIAL TO UNDERSTAND HOW THE CODE REALLY WORKS.

    void Awake()
    {
        objPoolManager = this;

        //I Object pooling for the love bullets

        loveBullets = new List<GameObject>();
        for (int i = 0; i < maxPooledLoveBullets; i++)
        {
            GameObject obj = (GameObject)Instantiate(loveBullet);
            obj.SetActive(false);
            loveBullets.Add(obj);
        }


        //I Object pooling for the hate bullets

        hateBullets = new List<GameObject>();
        for (int i = 0; i < maxPooledHateBullets; i++)
        {
            GameObject obj = (GameObject)Instantiate(hateBullet);
            obj.SetActive(false);
            hateBullets.Add(obj);
        }
    }


    //I This is for the player to get a love bullet pooled object
    public GameObject GetLoveBulletsPooledObject()
    {
        for (int i = 0; i < loveBullets.Count; i++)
        {
            if (!loveBullets[i].activeInHierarchy)
            {
                return loveBullets[i];
            }
        }

        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(loveBullet);
            loveBullets.Add(obj);
            return obj;
        }

        return null;
    }

    //I This is for the player to get a hate bullet pooled object
    public GameObject GetHateBulletsPooledObject()
    {
        for (int i = 0; i < hateBullets.Count; i++)
        {
            if (!hateBullets[i].activeInHierarchy)
            {
                return hateBullets[i];
            }
        }

        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(hateBullet);
            hateBullets.Add(obj);
            return obj;
        }

        return null;
    }

}
