using UnityEngine;
using System.Collections;

public class ShootHateScript : MonoBehaviour {

    public bool isFiring;
    public bool fired;

    //I This code is to control what script this object was attached
    public BulletScript bullet;
    public float bulletSpeed;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;

    // Use this for initialization
    void Start () 
    {

    }

    void FixedUpdate()
    {

    }

    public void Shoot()
    {


    }
}
