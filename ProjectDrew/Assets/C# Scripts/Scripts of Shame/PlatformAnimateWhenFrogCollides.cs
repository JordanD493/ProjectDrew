using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAnimateWhenFrogCollides : MonoBehaviour {

    // ------------------ THIS CODE SHALL NOT BE JUDGED, JAKE MADE ME DO IT --------------------

    [SerializeField] private Animator platformAnimator;
    [SerializeField] private float animationSpeed = 1;

    private bool trigger = false;
    private float time = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Frog")
        {
            platformAnimator.speed = 1;
            trigger = true;
            StartCoroutine(PlayAnimation());
        }
    }

    private IEnumerator PlayAnimation()
    {
        while (time < platformAnimator.GetCurrentAnimatorClipInfo(0).Length)
        {
            time += Time.deltaTime * animationSpeed;
            platformAnimator.Play(0, 0, time);
            yield return null;
        }
    }

    // ----------------------------------------------------------------------------
}
