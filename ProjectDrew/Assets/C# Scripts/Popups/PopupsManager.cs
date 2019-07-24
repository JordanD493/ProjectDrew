using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupsManager : MonoBehaviour {

	public void FoldAllPopups()
    {
        foreach (Transform child in transform)
        {
            Animator anim = child.GetComponent<Animator>();
            anim.Play(0, 0, 0);
            anim.Update(0);
        }
    }

    public void UnfoldAllPopups()
    {
        foreach (Transform child in transform)
        {
            Animator anim = child.GetComponent<Animator>();
            anim.Play(0, 0, anim.GetCurrentAnimatorClipInfo(0).Length);
            anim.Update(0);
        }
    }
}
