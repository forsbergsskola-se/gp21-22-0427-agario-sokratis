using System;
using UnityEngine;

namespace Agario
{
    public class Scale : MonoBehaviour
    {
        [SerializeField] private PlayerStats stats;
        
        public void SetScale(int point) 
            => transform.localScale += SetScaleVector(point);
       
        public Vector3 SetScaleVector(int point) 
            => new (SetScaleUnit(point), SetScaleUnit(point), 1);
        
        private float SetScaleUnit(int point) 
            => point * stats.ScaleRate;
    }
}
