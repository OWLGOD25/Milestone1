using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float moveSpeed;
    public float fireRate = 2f;
   
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
        // Fire a bullet.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }

        // Fire a spread shot
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Create a spread of bullets
            Instantiate(bulletPrefab, transform.position + new Vector3(-0.2f, 0f, 0f), Quaternion.identity); // Left
            Instantiate(bulletPrefab, transform.position, Quaternion.identity); // Center
            Instantiate(bulletPrefab, transform.position + new Vector3( 0.2f, 0f, 0f), Quaternion.identity); // Right
        }

        if (Input.GetKeyDown(KeyCode.Q) && Time.time > nextFireTime)
        {
            FireBigSlowShot();
        }
    }

    private float nextFireTime; // Timer for the big slow bullet

    private void FireBigSlowShot()
    {
        GameObject bigBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bigBullet.transform.localScale = new Vector3(3f, 3f, 1f); // Set the big scale
        nextFireTime = Time.time + 1f; // Adjust the fire rate as needed
    }
  }
  

