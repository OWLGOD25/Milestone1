using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject enemyToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPoint = new Vector3(-7f, Random.Range(-10f, 5f), 0f);
        Instantiate(enemyToSpawn, spawnPoint, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
