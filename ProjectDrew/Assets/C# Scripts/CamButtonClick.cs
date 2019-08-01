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

    private float GlobalTValue;
   
    private bool IS_Right_Clicked;

    private bool IS_Left_Clicked;




    // Use this for initialization
    void Start ()
    {
        camFollow = FindObjectOfType<CameraFollow>();
        cam_zoom = FindObjectOfType<CameraZoom>();
        lastTvalue = 0;
        GlobalTValue = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {

       //if(camFollow.IsMovementAllowedRight == false)
       // {
       //     lastTvalue = camFollow.tParam;
       // }
    }

    public void OnRightClick()
    {
       
        camFollow.IsMovementAllowedRight = true;

    }

    public void OnRightClickUp()
    {
        camFollow.IsMovementAllowedRight = false;

        //GlobalTValue = camFollow.tParam;
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

        //GlobalTValue = camFollow.tParam;

        lastTvalue = camFollow.tParam;

        camFollow.tParam = 1;
 
    }
}
