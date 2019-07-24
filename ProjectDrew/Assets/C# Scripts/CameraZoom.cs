using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{    
    [SerializeField]
    private Vector3 zoomValue;

    [SerializeField]
    private Vector3 CamMaxZoomValue;

    [SerializeField]
    private Vector3 CamMinZoomValue;
   


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


            transform.position = new Vector3(transform.position.x + zoomValue.x*Time.deltaTime,
                                                         transform.position.y + zoomValue.y*Time.deltaTime,
                                                         transform.position.z - zoomValue.z*Time.deltaTime);

            //pos.z = Mathf.Clamp(pos.z, CamMinZoomValue.z, CamMaxZoomValue.z);
            //pos.y = Mathf.Clamp(pos.y, CamMinZoomValue.y, CamMaxZoomValue.y);
            //pos.x = Mathf.Clamp(pos.x, CamMinZoomValue.x, CamMaxZoomValue.x);

            //transform.position = pos;

           
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {


            transform.position = new Vector3(transform.position.x - zoomValue.x * Time.deltaTime,
                                                          transform.position.y - zoomValue.y * Time.deltaTime,
                                                          transform.position.z + zoomValue.z * Time.deltaTime);


            pos.z = Mathf.Clamp(transform.position.z, CamMinZoomValue.z, CamMaxZoomValue.z);
            pos.y = Mathf.Clamp(transform.position.y, CamMinZoomValue.y, CamMaxZoomValue.y);
            pos.x = Mathf.Clamp(transform.position.x, CamMinZoomValue.x, CamMaxZoomValue.x);

            //transform.position = pos;


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
