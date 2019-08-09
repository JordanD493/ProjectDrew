using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBookAnim : MonoBehaviour
{
    
    private Animator anim;

    private MainMenuCamera cam;

    [SerializeField]
    private GameObject Popups;

    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private GameObject Goal;

    [SerializeField]
    private GameObject Particle;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponentInParent<Animator>();
        cam = FindObjectOfType<MainMenuCamera>();
        anim.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
    }

    private void OnMouseDown()
    {
        cam.IsMovementAllowed = true;
        anim.enabled = true;

        Popups.SetActive(true);
        Player.SetActive(true);
        Goal.SetActive(true);
        Particle.SetActive(false);
    }
}
