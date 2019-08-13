using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelAtEndGoal : MonoBehaviour {

    [SerializeField]
    private string LevelName;

    private MaterialColor Mat;
   

    private void Awake()
    {
        Mat = FindObjectOfType<MaterialColor>();
    }

    private void Update()
    {
        if(Mat.IsFolding == true)
        {
            SceneManager.LoadSceneAsync(LevelName, LoadSceneMode.Single);
        }
    }

  
}
