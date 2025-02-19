using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPScript : MonoBehaviour
{
   
    [SerializeField] Transform PowerUP;
    public float spawnInterval = 2f;

    private void Start()
    {
        InvokeRepeating("PowerUPSpawn", 0f, spawnInterval);


    }


    private void PowerUPSpawn()
    {

        Vector3 randomSpawn = new Vector3(9.5f, Random.Range(-5.5f, 5.5f), 0f);
        Transform newTarget = Instantiate(PowerUP, randomSpawn, Quaternion.identity);
        newTarget.gameObject.AddComponent<MoveLeft>();


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PUP1")
        {
            GameObject Player = collision.gameObject;
            PlayerScript playerscript = Player.GetComponent<PlayerScript>();
            if (playerscript)
            {
                
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
