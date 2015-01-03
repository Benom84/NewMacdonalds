using UnityEngine;
using System.Collections;

public class GameMusic : MonoBehaviour {

	public float volume = 0.2f;

	private string prevState;
	private AudioSource audioSource;

	void Start(){

		GameObject mainMenuMusic = GameObject.Find ("MainMenuMusic");
		if (mainMenuMusic)
						Destroy (mainMenuMusic);
	
	}

	void Awake() {

		audioSource = GetComponent<AudioSource> ();
		audioSource.ignoreListenerVolume = true;
		audioSource.volume = volume;
		prevState = PlayerPrefs.GetString ("Music");
		if (string.Equals (prevState, "Off")) {
			audioSource.Pause ();

		} else {
		PlayerPrefs.SetString("Music", "On");
		audioSource.Play ();
		}
	}


	void Update() {
		string currentState = PlayerPrefs.GetString ("Music");
		if (!string.Equals(prevState,currentState)) {
			prevState = currentState;
			if (string.Equals(currentState,"Off")) {
				audioSource.Pause ();

			}
			else {
				audioSource.Play ();
			}
		}
	}
}
