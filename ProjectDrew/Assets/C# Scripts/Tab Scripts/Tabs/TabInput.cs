using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TabDragEventArgs : EventArgs
{
    public float MouseMovementMagnitude { get; set; }
}

[RequireComponent(typeof(Collider))]
public class TabInput : MonoBehaviour
{
    public event EventHandler<EventArgs> SelectionBegin;
    public event EventHandler<EventArgs> SelectionRelease;
    public event EventHandler<EventArgs> ChargeReady;
    public event EventHandler<TabDragEventArgs> TabDrag;

    [SerializeField] private DragDirection dragDirection = DragDirection.Horizontal;
    [Tooltip("If mouse moved by less than this much since last frame, ignore the input")]
    [SerializeField] private float deadZone = 0.1f;
    [Tooltip("After you selected the tab, you need to move the mouse (no time limits) by this amount before the tab starts to move")]
    [SerializeField] private float chargeNeeded = 1.0f;
    [SerializeField] private float maxInputSpeed = 1.0f;

    private float currentCharge = 0;
    private bool isCharged = false;

    private enum DragDirection { Horizontal, Vertical }
    private bool selected = false;

    private void OnMouseOver()
    {
        if (!selected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                selected = true;
                OnSelectionBegin();
            }
        }
    }

    private void Start()
    {
        maxInputSpeed = maxInputSpeed / 1;
    }

    private void Update()
    {
        if (selected)
        {
            TabDragEventArgs args = new TabDragEventArgs();
            switch (dragDirection)
            {
                case DragDirection.Horizontal:
                    if (Input.GetAxis("Mouse X") >= 0)
                        args.MouseMovementMagnitude = Mathf.Min(Input.GetAxis("Mouse X"), maxInputSpeed);
                    else
                        args.MouseMovementMagnitude = Mathf.Max(Input.GetAxis("Mouse X"), -maxInputSpeed);
                    break;
                case DragDirection.Vertical:
                    if (Input.GetAxis("Mouse Y") >= 0)
                        args.MouseMovementMagnitude = Mathf.Min(Input.GetAxis("Mouse Y"), maxInputSpeed);
                    else
                        args.MouseMovementMagnitude = Mathf.Max(Input.GetAxis("Mouse Y"), -maxInputSpeed);
                    break;
            }
            if (Mathf.Abs(args.MouseMovementMagnitude) < deadZone)
            {
                args.MouseMovementMagnitude = 0;
            }
            
            if (isCharged)
            {
                OnTabDrag(args);
            }
            else
            {
                currentCharge += args.MouseMovementMagnitude;
                if (Mathf.Abs(currentCharge) >= chargeNeeded)
                {
                    //Debug.Log("charge ready!");
                    OnChargeReady();
                }
            }

            // if mouse left click is released, release selection
            if (!Input.GetMouseButton(0))
            {
                OnSelectionRelease();
            }
        }
    }

    protected virtual void OnSelectionBegin()
    {
        if (SelectionBegin != null)
            SelectionBegin(this, EventArgs.Empty);
    }
    protected virtual void OnChargeReady()
    {
        isCharged = true;
        currentCharge = 0;

        if (ChargeReady != null)
            ChargeReady(this, EventArgs.Empty);
    }
    protected virtual void OnSelectionRelease()
    {
        selected = false;
        isCharged = false;

        if (SelectionRelease != null)
            SelectionRelease(this, EventArgs.Empty);
    }
    protected virtual void OnTabDrag(TabDragEventArgs args)
    {
        if (TabDrag != null)
            TabDrag(this, args);
    }

}
