using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public float spawnTime = 0;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public GameObject[] enemies;		// Array of enemy prefabs.
	public int enemyCounter = 0;
	private float prevSpawnTime;

	void Awake ()
	{
		// Start calling the Spawn function repeatedly after a delay .
		prevSpawnTime = spawnTime;
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}

	void FixedUpdate() {
		if (prevSpawnTime != spawnTime) {
			//Debug.Log("into condition cancelinvoke");
			CancelInvoke("Spawn");
			prevSpawnTime = spawnTime;
			InvokeRepeating("Spawn", spawnDelay, spawnTime);
		}
	}

	void Spawn ()
	{
		// Instantiate a random enemy.
		int enemyIndex = Random.Range(0, enemies.Length);
		Instantiate(enemies[enemyIndex], transform.position, transform.rotation);
		enemyCounter++;
		// Play the spawning effect from all of the particle systems.
		foreach(ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
		{
			p.Play();
		}
	}

	public void StopSpawner() {

		CancelInvoke ("Spawn");
	}
}
