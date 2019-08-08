using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(TabInput))]
[RequireComponent(typeof(TabMovement))]
public class TabParticleEffects : MonoBehaviour
{

    [Header("Particles")]
    //[SerializeField] private Color selectedColor;
    //[SerializeField] private Color snappingColor;
    [SerializeField] private ParticleSystem onSnapReached;
    [SerializeField] private ParticleSystem onMovement;
    [SerializeField] private ParticleSystem onRelease;
    [SerializeField] private ParticleSystem onChargeReady;
    [SerializeField] private ParticleSystem onHint;

    [Header("")]
    [SerializeField] private CameraShake cameraShake;
    [SerializeField] private float shakeDuration = 0.1f;
    [SerializeField] private float shakeMagnitude = 0.1f;
    [SerializeField] private float shakeSpeed = 1.0f;

    private Material material;

    private bool runeActive;
    private float visibilityValue = 0;
    
    private TabInput tabInput;
    private TabMovement tabMovement;

    // Use this for initialization
    void Start()
    {
        tabInput = GetComponent<TabInput>();
        tabMovement = GetComponent<TabMovement>();

        tabInput.SelectionBegin += OnSelectionBegin;
        tabInput.SelectionRelease += OnSelectionRelease;
        tabInput.ChargeReady += OnChargeReady;
        tabMovement.SnapReached += OnSnapReached;

        material = GetComponent<Renderer>().material;
        //initialColor = material.color;
    }

    protected void OnSelectionBegin(object source, EventArgs args)
    {
        //material.color = selectedColor;
        onMovement.Play();
        runeActive = true;
    }

    protected void OnChargeReady(object source, EventArgs args)
    {
        onChargeReady.Play();
    }

    protected void OnSelectionRelease(object source, EventArgs args)
    {
        //material.color = snappingColor;
        onRelease.Play();

    }

    protected void OnSnapReached(object source, EventArgs args)
    {
        //material.color = initialColor;
        onSnapReached.Play();
        onMovement.Stop();

        if (cameraShake != null)
        {
            StartCoroutine(cameraShake.Shake(shakeDuration, shakeMagnitude, shakeSpeed));
        }

        runeActive = false;
    }

    public void HighlightAsHint()
    {
        onHint.Play();
    }
}
