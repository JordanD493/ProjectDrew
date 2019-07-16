using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
public class PopupAnimate : MonoBehaviour {

    [Tooltip("The tab that controls the animation of this popup.")]
    [SerializeField] private TabMovement tab;

    private Animator anim;

	// Use this for initialization
	void Start () {
        tab.TabMove += OnTabMove;
        anim = GetComponent<Animator>();
        anim.Play(0, 0, anim.GetCurrentAnimatorClipInfo(0).Length * tab.TabMovementPercentage);
    }

    protected virtual void OnTabMove(object source, EventArgs args)
    {
        anim.Play(0, 0, anim.GetCurrentAnimatorClipInfo(0).Length * tab.TabMovementPercentage);
    }
}
