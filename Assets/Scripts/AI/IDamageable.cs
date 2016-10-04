using UnityEngine;


public interface IDamageable
{

    void loveTakeHit(int damage, Collision col);

    void hateTakeHit(int damage, Collision col);


    void loveBulletTakeDamage(int damage);

    void hateBulletTakeDamage(int damage);


}