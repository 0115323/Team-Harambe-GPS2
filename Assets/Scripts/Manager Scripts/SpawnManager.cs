using UnityEngine;
using System.Collections;


public class SpawnManager : MonoBehaviour 
{
    protected Transform player;

    public Transform[] spawnPoints;

    public float spawnTime = 3f;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void spawnMales()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        
        GameObject maleNpcOBJ = ObjectPoolingManager.objPoolManager.GetMaleNPCType();

        if (maleNpcOBJ == null)return;
        maleNpcOBJ.transform.position = spawnPoints[spawnPointIndex].position;
        maleNpcOBJ.transform.rotation = spawnPoints[spawnPointIndex].rotation;
        maleNpcOBJ.SetActive(true);
    }

    public void spawnFemales()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        GameObject npcOBJ = ObjectPoolingManager.objPoolManager.GetFemaleNPCType();

        if (npcOBJ == null)return;
        npcOBJ.transform.position = spawnPoints[spawnPointIndex].position;
        npcOBJ.transform.rotation = spawnPoints[spawnPointIndex].rotation;
        npcOBJ.SetActive(true);

    }



}
