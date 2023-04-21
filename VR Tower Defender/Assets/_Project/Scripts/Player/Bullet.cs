using System;
using UnityEngine;

namespace Game
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;

        private float _damage;

        private void Start()
        {
            Destroy(gameObject, 5f);
        }

        private void Update()
        {
            transform.position += moveSpeed * Time.deltaTime * transform.forward;
        }

        public void SetupBullet(float damage, Transform target)
        {
            transform.LookAt(target);
            _damage = damage;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageable iDamageable))
                iDamageable.TakeDamage(_damage);
            
            Destroy(gameObject);
        }
    }
}