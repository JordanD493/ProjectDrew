using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TabDisableCollider : MonoBehaviour {

    private TabMovement tabMovement;
    [SerializeField] private List<Collider2D> popupColliders2D;

	// Use this for initialization
	void Start () {
        tabMovement = GetComponent<TabMovement>();
        tabMovement.SnapReached += OnSnapReached;

        foreach (Collider2D c in popupColliders2D)
        {
            c.enabled = false;
        }
	}

    protected virtual void OnSnapReached(object source, EventArgs args)
    {
        foreach (Collider2D c in popupColliders2D)
        {
            if (tabMovement.TabMovementPercentage == 1)
            {
                c.enabled = true;
            }
            else
            {
                c.enabled = false;
            }
        }
    }
}
