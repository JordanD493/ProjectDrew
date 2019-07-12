using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(TabInput))]
public class TabMovement : MonoBehaviour
{
    public event EventHandler<EventArgs> TabMove;

    // ------------------------------------------------------------------------------------------------------ INSPECTOR INTERFACE - YOU CAN SAFELY TWEAK THESE VALUES
    #region INSPECTOR 
    [SerializeField]
    private Transform beginLimit;
    [SerializeField]
    private Transform endLimit;
    [SerializeField]
    private float slideSpeed = 1;
    [SerializeField]
    [Tooltip("What percentage of the way between the two limits is the tab? I.e. if the tab is at the same position as beginLimit, insert 0. If same position as endLimit, insert 1. Halfway, insert 0.5. I might try to calculate this in code in the future, but for now you'll have to do it. :)")]
    private float initialPosition = 0;
    #endregion
    // --------------------------------------------------------------------------------------------------------------------------------------- INSPECTOR INTERFACE END

    public float TabMovementPercentage { get; private set; }

    private TabInput tabInput;
    // Use this for initialization
    void Start()
    {
        tabInput = GetComponent<TabInput>();
        tabInput.SelectionRelease += OnSelectionRelease;
        tabInput.TabDrag += OnTabDrag;

        TabMovementPercentage = initialPosition;
    }

    protected void OnTabDrag(object source, TabDragEventArgs args)
    {
        TabMovementPercentage = Mathf.Clamp(TabMovementPercentage + (args.mouseMovementMagnitude * slideSpeed * 0.05f), 0, 1);
        transform.position = Vector3.Lerp(beginLimit.position, endLimit.position, TabMovementPercentage);
        transform.eulerAngles = Vector3.Lerp(beginLimit.eulerAngles, endLimit.eulerAngles, TabMovementPercentage);
        OnTabMove();
    }
    
    protected void OnSelectionRelease(object source, EventArgs args)
    {
        Debug.Log("tab has been released");
    }

    protected virtual void OnTabMove()
    {
        if (TabMove != null)
            TabMove(this, EventArgs.Empty);
    }

}
