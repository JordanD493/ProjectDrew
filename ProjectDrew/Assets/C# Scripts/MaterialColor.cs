using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MaterialColor : MonoBehaviour
{
    [SerializeField]
    private Material Mat;

    private float time;

    private float ShaderColorValue;
   
    // Use this for initialization
    void Start ()
    {
        ShaderColorValue = -0.75f;
	}
	
	// Update is called once per frame
	void Update ()
    {
       
        time = Time.deltaTime;
        time++;
        ShaderColorValue = Time.deltaTime;
        ShaderColorValue++;

        if(time >= 1)
        {
            Mat.SetFloat("Vector1_A2F82978", ShaderColorValue);
        }
	}
}
