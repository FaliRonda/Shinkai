using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		attractEnemyToTarget (other, transform.parent.position, 1f);
	}

	void OnTriggerStay2D(Collider2D other){
		attractEnemyToTarget (other, transform.parent.position, 1f);
	}

	void OnTriggerExit2D(Collider2D other){
		attractEnemyToTarget (other, other.transform.position.x > 0 ? other.transform.right : -other.transform.right, 2f);
	}

	private void attractEnemyToTarget(Collider2D other, Vector3 target, float speed){
		if(other.tag.Equals("Enemy")){
			other.GetComponent<EnemyMovementController> ().setDirection (target - other.transform.position);
			other.GetComponent<EnemyMovementController> ().setSpeed (speed);
		}
	}
}
