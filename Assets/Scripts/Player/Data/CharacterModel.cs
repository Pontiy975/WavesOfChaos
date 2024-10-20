using UnityEngine;

namespace WavesOfChaos.Player.Data
{
    [CreateAssetMenu(fileName = "CharacterModel", menuName = "Scriptable Objects/Characters Data/Character Model")]
    public class CharacterModel : ScriptableObject
    {
        [field: Header("Movement settings")]
        [field: SerializeField] public float Speed { get; private set; } = 5f;
        [field: SerializeField] public float SprintSpeed { get; private set; } = 20f;
        [field: SerializeField] public float JumpHeight { get; private set; } = 1f;

        [field: Header("Crouching")]
        [field: SerializeField] public float StandingHeight { get; private set; } = 2f;
        [field: SerializeField] public float CrouchedHeight { get; private set; } = 1f;
        [field: SerializeField] public float CrouchedSpeed { get; private set; } = 2f;
    }
}
