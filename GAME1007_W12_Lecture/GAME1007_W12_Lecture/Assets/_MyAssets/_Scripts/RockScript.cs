using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    [SerializeField] Transform spacerock;
    public float spawnInterval = 2f;
     
    private void Start()
    {
        InvokeRepeating("RockSpawn", 0f, spawnInterval);


    }
   
   
    private void RockSpawn()
    {

        Vector3 randomSpawn = new Vector3(8.5f, Random.Range(-5.5f, 5.5f), 0f);
        Transform newTarget = Instantiate(spacerock, randomSpawn, Quaternion.identity);
        newTarget.gameObject.AddComponent<MoveLeft>();


    }
}
    
