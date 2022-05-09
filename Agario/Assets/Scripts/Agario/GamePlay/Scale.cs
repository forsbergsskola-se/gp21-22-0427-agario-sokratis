using Agario.Interfaces;
using UnityEngine;

namespace Agario
{
    public class Scale 
    {
        private static Vector3 SetScaleMagnitude(int points, float sRate)
        {
            var scale = points * sRate;
            return new Vector3(scale, scale, 0);
        } 
        
    }
}
