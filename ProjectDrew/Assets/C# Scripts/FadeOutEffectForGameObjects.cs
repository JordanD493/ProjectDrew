using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutEffectForGameObjects : MonoBehaviour
{
    private MeshRenderer rend;
	// Use this for initialization
	void Start ()
    {
        rend = GetComponentInChildren<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
