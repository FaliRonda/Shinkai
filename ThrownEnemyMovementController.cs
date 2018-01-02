using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownEnemyMovementController : MonoBehaviour {
	public float speed = 10f;

	private float initialSpeed;
	private Vector2 direction;

	void Start(){
		this.direction = transform.position - GameObject.FindGameObjectWithTag ("Core").transform.position;
		this.direction.Normalize ();
		initialSpeed = speed;
	}
	
	void Update () {
		transform.Translate (direction * speed * Time.deltaTime);
	}

	public void setDirection(Vector2 direction){
		this.direction = direction;
		this.direction.Normalize ();
	}

	public void setSpeed(float speed){
		this.speed = speed;
	}
}
