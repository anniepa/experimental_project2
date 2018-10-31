using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MobileGameManager : MonoBehaviour {

    private bool phoneOn;
    private AudioSource sound;
    [SerializeField] int scene;
    [SerializeField] GameObject end;
    [SerializeField] GameObject final_panel;

    private void Start()
    {
        phoneOn = false;
        sound = GetComponent<AudioSource>();
    }

    public bool phone(){
        return phoneOn;
    }

    IEnumerator endDelay(){
		yield return new WaitForSeconds(1);
        end.GetComponent<InitiateDialogue>().end();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(scene);
	}
    public void nextScene(){
        if(phoneOn == true){
            ChangeGame();
        }
        if(scene < 7){
            scene += 1;
            StartCoroutine(endDelay());
        }else if(scene == 7){
            final_panel.SetActive(true);
            StartCoroutine(endDelay());
        }
    }
    public void ChangeGame ()
    {
        if (phoneOn == false)
        {
            if(sound !=null){
			    sound.Stop();
		    }
            SceneManager.LoadScene("Phone", LoadSceneMode.Additive);
            phoneOn = true;
        }    
        else if (phoneOn == true)
        {
            SceneManager.UnloadSceneAsync("Phone");
            phoneOn = false;
            if(sound !=null){
			    sound.Play();
		    }
        }
    }
}
