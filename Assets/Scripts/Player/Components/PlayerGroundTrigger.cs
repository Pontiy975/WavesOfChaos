using UnityEngine;

namespace WavesOfChaos.Player.Components
{
    public class PlayerGroundTrigger : MonoBehaviour
    {
        private const string GROUND_TAG = "Ground";

        public bool IsGrounded { get; private set; }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag(GROUND_TAG) && !IsGrounded)
                IsGrounded = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(GROUND_TAG) && IsGrounded)
                IsGrounded = false;
        }
    }
}
