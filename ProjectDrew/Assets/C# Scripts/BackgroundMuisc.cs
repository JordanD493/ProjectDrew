using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMuisc : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private static BackgroundMuisc instance = null;
    public static BackgroundMuisc Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
