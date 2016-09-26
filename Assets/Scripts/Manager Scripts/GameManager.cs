using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour {

public static GameManager instance;

public GameObject loader;

void Awake()
{
        if (instance == null)
        {
        instance = this;
        Instantiate(loader);
        }
        else if (instance != this)
        {
        Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        }
}


}

