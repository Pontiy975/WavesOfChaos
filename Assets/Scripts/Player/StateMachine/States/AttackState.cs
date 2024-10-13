using UnityEngine;
using UnityEngine.Animations.Rigging;
using WavesOfChaos.Player.Components;
using WavesOfChaos.Player.Data;
using WavesOfChaos.Settings;

namespace WavesOfChaos.Player.StateMachine.States
{
    public class AttackState : PlayerSuperState
    {
        private readonly Animator _playerAnimator;
        private readonly Rig _rig;

        private readonly static int _inAttackStateHash = Animator.StringToHash("InAttackState");

        public AttackState(CharacterController characterController, Transform body, CharacterModel characterModel,
                           PlayerInputComponent playerInputComponent, GameSettings gameSettings,
                           PlayerMovementParams playerMovementParams, PlayerGroundTrigger playerGroundTrigger,
                           Animator playerAnimator, Rig rig)
            : base(characterController, body, characterModel, playerInputComponent, gameSettings, playerMovementParams,
                   playerGroundTrigger)
        {
            _playerAnimator = playerAnimator;
            _rig = rig;
        }

        protected override void DoLogic()
        {
            base.DoLogic();

            if (playerInputComponent.GetPlayerAttackStarted())
            {
                Debug.Log("Attack started");
                _playerAnimator.SetBool(_inAttackStateHash, true);
                _rig.weight = 1f;
            }
            else if (playerInputComponent.GetPlayerAttackFinished())
            {
                Debug.Log("Attack ended");
                _playerAnimator.SetBool(_inAttackStateHash, false);
                _rig.weight = 0f;
            }
        }
    }
}
