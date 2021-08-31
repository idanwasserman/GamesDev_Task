using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashierMotion : MonoBehaviour
{
    private Animator animator;
    public Text frameText;
    public Text centerText;
    public GameObject camera;
    private bool cashierTalked = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        // check what object is in the camera's focus
        if(!cashierTalked && Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
        {         
            if(hit.transform.gameObject != null && hit.distance < 5)
            {
                if (this.transform.gameObject == hit.transform.gameObject)
                {
                    frameText.text = "Press [E] to talk...";

                    
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        CashierTalk();
                    }
                }
            }
        }
    }

    private void CashierTalk()
    {
        animator.SetInteger("state", 2);
        cashierTalked = true;
        
        centerText.text = "How can I help you?";
        centerText.gameObject.SetActive(true);
    }


}
