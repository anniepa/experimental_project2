/* Puts the dialogue into a Queue which will then display each sentence in the
dialogue text box */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{   

    //Variables
    public Text dialogueText; //text box that will display dialogue
    private Queue<string> sentences;
    

    //Methods
    void Start ()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        Debug.Log("Starting dialogue");

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence); //puts the sentences into the queue
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        Debug.Log(sentence);
    }

    void EndDialogue()
    {
        FindObjectOfType<InitiateDialogue>().ResetTrigger();
        Debug.Log("End of monologue");
    }
}
