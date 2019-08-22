using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndGoalMaterialColor : MonoBehaviour
{
    [SerializeField]
    private Material Mat;

    [SerializeField]
    private float AnimationMaxMatTime;

    private float time;

    private float ShaderColorValue;

    private float MaxShaderVaue;

    internal bool IsFading = false;

    internal bool IsFolding = false;
   
    // Use this for initialization
    void Start ()
    {
        ShaderColorValue = 100f;
        MaxShaderVaue = 100f;
	}
	
	// Update is called once per frame
	void Update ()
    {



        if (IsFading == false)
        {
            time += Time.deltaTime;
            if (time >= AnimationMaxMatTime)
            {
                ShaderColorValue--;
                
            }
            Mat.SetFloat("Vector1_A2F82978", ShaderColorValue / MaxShaderVaue);

            if (ShaderColorValue <= -75f)
            {
                ShaderColorValue = -75f;
                time = 0f;
            }

        }

        if (IsFading == true)
        {
            ShaderColorValue++;
            Mat.SetFloat("Vector1_A2F82978", ShaderColorValue / MaxShaderVaue);

            

            if (ShaderColorValue >= 100f)
            {
                ShaderColorValue = 100f;
                IsFolding = true;

            }
        }
    }

  

    private void OnApplicationQuit()
    {
        Mat.SetFloat("Vector1_A2F82978", -0.75f);

    }
}
