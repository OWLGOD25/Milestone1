using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float moveSpeed;
    public bool FIRE;
    public float Delay = 0;
    public float Firerate = -1;

    public ShootMode FireMode = ShootMode.BasicShooting;

    public enum ShootMode
    { 
    BasicShooting = 0,
    MoreShot,
    FireBigSlowShot,
    Count
    }

   
    // Start is called before the first frame update
    public int maxHealth = 5; // Player's maximum health
    public int currentHealth; // Player's current health

    // Start is called before the first frame update
    void Start()
    {
        nextFireTime = Time.time + Firerate; // Initialize the timer
    }



    // Update is called once per frame
    void Update()
    {
        // Individual key input.
        //if (Input.GetKey("up") || Input.GetKey(KeyCode.W)) // holding down key.
        //{
        //    transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
        //{
        //    transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        //}
        // Axis input. An axis goes from -1 to 0 to 1
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(x, y, 0f) * (moveSpeed * Time.deltaTime));


        //Press J to shoot
        FIRE = Input.GetButtonDown("Shoot");
       

        // Fire a bullet.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            FireMode = ShootMode.BasicShooting;
            
        }

        // Fire a spread shot
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            FireMode = ShootMode.MoreShot;

       
           
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && Time.time > nextFireTime)
        {

            FireMode = ShootMode.FireBigSlowShot;
            
        }

        if (FireMode == ShootMode.BasicShooting)
        {
            BasicShooting();

        } 
        else if (FireMode == ShootMode.MoreShot)
        {
            MoreShot();
        }

        //different way but the same but with switch statements
    // switch(FireMode)
    // {
    //     case ShootMode.BasicShooting;
    //         NormalShot();
    //         break;
    //         case ShootMode.NormalShot;
    //         BasicShooting();
    //         break;
    //         case ShootMode.MoreShot;
    //         MoreShot();
    //         break;
    //         case ShootMode.FireBigSlowShot;
    //         FireBigSlowShot();
    //         break;
    //
    // }


    }

    private void BasicShooting()
    {
        
        if (FIRE && Delay <= 0)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            float secondsPerShot = 1 / Firerate;
            Delay = secondsPerShot;
        }

        Delay -= Time.deltaTime;


        if (Delay < 0)
        {
            Delay = 0;
        }
    }

     private void NormalShot()
     {
         Instantiate(bulletPrefab, transform.position, Quaternion.identity);
     }

    private float nextFireTime; // Timer for the big slow bullet

    private void FireBigSlowShot()
    {
        GameObject bigBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bigBullet.transform.localScale = new Vector3(3f, 3f, 1f); // Set the big scale
        nextFireTime = Time.time + 1f; // Adjust the fire rate as needed

    }

    private void MoreShot()
    {

        if (FIRE && Delay <= 0)
        {
            Vector3 eulerRotation = transform.rotation.eulerAngles; // converts to XYZ angles
                                                                    // Create a multiple of bullets
            Instantiate(bulletPrefab, transform.position,
                Quaternion.Euler(eulerRotation.x, eulerRotation.y, eulerRotation.z + 30));// Left
            Instantiate(bulletPrefab, transform.position,
                Quaternion.Euler(eulerRotation.x, eulerRotation.y, eulerRotation.z)); // Center
            Instantiate(bulletPrefab, transform.position,
                Quaternion.Euler(eulerRotation.x, eulerRotation.y, eulerRotation.z - 30));  // Right
            float secondsPerShot = 1 / Firerate;
            Delay = secondsPerShot;
        }

        Delay -= Time.deltaTime;


        if (Delay < 0)
        {
            Delay = 0;
        }

    }
  }
  

