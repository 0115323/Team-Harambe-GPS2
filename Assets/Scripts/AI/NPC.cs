using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPC: MonoBehaviour, IDamageable
{
    public enum NPCBehaviour
    {
        Normal,
        Love,
        Hate,
        Running
    }

    public int startingAffectionPoint;
    public int maxAffectionPoint;

    protected float totalpercentage = 50f;
    private float chance;

    public int totalAffectionPoint;
    protected int affectionPoint;

    protected ScoreManagerScript score;

    public NPCGender gender = NPCGender.Female;
    public NPCBehaviour behaviour = NPCBehaviour.Normal;


    public Transform player;
    public GameObject[] runPoint;

    public bool loveCallOnce;
    public bool hateCallOnce;

    NavMeshAgent agent;

    public float updatePathTime;

    int randomizedIndex;

    Vector3 runPosition;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        score = GameObject.FindObjectOfType<ScoreManagerScript>();
        player = GameObject.Find("Player").transform;
        runPoint = GameObject.FindGameObjectsWithTag("RunPoint");
    }


    //I To override the child of this script for the lovetakehit at the male or female npc script
    public virtual void loveTakeHit(int damage, Collision col)
    {
        loveBulletTakeDamage(damage);
    }

    //I To override the child of this script for the hatetakehit at the male or female npc script
    public virtual void hateTakeHit(int damage, Collision col)
    {
        hateBulletTakeDamage(damage);
    }


    public virtual void loveBulletTakeDamage(int damage)
    {
        totalAffectionPoint -= damage;

        if (gender == NPCGender.Female)
        {
            if (totalAffectionPoint <= damage)
            {
                gameObject.layer = LayerMask.NameToLayer("Fall");
                behaviour = NPCBehaviour.Love;
            }
        }

        else if (gender == NPCGender.Male)
        {
            if (totalAffectionPoint <= damage)
            {
                gameObject.layer = LayerMask.NameToLayer("Fall");
                behaviour = NPCBehaviour.Love;
            }
        }

    }


    public virtual void hateBulletTakeDamage(int damage)
    {
        totalAffectionPoint += damage;

        if (gender == NPCGender.Female)
        {
            if (totalAffectionPoint >= damage)
            {
                gameObject.layer = LayerMask.NameToLayer("Hate");
                behaviour = NPCBehaviour.Hate;
            }

        }

        else if (gender == NPCGender.Male)
        {
            if (totalAffectionPoint >= damage)
            {
                gameObject.layer = LayerMask.NameToLayer("Hate");
                behaviour = NPCBehaviour.Hate;
            }
        }
    }

    public void OnDisable()
    {
        behaviour = NPCBehaviour.Normal;
        loveCallOnce = false;
        hateCallOnce = false;
        agent.enabled = false;
        gameObject.layer = LayerMask.NameToLayer("NPC");
        StopCoroutine(UpdatePath());
        this.gameObject.SetActive(false);
    }


    public virtual void OnEnable()
    {
        agent.enabled = true;
        chance = Random.Range(0f, totalpercentage);
        //I To avoid having an immortal love points!
        totalAffectionPoint = Random.Range(startingAffectionPoint,maxAffectionPoint);

        if (chance <= 5f)
        {
            affectionPoint = 1;
        }
        else
        {
            affectionPoint = totalAffectionPoint;
        }
        randomizedIndex = Random.Range(0, runPoint.Length);
        StartCoroutine(UpdatePath());
    }

    public virtual void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" && behaviour==NPCBehaviour.Love)
        {
            OnDisable();
        }
    }

    IEnumerator UpdatePath()
    {
        while (gameObject.activeSelf)
        {
            float runningPoint;
            if (behaviour == NPCBehaviour.Love)
            {
                agent.speed = 14;
                Vector3 playerPosition = new Vector3(player.position.x, 0, player.position.z);
                agent.SetDestination(playerPosition);
            }
            if (behaviour == NPCBehaviour.Hate)
            {
                agent.speed = 50;
                runPosition = new Vector3(runPoint[randomizedIndex].transform.position.x, 0, runPoint[randomizedIndex].transform.position.z);
                runningPoint = runPoint[randomizedIndex].transform.position.magnitude;
                agent.SetDestination(runPoint[randomizedIndex].transform.position);

            }

            yield return new WaitForSeconds(updatePathTime);
        }
    }

}
