using UnityEngine;
using System.Collections;

public class StalkerNavigation : MonoBehaviour {

    NavMeshAgent agent;

    public Transform Player;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void LateUpdate()
    {
        GetComponent<NavMeshAgent>().destination = Player.position;
    }
}
