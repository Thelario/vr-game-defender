using UnityEngine;
using System.Collections;
using Game.Managers;

namespace Game
{
	public class Spawner : Singleton<Spawner>
	{
		[SerializeField] private GameObject enemyPrefab;
		[SerializeField] private float spawnInterval = 3.5f;
        [SerializeField] private int numEnemies = 10;
        [SerializeField] private int maxEnemies = 5;
        [SerializeField] private Transform father;

        private int enemysAlive;
        private bool readyToSpawn;

        private void Update()
        {
            if (!readyToSpawn)
                return;
            
            readyToSpawn = false;
            StartCoroutine(spawnEnemys());
        }

        public void StartSpawning()
        {
            readyToSpawn = true;
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