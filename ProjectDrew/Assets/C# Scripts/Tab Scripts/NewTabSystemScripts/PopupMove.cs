using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PopupMove : MonoBehaviour
{
    [Tooltip("The tab that controls the movement of this popup.")]
    [SerializeField] private TabMovement tab;
    [SerializeField] private Transform beginLimit;
    [SerializeField] private Transform endLimit;

    // Use this for initialization
    void Start()
    {
        tab.TabMove += OnTabMove;
        transform.position = endLimit.position;
    }

    protected virtual void OnTabMove(object source, EventArgs args)
    {
        transform.position = Vector3.Lerp(beginLimit.position, endLimit.position, tab.TabMovementPercentage);
        transform.eulerAngles = Vector3.Lerp(beginLimit.eulerAngles, endLimit.eulerAngles, tab.TabMovementPercentage);
        Debug.Log(tab.TabMovementPercentage);
    }

    // ------------------------------------------------- EDITOR
    public void SnapToBegin()
    {
        transform.position = beginLimit.position;
        transform.rotation = beginLimit.rotation;
    }

    public void SnapToEnd()
    {
        transform.position = endLimit.position;
        transform.rotation = endLimit.rotation;
    }

}
