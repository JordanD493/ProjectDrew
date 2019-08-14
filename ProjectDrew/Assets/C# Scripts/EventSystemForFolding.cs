using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventSystemForFolding : MonoBehaviour
{
    [SerializeField]
    private GameObject PopUps;

    [SerializeField]
    private string LevelName;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        		
	}

    public void RemovePopUps()
    {
        PopUps.SetActive(false);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(LevelName, LoadSceneMode.Single);
    }
}
