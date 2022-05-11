using System.Collections;
using System.Collections.Generic;
using Agario.ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Agario.GamePlay.Stage
{
    public class CoinsPool : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private GameObject coin;
        [SerializeField] private int size;
        [SerializeField] private float timer;

        [Header("Dependencies")]
        [SerializeField] private IntValue stageSize;
        
        private Queue<GameObject> pool;

        private void Awake()
        {
            pool = new Queue<GameObject>();
            FillPool();  
        } 

        private void Start() => StartCoroutine(SpawnCoin());
        
        private IEnumerator SpawnCoin()
        {
            var item = pool.Dequeue();
            item.SetActive(true);
            item.transform.position = SetRandomPosition(stageSize.Value);
            pool.Enqueue(item);
            
            yield return new WaitForSeconds(timer);
            StartCoroutine(SpawnCoin());
        }

        private void FillPool()
        {
            for (int i = 0; i < size; i++)
            {
                var temp = Instantiate(coin);
                temp.SetActive(false);
                pool.Enqueue(Instantiate(coin)); 
            }
        }
        
        private Vector3 SetRandomPosition(int threshold) 
            => new (Random.Range(stageSize.Value * -1, stageSize.Value), 
                    Random.Range(stageSize.Value * -1, stageSize.Value), 
                    0);
    }
}
