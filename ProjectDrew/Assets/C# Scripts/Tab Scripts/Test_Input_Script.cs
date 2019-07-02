
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test_Input_Script : MonoBehaviour {

    private Vector3 position;
    private float width;
    private float height;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if(Input.touchCount >0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;
                pos.x = (pos.x - width) / width;
                pos.y = (pos.y - height) / height;
                position = new Vector3(-pos.x, pos.y, 0.0f);

                // Position the cube.
                transform.position = position;
            }
        }
    }
}
