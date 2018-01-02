using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreHitController : MonoBehaviour {
	public GameObject[] rocks;
	public Image button;
	public Text text;
	public GameObject spawns;
	public MusicController musicController;

	private bool ended = false;
	private int index = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag.Equals("BigEnemy")){
			Destroy (other.gameObject);
			StartCoroutine (removeRock ());
		}
	}

	IEnumerator removeRock(){
		GetComponent<AudioSource> ().Play ();
		if (index < 3) {
			GameObject rock = rocks [index];
			rock.SetActive (false);
			yield return new WaitForSeconds (0.2f);
			rock.SetActive (true);
			yield return new WaitForSeconds (0.2f);
			rock.SetActive (false);
			yield return new WaitForSeconds (0.2f);
			rock.SetActive (true);
			yield return new WaitForSeconds (0.2f);
			rock.SetActive (false);
			yield return new WaitForSeconds (0.2f);
			rock.SetActive (true);
			yield return new WaitForSeconds (0.2f);
			rock.SetActive (false);

			index++;
		} else {
			if (!ended) {
				ended = true;
				spawns.SetActive (false);
				musicController.fadeOutMainMusic ();
				GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
				GameObject[] bigEnemies = GameObject.FindGameObjectsWithTag ("BigEnemy");
				StartCoroutine (FadeToZeroAlpha (GameObject.FindGameObjectWithTag("Player")));
				foreach(GameObject enemy in enemies){
					StartCoroutine (FadeToZeroAlpha (enemy));
				}

				foreach(GameObject bigEnemy in bigEnemies){
					StartCoroutine (FadeToZeroAlpha (bigEnemy));
				}
				text.gameObject.SetActive (true);
				button.gameObject.SetActive (true);
				StartCoroutine (FadeToFullAlpha (text));
				StartCoroutine (FadeToFullAlpha (button));
			}
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




	public IEnumerator FadeToFullAlpha(Text image){
		image.color = new Color (image.color.r, image.color.g, image.color.b, 0);
		while (image.color.a < 1f) {
			image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + Time.deltaTime/2);
			yield return null;
		}
	}

	public IEnumerator FadeToZeroAlpha(Text image){
		image.color = new Color (image.color.r, image.color.g, image.color.b, 1f);
		while (image.color.a > 0f) {
			image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - Time.deltaTime/2);
			yield return null;
		}
	}

	public IEnumerator FadeToZeroAlpha(GameObject go){
		foreach (SpriteRenderer sprite in go.transform.GetComponentsInChildren<SpriteRenderer>()) {
			sprite.color = new Color (sprite.color.r, sprite.color.g, sprite.color.b, 1f);
			while (sprite.color.a > 0f) {
				sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a - Time.deltaTime/2);
				yield return null;
			}
		}
	}
}
