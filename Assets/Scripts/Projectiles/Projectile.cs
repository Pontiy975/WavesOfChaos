using PoolingSystem;
using System.Collections;
using UnityEngine;

namespace Projectiles
{
    public class Projectile : PoolableObject
    {
        [SerializeField] private PoolController projectilesPool;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float speed = 25f;
        [SerializeField] private float returnToPoolDelay = 30f;

        protected Transform _transform;
        protected int attackPower;

        private bool _isFinished;

        private void Awake()
        {
            _transform = transform;
        }

        public virtual void Launch(int attackPower)
        {
            this.attackPower = attackPower;
            rb.isKinematic = false;
            rb.AddForce(_transform.forward * speed, ForceMode.Impulse);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_isFinished)
                return;

            _isFinished = true;
            rb.isKinematic = true;

            StartCoroutine(ReturnToPoolRoutine());
        }

        private IEnumerator ReturnToPoolRoutine()
        {
            yield return new WaitForSeconds(returnToPoolDelay);
            projectilesPool.ReturnToPool(this);
        }
    }
}