using System.Collections;
using UnityEngine;

namespace Runtime.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] enemyPrefabs;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private int spawnAmount;
        [SerializeField] private int maxSpawnSeconds;

        private IEnumerator SpawnEnemies()
        {
            for (var i = 0; i < spawnAmount; i++)
            {
                var randomEnemyId = Random.Range(0, enemyPrefabs.Length);
                var randomSpawnPoint = Random.Range(0, spawnPoints.Length);

                Instantiate(enemyPrefabs[randomEnemyId], spawnPoints[randomSpawnPoint]);
                yield return new WaitForSeconds(maxSpawnSeconds);
            }
        }
    }
}