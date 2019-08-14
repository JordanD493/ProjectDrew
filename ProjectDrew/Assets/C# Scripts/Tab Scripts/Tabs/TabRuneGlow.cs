using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(TabInput))]
[RequireComponent(typeof(TabMovement))]
public class TabRuneGlow : MonoBehaviour
{

    [SerializeField] private float runeGlowChangeSpeed = 2;
    [SerializeField, Range(0, 1)] private float minGlow = 0.2f;

    private TabInput tabInput;
    private TabMovement tabMovement;
    private Material material;

    private bool lastSwitchAction = false;
    private float runeGlowAmount;
    private bool runeGlowMax = false;

    // Use this for initialization
    void Start()
    {
        tabInput = GetComponent<TabInput>();
        tabMovement = GetComponent<TabMovement>();
        material = GetComponent<Renderer>().material;

        tabInput.SelectionBegin += OnSelectionBegin;
        tabInput.SelectionRelease += OnSelectionRelease;
        tabInput.ChargeReady += OnChargeReady;
        tabMovement.SnapReached += OnSnapReached;

        runeGlowAmount = minGlow;
        UpdateGlowAmount();
    }

    private void Update()
    {
        if (runeGlowMax)
        {
            runeGlowAmount = 0.8f + (Mathf.Sin(Time.time * runeGlowChangeSpeed) / 5);
            UpdateGlowAmount();
        }
    }

    private void UpdateGlowAmount()
    {
        material.SetFloat("Vector1_96B6E2AB", runeGlowAmount);
    }

    IEnumerator RuneGlowSwitch(bool switchedOn)
    {
        if (switchedOn)
        {
            while (runeGlowAmount < 0.9f && lastSwitchAction == true)
            {
                runeGlowAmount += Time.deltaTime * runeGlowChangeSpeed;
                UpdateGlowAmount();
                yield return null;
            }
            if (runeGlowAmount >= 0.9f)
            {
                runeGlowMax = true;

                // !!!!!!!!!!!!! warning, this next line of code is currently deadly. DO NOT UNCOMMENT IT !!!!!!!!!!!!!!!!!!!!!!!!!!!
                //StartCoroutine(GlowFluctuation());
            }
        }
        else
        {
            runeGlowMax = false;
            while (runeGlowAmount > minGlow && lastSwitchAction == false)
            {
                runeGlowAmount -= Time.deltaTime * runeGlowChangeSpeed;
                UpdateGlowAmount();
                yield return null;
            }
            runeGlowAmount = minGlow;
        }
        yield return null;
    }

    // DEADLY, DO NOT USE THIS FUNCTION
    //IEnumerator GlowFluctuation()
    //{
    //    while (runeGlowMax)
    //    {
    //        runeGlowAmount = 1 + Mathf.Sin(Time.deltaTime);
    //        UpdateGlowAmount();
    //    }
    //    yield return null;
    //}

    protected void OnSelectionBegin(object source, EventArgs args)
    {
        lastSwitchAction = true;
        StartCoroutine(RuneGlowSwitch(true));
    }

    protected void OnChargeReady(object source, EventArgs args)
    {
    }

    protected void OnSelectionRelease(object source, EventArgs args)
    {

    }

    protected void OnSnapReached(object source, EventArgs args)
    {
        lastSwitchAction = false;
        StartCoroutine(RuneGlowSwitch(false));
    }
}
