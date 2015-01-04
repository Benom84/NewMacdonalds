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
	private bool changedLight;

	// Use this for initialization
	void Start () {

		Vector3 pos =  new Vector3 (transform.position.x, transform.position.y, zStart);
		vChange = new Vector3 (0, 0, change);
		light = transform.FindChild ("MovieLight").GetComponent<Light>();
		transform.position = pos;

		if (zEnd < zStart)
						direction = -1;
	
	}
	

	void Update () {

		if (transform.position.z < zEnd) {
			if (transform.position.z > zColorChange)
				light.color += Color.red / 2.0F * Time.deltaTime;
			Vector3 newPos = transform.position;
			newPos = newPos + vChange;
			transform.position = newPos;
		}

	
	
	}
}
