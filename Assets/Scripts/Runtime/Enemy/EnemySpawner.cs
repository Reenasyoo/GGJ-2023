using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Systems.GameEvents;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private GameObject[] enemyPrefabs;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private int spawnAmount;
        [SerializeField] private int maxSpawnSeconds;
        [SerializeField] private GameEvent startDayEvent;

        private List<SpawnedEnemy> spawnedEnemies = new List<SpawnedEnemy>();
        
        private IEnumerator SpawnEnemies()
        {
            for (var i = 0; i < spawnAmount; i++)
            {
                var enemyIndex = i;
                var randomEnemyId = Random.Range(0, enemyPrefabs.Length);
                var randomSpawnPoint = Random.Range(0, spawnPoints.Length);

                var enemy = Instantiate(enemyPrefabs[randomEnemyId], spawnPoints[randomSpawnPoint]);
                var enemyComp = enemy.GetComponent<EnemyFacade>();
                enemyComp._callback = () => RemoveEnemy(enemyIndex);
                enemyComp.Target = target;
                var tmp = new SpawnedEnemy
                {
                    id = enemyIndex,
                    obj = enemy
                };
                spawnedEnemies.Add(tmp);
                yield return new WaitForSeconds(maxSpawnSeconds);
            }
        }

        public void StartSpawning()
        {
            StartCoroutine(SpawnEnemies());
        }

        private void RemoveEnemy(int id)
        {
            foreach (var enemy in spawnedEnemies.Where(enemy => enemy.id == id))
            {
                Destroy(enemy.obj);
                spawnedEnemies.Remove(enemy);
                break;
            }
        }
    }

    public class SpawnedEnemy
    {
        public int id;
        public GameObject obj;
    }
}