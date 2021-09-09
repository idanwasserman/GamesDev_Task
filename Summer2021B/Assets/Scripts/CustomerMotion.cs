using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerMotion : MonoBehaviour
{
    private Animator animator;
    public Text frameText;
    public Text centerText;
    public GameObject camera;
    public GameObject thePlayer;
    private bool customerTalked = false;
    private bool talkedAlready = false;
    public GameObject playersSponge;
    private bool inTalkingArea = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
                //if (hit.transform.gameObject.name == "Customer")
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        RotateCustomerToPlayer();
                        StartCoroutine("FirstCustomerTalk");
                        frameText.text = "";
                    }
                    else if (Input.GetKeyDown(KeyCode.R))
                    {
                        if (playersSponge.activeInHierarchy)
                        {
                            playersSponge.SetActive(false);
                            centerText.text = "SPONGE is the right answer!\nHere's your money as promised.";
                            thePlayer.GetComponent<PlayerMotion>().coins++;
                        }
                        else
                        {
                            centerText.text = "You've got nothing";
                        }
                    }
                }
            }
        }

    }
    
    IEnumerator FirstCustomerTalk()
    {
        animator.SetInteger("state", 1);
        customerTalked = true;
        centerText.text = "Sup? Need some change?\nAnswer this riddle:\nWHAT IS FULL OF HOLES BUT STILL HOLDS WATER?";

        yield return new WaitForSeconds(8f);

        animator.SetInteger("state", 0);
        centerText.text = "There are some objects hidden inside\nif you need a hint.";

        yield return new WaitForSeconds(8f);

        centerText.text = "";
        customerTalked = false;
        talkedAlready = true;
    }

    

    private void RotateCustomerToPlayer()
    {
        Vector3 playerPos = thePlayer.transform.position;
        Vector3 npcPos = gameObject.transform.position;
        Vector3 delta = new Vector3(playerPos.x - npcPos.x, 0.0f, playerPos.z - npcPos.z);
        Quaternion rotation = Quaternion.LookRotation(delta);
        this.gameObject.transform.rotation = rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Player")
            return;

        if (!talkedAlready)
        {
            frameText.text = "Press [E] to talk...";
        }
        else
        {
            frameText.text = "Press [R] to give object\nPress [E] to talk again";
        }

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

