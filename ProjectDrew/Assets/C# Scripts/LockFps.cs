using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockFps : MonoBehaviour {

    private void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 30;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
