using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {
	public GameObject target;
	public float RotateSpeed = 10f;

	private float coeficient = 100f;
	private Vector2 _targetCenter;
	private bool flipped = false;

	private void Start(){
		_targetCenter = target.transform.position;
	}

	private void Update(){
		float input = Input.GetAxis ("Horizontal");
		transform.RotateAround(_targetCenter, Vector3.forward, -1*coeficient*input*RotateSpeed*Time.deltaTime);
		if (transform.position.x < 0 && !flipped) {
			//flip ();
		} else if(transform.position.x >= 0 && flipped){
			//flip ();
		}
	}

	private void flip(){
		transform.Rotate (new Vector2 (0f, 180f));
		flipped = !flipped;
	}
}