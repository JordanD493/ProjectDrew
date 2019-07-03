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
#if UNITY_EDITOR
        Message.text = "On Windows";
#endif

#if UNITY_IOS
        Message.text = "On IOS";
#endif
    }

    //private void OnMouseDown()
    //{
    //    Message.text = "Got Touched";

    //    rb.AddForce(new Vector3(0, 0, 1) * Acceleration);

    //}

    //private void OnMouseDrag()
    //{
    //    rb.transform.position = new Vector3(1, 1, 1);
    //}

    //private void OnMouseOver()
    //{
    //    Message.text = "HoverOver";
    //}
}
