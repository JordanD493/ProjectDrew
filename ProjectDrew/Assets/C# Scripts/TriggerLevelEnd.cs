﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerLevelEnd : MonoBehaviour
{

    [Tooltip("this is needed so i can easily access the player's animatior component")]
    [SerializeField] private GameObject player;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.tag == "Player")
        //{
        //    //player.GetComponent<Animator>().SetBool("ReachedEnd", true);
        //    Debug.Log("player hit end");
        //    SceneManager.LoadScene("LVL1.1"); ;
        //}
        
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //}
}
