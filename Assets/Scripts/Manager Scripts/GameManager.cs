using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

public static GameManager instance;

public GameObject loader;

    public bool TestingMode;


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

    void Update()
    {
        if (TestingMode)
        {
            int fingerCount = 0;

            string sceneName = SceneManager.GetActiveScene().name;

            foreach (Touch touch in Input.touches)
            {
                if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
                    fingerCount++;
            }
            if (fingerCount >= 5)
            {
                Debug.Log("Finger count : " + fingerCount);
                SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            }
        }

    }


}

