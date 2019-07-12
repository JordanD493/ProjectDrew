using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TabDragEventArgs : EventArgs
{
    public float mouseMovementMagnitude { get; set; }
}

[RequireComponent(typeof(Collider))]
public class TabInput : MonoBehaviour
{
    public event EventHandler<EventArgs> SelectionBegin;
    public event EventHandler<EventArgs> SelectionRelease;
    public event EventHandler<TabDragEventArgs> TabDrag;

    [SerializeField] private DragDirection dragDirection = DragDirection.Horizontal;

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

    private void Update()
    {
        if (selected)
        {
            TabDragEventArgs args = new TabDragEventArgs();
            switch (dragDirection)
            {
                case DragDirection.Horizontal:
                    args.mouseMovementMagnitude = Input.GetAxis("Mouse X");
                    break;
                case DragDirection.Vertical:
                    args.mouseMovementMagnitude = Input.GetAxis("Mouse Y");
                    break;
            }
            OnTabDrag(args);
            // if mouse left click is released, release selection
            if (!Input.GetMouseButton(0))
            {
                selected = false;
                OnSelectionRelease();
            }
        }
    }

    protected virtual void OnSelectionBegin()
    {
        if (SelectionBegin != null)
            SelectionBegin(this, EventArgs.Empty);
    }
    protected virtual void OnSelectionRelease()
    {
        if (SelectionRelease != null)
            SelectionRelease(this, EventArgs.Empty);
    }
    protected virtual void OnTabDrag(TabDragEventArgs args)
    {
        if (TabDrag != null)
            TabDrag(this, args);
    }

}
