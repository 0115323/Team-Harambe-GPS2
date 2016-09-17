using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    public float speed;
    public float distanceTraveled;
    public float range;

   // private float Timer = 4f;
   // private float maxTimer = 4f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnEnable()
    {
        Invoke("Destroy", 2f);
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
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
