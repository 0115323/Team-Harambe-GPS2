using UnityEngine;
using System.Collections;

public class FemaleNPCScript : NPC
{
    public ParticleSystem loveParticle;
    public ParticleSystem hateParticle;


    //I Everytime the object is enabled, this function will be overridden by the NPC Entity script
    public override void OnEnable () 
    {
        //I Get called onenable function and everytime the object is enabled, reset the health to full
        base.OnEnable();
    }


    public override void loveTakeHit(int damage, Collision col)
    {
        base.loveTakeHit(damage, col);
        if (totalAffectionPoint <= damage)
        {
            if (!loveCallOnce)
            {
                Destroy(Instantiate(loveParticle.gameObject, gameObject.transform.position, Quaternion.FromToRotation(Vector3.forward,Vector3.up)) as GameObject, loveParticle.startLifetime);
                loveCallOnce = true;
                hateCallOnce = false;
            }
        }
    }

    public override void hateTakeHit(int damage, Collision col)
    {
        if (totalAffectionPoint>=damage)
        {
            if (!hateCallOnce)
            {
                Destroy(Instantiate(hateParticle.gameObject, gameObject.transform.position, Quaternion.FromToRotation(Vector3.forward,Vector3.up)) as GameObject, hateParticle.startLifetime);
                hateCallOnce = true;
                loveCallOnce = false;
            }
        }
        base.hateTakeHit(damage, col);
    }

    public override void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" && behaviour==NPCBehaviour.Love)
        {
            Destroy(Instantiate(loveParticle.gameObject, gameObject.transform.position, Quaternion.FromToRotation(Vector3.forward,Vector3.up)) as GameObject, loveParticle.startLifetime);

            score.haremMeter.CurrentVal += 5;
        }
        base.OnCollisionEnter(col);
    }

}
