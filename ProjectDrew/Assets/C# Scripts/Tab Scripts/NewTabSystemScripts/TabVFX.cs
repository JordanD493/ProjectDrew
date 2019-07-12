using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(TabInput))]
public class TabVFX : MonoBehaviour {
    
    [SerializeField] private Color selectedColor;

    private Material material;
    private Color initialColor;
    
    private TabInput tabInput;
    // Use this for initialization
    void Start () {
        tabInput = GetComponent<TabInput>();
        tabInput.SelectionBegin += OnSelectionBegin;
        tabInput.SelectionRelease += OnSelectionRelease;

        material = GetComponent<Renderer>().material;
        initialColor = material.color;
    }

    protected void OnSelectionBegin(object source, EventArgs args)
    {
        material.color = selectedColor;
    }

    protected void OnSelectionRelease(object source, EventArgs args)
    {
        material.color = initialColor;
    }
}
