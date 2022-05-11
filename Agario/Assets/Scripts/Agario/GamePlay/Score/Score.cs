using Agario.Interfaces;
using Agario.ScriptableObjects;
using UnityEngine;

namespace Agario.GamePlay.Score
{
    public class Score : MonoBehaviour, IPoints
    {
        [Header("Dependencies")]
        [SerializeField] private IntValue intPoints;
        
        public int Points 
        {
            get => intPoints.Value;
            set => intPoints.Value = value;
        }

    }
}

