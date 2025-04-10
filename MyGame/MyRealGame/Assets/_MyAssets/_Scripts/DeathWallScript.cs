using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWallScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroy the GameObject that collides with the DeathWall
        Destroy(collision.gameObject);
    }
}
