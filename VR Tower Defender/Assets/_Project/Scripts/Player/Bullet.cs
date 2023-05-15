using UnityEngine;

namespace Game
{
    public class Bullet : MonoBehaviour, IConfigurable
    {
        [SerializeField] private float moveSpeed;

        protected float _damage;

        private void Start()
        {
            Destroy(gameObject, 5f);
        }

        private void Update()
        {
            transform.position += moveSpeed * Time.deltaTime * transform.forward;
        }

        public void ConfigureBullet(float damage, Transform target)
        {
            transform.LookAt(target);
            _damage = damage;
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Obstacle"))
            {
                Destroy(gameObject);
                return;
            }

            if (!other.CompareTag("Enemy"))
                return;
        
            if (other.TryGetComponent(out IDamageable iDamageable))
                iDamageable.TakeDamage(_damage);
            
            Destroy(gameObject);
        }
    }
}