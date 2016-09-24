using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {


    public float spawnTime;
    public Transform[] spawnPoints;


    //I Work in progress. Will be fully implemented

	// Use this for initialization
	void Start () 
    {
        InvokeRepeating("SpawnFemaleNPC", spawnTime, spawnTime);
        InvokeRepeating("SpawnMaleNPC", spawnTime, spawnTime);
	}
	
    void SpawnFemaleNPC()
    {
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
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        GameObject npcOBJ = ObjectPoolingManager.objPoolManager.GetMaleNPCType1();

        if (npcOBJ == null)
            return;
        npcOBJ.transform.position = spawnPoints[spawnPointIndex].position;
        npcOBJ.transform.rotation = spawnPoints[spawnPointIndex].rotation;
        npcOBJ.SetActive(true);
    }
}
