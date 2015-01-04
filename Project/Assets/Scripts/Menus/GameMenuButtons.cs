using UnityEngine;
using System.Collections;

public class GameMenuButtons : MonoBehaviour {

	public enum GameMenuButton {Resume, MainMenu, Music, Effects}
	public GameMenuButton button;

	private Pauser pauser;
	// Use this for initialization
	void Start () {

		GameObject menu = GameObject.Find ("MenuButton"); 
		pauser = menu.GetComponent<Pauser>();

		if (button == GameMenuButton.Effects)
			if (!PlayerPrefs.HasKey ("Effects"))
				PlayerPrefs.SetString ("Effects", "On");

		if (button == GameMenuButton.Music)
			if (!PlayerPrefs.HasKey ("Music"))
				PlayerPrefs.SetString ("Music", "On");


	
	}

	void Awake() {

		if ((button == GameMenuButton.Music) && (PlayerPrefs.GetString ("Music") == "Off")) {
			GameObject musicDisableButton = transform.parent.FindChild ("MusicDisabled").gameObject;
			//Debug.Log("Awake - Music is off then should be disabled");
			musicDisableButton.SetActive (true);
		}
		if ((button == GameMenuButton.Effects) && (PlayerPrefs.GetString ("Effects") == "Off")) {
			GameObject effectsDisableButton = transform.parent.FindChild ("EffectsDisabled").gameObject;
			//Debug.Log("Awake - Effects is off then should be disabled");
			effectsDisableButton.SetActive (true);
		}
	
	
	}
	
	// Update is called once per frame
	void OnMouseDown() {
		if (button == GameMenuButton.Resume)
						pauser.paused = false;
		if (button == GameMenuButton.MainMenu)
						Application.LoadLevel ("MainMenu");
		if (button == GameMenuButton.Music)
						MusicChanger ();
		if (button == GameMenuButton.Effects)
						EffectsChanger ();
		
	}

	void MusicChanger() {
		GameObject musicDisableButton = transform.parent.FindChild ("MusicDisabled").gameObject;
		//Debug.Log ("Music Changer: " + musicDisableButton.activeSelf);
		musicDisableButton.SetActive (!musicDisableButton.activeSelf);
		if (PlayerPrefs.GetString("Music") == "On") {
			PlayerPrefs.SetString ("Music", "Off");
		} else {
			PlayerPrefs.SetString ("Music", "On");
		}
	}

	void EffectsChanger() {

		GameObject effectsDisableButton = transform.parent.FindChild ("EffectsDisabled").gameObject;
		//Debug.Log ("Effects Changer: " + effectsDisableButton.activeSelf);
		effectsDisableButton.SetActive (!effectsDisableButton.activeSelf);
		if (PlayerPrefs.GetString("Effects") == "On") {
			AudioListener.volume = 0;
			PlayerPrefs.SetString ("Effects", "Off");
		} else {
			PlayerPrefs.SetString ("Effects", "On");
			AudioListener.volume = 1;
		}

	}
}
