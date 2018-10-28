using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipController : MonoBehaviour{
	[SerializeField] float fireRate = 1f;
	[SerializeField] float speed = 10f;

	[SerializeField] float bottom = -5f;
	[SerializeField] float top = 5f;
	[SerializeField] float left = -5f;
	[SerializeField] float right = 5f;
	[SerializeField] GameObject shot;
	[SerializeField] Transform shotSpawn;

	[SerializeField] gameManager manager;

	private float myTime = 0.0F;
	private float nextFire = 0.5F;
	private Rigidbody2D rb;
	private Animator animator;
	private AudioSource pew;
	private bool disable;

	void Start(){
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		disable = false;
		//pew = GetComponent<AudioSource>();
	}

	void Update(){
		myTime = myTime + Time.deltaTime;

		if (Input.GetButton("Fire1") && myTime > nextFire) {
			nextFire = myTime + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

			//pew.Play();

			nextFire = nextFire - myTime;
			myTime = 0.0F;
		}
	}

	void FixedUpdate(){
		if(!disable){
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

	IEnumerator reset(){
		manager.loseLife();
		disable = true;
		rb.velocity = new Vector2(0f,0f);
		animator.SetTrigger("hurt");
		gameObject.transform.position = new Vector3(0f, -2.5f, 0f);
		yield return new WaitForSeconds(0.5f);
		disable = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("alien")) {
			StartCoroutine(reset());
		}
	}
}