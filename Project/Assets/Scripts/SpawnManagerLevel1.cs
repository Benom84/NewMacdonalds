using UnityEngine;
using System.Collections;

public class SpawnManagerLevel1 : MonoBehaviour {

	public GameObject victoryScreen;
	public static int chickenCounter;
	[HideInInspector]
	public static int deathCounter;
	[HideInInspector]

	private Spawner firstSpawner;
	private Spawner secondSpawner;
	private Spawner thirdSpawner;
	private Spawner fourthSpawner;

	private float endOfFirstWave;
	private float endOfSecondWave;

	private bool firstWaveStarted;
	private bool secondWaveStarted;
	private bool thirdWaveStarted;

	private bool finished = false;


	// Use this for initialization
	void Start () {
		firstWaveStarted = true;
		secondWaveStarted = false;
		thirdWaveStarted = false;

		chickenCounter = 0;
		deathCounter = 0;
	
		firstSpawner = GameObject.Find("spawner-1").GetComponent<Spawner> ();
		secondSpawner = GameObject.Find("spawner-2").GetComponent<Spawner> ();
		thirdSpawner = GameObject.Find("spawner-3").GetComponent<Spawner> ();
		fourthSpawner = GameObject.Find("spawner-4").GetComponent<Spawner> ();


		firstSpawner.spawnTime = 5.0f;
		secondSpawner.spawnTime = 10.0f;
		thirdSpawner.spawnTime = 0f;
		fourthSpawner.spawnTime = 0f;


	}
	
	// Update is called once per frame
	void Update () {
		ChickenCounter ();
		if (firstWaveStarted) 
			FirstWave ();
		else if ((Time.time >= (endOfFirstWave + 10.0f)) && secondWaveStarted) 
			SecondWave();
		else if ((Time.time >= (endOfSecondWave + 10.0f)) && thirdWaveStarted) 
			ThirdWave();

		if ((deathCounter == 30) && !finished) {
			finished = true;
			GameObject player = GameObject.Find ("Player");
			player.rigidbody2D.gravityScale = 0;
			player.rigidbody2D.velocity = new Vector2 (0, 0);
			player.GetComponent<PlayerControl> ().enabled = false;
			player.GetComponent<Animator> ().SetFloat ("Speed", 0);
			GameObject.Find ("Gun").SetActive (false);
			GameObject.Instantiate(victoryScreen, victoryScreen.transform.position, victoryScreen.transform.rotation);
		}
	}

	public static void DeathCounter () {
		deathCounter++;
		Debug.Log ("Death counter is: " + deathCounter);
	}

	void ChickenCounter () {
		chickenCounter = firstSpawner.enemyCounter + secondSpawner.enemyCounter;
	}

	void FirstWave () {
		if (chickenCounter > 5) {
			firstSpawner.spawnTime = 0f;
			secondSpawner.spawnTime = 0f;
			thirdSpawner.spawnTime = 0f;
			fourthSpawner.spawnTime = 0f;

			firstWaveStarted = false;
			secondWaveStarted = true;

			endOfFirstWave = Time.time;
			chickenCounter = 0;
		}
	}

	void SecondWave () {
		firstSpawner.spawnTime = 5.0f;
		secondSpawner.spawnTime = 2.5f;
		thirdSpawner.spawnTime = 10f;
		fourthSpawner.spawnTime = 12f;
		thirdSpawner.spawnDelay = 1f;
		fourthSpawner.spawnDelay = 1f;
		
		if (chickenCounter > 10) {

			firstSpawner.spawnTime = 0f;
			secondSpawner.spawnTime = 0f;
			thirdSpawner.spawnTime = 0f;
			fourthSpawner.spawnTime = 0f;
	
			secondWaveStarted = false;
			thirdWaveStarted = true;


			endOfSecondWave = Time.time;
			chickenCounter = 0;

		}
	}
	
	void ThirdWave () {

		firstSpawner.spawnTime = 7.5f;
		secondSpawner.spawnTime = 5f;
		thirdSpawner.spawnTime = 2.5f;
		fourthSpawner.spawnTime = 2.25f;

		if (chickenCounter > 15) {

			firstSpawner.spawnTime = 0f;
			secondSpawner.spawnTime = 0f;
			thirdSpawner.spawnTime = 0f;
			fourthSpawner.spawnTime = 0f;

			thirdWaveStarted = false;
		}	
	}
}
