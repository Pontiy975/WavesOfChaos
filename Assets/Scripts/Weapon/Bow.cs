using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace WavesOfChaos.Weapon
{
    public class Bow : Weapon
    {
        [SerializeField] private Rig rig;
        [SerializeField] private Transform stringBone;
        [SerializeField] private Transform arrow;

        private Vector3 _stringBasePosition;

        private void Awake()
        {
            _stringBasePosition = stringBone.localPosition;
        }

        private void Update()
        {
            //arrow.position = stringBone.position;
        }

        public override void EnableRig()
        {
            rig.weight = 0.1f;
        }

        public override void DisableRig()
        {
            rig.weight = 0f;
            stringBone.localPosition = _stringBasePosition;
        }
    }
}
