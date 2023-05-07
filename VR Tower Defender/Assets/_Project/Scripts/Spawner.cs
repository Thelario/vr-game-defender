using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Game
{
	public class Spawner : Managers.Singleton<Spawner>
    {
		[SerializeField] private GameObject[] enemyPrefabs;
		[SerializeField] private float spawnInterval = 3.5f;
        [SerializeField] private int numEnemies;
        [SerializeField] private int maxEnemies = 20;
        [SerializeField] private Transform father;
        [SerializeField] private Button startRoundButton;

        private Vector3 startRoundElementPosition;
        private int round;

        private int enemysAlive;
        private bool readyToSpawn;

        private void Start()
        {
            round = 1;
            readyToSpawn = true;
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
                    Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], transform.position, Quaternion.identity, father);
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


            startRoundButton.gameObject.SetActive(true);

            while (startRoundButton.isActiveAndEnabled)
            {
                yield return new WaitForSeconds(1);
            }


            readyToSpawn = true;
            round++;
        }
    }
}