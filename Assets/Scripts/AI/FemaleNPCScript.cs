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
        if (damage >= affectionPoint)
        {
            if (!callOnce)
            {
                Destroy(Instantiate(loveParticle.gameObject, gameObject.transform.position, Quaternion.FromToRotation(Vector3.forward,Vector3.up)) as GameObject, loveParticle.startLifetime);
                callOnce = true;
            }
        }
        base.loveTakeHit(damage, col);
    }

    public override void hateTakeHit(int damage, Collision col)
    {
        Destroy(Instantiate(hateParticle.gameObject, gameObject.transform.position, Quaternion.FromToRotation(Vector3.forward,Vector3.up)) as GameObject, loveParticle.startLifetime);
        base.hateTakeHit(damage, col);
    }

    public override void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player" && fall == true)
        {
            Destroy(Instantiate(loveParticle.gameObject, gameObject.transform.position, Quaternion.FromToRotation(Vector3.forward,Vector3.up)) as GameObject, loveParticle.startLifetime);

            score.haremMeter.CurrentVal += 5;
        }
        base.OnCollisionEnter(col);
    }

}
