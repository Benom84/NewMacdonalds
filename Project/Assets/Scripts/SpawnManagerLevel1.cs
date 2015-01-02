using UnityEngine;
using System.Collections;

public class SpawnManagerLevel1 : MonoBehaviour {

	private bool firstMiniLevel;
	private bool waited;

	public static int chickenCounter;
	[HideInInspector]
	public static int deathCounter;
	[HideInInspector]

	private Spawner firstSpawner;
	private Spawner secondSpawner;

	// Use this for initialization
	void Start () {
		firstMiniLevel = true;
		waited = false;

		chickenCounter = 0;
		deathCounter = 0;
	
		firstSpawner = GameObject.Find("spawner-1").GetComponent<Spawner> ();
		secondSpawner = GameObject.Find("spawner-2").GetComponent<Spawner> ();

		firstSpawner.spawnTime = 5.0f;
		secondSpawner.spawnTime = 10.0f;

		//GameObject.Find ("spawner-1").SetActive (true);
		//GameObject.Find ("spawner-2").SetActive (true);

	}
	
	// Update is called once per frame
	void Update () {
		ChickenCounter ();

		if (firstMiniLevel) {
			if (chickenCounter > 4) {
				Debug.Log("into firstminilevel too many chickens");

				firstSpawner.spawnTime = 0f;
				secondSpawner.spawnTime = 0f;
				firstMiniLevel = false;
				StartCoroutine (Wait (5));
			}
		} else if (waited) {
			Debug.Log("into waited");

			if (chickenCounter > 20) {
				firstSpawner.spawnTime = 0f;
				secondSpawner.spawnTime = 0f;
				Debug.Log("done");
			}
		}


		if (deathCounter == 23) {
			Application.LoadLevel ("GrassLevel2");
		}
	}

	public static void DeathCounter () {
		deathCounter++;
		Debug.Log ("deathcounter is" + deathCounter);
	}

	void ChickenCounter () {
		chickenCounter = firstSpawner.enemyCounter + secondSpawner.enemyCounter;
		Debug.Log ("chickencounter is " + chickenCounter);

	}

	IEnumerator Wait (float seconds) {
		Debug.Log ("entered wait");

		yield return new WaitForSeconds(seconds);
		firstSpawner.spawnTime = 5.0f;
		secondSpawner.spawnTime = 2.5f;
		
		chickenCounter = 0;
		waited = true;
	}



}
