using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public float gameTime = 90f;
	public GameObject victoryScreen;
	[HideInInspector]
	public bool gameEnded = false;
	
	private float startTime;
	private float endTime;
	private bool endLevelRan = false;

	// Use this for initialization
	void Awake () {

		startTime = Time.time;
		endTime = startTime + gameTime;
		guiText.text = "" + (endTime - startTime);

	
	}
	
	// Update is called once per frame
	void Update () {

		if (!gameEnded) {
			if ((endTime - Time.time) >= 0)
				guiText.text = "" + (int)(endTime - Time.time);
			else if (!endLevelRan) {
				guiText.text = "0";
				EndLevel ();
			}
		}
	}

	void EndLevel() {

		endLevelRan = true;


		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject enemy in enemies) 
			enemy.SetActive(false);	

		GameObject[] spawners = GameObject.FindGameObjectsWithTag ("Spawner");
		foreach (GameObject spawner in spawners)
						spawner.GetComponent<Spawner> ().StopSpawner ();

		GameObject player = GameObject.Find ("Player");
		player.rigidbody2D.gravityScale = 0;
		player.rigidbody2D.velocity = new Vector2 (0, 0);
		player.GetComponent<PlayerControl> ().enabled = false;
		player.GetComponent<Animator> ().SetFloat ("Speed", 0);
		GameObject.Find ("Gun").SetActive (false);
		Instantiate (victoryScreen, victoryScreen.transform.position, transform.rotation);
	}
}
