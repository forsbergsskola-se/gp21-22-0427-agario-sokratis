using System.Collections;
using System.Collections.Generic;
using Agario.Network;
using Agario.ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;

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
        
        private Queue<GameObject> _pool;
        private Requester _requester;

        private void Awake()
        {
            LoadClass();
            FillPool();
        }

        private void Start() => StartCoroutine(SpawnCoin());

        private IEnumerator SpawnCoin()
        {
            var item = _pool.Dequeue();
            item.SetActive(true);
            item.transform.position = _requester.ServerPosition(stageSize.Value);
            _pool.Enqueue(item);
            
            yield return new WaitForSeconds(timer);
            StartCoroutine(SpawnCoin());
        }

        private void LoadClass()
        {
            _pool = new Queue<GameObject>();
            _requester = new Requester(nwSetup);
        }

        private void FillPool()
        {
            for (int i = 0; i < size; i++)
            {
                var temp = Instantiate(coin, this.transform);
                temp.SetActive(false);
                _pool.Enqueue(temp); 
            }
        }
    }
}
