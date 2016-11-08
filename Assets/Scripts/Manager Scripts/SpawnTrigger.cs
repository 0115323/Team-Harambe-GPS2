using UnityEngine;
using System.Collections;


public class SpawnTrigger:MonoBehaviour {


    public SpawnManager spawnManager;


    public Transform[] spawnPoints;

    public float checkRadius;
    public float spawnTimer;

    Transform player;


    float rangeToSpawn;


    void Start()
    {
        player = GameObject.Find("Player").transform;
        StartCoroutine("checkPlayerInDistance");
    }



    IEnumerator checkPlayerInDistance()
    {
        while (true)
        {
            rangeToSpawn = Vector3.Distance(player.position, transform.position);
            if (rangeToSpawn <= checkRadius)
            {
                spawnFemales();
            }
            //Debug.Log(rangeToSpawn);

            yield return new WaitForSeconds(spawnTimer);
        }
    }



    void spawnMales()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        GameObject maleNpcOBJ = ObjectPoolingManager.objPoolManager.GetMaleNPCType();

        if (maleNpcOBJ == null)return;
        maleNpcOBJ.transform.position = spawnPoints[spawnPointIndex].position;
        maleNpcOBJ.transform.rotation = spawnPoints[spawnPointIndex].rotation;
        maleNpcOBJ.SetActive(true);
    }



    void spawnFemales()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        GameObject femaleNpcOBJ = ObjectPoolingManager.objPoolManager.GetFemaleNPCType();

        if (femaleNpcOBJ == null)return;
        femaleNpcOBJ.transform.position = spawnPoints[spawnPointIndex].transform.position;
        femaleNpcOBJ.transform.rotation = spawnPoints[spawnPointIndex].transform.rotation;
        femaleNpcOBJ.SetActive(true);
    }
}
