using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

public static GameManager instance;
    public float timer;

    public GameObject loader;

    public bool testingMode;

    public GameObject gunShopInterface;

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

    void Start()
    {
        gunShopInterface = GameObject.Find("GunShop");
        gunShopInterface.gameObject.SetActive(false);
    }

    void Update()
    {
        timer = Time.timeScale;
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
                SceneManager.LoadScene(sceneName.name);
            }
        }
    }


}

