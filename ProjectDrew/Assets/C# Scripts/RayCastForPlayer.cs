using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastForPlayer : MonoBehaviour
{
    [SerializeField]
    private float distance;

    private Player_Movement player;
	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<Player_Movement>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Raycast();	
	}

    private void RayEmitter()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * (distance), Color.red);
    }

    private void Raycast()
    {
        RayEmitter();
      
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.left, out hit, distance))
        {
           

            if(hit.collider.gameObject.tag == "Wall")
            {
                player.RotatePlayerAround();
            }


        }

         
       
        //if (Physics.Raycast(transform.position, , out hit, distance))
        //{
        //        print("Found an object - distance: " + hit.distance);

        //        if (hit.collider.gameObject.tag == "ResetWall")
        //        {
        //            player.RotatePlayeToOrigialPosition();
        //        }

        //}

      


    }
}
