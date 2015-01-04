using UnityEngine;
using System.Collections;

public class SpawnManagerLevel2 : MonoBehaviour {

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
		thirdSpawner.spawnTime = 7.5f;
		fourthSpawner.spawnTime = 10.0f;

	}
	
	void Update () {
		ChickenCounter ();
		if (firstWaveStarted) 
			FirstWave ();
		else if ((Time.time >= (endOfFirstWave + 10.0f)) && secondWaveStarted) 
			SecondWave();
		else if ((Time.time >= (endOfSecondWave + 7.0f)) && thirdWaveStarted) 
			ThirdWave();
	}
	
	public static void DeathCounter () {
		deathCounter++;
	}
	
	void ChickenCounter () {
		chickenCounter = firstSpawner.enemyCounter + secondSpawner.enemyCounter;
	}
	
	void FirstWave () {
		if (chickenCounter > 15) {
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
		firstSpawner.spawnTime = 3.5f;
		secondSpawner.spawnTime = 4.0f;
		thirdSpawner.spawnTime = 4.5f;
		fourthSpawner.spawnTime = 5.0f;
		
		if (chickenCounter > 35) {
			
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
		
		firstSpawner.spawnTime = 1.25f;
		secondSpawner.spawnTime = 0.5f;
		thirdSpawner.spawnTime = 1.25f;
		fourthSpawner.spawnTime = 0.5f;
		
		//if (chickenCounter > 100) {
			
		//	firstSpawner.spawnTime = 0f;
		//	secondSpawner.spawnTime = 0f;
		//	thirdSpawner.spawnTime = 0f;
		//	fourthSpawner.spawnTime = 0f;
			
		//	thirdWaveStarted = false;
		//}	
	}
}
