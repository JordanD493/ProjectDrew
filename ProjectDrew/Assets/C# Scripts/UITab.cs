using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UITab : MonoBehaviour
{
    [SerializeField]
    private GameObject AudioButton;

    [SerializeField]
    private GameObject ResetButton;

    [SerializeField]
    private GameObject ExitButton;

    [SerializeField]
    private GameObject AudioMuteButton;

    private bool Is_Touching = false;

    private bool Is_AudioTouching = false;

    [SerializeField]
    private AudioListener Listner;

    [SerializeField]
    private string LevelName;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void TouchUI()
    {
        Is_Touching = !Is_Touching;
        if(Is_Touching == true)
        {
            ExitButton.SetActive(true);       
            AudioButton.SetActive(true);
            ResetButton.SetActive(true);

        }
        else
        {
            ExitButton.SetActive(false);
            AudioButton.SetActive(false);
            ResetButton.SetActive(false);

        }
    }

    public void DisableAudio()
    {
            Listner.enabled = false;
            AudioMuteButton.SetActive(true);
            AudioButton.SetActive(false);
                                 
    }

    public void EnableAudio()
    {
        Listner.enabled = true;
        AudioMuteButton.SetActive(false);
        AudioButton.SetActive(true);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadSceneAsync(LevelName);
    }

    public void Exit()
    {
        Application.Quit();
    }

   
}
