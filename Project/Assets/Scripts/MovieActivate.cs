using UnityEngine;
using System.Collections;

public class MovieActivate : MonoBehaviour {

	public MovieTexture movTexture;
	void Start() {
		renderer.material.mainTexture = movTexture;
		movTexture.Play();
	}
	void Update() {

		if (Input.GetKeyDown (KeyCode.Space)) 
						Application.LoadLevel ("Level1");

		if (movTexture.isPlaying == false)
						Application.LoadLevel ("Level1");
	}

}
