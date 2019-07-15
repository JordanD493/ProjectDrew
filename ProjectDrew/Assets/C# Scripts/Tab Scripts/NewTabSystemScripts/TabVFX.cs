using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(TabInput))]
[RequireComponent(typeof(TabMovement))]
public class TabVFX : MonoBehaviour {
    
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color snappingColor;

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
    }

    protected void OnSelectionBegin(object source, EventArgs args)
    {
        material.color = selectedColor;
    }

    protected void OnSelectionRelease(object source, EventArgs args)
    {
        material.color = snappingColor;
    }

    protected void OnSnapReached(object source, EventArgs args)
    {
        material.color = initialColor;
    }
}
