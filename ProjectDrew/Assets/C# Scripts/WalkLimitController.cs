using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class WalkLimitController : MonoBehaviour
{

    [SerializeField] private TabMovement thisControlsMe;
    [SerializeField, Range(0, 1)] private float activeWhenTabAt;

    private BoxCollider boxCollider;

    // Use this for initialization
    void Start()
    {
        thisControlsMe.SnapReached += OnSnapReached;
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnSnapReached(object sender, EventArgs e)
    {
        if (thisControlsMe.TabMovementPercentage == activeWhenTabAt)
        {
            boxCollider.enabled = true;
        }
        else
        {
            boxCollider.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
