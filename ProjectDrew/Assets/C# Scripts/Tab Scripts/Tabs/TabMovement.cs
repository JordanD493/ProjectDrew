using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(TabInput))]
public class TabMovement : MonoBehaviour
{
    public event EventHandler<EventArgs> TabMove;
    public event EventHandler<EventArgs> SnapReached;

    // ------------------------------------------------------------------------------------------------------ INSPECTOR INTERFACE - YOU CAN SAFELY TWEAK THESE VALUES
    #region INSPECTOR 
    [SerializeField] private Transform beginLimit;
    [SerializeField] private Transform endLimit;
    [SerializeField] private float slideSpeed = 1;
    [Tooltip("What percentage of the way between the two limits is the tab? I.e. if the tab is at the same position as beginLimit, insert 0. If same position as endLimit, insert 1. Halfway, insert 0.5. I might try to calculate this in code in the future, but for now you'll have to do it. :)")]
    [SerializeField] private float initialPosition = 0;
    [SerializeField] private bool snapOnRelease = true;
    [ConditionalHide("snappingOn", true, false)]
    [SerializeField] private float snapSpeed = 1;
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
        TabMovementPercentage = Mathf.Clamp(TabMovementPercentage + (args.MouseMovementMagnitude * slideSpeed * 0.05f), 0, 1);
        UpdateTabTransform();
    }

    protected void OnSelectionRelease(object source, EventArgs args)
    {
        if (snapOnRelease)
        {
            StartCoroutine(InterpolateToClosestSnapPoint());
        }
    }

    protected virtual void OnTabMove()
    {
        if (TabMove != null)
            TabMove(this, EventArgs.Empty);
    }

    protected virtual void OnSnapReached()
    {
        if (SnapReached != null)
            SnapReached(this, EventArgs.Empty);
    }

    private void UpdateTabTransform()
    {
        transform.position = Vector3.Lerp(beginLimit.position, endLimit.position, TabMovementPercentage);
        transform.eulerAngles = Vector3.Lerp(beginLimit.eulerAngles, endLimit.eulerAngles, TabMovementPercentage);
        OnTabMove();
    }

    IEnumerator InterpolateToClosestSnapPoint()
    {
        float closestSnapPoint = 0;
        if (TabMovementPercentage > 0.5f)
        {
            closestSnapPoint = 1;
            while (closestSnapPoint > TabMovementPercentage)
            {
                TabMovementPercentage = Mathf.Clamp(TabMovementPercentage += snapSpeed * Time.deltaTime, 0, 1);
                UpdateTabTransform();
                yield return null;
            }
            TabMovementPercentage = 1;
            OnSnapReached();
            yield return null;
        }
        else
        {
            while (closestSnapPoint < TabMovementPercentage)
            {
                TabMovementPercentage -= snapSpeed * Time.deltaTime;
                UpdateTabTransform();
                yield return null;
            }
            TabMovementPercentage = 0;
            OnSnapReached();
            yield return null;
        }
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
