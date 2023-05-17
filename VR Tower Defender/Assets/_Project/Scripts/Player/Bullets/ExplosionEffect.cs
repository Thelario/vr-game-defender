using UnityEngine;

namespace Game
{
    public class ExplosionEffect : MonoBehaviour
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
