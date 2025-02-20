using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float moveSpeed;
    public bool FIRE;
    public float Delay = 0;
    public float Firerate = -1;
    private float pupEffectDuration = 5f; // Duration of the PUP effect (in seconds)
    private float pupEffectStartTime = 0f; // Time when the PUP effect started



    public ShootMode FireMode = ShootMode.BasicShooting;

    public enum ShootMode
    { 
    BasicShooting = 0,
    MoreShot,
    FireBigSlowShot,
    Count
    }

   
   
    // Start is called before the first frame update
    void Start()
    {
        nextFireTime = Time.time + Firerate; // Initialize the timer
    }



    // Update is called once per frame
    void Update()
    {
        
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(x, y, 0f) * (moveSpeed * Time.deltaTime));


        //Press J to shoot
        FIRE = Input.GetButtonDown("Shoot");


       

        //different way but the same but with switch statements
        if (Input.GetButtonDown("Shoot") && Time.time > nextFireTime)
        {
            switch (FireMode)
            {
                case ShootMode.BasicShooting:
                    BasicShooting();
                    break;
                case ShootMode.MoreShot:
                    MoreShot();
                    break;
                case ShootMode.FireBigSlowShot:
                    FireBigSlowShot();
                    break;

            }
        }
        if (pupEffectStartTime != 0f && Time.time - pupEffectStartTime >= pupEffectDuration)
        {
            // Reset the fire mode to the default
            FireMode = ShootMode.BasicShooting; // Replace with your default fire mode
            pupEffectStartTime = 0f; // Reset the timer
            Debug.Log("PUP effect ended, fire mode reset.");

        }
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
private void OnCollisionEnter2D(Collision2D collision)
{
        if (collision.gameObject.tag == "PUP1" ||
            collision.gameObject.tag == "PUP2" ||
            collision.gameObject.tag == "PUP3")
        {
            Destroy(collision.gameObject);
            Debug.Log(gameObject.tag);
            if (collision.gameObject.tag == "PUP1")
            {
                FireMode = ShootMode.MoreShot; // Or whatever mode you want for PUP1
            }
            else if (collision.gameObject.tag == "PUP2")
            {
                FireMode = ShootMode.FireBigSlowShot; // Or whatever mode you want for PUP2
            }
            else if (collision.gameObject.tag == "PUP3")
            {
                FireMode = ShootMode.BasicShooting; // Or whatever mode you want for PUP3
            }

            Debug.Log("Fire mode switched to: " + FireMode);
        }


    }
  }

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

//  // Fire a bullet. in the first way that is coded
//  if (Input.GetKeyDown(KeyCode.Alpha1))
//  {
//      FireMode = ShootMode.BasicShooting;
//
//  }
//
//  // Fire a spread shot
//  if (Input.GetKeyDown(KeyCode.Alpha2))
//  {
//      FireMode = ShootMode.MoreShot;
//
//
//
//  }
//
//  if (Input.GetKeyDown(KeyCode.Alpha3) && Time.time > nextFireTime)
//  {
//
//      FireMode = ShootMode.FireBigSlowShot;
//
//  }
//
//  if (FireMode == ShootMode.BasicShooting)
//  {
//      BasicShooting();
//
//  }
//  else if (FireMode == ShootMode.MoreShot)
//  {
//      MoreShot();
//  }
