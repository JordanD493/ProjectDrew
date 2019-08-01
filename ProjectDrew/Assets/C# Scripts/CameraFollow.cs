using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform[] wayPoints;

    [SerializeField]
    private Transform Target;

    [SerializeField]
    private float camMovementSpeed;

    [SerializeField]
    private Text CamPositionText;

    private Camera cam;

    internal int waytoGO;

    internal float tParam;

    private Vector3 camCurrentPosition;

    internal bool IsMovementAllowedRight;

    internal bool IsMovementAllowedLeft;

    private bool IsLerping;

    private float TimeStartLerping;

    private Vector3 p0;

    private Vector3 p3;

    private CamButtonClick camButtonClick;

    private float WayPointValue;

    // Use this for initialization
    void Start ()
    {
        cam = GetComponent<Camera>();
        camButtonClick = FindObjectOfType<CamButtonClick>();
    

        waytoGO = 0;

        

    }



    // Update is called once per frame
    void Update ()
    {

        if (IsMovementAllowedLeft)
        {
           StartCoroutine( FollowTheLeftRoute(waytoGO,  camButtonClick.lastTvalue));
        }

        
		if(IsMovementAllowedRight)
        {
            // only if mouse was relea
            StartCoroutine( FollowTheRightRoute(waytoGO, camButtonClick.lastTvalue));
            

        }
      
        cam.transform.LookAt(Target);
        camCurrentPosition = cam.transform.position;

        //CamPositionText.text = camCurrentPosition.ToString();

        WayPointValue = camButtonClick.lastTvalue;
        

    }



    private IEnumerator FollowTheRightRoute(int wayPointNumber, float wayPointValue)
    {
        IsMovementAllowedRight = false;

      


        Vector3 p0 = wayPoints[wayPointNumber].GetChild(0).position;
        Vector3 p1 = wayPoints[wayPointNumber].GetChild(1).position;
        Vector3 p2 = wayPoints[wayPointNumber].GetChild(2).position;
        Vector3 p3 = wayPoints[wayPointNumber].GetChild(3).position;


        tParam = wayPointValue;
      
        while (tParam < 1)
        {
            tParam += Time.deltaTime * camMovementSpeed;

            //p0 = camCurrentPosition;
            cam.transform.position =  Mathf.Pow(1 - tParam, 3) * p0 +
                                     3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                                     3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                                     Mathf.Pow(tParam, 3) * p3;

            //if (Input.GetMouseButtonUp(0))
            //{
            //    tParam = 1;
            //}

            yield return new WaitForEndOfFrame();
        }


        // p0 = camCurrentPosition;





        waytoGO += 1;

        if (waytoGO > wayPoints.Length - 1)
        {
            waytoGO = 0;
            tParam = 0;

        }



        //IsMovementAllowedRight = true;
        //IsMovementAllowed = false;


    }

    private IEnumerator FollowTheLeftRoute(int wayPointNumber, float wayPointValue)
    {
        IsMovementAllowedLeft = false;

        if (wayPointNumber > 0)
        {
            wayPointNumber = waytoGO - 1;

        }

        Vector3 p0 = wayPoints[wayPointNumber].GetChild(0).position;
        Vector3 p1 = wayPoints[wayPointNumber].GetChild(1).position;
        Vector3 p2 = wayPoints[wayPointNumber].GetChild(2).position;
        Vector3 p3 = wayPoints[wayPointNumber].GetChild(3).position;

        tParam = wayPointValue; 


        while (tParam < 1)
        {
           
            tParam -= Time.deltaTime * camMovementSpeed;

            cam.transform.position = Mathf.Pow(1 - tParam, 3) * p0 +
                            3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                            3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                            Mathf.Pow(tParam, 3) * p3;

            

            yield return new WaitForEndOfFrame();
        }



        waytoGO += 1;

        if (waytoGO > wayPoints.Length - 1)
        {
            waytoGO = 0;
            tParam = 0;
        }

        //IsMovementAllowedLeft = true;
        //IsMovementAllowed = false;

    }
}
