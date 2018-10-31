using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	// Use this for initialization
	[SerializeField] float speed = -15f;
	[SerializeField] float bottom = -4.5f;
	[SerializeField] int health = 1;
	[SerializeField] int points = 100;

	private Rigidbody2D rb;
	private gameManager manager;
	private AudioSource boom;
	void Start () {
		boom = GetComponent<AudioSource>();
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = transform.up * speed;
		GameObject managerObject = GameObject.FindWithTag("GameController");
		if (managerObject != null) {
			manager = managerObject.GetComponent<gameManager>();
		}
		if (managerObject == null) {
			Debug.Log("Cannot find 'gameManager' script");
		}
	}
	
	// Update is called once per frame
	void FixedUpdate(){
		if(health == 0){
			boom.Play();
			manager.addScore(points);
			Destroy(gameObject);
		}
		if (rb.position.y < bottom){
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("bullet")) {
			health -= 1;
			Destroy(other.gameObject);
		}
	}
}
