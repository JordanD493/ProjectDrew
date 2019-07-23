using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateCamera : MonoBehaviour
{
    Camera cam;

   
    [SerializeField]
    public Transform Target;

    private bool IsRotating = false;
    
    private Quaternion currentRotation;

    private Quaternion newRotation;

    [SerializeField]
    private Vector3 TargetAngle;

    private Vector3 currentAngle;

    [SerializeField]
    private float AngleChange;

    private float MaxAngle;

    // Use this for initialization
    void Start ()
    {
        cam = FindObjectOfType<Camera>();
        cam.transform.LookAt(Target);
        currentAngle = Target.eulerAngles;

    }

    // Update is called once per frame
    void Update ()
    {

        //if(IsRotating == true)
        //{
        //    IsRotating = false;
        //}

    }

    public void RotateToRight()
    {

        newRotation = Quaternion.Euler(new Vector3(Target.rotation.x, Target.rotation.y + TargetAngle.y, Target.rotation.z));

        Target.rotation = Quaternion.Lerp(Target.rotation, newRotation, Time.deltaTime);

       //   Target.rotation = Quaternion.Lerp(cam.transform.rotation,dir, Time.deltaTime );        
        //Target.Rotate(new Vector3(Target.rotation.x , Target.rotation.y + TargetAngle.y, Target.rotation.z )* Time.deltaTime, Space.World);

       

    }

    //public void RotateToLeft()
    //{
    //    //currentAngle = new Vector3(
    //    //    Mathf.LerpAngle(currentAngle.x, TargetAngle.x, Time.deltaTime),
    //    //    Mathf.LerpAngle(currentAngle.y, -TargetAngle.y, Time.deltaTime),
    //    //    Mathf.LerpAngle(currentAngle.z, -TargetAngle.z, Time.deltaTime));

    //    //Target.eulerAngles = currentAngle;

    //    Target.rotation = Quaternion.Lerp(cam.transform.rotation,dir, Time.deltaTime);

    //    //Target.Rotate(new Vector3((Target.rotation.x + TargetAngle.x)*Time.deltaTime*10, (Target.rotation.y - TargetAngle.y) * Time.deltaTime * 10, (Target.rotation.z - TargetAngle.z) * Time.deltaTime * 10), Space.World);
    //}
}
