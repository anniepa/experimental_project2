/* Starts playing the dialogue if the player clicks on an interactable object */
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitiateDialogue : MonoBehaviour {

	//Variables
	public Dialogue dialogue;
	private static bool dialogueOn; //used to dictate whether dialogue is being played, applies to all tirggers

	//Methods
	private void Start ()
	{
		dialogueOn = false;
	}
/* Alternate method for turning off the triggers
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
				Debug.Log("player has clicked " + this.name);
				TriggerDialogue();
				dialogueOn = true;
		}
		else
		{
			return;
		}
	}

    public void ResetTrigger()
    {
        dialogueOn = false;
        Debug.Log("Dialogue for " + this.name + " is over.");
    }

	public void TriggerDialogue () //begins playing the dialogue attached to this trigger
	{
			FindObjectOfType<DialogueSystem>().StartDialogue(dialogue);
	}
}
