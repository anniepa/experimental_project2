using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour {

	// Use this for initialization
	[SerializeField] float speed = -15f;
	[SerializeField] float bottom = -5f;
	[SerializeField] int health = 1;

	private Rigidbody2D rb;
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = transform.up * speed;
	}
	
	// Update is called once per frame
	void FixedUpdate(){
		if(health == 0){
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
