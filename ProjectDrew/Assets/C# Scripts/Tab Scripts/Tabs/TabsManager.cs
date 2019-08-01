﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TabsManager : MonoBehaviour {
    
    [SerializeField] private CrystallBallInput crystalBall;
    [Header("")]
    [SerializeField] private List<TabParticleEffects> importantTabs;

    // Use this for initialization
    void Start () {
        crystalBall.CrystalBallTouch += OnCrystalBallTouch;
	}

    protected void OnCrystalBallTouch(object source, EventArgs args)
    {
        foreach  (TabParticleEffects tabVFX in importantTabs)
        {
            tabVFX.HighlightAsHint();
        }
    }
}
