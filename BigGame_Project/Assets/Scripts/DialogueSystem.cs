using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {

    public GameObject textPanel;
    public GameObject ContinueBtn;
    public ArrayList text;

	// Use this for initialization
	void Start () {
        textPanel.SetActive(false);
	}

    // Update is called once per frame
    private void OnMouseOver()
    {
        textPanel.SetActive(true);
    }

    
}
