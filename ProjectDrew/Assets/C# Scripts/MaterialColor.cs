using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MaterialColor : MonoBehaviour
{
    [SerializeField]
    private Material Mat;

    private float time;

    private float ShaderColorValue;

    private float MaxShaderVaue;
   
    // Use this for initialization
    void Start ()
    {
        ShaderColorValue = -75f;
        MaxShaderVaue = 100f;
	}
	
	// Update is called once per frame
	void Update ()
    {
       
        time = Time.deltaTime;
        time++;
        

        if(time >= 1)
        {
            ShaderColorValue++;
            Mat.SetFloat("Vector1_A2F82978", ShaderColorValue/MaxShaderVaue);

            if(ShaderColorValue >=100f)
            {
                ShaderColorValue = 100f;
            }
        }
	}

    private void OnApplicationQuit()
    {
        Mat.SetFloat("Vector1_A2F82978", -0.75f);

    }
}
