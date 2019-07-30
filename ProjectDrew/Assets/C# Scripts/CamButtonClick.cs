using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CamButtonClick : MonoBehaviour
{
    public EventHandler<EventArgs> MouseUp;

    internal float lastTvalue;

    CameraFollow camFollow;

    private CameraZoom cam_zoom;
	// Use this for initialization
	void Start ()
    {
        camFollow = FindObjectOfType<CameraFollow>();
        cam_zoom = FindObjectOfType<CameraZoom>();
        lastTvalue = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnRightClick()
    {
        cam_zoom.enabled = false;
        camFollow.enabled = true;
        camFollow.IsMovementAllowedRight = true;
       

    }

    public void OnRightClickUp()
    {
        camFollow.IsMovementAllowedRight = false;

        lastTvalue = camFollow.tParam;
        //camFollow.tParam = 1;

        cam_zoom.enabled = true;
        camFollow.enabled = false;

    }

    public void OnLeftClick()
    {
        cam_zoom.enabled = false;
        camFollow.enabled = true;
        camFollow.IsMovementAllowedLeft= true;

    }

    public void OnLeftClickUp()
    {
        camFollow.IsMovementAllowedLeft = false;

        lastTvalue = camFollow.tParam;
        //camFollow.tParam = 1;

       
    }
}
