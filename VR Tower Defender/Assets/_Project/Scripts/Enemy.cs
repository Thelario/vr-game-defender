using System.Collections;
using UnityEngine;

namespace Game
{
	public class Enemy : MonoBehaviour, IDamageable, IFreezable
	{
		[Header("Fields")]
		[SerializeField] private float velocidad = 2.0f;
		[SerializeField] private float distanciaCambio = 0.5f;
		[SerializeField] private float health;
		[SerializeField] private float hitTime;
		[SerializeField] private float damage;
		[SerializeField] private int manaRefill;
		[SerializeField] private int minMoneyOnDeath;
		[SerializeField] private int maxMoneyOnDeath;

		[Header("References")]
		[SerializeField] private MeshRenderer enemyMeshRenderer;
		[SerializeField] private Material defaultMaterial;
		[SerializeField] private Material hitMaterial;
		[SerializeField] private Material freezeMaterial;

		private Transform[] waypoints;
		private Vector3 siguientePosicion;
		private int numeroSiguientePosicion;
		private float _currentSpeed;
		
		private void Start()
		{
			waypoints = PathManager.Instance.GetRandomPath();
			siguientePosicion = waypoints[0].position;
			_currentSpeed = velocidad;
		}

		private void Update()
		{
			Vector3 relPos = siguientePosicion - transform.position;
			transform.rotation = Quaternion.LookRotation(relPos, Vector3.up);
			
			transform.position = Vector3.MoveTowards(
				transform.position,
				siguientePosicion,
				_currentSpeed * Time.deltaTime);

			if (Vector3.Distance(transform.position, siguientePosicion) < distanciaCambio)
			{
				numeroSiguientePosicion++;
			}
			
			if (numeroSiguientePosicion < waypoints.Length)
			{
				siguientePosicion = waypoints[numeroSiguientePosicion].position;
			}
		}
		
		public void TakeDamage(float damage)
		{
			health -= damage;

			StartCoroutine(nameof(Hit));

			if (health > 0f)
				return;
			
			PlayerSpells.Instance.RefillMana(manaRefill);
			SfxManager.Instance.PlayClip(SfxType.EnemyDeath);
			Shop.Instance.AddMoney(Random.Range(minMoneyOnDeath, maxMoneyOnDeath));
			Destroy(gameObject);
		}

		private IEnumerator Hit()
		{
			enemyMeshRenderer.material = hitMaterial;
			SfxManager.Instance.PlayClip(SfxType.EnemyHit);

			yield return new WaitForSeconds(hitTime);
			
			enemyMeshRenderer.material = defaultMaterial;
		}
		
		private void OnTriggerEnter(Collider other)
		{
			if (!other.gameObject.CompareTag("Door"))
				return;
			
			other.GetComponent<Castle>().LoseHealth(damage);
			Destroy(gameObject);
		}

		public void Freeze(float freezeTime)
		{
			StartCoroutine(Co_Freeze(freezeTime));
		}

		private IEnumerator Co_Freeze(float freezeTime)
		{
			_currentSpeed = 0;
			enemyMeshRenderer.material = freezeMaterial;
			print(freezeTime);
			yield return new WaitForSeconds(freezeTime);

			_currentSpeed = velocidad;
			enemyMeshRenderer.material = defaultMaterial;
		}
	}
}