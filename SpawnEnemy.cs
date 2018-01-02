using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {
	public GameObject enemy;
	public float minTime = 10f;
	public float maxTime = 15f;

	private Vector2 direction;

	// Use this for initialization
	void Start () {
		StartCoroutine (spawnEnemies());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator spawnEnemies(){
		while (true) {
			enemy.transform.position = transform.position;
			float randonNumber = Random.Range (minTime, maxTime);
			yield return new WaitForSeconds (randonNumber);
			Instantiate (enemy);
		}
	}
}