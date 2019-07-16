using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform[] wayPoints;

    [SerializeField]
    private Transform Target;

    [SerializeField]
    private float camMovementSpeed;

    private Camera cam;

    internal int waytoGO;

    internal float tParam;

    private Vector3 camPosition;

    internal bool IsMovementAllowedRight;

    internal bool IsMovementAllowedLeft;


	// Use this for initialization
	void Start ()
    {
        cam = GetComponent<Camera>();

        waytoGO = 0;
       /* tParam = 0*/;
        //IsMovementAllowedRight = true;
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(IsMovementAllowedRight)
        {
            StartCoroutine(FollowTheRightRoute(waytoGO));
        }

        if(IsMovementAllowedLeft)
        {
            StartCoroutine(FollowTheLeftRoute(waytoGO));
        }

        cam.transform.LookAt(Target);
	}

    private IEnumerator FollowTheRightRoute(int wayPointNumber)
    {
        IsMovementAllowedRight = false;

        //if (wayPointNumber > 0)
        //{
        //    wayPointNumber = waytoGO - 1;

        //}

        Vector3 p0 = wayPoints[wayPointNumber].GetChild(0).position;
        Vector3 p1 = wayPoints[wayPointNumber].GetChild(1).position;
        Vector3 p2 = wayPoints[wayPointNumber].GetChild(2).position;
        Vector3 p3 = wayPoints[wayPointNumber].GetChild(3).position;

        while(tParam < 1)
        {
            tParam += Time.deltaTime * camMovementSpeed;

            cam.transform.position = Mathf.Pow(1 - tParam, 3) * p0 +
                            3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                            3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                            Mathf.Pow(tParam, 3) * p3;
            yield return new WaitForEndOfFrame();   

        }

      
        tParam = 0f;


        waytoGO += 1;

        if (waytoGO > wayPoints.Length - 1 )
        {
            waytoGO = 0;
        }

        

        //IsMovementAllowed = true;
        //IsMovementAllowed = false;

       

    }

    private IEnumerator FollowTheLeftRoute(int wayPointNumber)
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

        while (tParam < 1)
        {
            tParam += Time.deltaTime * camMovementSpeed;

            cam.transform.position = Mathf.Pow(1 - tParam, 3) * p3 +
                            3 * Mathf.Pow(1 - tParam, 2) * tParam * p2 +
                            3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p1 +
                            Mathf.Pow(tParam, 3) * p0;

            yield return new WaitForEndOfFrame();
        }

        tParam = 0f;

        waytoGO -= 1;

        if (waytoGO > wayPoints.Length - 1)
        {
            waytoGO = 0;
        }

        //IsMovementAllowed = true;
        //IsMovementAllowed = false;

    }
}
