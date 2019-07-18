using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleSSSIntensity : MonoBehaviour {


    public Light _candleLight;
    public float scatterIntensity;
    public Material candleMat;
    public float scatterMultiplier;

    public float minIntensity = 1.5f;
    public float maxIntensity = 2.5f;

    private float random;

    Color initialIntensity;

    // Use this for initialization
    void Start () {
        random = Random.Range(0.0f, 65535.0f);
        scatterIntensity = 0;
        initialIntensity = candleMat.GetColor("_EmissionColor");
    }
	
	// Update is called once per frame
	void Update () {
        scatterIntensity = _candleLight.intensity;
        candleMat.SetColor("_EmissionColor", new Color (191, 86, 0, 1) * (scatterIntensity / scatterMultiplier));

        float noise = Mathf.PerlinNoise(random, Time.time);
        _candleLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
    }

    private void OnApplicationQuit()
    {
        candleMat.SetColor("_EmissionColor", initialIntensity);
    }

}
