using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButtonController : MonoBehaviour {
	public GameObject spawns;
	public Image title;
	public Text points;
	public SpriteRenderer fishA;
	public SpriteRenderer fishB;
	public SpriteRenderer fishC;
	public SpriteRenderer fishD;
	public MusicController musicController;

	private bool started = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startGame(){
		StartCoroutine (start());
	}

	IEnumerator start(){
		if(!started){
			started = true;
			musicController.fadeOutStartMusic ();
			musicController.fadeInMainMusic ();

			GetComponent<AudioSource> ().Play ();
			if (title != null)
				StartCoroutine (FadeToZeroAlpha (title));
			
			if (points != null)
				StartCoroutine (FadeToZeroAlpha (points));
			
			StartCoroutine(FadeToZeroAlpha (GetComponent<Image>()));
			StartCoroutine(FadeToFullAlpha (fishA));
			StartCoroutine(FadeToFullAlpha (fishB));
			StartCoroutine(FadeToFullAlpha (fishC));
			StartCoroutine(FadeToFullAlpha (fishD));
			yield return new WaitForSeconds (3f);
			spawns.SetActive (true);
			if (title != null)
				title.gameObject.SetActive (false);
			if (points != null)
				points.gameObject.SetActive (false);
			gameObject.SetActive (false);
			//SceneManager.LoadScene ("Assets/_Scenes/Main.unity");
		}
	}



	public IEnumerator FadeToFullAlpha(Image image){
		image.color = new Color (image.color.r, image.color.g, image.color.b, 0);
		while (image.color.a < 1f) {
			image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + Time.deltaTime/2);
			yield return null;
		}
	}

	public IEnumerator FadeToZeroAlpha(Image image){
		image.color = new Color (image.color.r, image.color.g, image.color.b, 1f);
		while (image.color.a > 0f) {
			image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - Time.deltaTime/2);
			yield return null;
		}
	}




	public IEnumerator FadeToFullAlpha(SpriteRenderer image){
		image.color = new Color (image.color.r, image.color.g, image.color.b, 0);
		while (image.color.a < 1f) {
			image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + Time.deltaTime/2);
			yield return null;
		}
	}

	public IEnumerator FadeToZeroAlpha(SpriteRenderer image){
		image.color = new Color (image.color.r, image.color.g, image.color.b, 1f);
		while (image.color.a > 0f) {
			image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - Time.deltaTime/2);
			yield return null;
		}
	}



	public IEnumerator FadeToFullAlpha(Text text){
		text.color = new Color (text.color.r, text.color.g, text.color.b, 0);
		while (text.color.a < 1f) {
			text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + Time.deltaTime/2);
			yield return null;
		}
	}

	public IEnumerator FadeToZeroAlpha(Text text){
		text.color = new Color (text.color.r, text.color.g, text.color.b, 1f);
		while (text.color.a > 0f) {
			text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - Time.deltaTime/2);
			yield return null;
		}
	}
}
