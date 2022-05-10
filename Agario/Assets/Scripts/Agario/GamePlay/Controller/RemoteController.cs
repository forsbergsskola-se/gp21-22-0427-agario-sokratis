using Agario.ScriptableObjects;
using UnityEngine;

namespace Agario.GamePlay.Controller
{
    public class RemoteController : MonoBehaviour
    {
        [SerializeField] private Transform drone;
        [SerializeField] private IntValue remoteScore;
    }
}
