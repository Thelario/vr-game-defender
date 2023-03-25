using UnityEngine;
using System.Collections;

namespace Game
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private GameObject enemyPrefab;
		[SerializeField] private float spawnInterval = 3.5f;
        [SerializeField] private int numEnemies = 10;
        [SerializeField] private int maxEnemies = 5;
        [SerializeField] private Transform father;

        private int enemysAlive;
        private bool readyToSpawn;
        
        private void Start()
        {
            readyToSpawn = true;
        }
        
        private void Update()
        {
            if (!readyToSpawn)
                return;
            
            readyToSpawn = false;
            StartCoroutine(spawnEnemys());
        }

        private IEnumerator spawnEnemys()
        {
            for (int i = numEnemies; i != 0; i--)
            {
                if (father.childCount < maxEnemies)
                {
                    Instantiate(enemyPrefab, transform.position, Quaternion.identity, father);
                    yield return new WaitForSeconds(0.5f);
                }
                else
                {
                    yield return new WaitForSeconds(spawnInterval);
                    i++;
                }
            }
            
            while (father.childCount > 0)
            {
                yield return new WaitForSeconds(1);
            }
            
            readyToSpawn = true;
        }
    }
}