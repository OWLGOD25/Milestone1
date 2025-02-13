    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class SpawnTarget : MonoBehaviour
    {
        [SerializeField] Transform targetPrefab;
        public float spawnInterval = 2f;
     
        private void Start()
        {
            InvokeRepeating("TargetSpawn", 0f, spawnInterval);
       

    }
    private void TargetSpawn()
        {
        
            Vector3 randomSpawn = new Vector3(8.5f, Random.Range(-5.5f, 5.5f), 0f);
        Transform newTarget = Instantiate(targetPrefab, randomSpawn, Quaternion.identity);
        newTarget.gameObject.AddComponent<MoveLeft>();
       
      
        }
    }
