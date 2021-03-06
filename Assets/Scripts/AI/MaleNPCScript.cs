﻿using UnityEngine;
using System.Collections;

public class MaleNPCScript :NPC
{
    public ParticleSystem loveParticle;
    public ParticleSystem hateParticle;



    //I Override by NPC Entity script on OnEnable to reset the health on the NPC
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
                //I Instantiate the particle as a gameobject and destroy after amount of time. The loveparticle.startlifetime can be set on the gameobject called love particle and can be set there for the amount of lifetime.
                //I if 2 seconds is being set, the loveparticle is also being set 2 seconds, after 2 seconds, the object is destroyed
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

            score.yaoiMeter.CurrentVal += 5;
        }
        base.OnCollisionEnter(col);
    }
}
