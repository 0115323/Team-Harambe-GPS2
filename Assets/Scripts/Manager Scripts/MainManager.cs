using UnityEngine;
using System.Collections;


//I This is to avoid clashing between scripts between Managers
namespace Manager
{
    public class MainManager : MonoBehaviour {

        public static MainManager instance;

        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }


    }

}

