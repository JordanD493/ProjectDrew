using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour {

    [SerializeField]
    private Transform[] wayPoints;

    [SerializeField]
    private Transform Target;

    [SerializeField]
    private float camMovementSpeed;

    [SerializeField]
    private float RotX;

    [SerializeField]
    private float RotY;

    [SerializeField]
    private float RotZ;

    private Camera cam;

    internal int waytoGO;

    internal float tParam;

    private Vector3 camCurrentPosition;

    Vector3 p0;

    private bool Is_Cam_Rotating = false;

     internal bool IsMovementAllowed;
    // Use this for initialization
    void Start()
    {
        cam = GetComponent<Camera>();
       

        waytoGO = 0;

        cam.transform.rotation = Quaternion.Euler(0, 0, 0);

        //Target = Camera.main.transform;
        //cam.transform.LookAt(Target);
        
    }



    // Update is called once per frame
    void Update()
    {

         if(IsMovementAllowed == true)
        {
            StartCoroutine(FollowTheRightRoute(waytoGO));

           

        }

      


        cam.transform.LookAt(Target);

       if(Is_Cam_Rotating == true)
        {
            cam.transform.rotation = Quaternion.Euler(RotX, RotY, RotZ);
        }

        //cam.transform.rotation = Quaternion.LookRotation();

    }



    private IEnumerator FollowTheRightRoute(int wayPointNumber)
    {
        IsMovementAllowed = false;

        p0 = wayPoints[wayPointNumber].GetChild(0).position;
        Vector3 p1 = wayPoints[wayPointNumber].GetChild(1).position;
        Vector3 p2 = wayPoints[wayPointNumber].GetChild(2).position;
        Vector3 p3 = wayPoints[wayPointNumber].GetChild(3).position;





        while (tParam < 1)
        {

            tParam += Time.deltaTime * camMovementSpeed;
            //cam.transform.LookAt(Target);
            //p0 = camCurrentPosition;
            cam.transform.position = Mathf.Pow(1 - tParam, 3) * p0 +
                                     3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                                     3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                                     Mathf.Pow(tParam, 3) * p3;

            //cam.transform.rotation = Quaternion.Euler(0, 0, 0);

            cam.transform.rotation = Quaternion.LookRotation(p0);


            //    //cam.transform.rotation = Target.rotation;


            //if (tParam >= 0.02f)
            //{

            //}    



            yield return new WaitForEndOfFrame();
            
        }



        tParam = 0;

        waytoGO += 1;

        if (waytoGO > wayPoints.Length - 1)
        {
            waytoGO = 0;

            Is_Cam_Rotating = true;
        }






    }

  
}
