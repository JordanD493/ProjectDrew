using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversePlayAnimationForProps : MonoBehaviour
{
    private Animator anim;
    private MaterialColor Mat;

    [SerializeField]
    private GameObject Transition;

    private float time;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        Mat = FindObjectOfType<MaterialColor>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Mat.IsFolding == true)
        {
            anim.SetBool("IS_Folding", true);
            //anim.Play(0, 0, 0);

            anim.SetFloat("Speed", -1.0f);
            time += Time.deltaTime; 

        }

        if(time >= 3f)
        {
            Transition.SetActive(true);

        }
        
	}
}
