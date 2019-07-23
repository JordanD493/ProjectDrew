using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_Objects_Ipad : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

//#if UNITY_IOS
//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.touchCount > 0)
//        {
//            Touch touch = Input.GetTouch(0);

//            // Move the cube if the screen has the finger moving.
//            if (touch.phase == TouchPhase.Moved)
//            {
               
//            }

//        }
//    }
//#endif

    private void OnMouseOver()
    {
        Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(this.transform.position.x, this.transform.position.y, 10));

        transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);
    }
}
