using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_Touch_Input : MonoBehaviour {

    [SerializeField]
    private Text Message;

    private void OnMouseDown()
    {
        Message.text = "Touched the Screen ";
    }
}
