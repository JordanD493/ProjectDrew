using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMoveAtEndGoal : MonoBehaviour
{
    private bool Is_Moving_Camera = false;

    [SerializeField]
    private Camera Cam;

    [SerializeField]
    private Vector3 FinalCamPosition;

    [SerializeField]
    private GameObject audio1;

    [SerializeField]
    private GameObject audio2;


    // Use this for initialization
    void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Is_Moving_Camera == true)
        {
            MoveCamera();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            print("Reached the End");
           collision.gameObject.SetActive(false);

            Is_Moving_Camera = true;

            audio1.SetActive(false);
            audio2.SetActive(true);


        }
    }

    void MoveCamera()
    {
        Cam.transform.position = new Vector3(FinalCamPosition.x, FinalCamPosition.y, FinalCamPosition.z);
    }

}
