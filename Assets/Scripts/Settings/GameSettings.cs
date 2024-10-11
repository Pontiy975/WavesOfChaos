using UnityEngine;

namespace WavesOfChaos.Settings
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptable Objects/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [field: SerializeField] public float MouseSensivity { get; private set; } = 10f;
        [field: SerializeField] public float Gravity { get; private set; } = -9.81f;
    }
}
