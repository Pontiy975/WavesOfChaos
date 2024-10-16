using UnityEngine;
using WavesOfChaos.Player.Components;
using WavesOfChaos.Player.Data;
using WavesOfChaos.Settings;
using WavesOfChaos.Weapon;

namespace WavesOfChaos.Player.StateMachine.States
{
    public class AttackState : PlayerSuperState
    {
        private readonly Animator _playerAnimator;
        private readonly IWeapon _weapon;

        private readonly static int _inAttackStateHash = Animator.StringToHash("InAttackState");

        public AttackState(CharacterController characterController, Transform body, CharacterModel characterModel,
                           PlayerInputComponent playerInputComponent, GameSettings gameSettings,
                           PlayerMovementParams playerMovementParams, PlayerGroundTrigger playerGroundTrigger,
                           Animator playerAnimator, IWeapon weapon)
            : base(characterController, body, characterModel, playerInputComponent, gameSettings, playerMovementParams,
                   playerGroundTrigger)
        {
            _playerAnimator = playerAnimator;
            _weapon = weapon;
        }

        protected override void DoLogic()
        {
            base.DoLogic();

            if (playerInputComponent.GetPlayerAttackStarted())
            {
                Debug.Log("Attack started");
                _playerAnimator.SetBool(_inAttackStateHash, true);
                _weapon.EnableRig();
            }
            else if (playerInputComponent.GetPlayerAttackFinished())
            {
                Debug.Log("Attack ended");
                _playerAnimator.SetBool(_inAttackStateHash, false);
                _weapon.DisableRig();
            }
        }
    }
}
