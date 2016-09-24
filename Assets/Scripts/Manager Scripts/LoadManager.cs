using UnityEngine;
using System.Collections;
using System.Collections.Generic;



namespace Manager
{
    public class LoadManager : MonoBehaviour {

        public GameObject Managers;
        public GameObject objPoolingManager;
        public GameObject soundManager;

        void Awake()
        {
            //I To create the object pooling manager
           if (MainManager.instance == null)
            {
               Instantiate(objPoolingManager);
            }

            //I To create the sound Manager
            if (MainManager.instance == null)
            {
                Instantiate(soundManager);
            }
        }
    }
}


