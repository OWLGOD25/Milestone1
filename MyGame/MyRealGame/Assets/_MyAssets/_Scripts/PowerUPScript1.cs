using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPScript : MonoBehaviour
{

    [SerializeField] Transform PowerUP1;
    [SerializeField] Transform PowerUP2;
    [SerializeField] Transform PowerUP3;
    public float spawnInterval = 4.5f;

    private void Start()
    {
        InvokeRepeating("PowerUPSpawn", 0f, spawnInterval);


    }
    private void PowerUPSpawn()
    {
        // Choose a random power-up to spawn
        int randomIndex = Random.Range(0, 3); // 0, 1, or 2
        Transform powerUpToSpawn;

        switch (randomIndex)
        {
            case 0:
                powerUpToSpawn = PowerUP1;
                break;
            case 1:
                powerUpToSpawn = PowerUP2;
                break;
            case 2:
                powerUpToSpawn = PowerUP3;
                break;
            default:
                powerUpToSpawn = PowerUP1; // Default to PowerUP1 if something goes wrong
                break;

        }
                Vector3 randomSpawn = new Vector3(9.5f, Random.Range(-5.5f, 5.5f), 0f);
                Transform newTarget = Instantiate(powerUpToSpawn, randomSpawn, Quaternion.identity);
                newTarget.gameObject.AddComponent<MoveLeft>();
        }



        // Update is called once per frame
        void Update()
        {

        }

    }

        
