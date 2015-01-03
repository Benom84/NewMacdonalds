﻿using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
	public Rigidbody2D bullet;				// Prefab of the rocket.
	public float speed;						// The speed the rocket will fire at.
	public float reloadTime = 1f;
	
	
	private PlayerControl playerCtrl;		// Reference to the PlayerControl script.
	private Animator anim;					// Reference to the Animator component.
	
	private Pauser pauser;
	private float lastShot;

	void Awake()
	{
		// Setting up the references.
		anim = transform.root.gameObject.GetComponent<Animator>();
		playerCtrl = transform.root.GetComponent<PlayerControl>();
		GameObject menu = GameObject.Find ("MenuButton"); 
		pauser = menu.GetComponent<Pauser>();
		lastShot = Time.time;

	}
	
	
	void Update ()
	{

		float currTime = Time.time;
		// If the fire button is pressed...
		if((Input.GetButtonDown("Fire1")) && (!pauser.paused) && (currTime > lastShot + reloadTime))
		{
			// ... set the animator Shoot trigger parameter and play the audioclip.
			Debug.Log("I'm setting shoot");
			lastShot = currTime;
			anim.SetTrigger("Shoot");
			//audio.Play();
			
			// If the player is facing right...
			if(playerCtrl.facingRight)
			{
				// ... instantiate the rocket facing right and set it's velocity to the right. 
				Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2(-speed, 0);
			}
			else
			{
				// Otherwise instantiate the rocket facing left and set it's velocity to the left.
				Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0,0,180f))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2(speed, 0);
			}
		}
	}
}
