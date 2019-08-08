using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{    
    [SerializeField]
    private float zoomValue;
   
    [SerializeField]
    private float CamMaxZoomValue;

    [SerializeField]
    private float CamMinZoomValue;

    [SerializeField]
    private CameraFollow cam_follow;

    
	// Use this for initialization
	void Start ()
    {
       

    }

    // Update is called once per frame
    void Update ()
    {
        cameraZoom();

        //TouchInput();
	}

   

    void cameraZoom()
    {
       Vector3 pos = transform.position;

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {


          //Camera.main.transform.position = new Vector3(transform.position.x + zoomValue.x*Time.deltaTime,
          //                                             transform.position.y + zoomValue.y*Time.deltaTime,
          //                                             transform.position.z - zoomValue.z*Time.deltaTime);

            Camera.main.fieldOfView -= zoomValue;

           
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {

            //Camera.main.transform.position = new Vector3(transform.position.x - zoomValue.x * Time.deltaTime,
            //                                             transform.position.y - zoomValue.y * Time.deltaTime,
            //                                             transform.position.z + zoomValue.z * Time.deltaTime);
            //this.enabled = true;

            Camera.main.fieldOfView += zoomValue;
           

        }


        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, CamMinZoomValue, CamMaxZoomValue);

        //cam_follow.enabled = true;

        //pos.y = Mathf.Clamp(transform.position.y, CamMinZoomValue.y, CamMaxZoomValue.y);
        //pos.x = Mathf.Clamp(transform.position.x, CamMinZoomValue.x, CamMaxZoomValue.x);
        //pos.z = Mathf.Clamp(transform.position.z, CamMinZoomValue.z, CamMaxZoomValue.z);

        //Camera.main.transform.position = pos;



    }

   
    void TouchInput()
    {
        Vector3 pos = transform.position;
        if (Input.touchCount == 2)
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
                Camera.main.fieldOfView -= zoomValue;

            }

            if(deltaMagnitudeDiff > 0)
            {
                Camera.main.fieldOfView += zoomValue;
            }

            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, CamMinZoomValue, CamMaxZoomValue);

        }
    }
}
