using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnableDisableCrown : MonoBehaviour {

    [SerializeField] private TabMovement thisControlsMe;
    [SerializeField, Range(0, 1)] private float activeWhenTabAt;
    [SerializeField] bool crownEnabled = false;
    

    // Use this for initialization
    void Start()
    {
        thisControlsMe.SnapReached += OnSnapReached;
    }

    private void OnSnapReached(object sender, EventArgs e)
    {
        if (thisControlsMe.TabMovementPercentage == activeWhenTabAt)
        {
            crownEnabled = true;
        }
        else
        {
            crownEnabled = false;
        }
    }

    private void Update()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = crownEnabled;
    } 

        
}
