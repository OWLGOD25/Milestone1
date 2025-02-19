using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float moveSpeed;
    public float fireRate = 2f;
    public bool FIRE;
    public float Delay = 0;
    public float Firerate = -1;
   
    // Start is called before the first frame update
    public int maxHealth = 5; // Player's maximum health
    public int currentHealth; // Player's current health

    // Start is called before the first frame update
    void Start()
    {
        nextFireTime = Time.time + fireRate; // Initialize the timer
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
        BasicShootingPattern();


        //The fire button is LCtrl but you can press space to do the same thing
    
        // Fire a bullet.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NormalShot();
        }

        // Fire a spread shot
        if (Input.GetKeyDown(KeyCode.E))
        {

            MoreShot();
           
        }

        if (Input.GetKeyDown(KeyCode.Q) && Time.time > nextFireTime)
        {
            FireBigSlowShot();
        }
      


    }

    private void BasicShootingPattern()
    {
        //The fire button is J but you can press space to do the Normal shot with out any limits
        if (FIRE && Delay <= 0)
        {
            NormalShot();
            float secondsPerShot = 1 / Firerate;
            Delay += secondsPerShot;
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

        // Create a multiple of bullets
        Instantiate(bulletPrefab, transform.position + new Vector3(-0.4f, 0f, 0f), Quaternion.identity); // Left
        Instantiate(bulletPrefab, transform.position, Quaternion.identity); // Center
        Instantiate(bulletPrefab, transform.position + new Vector3(0.2f, 0f, 0f), Quaternion.identity); // Right

    }
  }
  

