using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMotion : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // need to check that player is the collider
        animator.SetBool("isOpen", true);
    }

    private void OnTriggerExit(Collider other)
    {
        // need to check that player is the collider
        animator.SetBool("isOpen", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
