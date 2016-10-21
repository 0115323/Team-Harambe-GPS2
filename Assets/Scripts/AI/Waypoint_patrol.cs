using UnityEngine;
using System.Collections;

public class Waypoint_patrol : MonoBehaviour 
{
	//private GetComponent<ConeOfVision>;

	//D waypoint array
	public GameObject[] waypoints;
	public int num = 0;
	//D declaring spped and minimum distance for traveling
	public float minDist;
	public float speed;
	//D to set AI to walk to random waypoints
	public bool rand = false;
	public bool go = true;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	//D to make AI moke to waypoints
	void Update () 
	{
		float dist = Vector3.Distance (
			gameObject.transform.position, waypoints [num].transform.position);

		if (go) 
		{
			if (dist > minDist) 
			{
				Move ();
			} 
			else 
			{
				if (!rand) {
					if (num + 1 == waypoints.Length) {
						num = 0;
					} else {
						num++;
					}

				} 
				else 
				{
					num = Random.Range (0, waypoints.Length);
				}
			}
			//return 0;
		}
	}

	public void Move()
	{
        gameObject.transform.LookAt (waypoints [num].transform.position);
		gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
	}

}
