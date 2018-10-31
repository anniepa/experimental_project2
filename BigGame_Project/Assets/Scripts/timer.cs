using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour {

	// Use this for initialization
	[SerializeField] float time;
	private MobileGameManager manager;
	private bool off;
	void Awake () {
		manager = GameObject.FindWithTag("phoneManager").GetComponent<MobileGameManager>();
		off = false;
	}

	public void Update(){
		if(time <= 0f && off == false){
			off = true;
			manager.nextScene();
		}else{
			time -= Time.deltaTime;
		}
	}
	
}
