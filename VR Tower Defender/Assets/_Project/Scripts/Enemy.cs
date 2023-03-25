using System.Collections;
using UnityEngine;

namespace Game
{
	public class Enemy : MonoBehaviour, IDamageable
	{
		[Header("Fields")]
		[SerializeField] float velocidad = 2.0f;
		[SerializeField] float distanciaCambio = 0.5f;
		[SerializeField] private float health;
		[SerializeField] private float hitTime;

		[Header("References")]
		[SerializeField] private MeshRenderer enemyMeshRenderer;
		[SerializeField] private Material defaultMaterial;
		[SerializeField] private Material hitMaterial;
		
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
				// TODO: bajar vida del castillo
				Destroy(gameObject);
			}
		}
	}
}