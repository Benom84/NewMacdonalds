using UnityEngine;
using System.Collections;

public class BulletsUI : MonoBehaviour {

	private Gun gunScript;
	private int bullets;
	private float timeToReload;
	// Use this for initialization
	void Start () {

		gunScript = GameObject.Find ("Gun").GetComponent<Gun> ();
	}
	
	// Update is called once per frame
	void Update () {

		bullets = gunScript.bullets;
		if (bullets > 0)
						guiText.text = "Bullets: " + bullets;
		else {
			timeToReload = gunScript.nextReload;
			guiText.text = "Reloading in: " + (int)(Mathf.Max((timeToReload + 1f - Time.time), 0));

	
		}
	
	}
}
