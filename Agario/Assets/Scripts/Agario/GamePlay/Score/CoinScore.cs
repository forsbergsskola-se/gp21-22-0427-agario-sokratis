using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Agario.GamePlay.Score
{
    public class CoinScore : Score
    {
        private void OnCollisionEnter2D(Collision2D col)
        {
            gameObject.SetActive(false);
        }
    }
}
