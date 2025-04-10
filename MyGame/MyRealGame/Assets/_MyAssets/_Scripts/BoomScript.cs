using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomScript : MonoBehaviour
{
    [SerializeField] private AudioClip explosionSound; // The explosion sound effect

    private void OnDestroy()
    {
        // Play the explosion sound when the object is destroyed
        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        }
        else
        {
            Debug.LogWarning("Explosion sound is not assigned!");
        }
    }
}
