using System.Collections;
using System.Collections.Generic;
using Agario.Network;
using Agario.ScriptableObjects;
using UnityEngine;

namespace Agario.GamePlay.Stage
{
    public class CoinsPool : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private GameObject coin;
        [SerializeField] private int size;
        [SerializeField] private float timer;

        [Header("Network")] 
        [SerializeField] private NetworkSetup nwSetup;
       
        [Header("Dependencies")]
        [SerializeField] private IntValue stageSize;
        
        private Queue<GameObject> pool;
        private Requester requester;

        private void Awake()
        {
            LoadClass();
            FillPool();
        }

        private void Start() => StartCoroutine(SpawnCoin());

        private IEnumerator SpawnCoin()
        {
            var item = pool.Dequeue();
            item.SetActive(true);
            item.transform.position = requester.ServerPosition(stageSize.Value);
            pool.Enqueue(item);
            
            yield return new WaitForSeconds(timer);
            StartCoroutine(SpawnCoin());
        }

        private void LoadClass()
        {
            pool = new Queue<GameObject>();
            requester = new Requester(nwSetup);
        }

        private void FillPool()
        {
            for (int i = 0; i < size; i++)
            {
                var temp = Instantiate(coin, transform);
                temp.SetActive(false);
                pool.Enqueue(temp); 
            }
        }
    }
}
