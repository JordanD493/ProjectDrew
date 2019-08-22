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


    public void RemovePopUps()
    {
        PopUps.SetActive(false);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(LevelName, LoadSceneMode.Single);
    }
}
