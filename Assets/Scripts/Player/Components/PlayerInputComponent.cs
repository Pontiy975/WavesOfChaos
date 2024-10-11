using UnityEngine;

namespace WavesOfChaos.Player.Components
{
    public class PlayerInputComponent : MonoBehaviour
    {
        private PlayerInput _playerInput;

        private void Awake()
        {
            _playerInput = new PlayerInput();
        }

        private void OnEnable()
        {
            _playerInput.Player.Enable();
        }

        private void OnDisable()
        {
            _playerInput.Player.Disable();
        }

        public Vector2 GetPlayerMovement() => _playerInput.Player.Move.ReadValue<Vector2>();

        public Vector2 GetMouseDelta() => _playerInput.Player.Look.ReadValue<Vector2>();

        public bool GetPlayerJump() => _playerInput.Player.Jump.triggered;

        public bool GetPlayerCrouch() => _playerInput.Player.Crouch.IsPressed();

        public bool GetPlayerSprint() => _playerInput.Player.Sprint.IsPressed();
    }
}
