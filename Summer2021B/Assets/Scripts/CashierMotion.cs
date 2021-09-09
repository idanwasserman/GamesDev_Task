using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class CashierMotion : MonoBehaviour
{
    private Animator animator;
    public Text frameText;
    public Text centerText;
    public GameObject camera;
    public GameObject thePlayer;
    private bool cashierTalked;
    private bool inTalkingArea;
    public GameObject espressoCup;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        inTalkingArea = false;
        cashierTalked = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (inTalkingArea)
        {
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (Input.GetKeyDown(KeyCode.T))
                {
                    StartCoroutine("CashierTalk");

                    frameText.text = "";
                }
            }
        }
    }

    IEnumerator CashierTalk()
    {
        animator.SetInteger("state", 2);
        cashierTalked = true;

        if(thePlayer.GetComponent<PlayerMotion>().coins <= 0)
        {
            centerText.text = "Don't have money?\nI heard that the guy upstairs is giving money for riddle solvers";
        }
        else
        {
            StartCoroutine("MakeCoffee");
            thePlayer.GetComponent<PlayerMotion>().coins--;
        }

        yield return new WaitForSeconds(15f);
        
        animator.SetInteger("state", 0);
        centerText.text = "";
        cashierTalked = false;
    }

    IEnumerator MakeCoffee()
    {
        centerText.text = "One espresso is on the way";
        yield return new WaitForSeconds(7.5f);

        centerText.text = "Here's your coffee.\nEnjoy!";
        espressoCup.SetActive(true);

        yield return new WaitForSeconds(5f);
        centerText.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Player")
            return;

        frameText.text = "Press [T] to talk..."; 
        inTalkingArea = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name != "Player")
            return;

        frameText.text = ""; 
        inTalkingArea = false;
    }

}
