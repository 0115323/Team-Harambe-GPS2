using UnityEngine;
using System.Collections;

public class BulletRangeScript : MonoBehaviour 
{
	public ChangeMode currentGun;
	public float time;
	public PlayerMovement range;
	
	// Use this for initialization
	void Awake () 
	{
		range = GameObject.Find("Player").GetComponent<PlayerMovement>();
	}
		

	void OnEnable()
	{
		Invoke("Destroy", range.GetComponent<PlayerMovement>().bulletRange);
    }

	void Destroy()
	{
		gameObject.SetActive(false);
	}

    void OnDisable()
    {
		CancelInvoke();
    }
		
		
}
