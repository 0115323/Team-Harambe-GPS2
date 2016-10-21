using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnTrigger:SpawnManager {

    Vector3 spawnPosition;


    public float checkRadius;
    float rangeToSpawn;

    void Start()
    {

        StartCoroutine("checkPlayerInDistance");
        //StartCoroutine(checkPlayerInDistance());
    }

    IEnumerator checkPlayerInDistance()
    {
        while (true)
        {
            rangeToSpawn = Vector3.Distance(player.position, transform.position);

            if (rangeToSpawn <= checkRadius)
            {
                Invoke("spawnFemales", 1.0f);
                Invoke("spawnMales", 1.3f);
            }
            yield return new WaitForSeconds(1.0f);
        }
    }


}
