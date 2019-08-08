using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(TabInput))]
[RequireComponent(typeof(TabMovement))]
[RequireComponent(typeof(AudioSource))]
public class TabAudio : MonoBehaviour
{
    [Header("One shot audio source")]
    [Tooltip("Drag here the non-looping audio source attaced to this tab.")]
    [SerializeField] private AudioSource oneshotSource;
    [Header("On Snap Reached")]
    [SerializeField] private AudioClip clip1;
    [SerializeField, Range(0, 1)] private float volume1 = 1;
    [Header("On Selection")]
    [SerializeField] private AudioClip clip2;
    [SerializeField, Range(0, 1)] private float volume2 = 1;
    [Header("On Release")]
    [SerializeField] private AudioClip clip3;
    [SerializeField, Range(0, 1)] private float volume3 = 1;
    [Header("On Charge Ready")]
    [SerializeField] private AudioClip clip4;
    [SerializeField, Range(0, 1)] private float volume4 = 1;

    [Header("")]
    [Header("Looping audio source")]
    [Tooltip("This should be a different audio source. Each tab needs to have two audio sources, one set as looping and one not.")]
    [SerializeField] private AudioSource loopingSource;
    [Header("On Movement")]
    [SerializeField] private AudioClip clip5;
    [SerializeField, Range(0, 1)] private float volume5 = 1;

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

        loopingSource.clip = clip5;
    }

    protected void OnSelectionBegin(object source, EventArgs args)
    {
        oneshotSource.PlayOneShot(clip2, volume2);
    }

    protected void OnChargeReady(object source, EventArgs args)
    {
        oneshotSource.PlayOneShot(clip4, volume4);
        loopingSource.Play();
    }

    protected void OnSelectionRelease(object source, EventArgs args)
    {
        oneshotSource.PlayOneShot(clip3, volume3);
    }

    protected void OnSnapReached(object source, EventArgs args)
    {
        oneshotSource.PlayOneShot(clip1, volume1);
        loopingSource.Stop();
    }
}
