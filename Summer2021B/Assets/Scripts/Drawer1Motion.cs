using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer1Motion : MonoBehaviour
{

    public Animator animator;
    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
       // animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(!isOpen)
                animator.SetBool("Drawer1isOpen", true);
            else
                animator.SetBool("Drawer1isOpen", false);

            isOpen = !isOpen;
        }
    }
}
