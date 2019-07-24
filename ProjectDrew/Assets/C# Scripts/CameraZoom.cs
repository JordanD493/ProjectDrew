using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{    
    [SerializeField]
    private Vector3 zoomValue;

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
            
            Camera.main.transform.position = new Vector3(transform.position.x + zoomValue.x*Time.deltaTime, 
                                                         transform.position.y + zoomValue.y*Time.deltaTime, 
                                                         transform.position.z - zoomValue.z*Time.deltaTime);
                                             
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {

            Camera.main.transform.position = new Vector3(transform.position.x - zoomValue.x * Time.deltaTime,
                                                         transform.position.y - zoomValue.y * Time.deltaTime,
                                                         transform.position.z + zoomValue.z * Time.deltaTime);

        }
    }
}
