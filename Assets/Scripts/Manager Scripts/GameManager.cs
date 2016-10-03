using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

public static GameManager instance;

public GameObject loader;

    public bool testingMode;

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
        if (testingMode)
        {
            int fingerCount = 0;
            Scene sceneName = SceneManager.GetActiveScene();

            foreach (Touch touch in Input.touches)
            {
                if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
                {
                    fingerCount++;
                }

            }
            if (fingerCount >= 5)
            {
                Debug.Log("Reloading");
                SceneManager.LoadScene(sceneName.name);
            }
        }
    }


}

