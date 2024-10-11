using UnityEngine;
using WavesOfChaos.Player.Components;
using WavesOfChaos.Player.Data;
using WavesOfChaos.Player.StateMachine;
using WavesOfChaos.Settings;

namespace WavesOfChaos.Player
{
    [RequireComponent(typeof(PlayerInputComponent), typeof(CharacterController))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private Transform body;
        
        [SerializeField] private PlayerInputComponent inputComponent;
        [SerializeField] private PlayerGroundTrigger playerGroundTrigger;

        [SerializeField] private CharacterModel characterModel;
        [SerializeField] private GameSettings gameSettings;

        private PlayerMovementParams _playerMovementParams = new();
        private PlayerStateMachine _playerStateMachine;

        private void Start()
        {
            _playerStateMachine = new PlayerStateMachine(characterController, body, characterModel, inputComponent,
                                                         gameSettings, _playerMovementParams, playerGroundTrigger);

            StartCoroutine(_playerStateMachine.Execute().GetEnumerator());
        }
    }

    public class PlayerMovementParams
    {
        public Vector2 turn;
        public Vector3 velocity;
        public bool isCrouching;
        public bool isInSprint;
    }
}
