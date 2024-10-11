using UnityEngine;
using WavesOfChaos.Player.Data;
using WavesOfChaos.Player.Components;
using WavesOfChaos.Player.StateMachine.States;
using WavesOfChaos.Settings;

namespace WavesOfChaos.Player.StateMachine
{
    public class PlayerStateMachine : global::StateMachine.StateMachine
    {
        public PlayerStateMachine(CharacterController characterController, Transform body, CharacterModel characterModel,
                                  PlayerInputComponent inputComponent, GameSettings gameSettings,
                                  PlayerMovementParams playerMovementParams, PlayerGroundTrigger playerGroundTrigger)
        {
            States = new()
            {
                { typeof(PlayerSuperState), new PlayerSuperState(characterController, body, characterModel, inputComponent,
                                                                 gameSettings, playerMovementParams, playerGroundTrigger) },
            };

            State = States[typeof(PlayerSuperState)];
        }
    }
}
