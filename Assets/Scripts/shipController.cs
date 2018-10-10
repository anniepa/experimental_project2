using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipController : MonoBehaviour{
	[SerializeField] float fireRate = 0.5F;
	[SerializeField] float speed = 10f;

	[SerializeField] float top = -5f;
	[SerializeField] float bottom = 5f;
	[SerializeField] float left = -5f;
	[SerializeField] float right = 5f;
	[SerializeField] GameObject shot;
	[SerializeField] Transform shotSpawn;

	private float myTime = 0.0F;
	private float nextFire = 0.5F;
	private Rigidbody2D rb;
	private AudioSource audioSource;

	void Start(){
		rb = GetComponent<Rigidbody2D>();
		//audioSource = GetComponent<AudioSource>();
	}

	void Update(){
		myTime = myTime + Time.deltaTime;

		if (Input.GetButton("Fire1") && myTime > nextFire) {
			nextFire = myTime + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

			//audioSource.Play();

			nextFire = nextFire - myTime;
			myTime = 0.0F;
		}
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector2 movement = new Vector2(moveHorizontal, moveVertical);
		rb.velocity = movement * speed;

		rb.position = new Vector2(
			Mathf.Clamp(rb.position.x, left, right),
			Mathf.Clamp(rb.position.y, top, bottom)			
		);
	}
}