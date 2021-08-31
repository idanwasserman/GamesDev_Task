using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMotion : MonoBehaviour
{
    private Animator animator;
    //private AudioSource doorSound;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //doorSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // need to check that player is the collider
        animator.SetBool("isOpen", true);
        //doorSound.PlayDelayed(0.5f);
    }

    private void OnTriggerExit(Collider other)
    {
        // need to check that player is the collider
        animator.SetBool("isOpen", false);
        //doorSound.PlayDelayed(1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
