using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConeOfVision : MonoBehaviour 
{
    public StalkerBehaviour stalkerState = StalkerBehaviour.Normal;


	//D to declare variable for radius and angle
	public float viewRadius;
	[Range(0,360)]
	public float viewAngle;

	public LayerMask targetMask;
	public LayerMask wallMask;

	//D this line of code makes a list for the stalker to chase once it enters the conne of vision
	public List<Transform> visibleTargets = new List <Transform> ();

    NavMeshAgent agent;
    public int num = 0;

    public float minDist;
    public float speed;
    //D to set AI to walk to random waypoints
    public bool rand = false;

    public Transform[] way;
    private int wayPointIndex;

    public Transform player;

    //public GameObject[] way;

    public bool see;

    void Start()
    {

        agent = GetComponent<NavMeshAgent>();

        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Waypoints");

        way = new Transform[waypoints.Length];

        for (int i = 0; i < waypoints.Length; i++)
        {
            way[i] = waypoints[i].transform;
        }

        wayPointIndex = Random.Range(0, way.Length);

    }

    void LateUpdate()
    {
        agent.speed = speed;

        FindVisibleTargets();

        float dist = Vector3.Distance(
                         gameObject.transform.position, way[wayPointIndex].transform.position);
        
        if (stalkerState == StalkerBehaviour.Normal)
        {
                agent.SetDestination(way[wayPointIndex].transform.position);

                gameObject.transform.LookAt(way[wayPointIndex].transform.position);
                if (!rand)
                {
                    if (Vector3.Distance(this.transform.position, way[wayPointIndex].transform.position) >= 2)
                    {
                    agent.SetDestination(way[wayPointIndex].transform.position);

                    }
                    else if (Vector3.Distance(this.transform.position, way[wayPointIndex].transform.position) <= 2)
                    {
                        wayPointIndex = Random.Range(0, wayPointIndex);                    
                         
                    }
                }
        }
            Debug.Log(dist);
            Debug.Log(way[wayPointIndex]);

    }
    
    


	//D to detect targets within range(creates a triangle to the stalker and the object)
	void FindVisibleTargets()
	{
		visibleTargets.Clear ();
		Collider[] targetInViewRadius = Physics.OverlapSphere (transform.position, viewRadius, targetMask);


        for(int i=0;i< targetInViewRadius.Length; i++)
		{
            Transform target = targetInViewRadius[i] .transform;
			Vector3 dirToTarget = (target.position - transform.position).normalized;
			if (Vector3.Angle (transform.forward, dirToTarget) < viewAngle / 2) 
			{
				//D declaring variable for distance
				float distToTarget = Vector3.Distance (transform.position, target.position);


				if (!Physics.Raycast (transform.position, dirToTarget, distToTarget, wallMask)) 
				{
                    stalkerState = StalkerBehaviour.InSight;
                        
                    if(stalkerState == StalkerBehaviour.InSight)
                    {
                        if (Vector3.Distance(transform.position, player.position) >= minDist)
                        {
                            transform.LookAt(player);
                            transform.position += transform.forward * speed * Time.deltaTime;

                        }
                    }

				}

			}
		}
	}

	//D to change angle to direction
	public Vector3 DirecFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
		if (!angleIsGlobal) 
		{
			angleInDegrees += transform.eulerAngles.y;
		}
		return new Vector3 (Mathf.Sin (angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos (angleInDegrees * Mathf.Deg2Rad));

	}

}


