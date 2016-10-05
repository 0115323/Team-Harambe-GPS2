﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class ObjectPoolingManager : MonoBehaviour 
{

    public static ObjectPoolingManager objPoolManager;


    List<GameObject> loveBulletsList;
    List<GameObject> hateBulletsList;


    private int maxPooledLoveBullets = 3;
    private int maxPooledHateBullets = 3;


    public GameObject loveBullet;
    public GameObject hateBullet;

    public bool willGrow = true;

    //I ============== FOR THE NPC POOL OBJECT ====================
    List<GameObject> femaleNPCList;
    List<GameObject> maleNPCList;

    public GameObject femaleNPCType1;
    public GameObject maleNPCType1;
    //I ============== END OF THE NPC POOL OBJECT =================

    private int FemaleNPCPooling = 0;
    private int MaleNPCPooling = 0;

    [SerializeField]
    private int maxFemaleNPCPooling = 0;
    [SerializeField]
    private int maxMaleNPCPooling = 0;


    //I All THIS SCRIPT WILL BE COMMENTED LATER ON. STILL WATCHING THE TUTORIAL TO UNDERSTAND HOW THE CODE REALLY WORKS.

    void Start()
    {
        
        objPoolManager = this;

        //I Object pooling for the love bullets

        loveBulletsList = new List<GameObject>();
        for (int i = 0; i < maxPooledLoveBullets; i++)
        {
            GameObject obj = (GameObject)Instantiate(loveBullet);
            obj.transform.parent = transform;
            obj.SetActive(false);
            loveBulletsList.Add(obj);
        }


        //I Object pooling for the hate bullets

        hateBulletsList = new List<GameObject>();
        for (int i = 0; i < maxPooledHateBullets; i++)
        {
            GameObject obj = (GameObject)Instantiate(hateBullet);
            obj.transform.parent = transform;
            obj.SetActive(false);
            hateBulletsList.Add(obj);
        }

        femaleNPCList = new List<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            GameObject obj = (GameObject)Instantiate(femaleNPCType1);
            obj.transform.parent = transform;
            obj.SetActive(false);
            femaleNPCList.Add(obj);
        }


        //I Object pooling for the hate bullets

        maleNPCList = new List<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            GameObject obj = (GameObject)Instantiate(maleNPCType1);
            obj.transform.parent = transform;
            obj.SetActive(false);
            maleNPCList.Add(obj);
        }

    }


    //I This is for the player to get a love bullet pooled object
    public GameObject GetLoveBulletsPooledObject()
    {
        for (int i = 0; i < loveBulletsList.Count; i++)
        {
            if (!loveBulletsList[i].activeInHierarchy)
            {
                return loveBulletsList[i];
            }
        }

        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(loveBullet);
            obj.transform.parent = transform;
            loveBulletsList.Add(obj);
            return obj;
        }

        return null;
    }

    //I This is for the player to get a hate bullet pooled object
    public GameObject GetHateBulletsPooledObject()
    {
        for (int i = 0; i < hateBulletsList.Count; i++)
        {
            if (!hateBulletsList[i].activeInHierarchy)
            {
                return hateBulletsList[i];
            }
        }

        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(hateBullet);
            obj.transform.parent = transform;
            hateBulletsList.Add(obj);
            return obj;
        }

        return null;
    }



    //I ============== FOR THE SPAWN MANAGER ======================

    //I This is for the player to get a hate bullet pooled object
    public GameObject GetFemaleNPCType1()
    {
        for (int i = 0; i < femaleNPCList.Count; i++)
        {
            if (!femaleNPCList[i].activeInHierarchy)
            {
                return femaleNPCList[i];
            }
        }
        if (FemaleNPCPooling < maxFemaleNPCPooling)
        {
            FemaleNPCPooling++;
            GameObject femaleobj = (GameObject)Instantiate(femaleNPCType1);
            femaleobj.transform.parent = transform;
            femaleNPCList.Add(femaleobj);
            femaleobj.SetActive(false);
            //Debug.Log(maxFemaleNPCPooling);
            if (FemaleNPCPooling > maxFemaleNPCPooling)
            {
                return null;
            }
        }
        return null;
    }

    public GameObject GetMaleNPCType1()
    {
        for (int i = 0; i < maleNPCList.Count; i++)
        {
            if (!maleNPCList[i].activeInHierarchy)
            {
                return maleNPCList[i];
            }
        }
        if (MaleNPCPooling < maxMaleNPCPooling)
        {
            MaleNPCPooling++;
            GameObject maleobj = (GameObject)Instantiate(maleNPCType1);
            maleobj.transform.parent = transform;
            maleNPCList.Add(maleobj);
            maleobj.SetActive(false);
            if (MaleNPCPooling > maxMaleNPCPooling)
            {
                return null;
            }
        }
        return null;
    }
}
