using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer1Motion : MonoBehaviour
{

    public Animator animator;
    public GameObject crossHair;
    public GameObject crossHairTouch;
    public GameObject camera;
    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
       // animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
      
        Physics.Raycast(camera.transform.position, camera.transform.forward, out hit);
        if (hit.transform.gameObject != null && hit.distance < 5)
        {
                if (hit.transform.gameObject == this.gameObject)// we hve focused on THIS
                {
                    crossHair.SetActive(false);
                    crossHairTouch.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {

                        if (!isOpen)
                            animator.SetBool("Drawer1isOpen", true);
                        else
                            animator.SetBool("Drawer1isOpen", false);

                        isOpen = !isOpen;
                    }
                }
            }
       }
      //  else
       // {
       //     crossHair.SetActive(true);
       //     crossHairTouch.SetActive(false);
       // }
    
}
