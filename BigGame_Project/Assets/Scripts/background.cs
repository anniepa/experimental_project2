using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
	public float scrollSpeed;
	[SerializeField] float tileSize;

	private Vector3 startPosition;

	void Start(){
		startPosition = transform.position;
	}

	void Update(){
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSize);
		transform.position = startPosition + Vector3.down * newPosition;
	}
}
