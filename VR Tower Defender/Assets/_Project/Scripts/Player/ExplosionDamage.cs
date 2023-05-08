using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ExplosionDamage : MonoBehaviour
    {
        private float _damage;

        public void SetDamage(float damage)
        {
            _damage = damage;
        }

        protected void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Enemy"))
                return;

            other.GetComponent<IDamageable>().TakeDamage(_damage);
        }
    }
}
