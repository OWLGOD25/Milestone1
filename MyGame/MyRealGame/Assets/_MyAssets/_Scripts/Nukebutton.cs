 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nukebutton : MonoBehaviour
{
    void Update()
    {
        // Check if the "C" key is pressed
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Find all GameObjects in the scene
            GameObject[] allObjects = FindObjectsOfType<GameObject>();

            foreach (GameObject obj in allObjects)
            {
                // Destroy the object if it is not tagged as "Player"
                if (obj.CompareTag("Player") == false)
                {
                    Destroy(obj);
                }
            }

            Debug.Log("OH SHIT TOO MENY");
        }
    }
}
