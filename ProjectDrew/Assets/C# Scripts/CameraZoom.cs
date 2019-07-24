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
        //cameraZoom();

        TouchInput();
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

    void TouchInput()
    {
        if(Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne =  Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos =  touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            if(deltaMagnitudeDiff < 0)
            {
                Camera.main.transform.position = new Vector3(transform.position.x + zoomValue.x * Time.deltaTime,
                                                        transform.position.y + zoomValue.y * Time.deltaTime,
                                                        transform.position.z - zoomValue.z * Time.deltaTime);
            }

            if(deltaMagnitudeDiff > 0)
            {
                Camera.main.transform.position = new Vector3(transform.position.x - zoomValue.x * Time.deltaTime,
                                                         transform.position.y - zoomValue.y * Time.deltaTime,
                                                         transform.position.z + zoomValue.z * Time.deltaTime);
            }

        }
    }
}
