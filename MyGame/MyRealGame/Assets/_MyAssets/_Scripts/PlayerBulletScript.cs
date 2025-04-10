using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBulletScript : MonoBehaviour
{


    private float moveSpeed = 20;
    
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        // Method 1, world space check.
        if (transform.position.x > 20f) // When getting to a certain point, destroy bullet.
        {
            Destroy(gameObject);
        }
        // Method 2, screen space check.
        //Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        //if (screenPosition.x > (Screen.width + 10))
        //{
        //    Destroy(gameObject);
        //}
    }
  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Target")
        {

     
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            Debug.Log(collision.gameObject.tag);
        } 

          
    }

}
