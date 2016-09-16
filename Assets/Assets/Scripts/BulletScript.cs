using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    public float speed;

    private float Timer = 4f;
    private float maxTimer = 4f;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Timer -= Time.deltaTime;

        //I Destroy the object when the timer reached 0
        if (Timer <= 0)
        {
            Destroy(this.gameObject);
            Timer = maxTimer;
        }

	}
}
