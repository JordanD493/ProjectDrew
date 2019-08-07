using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversePlayAnimationForProps : MonoBehaviour
{
    private Animator anim;
	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
       

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            anim.SetBool("IS_Folding", true);
            

        }
        //anim.speed = -1;
	}
}
