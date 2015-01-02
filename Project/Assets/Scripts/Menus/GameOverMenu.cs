using UnityEngine;
using System.Collections;

public class GameOverMenu : MonoBehaviour {
	public enum GameOverButton {Restart, MainMenu}
	public GameOverButton button;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("space"))
						Application.LoadLevel ("GrassLevel2");
	
	}
}
