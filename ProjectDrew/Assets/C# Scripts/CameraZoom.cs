using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{    
    [SerializeField]
    private float zoomValueZ;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        cameraZoom();
	}

    void cameraZoom()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            
            Camera.main.transform.position = new Vector3(10.88f, 11.55f, Camera.main.transform.position.z - zoomValueZ * Time.deltaTime);
                                             
        }
    }
}
