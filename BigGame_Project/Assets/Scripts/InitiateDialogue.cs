/* Starts playing the dialogue if the player clicks on an interactable object */
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InitiateDialogue : MonoBehaviour {

	//Variables
	public Dialogue dialogue;
	private static bool dialogueOn; //used to dictate whether dialogue is being played, applies to all tirggers
	private MobileGameManager manager;
	private AudioSource sound;
	[SerializeField] int trans;
	//Methods
	private void Start ()
	{
		manager = GameObject.FindWithTag("phoneManager").GetComponent<MobileGameManager>();
		sound = GetComponent<AudioSource>();
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

	public void end(){
		if(sound !=null){
			sound.Play();
		}
		TriggerDialogue();
		dialogueOn = true;
	}
	void OnMouseDown()
	{
		if(dialogueOn == false && manager.phone() == false)
		{
				TriggerDialogue();
				dialogueOn = true;
		}
		else
		{
			return;
		}
	}

	public static bool check(){
		return dialogueOn;
	}
    public void ResetTrigger()
    {
        dialogueOn = false;
    }

	public void TriggerDialogue () //begins playing the dialogue attached to this trigger
	{
		GameObject.FindGameObjectWithTag("dSys").GetComponent<DialogueSystem>().StartDialogue(dialogue);
	}
}
