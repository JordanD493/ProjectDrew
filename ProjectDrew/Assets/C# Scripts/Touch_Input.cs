using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Touch_Input : MonoBehaviour {

    [SerializeField]
    private Text Message;

    Rigidbody rb;

    [SerializeField]
    private float Acceleration;

    private void Start()
    {

     rb = GetComponent<Rigidbody>();
#if UNITY_EDITOR
        Message.text = "On Windows";
#endif

#if UNITY_IOS
        Message.text = "On IOS";
#endif

    }

#if UNITY_EDITOR
    private void FixedUpdate()
    {
        if (Input.GetKeyDown("m"))
        {
            rb.AddForce(new Vector3(0, 0, 1) * Acceleration);

        }
    }
#endif

#if UNITY_IOS
    private void OnMouseDown()
    {
        Message.text = "Got Touched";

        rb.AddForce(new Vector3(0, 0, 1) * Acceleration);

    }
#endif
   
}
