using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(TabInput))]
[RequireComponent(typeof(TabMovement))]
public class RotateTabGlow : MonoBehaviour
{
    [SerializeField] private MeshRenderer glowMesh;
    [SerializeField] private float minGlow = 0.01f;

    private TabInput tabInput;
    private TabMovement tabMovement;

    private Color initialColor;

    private bool lastSwitchAction = false;
    private bool runeGlowMax = false;

    private float maxGlow = 1;

    // Use this for initialization
    void Start()
    {
        tabInput = GetComponent<TabInput>();
        tabMovement = GetComponent<TabMovement>();

        tabInput.SelectionBegin += OnSelectionBegin;
        tabMovement.SnapReached += OnSnapReached;

        initialColor = glowMesh.material.color;
        UpdateGlowAmount(minGlow);
    }

    private void UpdateGlowAmount(float glowAmount)
    {
        glowMesh.material.color = initialColor * glowAmount;
    }

    protected void OnSelectionBegin(object source, EventArgs args)
    {
        UpdateGlowAmount(maxGlow);
    }

    protected void OnSnapReached(object source, EventArgs args)
    {
        UpdateGlowAmount(minGlow);
    }
}
