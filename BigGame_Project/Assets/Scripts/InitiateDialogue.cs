using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitiateDialogue : MonoBehaviour {

		//Variables
		public Dialogue dialogue;
		private bool dialogueOn;
		Collider2D thisCollider;

	//Methods
	private void Start ()
	{
		dialogueOn = false;
		thisCollider = GetComponent<Collider2D>();
	}
/*
	private void OnMouseOver ()
	{
		if(dialogueOn == false)
		{
			if(Input.GetMouseButtonDown(0))
			{
				Debug.Log("player has clicked the object");
				TriggerDialogue();
				dialogueOn = true;
			}
			else
			{
				return;
			}
		}
	}
*/
	void OnMouseDown()
	{
		if(dialogueOn == false)
		{
			thisCollider.enabled = !thisCollider;
			Debug.Log("player has clicked the object");
			TriggerDialogue();
			dialogueOn = true;
		}
		else
		{
			return;
		}
	}

	public void TriggerDialogue ()
	{
		FindObjectOfType<DialogueSystem>().StartDialogue(dialogue);
	}
}
