using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Touch_Input : MonoBehaviour {

    [SerializeField]
    private Text Message;

    private void OnMouseDown()
    {
        Message.text = "Got Touched";
    }
}
