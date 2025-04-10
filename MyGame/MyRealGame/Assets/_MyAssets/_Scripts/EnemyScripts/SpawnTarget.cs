using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // For restarting the game

public class SpawnTarget : MonoBehaviour
{
    [SerializeField] Transform targetPrefab; // Prefab for the target
    [SerializeField] GameObject bulletPrefab; // Prefab for the bullet
    [SerializeField] AudioClip pewSound; // The "pew" sound effect
    public float spawnInterval = 5f;
    public float bulletSpeed = 5f; // Speed of the bullet
    public float shootInterval = 1f; // Time interval between each shot

    private AudioSource audioSource;

    private void Start()
    {
        // Add an AudioSource component to this GameObject if not already present
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        InvokeRepeating("TargetSpawn", 0f, spawnInterval);
    }

    private void TargetSpawn()
    {
        Vector3 randomSpawn = new Vector3(9.5f, Random.Range(-5f, 5.5f), 0f);
        Transform newTarget = Instantiate(targetPrefab, randomSpawn, Quaternion.identity);


        // Start shooting bullets to the left
        StartCoroutine(ShootBullets(newTarget));
    }

    private IEnumerator ShootBullets(Transform target)
    {
        while (target != null) // Keep shooting until the target is destroyed
        {
            // Instantiate the bullet at the target's position
            GameObject bullet = Instantiate(bulletPrefab, target.position, Quaternion.identity);

            // Add a Rigidbody2D and Collider2D to the bullet if not already present
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb == null)
            {
                rb = bullet.AddComponent<Rigidbody2D>();
                rb.gravityScale = 0; // Ensure the bullet doesn't fall due to gravity
            }

            Collider2D collider = bullet.GetComponent<Collider2D>();
            if (collider == null)
            {
                collider = bullet.AddComponent<BoxCollider2D>();
                collider.isTrigger = true; // Use trigger for collision detection
            }

            // Move the bullet to the left
            rb.velocity = Vector2.left * bulletSpeed;

            // Play the "pew" sound
            PlayPewSound();

            yield return new WaitForSeconds(shootInterval); // Wait for the next shot
        }
    }

    private void PlayPewSound()
    {
        if (pewSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(pewSound);
        }
        else
        {
            Debug.LogWarning("Pew sound or AudioSource is not assigned!");
        }
    }
}

