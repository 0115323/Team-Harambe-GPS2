using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {


    public GameObject femaleNPC1;
    public float spawnTime;
    public Transform[] spawnPoints;


    //I Work in progress. Will be fully implemented

	// Use this for initialization
	void Start () 
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        GameObject npcOBJ = ObjectPoolingManager.objPoolManager.GetFemaleNPCType1();

        if (npcOBJ == null)
            return;
        npcOBJ.transform.position = spawnPoints[spawnPointIndex].position;
        npcOBJ.transform.rotation = spawnPoints[spawnPointIndex].rotation;
        npcOBJ.SetActive(true);

    }
}
