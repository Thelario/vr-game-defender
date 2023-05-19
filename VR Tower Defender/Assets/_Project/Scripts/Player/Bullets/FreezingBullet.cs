using UnityEngine;

namespace Game
{
	public class FreezingBullet : MonoBehaviour, IConfigurable
	{
		[SerializeField] private GameObject freezingEffect;
		[SerializeField] private float moveSpeed;

		private float _freezingTime;

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
			_freezingTime = damage;
		}

		protected void OnTriggerEnter(Collider other)
		{
			if (!other.CompareTag("Enemy") && !other.CompareTag("Obstacle"))
				return;
			
			GameObject effect = Instantiate(freezingEffect, transform.position, Quaternion.identity);
			effect.GetComponent<FreezingEffect>().ConfiguraFreezeTime(_freezingTime);
			Destroy(effect, 2f);
			Destroy(gameObject);
		}
	}
}