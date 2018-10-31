using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	[SerializeField] float speed = 15f;
	[SerializeField] float top = 4.5f;
	[SerializeField] float left = 4.5f;
	[SerializeField] float right = 4.5f;
	private Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = transform.up * speed;
	}

	void FixedUpdate(){
		if (rb.position.y > top || rb.position.x < left || rb.position.x > right){
				Destroy(gameObject);
		}
	}
}
