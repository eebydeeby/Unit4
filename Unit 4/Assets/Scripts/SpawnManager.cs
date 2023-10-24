using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public GameObject enemyPrefab;
	public GameObject powerupPrefab;
	private float spawnRange = 9; // How far out the enemies can spawn
	public int enemyCount; // Number of enemies at any given point
	public int waveNumber = 1; // Number of enemies to spawn - corresponds to wave number
	
    void Start() {
		SpawnEnemyWave(waveNumber);
		Instantiate(powerupPrefab, GenerateSpawnPosition(),
			powerupPrefab.transform.rotation);
	}
	
	/* Checks too see if all enemies are destroyed and calls relevant functions if so,
	and spawns items */
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
		if (enemyCount == 0) {
			waveNumber++; SpawnEnemyWave(waveNumber);
			Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
		}
    }
	
	// Returns a random spot within a given range defined by spawnRange	
	private Vector3 GenerateSpawnPosition() {
    	float spawnPosX = Random.Range(-spawnRange, spawnRange);
		float spawnPosZ = Random.Range(-spawnRange, spawnRange);
		Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
		return randomPos;
	}
	
	// Spawns enemies
	void SpawnEnemyWave(int enemiesToSpawn) {
		for (int i = 0; i < enemiesToSpawn; i++) {
			Instantiate(enemyPrefab, GenerateSpawnPosition(),
				enemyPrefab.transform.rotation);
		}
	}
}
