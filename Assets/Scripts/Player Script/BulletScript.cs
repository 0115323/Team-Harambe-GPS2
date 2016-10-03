using UnityEngine;
using System.Collections;




public class BulletScript : MonoBehaviour {

    public float speed;
    public float distanceTraveled;
    public float range;

    public ScoreManagerScript scoreManager;

    public float meterIncreaseValue;

   // private float Timer = 4f;
   // private float maxTimer = 4f;
    Vector3 lastPosition;

    public BulletType bulletType = BulletType.LoveBullet;


    void Start()
    {
        //I Adding a Game Manager function to this bullet
        scoreManager = GameObject.Find("UI").GetComponent<ScoreManagerScript>();
    }


    void Update()
    {
        this.distanceTraveled += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;
        //Debug.Log("DISTANCE TRAVELLED " + distanceTraveled);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }


    void OnEnable()
    {

        Invoke("Destroy", 2f);

        /*if (this.distanceTraveled >= 80f)
        {
            //Debug.Log("Bullet destroyed");
            distanceTraveled = 0;

            Invoke("Destroy", 0);
        }*/
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    public void OnCollisionEnter(Collision col)
    {
        if (bulletType == BulletType.LoveBullet)
        {
            if (col.gameObject.CompareTag("FemaleNPC"))
            {
                //Debug.Log("COLLIDED");
                gameObject.SetActive(false);
                col.gameObject.SetActive(false);
                scoreManager.GetComponent<ScoreManagerScript>().haremMeter.CurrentVal += meterIncreaseValue;
            }
            if (col.gameObject.CompareTag("MaleNPC"))
            {
                //Debug.Log("GAY METER INCREASED");
                gameObject.SetActive(false);
                col.gameObject.SetActive(false);
                scoreManager.GetComponent<ScoreManagerScript>().yaoiMeter.CurrentVal += meterIncreaseValue;
            }
        }
        if (bulletType == BulletType.HateBullet)
        {
            if (col.gameObject.CompareTag("FemaleNPC"))
            {
                //Debug.Log("COLLIDED");
                gameObject.SetActive(false);
                col.gameObject.SetActive(false);
                scoreManager.GetComponent<ScoreManagerScript>().haremMeter.CurrentVal -= meterIncreaseValue;
            }
            if (col.gameObject.CompareTag("MaleNPC"))
            {
                gameObject.SetActive(false);
                col.gameObject.SetActive(false);
                scoreManager.GetComponent<ScoreManagerScript>().yaoiMeter.CurrentVal -= meterIncreaseValue;
            }
        }
    }
	
    /*void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.CompareTag("FemaleNPC"))
        {
            Debug.Log("Collided");
            gameObject.SetActive(false);
            col.gameObject.SetActive(false);
            this.GetComponent<GameManagerScript>().haremMeter.CurrentVal += 1;
        }

    }



	// Update is called once per frame
	/*void Update () 
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Timer -= Time.deltaTime;

        //I Destroy the object when the timer reached 0
        if (Timer <= 0)
        {
            Destroy(this.gameObject);
            Timer = maxTimer;
        }

	}*/
}
