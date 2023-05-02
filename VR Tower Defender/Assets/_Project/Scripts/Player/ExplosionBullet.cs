using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ExplosionBullet : MonoBehaviour, IConfigurable
    {
        [SerializeField] private GameObject explosionEffect;
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

        protected void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy") || other.CompareTag("Obstacle"))
            {
                Destroy(Instantiate(explosionEffect, transform.position, transform.rotation), 2f);
                Destroy(gameObject);
            }
        }
    }
}
