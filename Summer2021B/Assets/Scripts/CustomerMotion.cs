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
        if (!customerTalked && Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
        {
            if (hit.transform.gameObject != null && hit.distance < 5)
            {
                if (this.transform.gameObject == hit.transform.gameObject)
                {
                    if(!talkedAlready)
                    {
                        frameText.text = "Press [E] to talk...";
                    }
                    else
                    {
                        frameText.text = "Press [R] to give object\nPress [E] to talk again";
                    }

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        RotateCustomerToPlayer();
                        StartCoroutine("FirstCustomerTalk");
                        frameText.text = "";
                    }
                    else if(Input.GetKeyDown(KeyCode.R))
                    {
                        // give object
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

    IEnumerator FirstCustomerTalk()
    {
        animator.SetInteger("state", 1);
        customerTalked = true;
        centerText.text = "Sup? Need some change?\nAnswer this riddle:\nWHAT IS FULL OF HOLES BUT STILL HOLDS WATER?";

        yield return new WaitForSeconds(8f);

        animator.SetInteger("state", 0);
        centerText.text = "There are some objects\nin the XXX if you need a hint.";

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
}

