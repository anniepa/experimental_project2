using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {

	[SerializeField] GameObject[] enemies;
	[SerializeField] Vector3 spawnValues;
	[SerializeField] int enemyCount;
	[SerializeField] float startWait;
	[SerializeField] float spawnWait;
	[SerializeField] float waveWait;
	void Start()
	{
		StartCoroutine(SpawnWaves());
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);

		while(true) {
			for (int i = 0; i < enemyCount; i++) {
				GameObject enemy = enemies[Random.Range(0, enemies.Length)];

				Vector3 pos = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion rot = Quaternion.identity;

				Instantiate(enemy, pos, rot);

				yield return new WaitForSeconds(spawnWait);
			}

			yield return new WaitForSeconds(waveWait);
		}
	}
}
