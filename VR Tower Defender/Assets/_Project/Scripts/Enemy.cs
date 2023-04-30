using System.Collections;
using UnityEngine;
using UnityEngine.Video;

namespace Game
{
	public class Enemy : MonoBehaviour, IDamageable
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
		[SerializeField] private Transform skullTransform;
		[SerializeField] private HPPuerta barraDeVida;

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
			//Vector3 nextPosModified = new Vector3(siguientePosicion.x, transform.position.y, siguientePosicion.z);
			//transform.up = (nextPosModified - transform.position).normalized;
			
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
			    Castle.Instance.LoseHealth(damage);
				Destroy(gameObject);
			}
		}
	}
}