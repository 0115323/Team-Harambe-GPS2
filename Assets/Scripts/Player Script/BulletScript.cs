using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    public float speed;
    public float distanceTraveled;
    public float range;


   // private float Timer = 4f;
   // private float maxTimer = 4f;
    Vector3 lastPosition;


    public ShootScript firepoint;

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
	
    void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.CompareTag("FemaleNPC"))
        {
            Debug.Log("Collided");
            gameObject.SetActive(false);
            col.gameObject.SetActive(false);
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
