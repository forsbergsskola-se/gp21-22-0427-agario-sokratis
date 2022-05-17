using System;
using Agario.Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Agario.GamePlay
{
    public class PlayerScore : Score.Score
    {
        [Header("Events")] 
        [SerializeField] public UnityEvent<int> onScore;

        [Header("Dependencies")] 
        [SerializeField] private PlayerStats stats;

        private void Awake() => Points = stats.StartPoints;

        private void OnCollisionEnter2D(Collision2D col)
        {
            var otherPoints = col.gameObject.GetComponent<IPoints>().Points;
            if (Points > otherPoints)
            {
                Points += otherPoints;
                onScore.Invoke(otherPoints);
            }
            else if(Points < otherPoints) gameObject.SetActive(false);
        }
    }
}
