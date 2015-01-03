using UnityEngine;
using System.Collections;




public class MainMenuScript : MonoBehaviour {

	[HideInInspector]
	public enum Button{Quit, Sound, Play, About}

	public Button button;
	private AudioSource menuMusic;

	void Start() {




		if (button == Button.Sound) {
			menuMusic = GameObject.Find ("MainMenuMusic").GetComponent<AudioSource> ();
			if (!PlayerPrefs.HasKey ("Music")) {
				PlayerPrefs.SetString ("Music", "On");
				menuMusic.mute = false;
			} else if (PlayerPrefs.GetString ("Music") == "Off") {
				menuMusic.mute = true;
				transform.parent.FindChild ("Main-sound-disabled").gameObject.SetActive(true);

			}
		}
	}

	void OnMouseDown() {
		if (button == Button.Quit)
			Application.Quit ();
		else if (button == Button.Play)
			Application.LoadLevel ("GrassLevel2");
		else if (button == Button.About)
			Application.LoadLevel ("About");
		else if (PlayerPrefs.GetString("Music") == "On") {
			PlayerPrefs.SetString ("Music", "Off");
			transform.parent.FindChild ("Main-sound-disabled").gameObject.SetActive(true);
			menuMusic.mute = true;
		} else {
			PlayerPrefs.SetString ("Music", "On");
			transform.parent.FindChild ("Main-sound-disabled").gameObject.SetActive(false);
			menuMusic.mute = false;;
		}
	}

}
