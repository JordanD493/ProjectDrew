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

    private float GlobalRightTValue;

    private float GlobalLeftTValue;

    private bool IS_Right_Clicked;

    private bool IS_Left_Clicked;




    // Use this for initialization
    void Start ()
    {
        camFollow = FindObjectOfType<CameraFollow>();
        cam_zoom = FindObjectOfType<CameraZoom>();
        lastTvalue = 0;
        GlobalRightTValue = 0;
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


       

        lastTvalue = GlobalRightTValue;

        lastTvalue = camFollow.tParam;


        camFollow.tParam = 1;

       
    }

    public void OnLeftClick()
    {
        
        camFollow.IsMovementAllowedLeft= true;

        lastTvalue = GlobalLeftTValue;

     

    }

    public void OnLeftClickUp()
    {
        camFollow.IsMovementAllowedLeft = false;

      

        lastTvalue = GlobalRightTValue;

        //lastTvalue = camFollow.tParam;

        lastTvalue = camFollow.tParam;


        camFollow.tParam = 1;

       
    }
}
