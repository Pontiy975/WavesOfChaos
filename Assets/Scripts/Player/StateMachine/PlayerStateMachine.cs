using UnityEngine;
using WavesOfChaos.Player.Data;
using WavesOfChaos.Player.Components;
using WavesOfChaos.Player.StateMachine.States;
using WavesOfChaos.Settings;
using UnityEngine.Animations.Rigging;
using StateMachine;

namespace WavesOfChaos.Player.StateMachine
{
    public class PlayerStateMachine : global::StateMachine.StateMachine
    {
        public PlayerStateMachine(CharacterController characterController, Transform body, CharacterModel characterModel,
                                  PlayerInputComponent inputComponent, GameSettings gameSettings,
                                  PlayerMovementParams playerMovementParams, PlayerGroundTrigger playerGroundTrigger,
                                  Animator playerAnimator, Rig rig)
        {
            States = new()
            {
                { typeof(PlayerSuperState), new PlayerSuperState(characterController, body, characterModel, inputComponent,
                                                                 gameSettings, playerMovementParams, playerGroundTrigger) },
                { typeof(AttackState), new AttackState(characterController, body, characterModel, inputComponent,
                                                       gameSettings, playerMovementParams, playerGroundTrigger,
                                                       playerAnimator, rig) }
            };

            State = States[typeof(PlayerSuperState)];
        }

        public void ToAttackState()
        {
            if (State is not AttackState)
                HandleStateBeginExit(this, new StateBeginExitEventArgs(typeof(AttackState)));
        }
    }
}
