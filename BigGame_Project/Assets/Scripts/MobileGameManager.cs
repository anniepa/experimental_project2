using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MobileGameManager : MonoBehaviour {

    private bool phoneOn;

    private void Start()
    {
        phoneOn = false;
    }

    public void ChangeGame ()
    {
        if (phoneOn == false)
        {
            SceneManager.LoadScene("Phone", LoadSceneMode.Additive);
            phoneOn = true;
        }    
        else if (phoneOn == true)
        {
            SceneManager.UnloadSceneAsync("Phone");
            phoneOn = false;
        }
        else
        {
            return;
        }

    }
}
