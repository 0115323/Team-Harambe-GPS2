using UnityEngine;
using System.Collections;

public class NPC: MonoBehaviour, IDamageable
{
    public int startingAffectionPoint;
    protected int affectionPoint;

    private ScoreManagerScript score;
    public BulletScript loveBullet;
    public BulletScript hateBullet;

    public NPCGender gender = NPCGender.Female;


    void Awake()
    {
        score = GameObject.Find("UI").GetComponent<ScoreManagerScript>();
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
                Die();
                score.GetComponent<ScoreManagerScript>().haremMeter.CurrentVal += 5;
            }
        }

        if (gender == NPCGender.Male)
        {

            if (affectionPoint <= 0)
            {
                
                Die();

                score.GetComponent<ScoreManagerScript>().yaoiMeter.CurrentVal += 5;
            }
        }
    }


    public virtual void hateBulletTakeDamage(int damage)
    {
        affectionPoint -= damage;

        if (gender == NPCGender.Female)
        {

            if (affectionPoint <= 0)
            {
                Die();
                score.GetComponent<ScoreManagerScript>().haremMeter.CurrentVal -= 5;
            }
        }

        if (gender == NPCGender.Male)
        {

            if (affectionPoint <= 0)
            {
                Die();

                score.GetComponent<ScoreManagerScript>().yaoiMeter.CurrentVal -= 5;
            }
        }
    }

    public void Die()
    {
        this.gameObject.SetActive(false);
    }


    public virtual void OnEnable()
    {
        //I To avoid having an immortal love points!
        affectionPoint = startingAffectionPoint;
    }
}
