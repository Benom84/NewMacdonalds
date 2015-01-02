using UnityEngine;
using System.Collections;

public class VictoryScore : MonoBehaviour {
	private int score = 0;

	// Use this for initialization
	void Start () {

		score = GameObject.Find("Score").GetComponent<Score>().score;
	
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "" + score;
	}
}
