﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed;
    private Rigidbody myRigidBody;

    public Vector3 moveInput;
    public Vector3 moveVelocity;

    private Camera mainCamera;

    public VirtualJoystick moveControl;
    public VirtualShootButton shootControl;

    public ShootScript shooting;

    public bool fired;

    public float timeBetweenShots;
    private float shotTimer = 0f;

    public GunType currentGun = GunType.Pistol;


	// Use this for initialization
	void Start () 
    {
        //I Register the move control on start on the player
        moveControl = GameObject.Find("UI").GetComponentInChildren<VirtualJoystick>();

        //I Register the shoot control on start on the player
        shootControl = GameObject.Find("UI").GetComponentInChildren<VirtualShootButton>();


        myRigidBody = GetComponent<Rigidbody>();
        //I To find the reference to the camera
        mainCamera = FindObjectOfType<Camera>();

    }
	

	void FixedUpdate () 
    {
        myRigidBody.velocity = moveVelocity;

        fired = false;

        //I We want to get a specific control and using a z value to move the player. If using a y value, it will move the player up to the sky.
        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        moveVelocity = moveInput*movementSpeed;

        Vector3 targetDirection = new Vector3(moveControl.InputDirection.x, moveControl.InputDirection.y);

        //float rayLength;
        //I This code is for the overwrite the above code from using W,A,S,D key instead using the virtual joystick.

        //I This code is for the movement part of the player
        if (moveControl.InputDirection != Vector3.zero)
        {
            moveVelocity = moveControl.InputDirection*movementSpeed;

            //I This code is to rotate the player dependant on the joystick
            /*Quaternion targetRotation = Quaternion.LookRotation(moveControl.InputDirection, Vector3.up);
            this.transform.rotation = targetRotation;*/
        }
        //I This code is to rotate the player and shooting
        if (shootControl.ShootInputDirection != Vector3.zero)
        {
            //I This code is to rotate the player dependant on the joystick
            Quaternion targetRotation = Quaternion.LookRotation(shootControl.ShootInputDirection, Vector3.up);
            this.transform.rotation = targetRotation;



            //I To detect the player how far the middle circle for the player have dragged and then the player shoot
            if (shootControl.ShootInputDirection.magnitude >= 0.99f)
            {
                fired = true;
                if (currentGun == GunType.Pistol)
                {
                    if (fired == true)
                    {
                        shotTimer -= Time.deltaTime;
                        if (shotTimer <= 0)
                        {
                            if (shooting.GetComponent<ShootScript>().shootType == ShootingType.LoveType)
                            {
                                //I This will reset the shot counter back to the full value of time between shots
                                //I To instantiate at where the gun was point to.
                                //I This is part for the pooled object
                                Invoke("FireLoveBullets",shotTimer);
                                shotTimer = timeBetweenShots;

                                //I TESTING BAR SCRIPT
                                //I haremMeter.CurrentVal += 1;

                            }
                            if (shooting.GetComponent<ShootScript>().shootType == ShootingType.HateType)
                            {
                                //I This will reset the shot counter back to the full value of time between shots
                                //I To instantiate at where the gun was point to.
                                //I BulletScript newBullet = Instantiate(hateBullet, shooting.firePoint.position, shooting.firePoint.rotation) as BulletScript;
                                Invoke("FireHateBullets",shotTimer);
                                shotTimer = timeBetweenShots;

                                //I TESTING BAR SCRIPT
                                //I yaoiMeter.CurrentVal += 1;
                            }                 
                        }
                    }
                }

            }
        }

    }

    //I To fire the love bullets
    void FireLoveBullets()
    {
        //I Getting a script from the object pool manager and getting the pooled objects
    GameObject obj = ObjectPoolingManager.objPoolManager.GetLoveBulletsPooledObject();


    if (obj == null) return;
    obj.transform.position = shooting.firePoint.position;
    obj.transform.rotation = shooting.firePoint.rotation;
    obj.SetActive(true);
    }

    //I To fire the hate bullets
    void FireHateBullets()
    {
    GameObject obj = ObjectPoolingManager.objPoolManager.GetHateBulletsPooledObject();

    if (obj == null) return;
    obj.transform.position = shooting.firePoint.position;
    obj.transform.rotation = shooting.firePoint.rotation;
    obj.SetActive(true);
    }

    void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.CompareTag("Building"))
            {
               // Debug.Log("Collided");
            }

    }

}




//float rayLength;

//I============================================== FOR PC TEST ===========================================================
//I This is for the player point to look at using mouse, need to figure out how to do from the joystick part.

//I where the camera ray intercepts anywhere else, the float raylength will be set to the value to this whatever camera hits.


/*if(groundPlane.Raycast(cameraRay, out rayLength))
            {
                //I We set a point a space to actually to set the camera to look at
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);

                Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            //I the code above to understand, try run the game, you will notice a blue line, the player will look at where the mouse was pointed.

            //I This code will tilted the player to look where the mouse was pointing and it will tilted
            //Itransform.LookAt(pointToLook);

            //I This code will stop the player from tilted to look at, which is making it look really weird
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }*/

/*if (Input.GetMouseButtonDown(0))
{
    theGun.isFiring = true;
}
if (Input.GetMouseButtonUp(0))
{
    theGun.isFiring = false;
}



if (Input.GetKey("escape"))
{
    Application.Quit();
}*/
//I ========================================== END OF THE PC CODE TEST ==========================================================
