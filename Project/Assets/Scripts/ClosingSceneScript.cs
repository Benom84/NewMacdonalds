using UnityEngine;
using System.Collections;

public class ClosingSceneScript : MonoBehaviour {

	public float zStart;
	public float zColorChange;
	public float zEnd;
	public float change;

	private int direction = 1;
	private Vector3 vChange;
	private Light light;
	private SpriteRenderer message;
	private AudioSource listener;

	// Use this for initialization
	void Start () {

		Vector3 pos =  new Vector3 (transform.position.x, transform.position.y, zStart);
		vChange = new Vector3 (0, 0, change);
		light = transform.FindChild ("MovieLight").GetComponent<Light>();
		message = transform.FindChild ("YouWon").GetComponent<SpriteRenderer>();
		listener = GetComponent<AudioSource> ();
		message.color = new Color (1f, 1f, 1f, 0f);
		transform.position = pos;

		if (zEnd < zStart)
						direction = -1;
	
	}
	

	void Update () {

		if (transform.position.z < zEnd) {
			if (transform.position.z > zColorChange)
				light.color += Color.red / 2.0F * Time.deltaTime;
			if (transform.position.z > zColorChange) {
				message.color = new Color (1f, 1f, 1f, 1f);
				Debug.Log ("Should be visible");
			}
				
			Vector3 newPos = transform.position;
			newPos = newPos + vChange;
			transform.position = newPos;
		}

		if (!listener.isPlaying)
						Application.LoadLevel ("MainMenu");
	
	}

	void OnMouseDown() {

		Application.LoadLevel ("MainMenu");

	}
}
