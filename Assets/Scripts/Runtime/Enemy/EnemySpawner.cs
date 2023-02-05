using System;
using System.Collections;
using System.Collections.Generic;
using Systems.GameEvents;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] enemyPrefabs;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private int spawnAmount;
        [SerializeField] private int maxSpawnSeconds;
        [SerializeField] private GameEvent startDayEvent;

        private List<GameObject> spawnedEnemies = new List<GameObject>();
        
        private IEnumerator SpawnEnemies()
        {
            for (var i = 0; i < spawnAmount; i++)
            {
                var enemyIndex = i;
                var randomEnemyId = Random.Range(0, enemyPrefabs.Length);
                var randomSpawnPoint = Random.Range(0, spawnPoints.Length);

                var enemy = Instantiate(enemyPrefabs[randomEnemyId], spawnPoints[randomSpawnPoint]);
                enemy.GetComponent<EnemyFacade>()._callback = () => RemoveEnemy(enemyIndex);
                spawnedEnemies.Add(enemy);
                yield return new WaitForSeconds(maxSpawnSeconds);
            }
        }

        public void StartSpawning()
        {
            StartCoroutine(SpawnEnemies());
        }

        private void RemoveEnemy(int id)
        {
            spawnedEnemies.RemoveAt(id);
        }
    }
}