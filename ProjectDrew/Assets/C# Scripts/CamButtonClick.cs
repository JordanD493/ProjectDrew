using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CamButtonClick : MonoBehaviour
{
    public EventHandler<EventArgs> MouseUp;

    internal float lastTvalue;

    CameraFollow camFollow;
	// Use this for initialization
	void Start ()
    {
        camFollow = FindObjectOfType<CameraFollow>();
        lastTvalue = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnRightClick()
    {
        camFollow.IsMovementAllowedRight = true;
       

    }

    public void OnRightClickUp()
    {
        camFollow.IsMovementAllowedRight = false;
        lastTvalue = camFollow.tParam;
        camFollow.tParam = 1;
    }

    public void OnLeftClick()
    {
        camFollow.IsMovementAllowedLeft= true;
       

    }

    public void OnLeftClickUp()
    {
        camFollow.IsMovementAllowedLeft = false;
        lastTvalue = camFollow.tParam;
        camFollow.tParam = 1;
    }
}
