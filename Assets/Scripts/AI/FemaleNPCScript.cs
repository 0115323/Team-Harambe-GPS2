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
        //I If the bullet damage is equal or more than affection point, the particle is created
        if (damage >= affectionPoint)
        {
            //I Instantiate the particle as a gameobject and destroy after amount of time. The loveparticle.startlifetime can be set on the gameobject called love particle and can be set there for the amount of lifetime.
            //I if 2 seconds is being set, the loveparticle is also being set 2 seconds, after 2 seconds, the object is destroyed
            Destroy(Instantiate(loveParticle.gameObject, gameObject.transform.position, Quaternion.FromToRotation(Vector3.forward,Vector3.up)) as GameObject, loveParticle.startLifetime);
        }
        //I Access the member of the class from within the derived class

        base.loveTakeHit(damage, col);
    }

    public override void hateTakeHit(int damage, Collision col)
    {
        if (damage >= affectionPoint)
        {
            //I Instantiate the particle as a gameobject and destroy after amount of time. The loveparticle.startlifetime can be set on the gameobject called love particle and can be set there for the amount of lifetime.
            //I if 2 seconds is being set, the loveparticle is also being set 2 seconds, after 2 seconds, the object is destroyed
            Destroy(Instantiate(hateParticle.gameObject, gameObject.transform.position, Quaternion.FromToRotation(Vector3.forward,Vector3.up)) as GameObject, hateParticle.startLifetime);
        }

        base.hateTakeHit(damage, col);
    }
}
