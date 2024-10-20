using PoolingSystem;
using Projectiles;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace WavesOfChaos.Weapon
{
    public class Bow : Weapon
    {
        [SerializeField] private PoolController projectilesPool;
        [SerializeField] private Rig rig;
        [SerializeField] private Transform stringBone;
        [SerializeField] private Transform projectilePoint;
        [SerializeField] private float attackDistance;

        private Transform _transform;
        private Projectile _projectile;
        private Vector3 _stringBasePosition;

        private void Start()
        {
            _stringBasePosition = stringBone.localPosition;
        }

        public override void EnableRig()
        {
            rig.weight = 0.1f;
            SpawnProjectile();
        }

        public override void DisableRig()
        {
            rig.weight = 0f;
            stringBone.localPosition = _stringBasePosition;
            Attack();
        }

        public override void Attack()
        {
            _projectile?.transform.SetParent(null);
            _projectile?.Launch(1);
            _projectile = null;
        }

        private void SpawnProjectile()
        {
            _projectile ??= projectilesPool.GetFromPool<Projectile>();
            _projectile.transform.SetParent(projectilePoint);
            _projectile.transform.SetLocalPositionAndRotation(Vector2.zero, Quaternion.identity);
            _projectile.transform.localScale = Vector3.one;
        }
    }
}
