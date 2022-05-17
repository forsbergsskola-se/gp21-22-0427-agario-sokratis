using System;
using UnityEngine;

namespace Agario
{
    [CreateAssetMenu(menuName = "ScriptableObjects/PlayerStats", fileName = "NewPlayerStats")]
    public class PlayerStats : ScriptableObject
    {
        [Header("Stats")]
        [SerializeField] private float speed;
        [SerializeField] private float scaleRate = 0.05f;

        [Header("Score")]
        [SerializeField] private int startPoints = 2;

        public float Speed => speed;
        public float ScaleRate => scaleRate;
        public int StartPoints => startPoints;
    }
}
