using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelAtEndGoal : MonoBehaviour {

    [SerializeField]
    private string LevelName;

    private EndGoalMaterialColor Mat;
   

    private void Awake()
    {
        Mat = FindObjectOfType<EndGoalMaterialColor>();
    }

    private void Update()
    {
        if(Mat.IsFolding == true)
        {
            SceneManager.LoadSceneAsync(LevelName, LoadSceneMode.Single);
        }
    }

  
}
