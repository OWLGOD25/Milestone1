using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float moveDistance = 20f; // Distance to move left
    private Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        // Move left until the distance is reached
        if (Vector3.Distance(transform.position, startingPosition) < moveDistance)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
