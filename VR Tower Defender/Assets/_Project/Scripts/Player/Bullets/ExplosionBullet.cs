using UnityEngine;

namespace Game
{
    public class ExplosionBullet : MonoBehaviour, IConfigurable
    {
        [SerializeField] private GameObject explosionEffect;
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

        public void ConfigureBullet(float damage, Transform target)
        {
            transform.LookAt(target);
            _damage = damage;
        }

        protected void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Enemy") && !other.CompareTag("Obstacle")) 
                return;

            GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
            explosion.GetComponent<ExplosionEffect>().SetDamage(_damage);
            Destroy(explosion, 2f);
            Destroy(gameObject);
        }
    }
}
