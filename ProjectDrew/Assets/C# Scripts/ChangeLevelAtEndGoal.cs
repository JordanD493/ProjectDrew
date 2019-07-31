using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelAtEndGoal : MonoBehaviour {

    [SerializeField]
    private string LevelName;

    private MaterialColor Mat_Color;

    private void Awake()
    {
        Mat_Color = GetComponent<MaterialColor>();
    }

    private void Update()
    {
            if(Mat_Color.IsChangingScene == true)
            {
                SceneManager.LoadScene(LevelName, LoadSceneMode.Single);

            }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SceneManager.LoadScene(LevelName, LoadSceneMode.Single);

        }
    }
}
