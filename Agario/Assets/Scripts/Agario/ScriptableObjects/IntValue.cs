using UnityEngine;

namespace Agario.ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Values/Int", fileName = "NewIntValue")]
    public class IntValue : ScriptableObject
    {
        [SerializeField] private int intValue;

        public int Value
        {
            get => intValue;
            set => intValue = value;
        }
    }
}
