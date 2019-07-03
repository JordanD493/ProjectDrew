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
    }

    private void OnMouseDown()
    {
        Message.text = "Got Touched";

        rb.AddForce(new Vector3(0, 0, 1) * Acceleration);

    }
}
