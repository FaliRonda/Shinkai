using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyMovementController : MonoBehaviour {
	public float speed = 10f;

	private float initialSpeed;
	private Vector2 direction;

	void Awake () {
		this.direction = GameObject.FindGameObjectWithTag ("Core").transform.position - transform.position;
		this.direction.Normalize ();
	}

	void Start(){
		initialSpeed = speed;

		if (transform.position.x >= 0) {
			flip ();
		}
	}
	
	void Update () {
		transform.Translate (direction * speed * Time.deltaTime);
	}

	public void setDirection(Vector2 direction){
		this.direction = direction;
		this.direction.Normalize ();
	}

	private void flip(){
		Transform child = transform.GetChild (0);
		child.Rotate (new Vector3 (0, 0, 180f));
	}

	public void setSpeed(float speed){
		this.speed = speed;
	}
}
