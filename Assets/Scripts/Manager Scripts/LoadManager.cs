using UnityEngine;
using System.Collections;
using System.Collections.Generic;



namespace Manager
{
    public class LoadManager : MonoBehaviour {

        public GameObject objPoolingManager;

        public GameObject spawnManager;

        void Awake()
        {
            //I To create the object pooling manager
            if (GameManager.instance != null)
            {
               Instantiate(objPoolingManager);
            }

            if (GameManager.instance != null)
            {
                Instantiate(spawnManager);
            }
        }
    }
}


