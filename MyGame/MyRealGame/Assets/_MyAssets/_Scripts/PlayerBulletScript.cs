using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBulletScript : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    int scoreValue = 10;
    private float moveSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
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
            scoreManager.AddScore(scoreValue);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
