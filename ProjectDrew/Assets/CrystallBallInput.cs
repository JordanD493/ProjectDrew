using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Collider))]
public class CrystallBallInput : MonoBehaviour {

    public EventHandler<EventArgs> CrystalBallTouch;

    [Tooltip("Time before the hint becomes available, in seconds.")]
    [SerializeField] private float CountdownToHint = 20.0f;

    private float timeSinceLevelStart;
    private bool hintReady = false;

    //[SerializeField] private Material glowShader;

	// Use this for initialization
	void Start () {
        hintReady = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!hintReady)
        {
            CountdownToHint -= Time.deltaTime;
            if (CountdownToHint <= 0)
            {
                hintReady = true;
                CountdownToHint = 0;
            }
        }
	}

    private void OnMouseDown()
    {
        if (hintReady)
        {
            OnCrystalBallTouch();
        }
    }

    protected virtual void OnCrystalBallTouch()
    {
        if (CrystalBallTouch != null)
            CrystalBallTouch(this, EventArgs.Empty);
    }

    // --------------------------------------------------------- EDITOR

    public void MinGlow()
    {
        //GetComponent<MeshRenderer>().material.SetFloat("Vector1_5111595C", 1);
    }

    public void MaxGlow()
    {
        //GetComponent<MeshRenderer>().material.SetFloat("Vector1_5111595C", 20);
    }
}
