using UnityEngine;
using System.Collections;

public class NPC: MonoBehaviour, IDamageable
{
    public int startingAffectionPoint;
    public int maxAffectionPoint;

    protected float totalpercentage = 50f;
    private float chance;

    protected int totalAffectionPoint;
    protected int affectionPoint;

    protected ScoreManagerScript score;

    public NPCGender gender = NPCGender.Female;

    NavMeshAgent agent;

    protected Transform player;

    protected bool fall;
    protected bool callOnce;


    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        score = GameObject.Find("UI").GetComponent<ScoreManagerScript>();
        player = GameObject.Find("Player").transform;
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
        affectionPoint -= damage;

        if (gender == NPCGender.Female)
        {
            
            if (affectionPoint <= 0)
            {
                fall = true;
            }
        }

        if (gender == NPCGender.Male)
        {

            if (affectionPoint <= 0)
            {
                fall = true;
            }
        }
    }


    public virtual void hateBulletTakeDamage(int damage)
    {
        affectionPoint += damage;
    }

    public void Die()
    {

        this.gameObject.SetActive(false);
    }


    public virtual void OnEnable()
    {

        fall = false;
        callOnce = false;
        chance = Random.Range(0f, totalpercentage);
        //I To avoid having an immortal love points!
        totalAffectionPoint = Random.Range(startingAffectionPoint,maxAffectionPoint);

        if (chance <= 5f)
        {
            affectionPoint = 1;
            //Debug.Log("health: " + affectionPoint);
        }
        else
        {
            affectionPoint = totalAffectionPoint;
        }
    }

    private void GoToPlayer()
    {
        GetComponent<NavMeshAgent>().destination = player.position;
    }

    void Update()
    {
        if (fall)
        {
            GoToPlayer();
        }


    }

    public virtual void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player" && fall == true)
        {
            Die();
        }
    }

}
