using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(TabInput))]
[RequireComponent(typeof(TabMovement))]
public class TabVFX : MonoBehaviour {
    
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color snappingColor;
    [SerializeField] private ParticleSystem snapReachedParticleEffect;
    [SerializeField] private ParticleSystem movementParticleEffect;
    [SerializeField] private ParticleSystem releaseParticleEffect;


    private Material material;
    private Color initialColor;
    
    private TabInput tabInput;
    private TabMovement tabMovement;
    // Use this for initialization
    void Start () {
        tabInput = GetComponent<TabInput>();
        tabMovement = GetComponent<TabMovement>();

        tabInput.SelectionBegin += OnSelectionBegin;
        tabInput.SelectionRelease += OnSelectionRelease;
        tabMovement.SnapReached += OnSnapReached;

        material = GetComponent<Renderer>().material;
        initialColor = material.color;

        movementParticleEffect.Stop();
    }

    protected void OnSelectionBegin(object source, EventArgs args)
    {
        material.color = selectedColor;
        movementParticleEffect.Play();
    }

    protected void OnSelectionRelease(object source, EventArgs args)
    {
        material.color = snappingColor;
        releaseParticleEffect.Play();
    }

    protected void OnSnapReached(object source, EventArgs args)
    {
        material.color = initialColor;
        snapReachedParticleEffect.Play();
        movementParticleEffect.Stop();
    }
}
