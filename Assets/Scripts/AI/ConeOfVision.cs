using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConeOfVision : MonoBehaviour 
{
	//D to declare variable for radius and angle
	public float viewRadius;
	[Range(0,360)]
	public float viewAngle;

	public LayerMask targetMask;
	public LayerMask wallMask;

	//D this line of code makes a list for the stalker to chase once it enters the conne of vision
	public List<Transform> visibleTargets = new List <Transform> ();

    NavMeshAgent agent;

    public Transform player;

    public bool see;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void LateUpdate()
    {
        see = false;
        FindVisibleTargets();
        if(see)
        {
            GetComponent<NavMeshAgent>().destination = player.position;
<<<<<<< HEAD
=======

>>>>>>> 25c1e67c1f1d3153cb85d655aa1219a334dd72fa
        }
    }


	//D to detect targets within range(creates a triangle to the stalker and the object)
	void FindVisibleTargets()
	{
		visibleTargets.Clear ();
<<<<<<< HEAD
		Collider[] targetInViewRadius = Physics.OverlapSphere (transform.position, viewRadius, targetMask);


        for(int i=0;i< targetInViewRadius.Length; i++)
		{
            Transform target = targetInViewRadius[i] .transform;
=======
		Collider[] targetsInViewRadius = Physics.OverlapSphere (transform.position, viewRadius, targetMask);


		for(int i=0;i< targetsInViewRadius.Length; i++)
		{
			Transform target = targetsInViewRadius [i].transform;
>>>>>>> 25c1e67c1f1d3153cb85d655aa1219a334dd72fa
			Vector3 dirToTarget = (target.position - transform.position).normalized;
			if (Vector3.Angle (transform.forward, dirToTarget) < viewAngle / 2) 
			{
				//D declaring variable for distance
				float distToTarget = Vector3.Distance (transform.position, target.position);


				if (!Physics.Raycast (transform.position, dirToTarget, distToTarget, wallMask)) 
				{
<<<<<<< HEAD
=======
					visibleTargets.Add (target);
>>>>>>> 25c1e67c1f1d3153cb85d655aa1219a334dd72fa
                    see = true;
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


