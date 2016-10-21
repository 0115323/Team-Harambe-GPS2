using UnityEngine;
using System.Collections;




public class BulletScript : MonoBehaviour {

    public float speed;
    protected int damage = 1;
    public int totalDamage = 1;

    public PlayerMovement player;

    public BulletType bulletType = BulletType.LoveBullet;

    public TrailRenderer trailrender;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


    void OnEnable()
    {
        Invoke("Destroy", player.GetComponent<PlayerMovement>().bulletRange);
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        //I trailrender.clear is to clear all the trail that this object have. So no buggy line render when using object pooling style.
        trailrender.Clear();
        CancelInvoke();
    }

    public void OnCollisionEnter(Collision col)
    {
        IDamageable damageableObject = col.collider.GetComponent<IDamageable>();

        if (bulletType == BulletType.LoveBullet)
        {
            //I To get if the object can be damaged, it will get from a component called IDamageable
            if (damageableObject != null)
            {
                this.gameObject.SetActive(false);
                //I Apply the damage from this bullet would cause toward the object it collided with
                damageableObject.loveTakeHit(damage, col);
            }
            //I If the damageableobject is null, for example, walls or other type of non damageobject, it is time to disable the bullet and put it back into the object pool manager
            //I to avoid of creating or requesting lots of bullet to shoot
            else
            {
                this.gameObject.SetActive(false);
            }
        }

        if (bulletType == BulletType.HateBullet)
        {
            if (damageableObject != null)
            {
                this.gameObject.SetActive(false);
                damageableObject.hateTakeHit(damage, col);
            }
            //I If the damageableobject is null, for example, walls or other type of non damageobject, it is time to disable the bullet and put it back into the object pool manager
            //I to avoid of creating or requesting lots of bullet to shoot
            else
            {
                this.gameObject.SetActive(false);
            }
        }
        if(damageableObject == null)
        {
            this.gameObject.SetActive(false);
        }
    }
}
