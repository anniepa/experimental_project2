/* Editor fields for inputing the dialogue that will be displayed */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
		[TextArea(3, 10)] //Inspector input field size
		public string[] sentences;
}
