using UnityEngine;
using System.Collections;
using Game.Managers;
using Unity.VisualScripting;

namespace Game
{
	public class Spawner : Managers.Singleton<Spawner>
    {
		[SerializeField] private GameObject enemyPrefab;
		[SerializeField] private float spawnInterval = 3.5f;
        [SerializeField] private int numEnemies;
        [SerializeField] private int maxEnemies = 20;
        [SerializeField] private Transform father;
        [SerializeField] private GameObject endRoundElementPrefab;

        private GameObject endRoundElement;
        private Vector3 endRoundElementPosition;
        private int round;

        private int enemysAlive;
        private bool readyToSpawn;

        private void Start()
        {
            round = 1;
            StartSpawning();
        }

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
            numEnemies = Mathf.RoundToInt(5f * Mathf.Pow(1.35f, round));
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
            endRoundElementPosition = Camera.main.transform.position;
            endRoundElementPosition.z = endRoundElementPosition.z + 0.5f;
         
            endRoundElement = Instantiate(endRoundElementPrefab, endRoundElementPosition, Quaternion.identity);

            while (endRoundElement != null)
            {
                yield return new WaitForSeconds(spawnInterval);
            }

            readyToSpawn = true;
            round++;
        }
    }
}