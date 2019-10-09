using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave {
        public Enemy[] enemies;
        public int count;
        public float timeBetweenSpawns;
    }

    public Wave[] waves;
    public Transform[] spawnPotins;
    public float timeBetweenWaves;


    private Wave currentWave;
    private int currentWaveIndex;
    private Transform player;

    private bool finishSpawning;

    public GameObject boss;
    public Transform bossSawnpPoint;

    public GameObject healthbar;
    public GameObject[] wavecounter;
    public GameObject bosswavecounter;
    // private float countdown = 1f;
    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartNextWave(currentWaveIndex));
        


    }

    IEnumerator StartNextWave(int index) {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpawnWave(index));
    }
    IEnumerator SpawnWave(int index) {
        currentWave = waves[index];
        for (int i = 0; i < currentWave.count; i++) {
            if (player == null) {
                yield break;
            }
            wavecounter[index].SetActive(true);
            Enemy randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            Transform randomSpot = spawnPotins[Random.Range(0, spawnPotins.Length)];
            Instantiate(randomEnemy, randomSpot.position, randomSpot.rotation);
            if (i == currentWave.count - 1)
            {
                finishSpawning = true;
            }
            else {
                finishSpawning = false;
            }



            yield return new WaitForSeconds(currentWave.timeBetweenSpawns);
        }

        
    }


    private void Update()
    {
        if (finishSpawning == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0) {
            scorecounter.scorevalue += 500;

            finishSpawning = false;
            if (currentWaveIndex + 1 < waves.Length)
            {
                currentWaveIndex++;
                StartCoroutine(StartNextWave(currentWaveIndex));
            }
            else {
                bosswavecounter.gameObject.SetActive(true);
                Instantiate(boss, bossSawnpPoint.position, bossSawnpPoint.rotation);
                healthbar.SetActive(true);
            }
        }
    }





}
