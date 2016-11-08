using UnityEngine;
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
    public List<GameObject>[] femaleNPCList;
    public List<GameObject>[] maleNPCList;

    public GameObject[] femaleNPCType;
    public GameObject[] maleNPCType;

    //I ============== END OF THE NPC POOL OBJECT =================

    private int FemaleNPCPooling = 0;
    private int MaleNPCPooling = 0;

    [SerializeField]
    private int maxFemaleNPCPooling = 0;
    [SerializeField]
    private int maxMaleNPCPooling = 0;


    //I All THIS SCRIPT WILL BE COMMENTED LATER ON. STILL WATCHING THE TUTORIAL TO UNDERSTAND HOW THE CODE REALLY WORKS.
    public int randomGenerate;

    void Start()
    {
        if (objPoolManager == null)
        {
            objPoolManager = this;
        }
        else if (objPoolManager != null)
        {
            Destroy(this.gameObject);
        }
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
        //femalePrefab = femaleNPCList[Random.Range(0, femaleNPCList.Length)];

        femaleNPCList = new List<GameObject>[femaleNPCType.Length];
        for (int i = 0; i <femaleNPCType.Length; i++)
        {
            randomGenerate = Random.Range(0, femaleNPCList.Length);
            femaleNPCList[i] = new List<GameObject>();
            GameObject obj = (GameObject)Instantiate(femaleNPCType[randomGenerate]);
            obj.transform.parent = transform;
            obj.SetActive(false);
        }


        //I Object pooling for the hate bullets

        maleNPCList = new List<GameObject>[maleNPCType.Length];
        for (int i = 0; i < maleNPCType.Length; i++)
        {
            randomGenerate = Random.Range(0, maleNPCList.Length);
            maleNPCList[i] = new List<GameObject>();
            GameObject obj = (GameObject)Instantiate(maleNPCType[randomGenerate]);
            obj.transform.parent = transform;
            obj.SetActive(false);
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
    public GameObject GetFemaleNPCType()
    {

        int randomizedIndex = Random.Range(0, femaleNPCList.Length);

        for (int i = 0; i < femaleNPCList[randomizedIndex].Count; i++)
        {
            GameObject go = femaleNPCList[randomizedIndex][i];
            if (go == null)
            {
                go = (GameObject)Instantiate(femaleNPCType[randomizedIndex]);
                go.transform.parent = transform;
                go.SetActive(false);
                femaleNPCList[randomizedIndex][i] = go;
                return go;
            }
            if (!go.activeInHierarchy)
            {
                return go;
            }
        }
        if (FemaleNPCPooling<=maxFemaleNPCPooling)
        {
            FemaleNPCPooling++;
            GameObject obj = (GameObject)Instantiate(femaleNPCType[randomizedIndex]);
            obj.transform.parent = transform;
            femaleNPCList[randomizedIndex].Add(obj);
            return obj;

        }
        return null;
    }

    public GameObject GetMaleNPCType()
    {
        int randomizedIndex = Random.Range(0, maleNPCList.Length);

        for (int i = 0; i < maleNPCList[randomizedIndex].Count; i++)
        {
            GameObject mo = maleNPCList[randomizedIndex][i];

            if (mo == null)
            {
                mo = (GameObject)Instantiate(maleNPCType[randomizedIndex]);
                mo.transform.parent = transform;
                mo.SetActive(false);
                maleNPCList[randomizedIndex][i] = mo;
                return mo;
            }

            if (!mo.activeInHierarchy)
            {
                return mo;
            }
        }
        if (MaleNPCPooling <= maxMaleNPCPooling)
        {
            MaleNPCPooling++;
            GameObject obj = (GameObject)Instantiate(maleNPCType[randomizedIndex]);
            obj.transform.parent = transform;
            maleNPCList[randomizedIndex].Add(obj);
            return obj;
        }
        return null;
    }
}
