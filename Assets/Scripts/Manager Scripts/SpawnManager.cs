﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SpawnManager : MonoBehaviour 
{
    //I Work in progress. Will be fully implemented


    public float spawnTime;

    public Transform[] spawnPoints;

    public GameObject[] maleNPC;
    public GameObject[] femaleNPC;

	void Start () 
    {
        //I This function is to find the gameobject tagged with Spawners
        GameObject[] spawner = GameObject.FindGameObjectsWithTag("Spawners");
        //I To get the total length of spawner array and then add it to spawnpoints array
        spawnPoints = new Transform[spawner.Length];

        //I Convert every array of gameobject to a transform
        for (int i = 0; i < spawnPoints.Length; i++)
            spawnPoints[i] = spawner[i].transform;

        //IDebug.Log(spawnPoints.Length);


        InvokeRepeating("SpawnFemaleNPC", 0, 3);
        InvokeRepeating("SpawnMaleNPC", 0, 4);
	}
	
    void SpawnFemaleNPC()
    {
        femaleNPC = GameObject.FindGameObjectsWithTag("FemaleNPC");


        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        GameObject npcOBJ = ObjectPoolingManager.objPoolManager.GetFemaleNPCType1();

        if (npcOBJ == null)
            return;
        npcOBJ.transform.position = spawnPoints[spawnPointIndex].position;
        npcOBJ.transform.rotation = spawnPoints[spawnPointIndex].rotation;
        npcOBJ.SetActive(true);
    }



    void SpawnMaleNPC()
    {
        maleNPC = GameObject.FindGameObjectsWithTag("MaleNPC");

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        GameObject npcOBJ = ObjectPoolingManager.objPoolManager.GetMaleNPCType1();

        if (npcOBJ == null)
            return;
        npcOBJ.transform.position = spawnPoints[spawnPointIndex].position;
        npcOBJ.transform.rotation = spawnPoints[spawnPointIndex].rotation;
        npcOBJ.SetActive(true);
    }



}
