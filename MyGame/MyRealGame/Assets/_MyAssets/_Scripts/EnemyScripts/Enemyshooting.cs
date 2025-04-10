using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemyshooting : MonoBehaviour
{
    private float moveSpeed = 20f;
    [SerializeField] private float destroyPoint = -10f; // Point at which the object is destroyed

    // Update is called once per frame
    void Update()
    {
        // Move the object to the left
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // Destroy the object when it moves past the destroy point
        if (transform.position.x < destroyPoint)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            Debug.Log(collision.gameObject.tag);
        }
    }
}
