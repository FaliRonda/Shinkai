using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void fadeInStartMusic(){
		StartCoroutine (volumeUp (GetComponents<AudioSource>()[2]));
	}

	public void fadeOutStartMusic(){
		StartCoroutine (volumeDown (GetComponents<AudioSource>()[2]));
	}

	public void fadeInMainMusic(){
		StartCoroutine (volumeUp (GetComponents<AudioSource>()[0]));
	}

	public void fadeOutMainMusic(){
		StartCoroutine (volumeDown (GetComponents<AudioSource>()[0]));
	}

	IEnumerator volumeUp(AudioSource audio){
		audio.volume = 0;
		while (audio.volume < 1f) {
			audio.volume += Time.deltaTime/2.5f;
			yield return null;
		}
	}

	IEnumerator volumeDown(AudioSource audio){
		audio.volume = 1f;
		while (audio.volume > 0) {
			audio.volume -= Time.deltaTime/2.5f;
			yield return null;
		}
	}
}
