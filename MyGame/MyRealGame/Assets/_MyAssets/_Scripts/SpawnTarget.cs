    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class SpawnTarget : MonoBehaviour
    {
        [SerializeField] Transform targetPrefab;

        public float spawnInterval = 5f;
     
        private void Start()
        {
            InvokeRepeating("TargetSpawn", 0f, spawnInterval);
       

    }
    private void TargetSpawn()
        {
        
            Vector3 randomSpawn = new Vector3(9.5f, Random.Range(-5f, 5.5f), 0f);
        Transform newTarget = Instantiate(targetPrefab, randomSpawn, Quaternion.identity);
        newTarget.gameObject.AddComponent<MoveLeft>();
       
      
        }
    }
