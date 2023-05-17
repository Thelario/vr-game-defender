using System.Collections;
using UnityEngine;

namespace Game
{
	public class Enemy : MonoBehaviour, IDamageable, IFreezable
	{
		[Header("Fields")]
		[SerializeField] float velocidad = 2.0f;
		[SerializeField] float distanciaCambio = 0.5f;
		[SerializeField] private float health;
		[SerializeField] private float hitTime;
		[SerializeField] private float damage;

		[Header("References")]
		[SerializeField] private MeshRenderer enemyMeshRenderer;
		[SerializeField] private Material defaultMaterial;
		[SerializeField] private Material hitMaterial;
		[SerializeField] private Material freezeMaterial;
		[SerializeField] private Transform skullTransform;

		private Transform[] waypoints;
		private Vector3 siguientePosicion;
		private int numeroSiguientePosicion;
		
		private void Start()
		{
			waypoints = PathManager.Instance.GetRandomPath();
			siguientePosicion = waypoints[0].position;
		}

		private void Update()
		{
			Vector3 relPos = siguientePosicion - transform.position;
			transform.rotation = Quaternion.LookRotation(relPos, Vector3.up);
			
			transform.position = Vector3.MoveTowards(
				transform.position,
				siguientePosicion,
				velocidad * Time.deltaTime);

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
			
			if (health <= 0f)
				Destroy(gameObject);
		}

		private IEnumerator Hit()
		{
			enemyMeshRenderer.material = hitMaterial;

			yield return new WaitForSeconds(hitTime);
			
			enemyMeshRenderer.material = defaultMaterial;
		}
		
		private void OnTriggerEnter(Collider other) 
		{
			if (other.gameObject.CompareTag ("Door"))
			{
				Destroy(gameObject);
			}
		}

		public IEnumerator Co_Freeze(float freezeTime)
		{
			float velocidadAnterior = velocidad;
			velocidad = 0;
			enemyMeshRenderer.material = freezeMaterial;
			
			yield return new WaitForSeconds(freezeTime);

			velocidad = velocidadAnterior;
			enemyMeshRenderer.material = defaultMaterial;
		}
	}
}