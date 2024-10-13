using StateMachine;
using System;
using System.Collections;
using UnityEngine;
using WavesOfChaos.Player.Data;
using WavesOfChaos.Player.Components;
using WavesOfChaos.Settings;

namespace WavesOfChaos.Player.StateMachine.States
{
    public class PlayerSuperState : IState
    {
        public event EventHandler<StateBeginExitEventArgs> OnBeginExit;

        private readonly CharacterModel _characterModel;
        private readonly GameSettings _gameSettings;

        private readonly CharacterController _characterController;
        private readonly Transform _body;
        
        protected readonly PlayerInputComponent playerInputComponent;
        private readonly PlayerGroundTrigger _playerGroundTrigger;
        private readonly PlayerMovementParams _playerMovementParams;

        public PlayerSuperState(CharacterController characterController, Transform body, CharacterModel characterModel,
                                PlayerInputComponent playerInputComponent, GameSettings gameSettings,
                                PlayerMovementParams playerMovementParams, PlayerGroundTrigger playerGroundTrigger)
        {
            _characterController = characterController;
            _body = body;

            _characterModel = characterModel;
            _gameSettings = gameSettings;
            
            this.playerInputComponent = playerInputComponent;
            _playerMovementParams = playerMovementParams;
            _playerGroundTrigger = playerGroundTrigger;
        }

        public IEnumerable Execute()
        {
            while (true)
            {
                DoLogic();

                yield return null;
            }
        }

        protected virtual void DoLogic()
        {
            Movement();
            Rotatiton();
            Jump();
            Crouch();
        }

        private void Movement()
        {
            _playerMovementParams.isInSprint = playerInputComponent.GetPlayerSprint();

            Vector2 inputVector = playerInputComponent.GetPlayerMovement();
            Vector3 movementVector = new Vector3(inputVector.x, 0f, inputVector.y);

            movementVector = _characterController.transform.TransformDirection(movementVector);
            movementVector.y = 0f;
            movementVector.Normalize();

            _characterController.Move(GetSpeed() * Time.deltaTime * movementVector);
        }

        private void Rotatiton()
        {
            _playerMovementParams.turn.x += CalculateAxisValue(playerInputComponent.GetMouseDelta().x);    
            _playerMovementParams.turn.y += CalculateAxisValue(playerInputComponent.GetMouseDelta().y);
            _playerMovementParams.turn.y = Mathf.Clamp(_playerMovementParams.turn.y, -60f, 45f);

            _body.localRotation = Quaternion.Euler(-_playerMovementParams.turn.y, 0f, 0f);
            _characterController.transform.localRotation = Quaternion.Euler(0, _playerMovementParams.turn.x, 0f);
        }

        private void Jump()
        {
            if (_playerGroundTrigger.IsGrounded && _playerMovementParams.velocity.y < 0f)
                _playerMovementParams.velocity.y = 0f;

            if (playerInputComponent.GetPlayerJump() && _playerGroundTrigger.IsGrounded)
                _playerMovementParams.velocity.y += Mathf.Sqrt(_characterModel.JumpHeight * -3f * _gameSettings.Gravity);

            _playerMovementParams.velocity.y += _gameSettings.Gravity * Time.deltaTime;
            _characterController.Move(_playerMovementParams.velocity * Time.deltaTime);
        }

        private void Crouch()
        {
            _playerMovementParams.isCrouching = playerInputComponent.GetPlayerCrouch();

            _characterController.height = _playerMovementParams.isCrouching 
                                          ? _characterModel.CrouchedHeight 
                                          : _characterModel.StandingHeight;
        }

        private float CalculateAxisValue(float axisValue) 
            => axisValue * _gameSettings.MouseSensivity * Time.deltaTime;

        private float GetSpeed()
        {
            if (_playerMovementParams.isCrouching)
                return _characterModel.CrouchedSpeed;
            else if (_playerMovementParams.isInSprint)
                return _characterModel.SprintSpeed;

            return _characterModel.Speed;
        }

        public void EndExit() { }
    }
}
