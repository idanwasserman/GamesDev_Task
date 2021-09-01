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
    public GameObject thePlayer;
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
        float playerYpos = thePlayer.transform.position.y;
        float npcYpos = this.transform.position.y;
        float diffYpos = playerYpos - npcYpos;

        // check what object is in the camera's focus
        if (!cashierTalked && Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
        {
            if (hit.transform.gameObject != null && hit.distance < 5)
            {
                if (this.transform.gameObject == hit.transform.gameObject)
                {
                    frameText.text = "Press [E] to talk...";
                    
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        StartCoroutine("CashierTalk");

                        frameText.text = "";
                    }
                }
                else
                {
                    if (diffYpos > -1 && diffYpos < 1)
                    {
                        frameText.text = "";
                    }
                }
            }
        }
    }

    IEnumerator CashierTalk()
    {
        animator.SetInteger("state", 2);
        cashierTalked = true;
        centerText.text = "Don't have money?\nI heard that the guy upstairs is giving money for riddle solvers";

        yield return new WaitForSeconds(15f);
        
        animator.SetInteger("state", 0);
        centerText.text = "";
        cashierTalked = false;
    }


}
