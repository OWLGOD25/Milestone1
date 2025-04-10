using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    [SerializeField] float scrollspeed; // Speed at which the background scrolls
    [SerializeField] float resetPoint; // The point at which the background resets
    [SerializeField] GameObject backgroundPrefab; // Prefab for the background
    private SpriteRenderer sr;
    private Vector2 offset;
    private Vector2 originalOffset; // To store the original offset
    private float backgroundWidth; // Width of the background

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        offset = sr.material.mainTextureOffset;
        originalOffset = offset; // Store the original offset

        // Calculate the width of the background based on the sprite's size
        backgroundWidth = sr.bounds.size.x;
    }

    private void Update()
    {
        // Scroll the background
        offset.x += scrollspeed * Time.deltaTime;

        // Check if the background has reached the reset point
        if (transform.position.x <= resetPoint)
        {
            // Reset the position of the background
            ResetBackgroundPosition();
        }

        sr.material.mainTextureOffset = offset;

        // Move the background
        transform.Translate(Vector3.left * scrollspeed * Time.deltaTime);
    }

    private void ResetBackgroundPosition()
    {
        // Calculate the position for the new background
        Vector3 newPosition = transform.position + new Vector3(backgroundWidth * 2, 0, 0);

        // Move the current background to the new position
        transform.position = newPosition;
    }
}
