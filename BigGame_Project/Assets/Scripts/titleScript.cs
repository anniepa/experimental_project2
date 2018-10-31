using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class titleScript : MonoBehaviour {

	[SerializeField] Image creds;
	// Use this for initialization
	public void quit(){
		Debug.Log("quit");
		Application.Quit();
	}

	public void openCredits(){
		creds.gameObject.SetActive(true);
	}

	public void closeCredits(){
		creds.gameObject.SetActive(false);
	}

	public void start(){
		SceneManager.LoadScene("1_KitchenDayScene");
	}
}
