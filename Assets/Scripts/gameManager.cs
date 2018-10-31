using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {

	[SerializeField] GameObject[] enemies;
	[SerializeField] GameObject[] lives;
	[SerializeField] Vector3 spawnValues;
	[SerializeField] int enemyCount;
	[SerializeField] float startWait;
	[SerializeField] float spawnWait;
	[SerializeField] float waveWait;
	[SerializeField] Text scoreText;
	private int score;
	private int lifeCounter;
	List<GameObject> active;
	Coroutine spawns;
	void Start()
	{	
		lifeCounter = 2;
		active = new List<GameObject>();
		spawns = StartCoroutine(SpawnWaves());
		score = 0;
		scoreText.text = score.ToString();
	}

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds(startWait);

		while(true) {
			for (int i = 0; i < enemyCount; i++) {
				GameObject enemy = enemies[Random.Range(0, enemies.Length)];

				Vector3 pos = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion rot = Quaternion.identity;

				active.Add(Instantiate(enemy, pos, rot));

				yield return new WaitForSeconds(spawnWait);
			}

			yield return new WaitForSeconds(waveWait);
		}
	}

	public void addScore(int points){
		score += points;
		scoreText.text = score.ToString();
	}

	public void loseLife(){
		if(lifeCounter == 0){
			gameReset();
		}else{
			lives[lifeCounter].SetActive(false);
			lifeCounter -= 1;
		}
	}
	public void gameReset(){
		foreach(GameObject g in active){
			Destroy(g);
		}
		StopCoroutine(spawns);
		spawns = StartCoroutine(SpawnWaves());
		score = 0;
		lifeCounter = 2;
		lives[0].SetActive(true);
		lives[1].SetActive(true);
		lives[2].SetActive(true);
		
	}

}
