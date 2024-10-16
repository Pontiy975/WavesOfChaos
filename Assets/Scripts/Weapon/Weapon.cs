using UnityEngine;

namespace WavesOfChaos.Weapon
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        public abstract void EnableRig();
        public abstract void DisableRig();
    }
}
