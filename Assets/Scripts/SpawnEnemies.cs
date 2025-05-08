using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies = new GameObject[2];
    [SerializeField] private Transform[] spawnPoint = new Transform[3];

    private float timeInterval = 2f;
    

    private int maxEnemies = 10;
    private int enemieSpawned = 0;

    public int enemieCount;
    private void Awake()
    {
        enemieCount = maxEnemies;
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while(enemieSpawned < maxEnemies)
        {
            int randomEnemies = Random.Range(0, enemies.Length);
            int random = Random.Range(0, spawnPoint.Length);
            Instantiate(enemies[randomEnemies], spawnPoint[random].position, spawnPoint[random].rotation);

            enemieSpawned++;

            yield return new WaitForSeconds(timeInterval);
        }
    }
}
