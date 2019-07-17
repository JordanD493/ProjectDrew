using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamButtonClick : MonoBehaviour
{
    CameraFollow camFollow;
	// Use this for initialization
	void Start ()
    {
        camFollow = FindObjectOfType<CameraFollow>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnRightClick()
    {
        camFollow.IsMovementAllowedRight = true;
       
    }

    public void OnLeftClick()
    {
        camFollow.IsMovementAllowedLeft= true;
       

    }
}
