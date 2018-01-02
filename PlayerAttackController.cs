using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour {
	private bool enemyInside = false;
	private int childIndex = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {
		if (enemyInside && Input.GetKeyDown ("space")) {
			enemyInside = false;
			GameObject thrownEnemy = (GameObject)Instantiate (Resources.Load ("Prefabs/ThrownEnemy"));
			thrownEnemy.transform.position = transform.position;
			//thrownEnemy.GetComponent<EnemyMovementController> ().setDirection (transform.up);
			GetComponentInChildren<Animator> ().SetTrigger ("bite");
			GetComponents<AudioSource> ()[1].Play();
			StartCoroutine (waitAndChange ());
		} else if (Input.GetKeyDown ("space")) {
			GetComponentInChildren<Animator> ().SetTrigger ("bite");
		}
	}

	public void setEnemyInside(){
		enemyInside = true;
	}

	void OnTriggerEnter2D(Collider2D other){
		catchFish (other);
	}

	void OnTriggerStay2D(Collider2D other){
		catchFish (other);
	}

	private void catchFish(Collider2D other){
		if(other.tag.Equals("Enemy") && Input.GetKeyDown("space") && !enemyInside){
			GetComponents<AudioSource> ()[0].Play();
			StartCoroutine (eatFish (other));
		}
	}

	IEnumerator eatFish (Collider2D other){
		StartCoroutine (setEnemyOnPlayer ());
		other.gameObject.SetActive (false);
		StartCoroutine (waitAndChange ());
		yield return null;
	}

	IEnumerator setEnemyOnPlayer(){
		yield return new WaitForSeconds (0.2f);
		GetComponentInParent<PlayerAttackController> ().setEnemyInside ();
	}

	IEnumerator waitAndChange(){
		yield return new WaitForSeconds (0.4f);
		transform.GetChild (childIndex).gameObject.SetActive (false);
		if (childIndex == 2) {
			childIndex++;
		} else {
			childIndex--;
		}
		transform.GetChild (childIndex).gameObject.SetActive (true);
	}
}
