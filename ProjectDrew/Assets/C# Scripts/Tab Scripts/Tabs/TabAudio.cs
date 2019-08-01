using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(TabInput))]
[RequireComponent(typeof(TabMovement))]
[RequireComponent(typeof(AudioSource))]
public class TabAudio : MonoBehaviour
{

    [Header("On Snap Reached")]
    [SerializeField] private AudioClip clip1;
    [SerializeField, Range(0, 1)] private float volume1 = 1;
    [Header("On Selection Begin")]
    [SerializeField] private AudioClip clip2;
    [SerializeField, Range(0, 1)] private float volume2 = 1;
    [Header("On Release")]
    [SerializeField] private AudioClip clip3;
    [SerializeField, Range(0, 1)] private float volume3 = 1;
    [Header("On Charge Ready")]
    [SerializeField] private AudioClip clip4;
    [SerializeField, Range(0, 1)] private float volume4 = 1;

    private TabInput tabInput;
    private TabMovement tabMovement;
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        tabInput = GetComponent<TabInput>();
        tabMovement = GetComponent<TabMovement>();
        audioSource = GetComponent<AudioSource>();

        tabInput.SelectionBegin += OnSelectionBegin;
        tabInput.SelectionRelease += OnSelectionRelease;
        tabInput.ChargeReady += OnChargeReady;
        tabMovement.SnapReached += OnSnapReached;
    }

    protected void OnSelectionBegin(object source, EventArgs args)
    {
        audioSource.PlayOneShot(clip2, volume2);
    }

    protected void OnChargeReady(object source, EventArgs args)
    {
        audioSource.PlayOneShot(clip4, volume4);
        //onChargeReady.Play();
    }

    protected void OnSelectionRelease(object source, EventArgs args)
    {
        audioSource.PlayOneShot(clip3, volume3);
        //onRelease.Play();
    }

    protected void OnSnapReached(object source, EventArgs args)
    {
        audioSource.PlayOneShot(clip1, volume1);
        //onSnapReached.Play();
        //onMovement.Stop();
    }
}
