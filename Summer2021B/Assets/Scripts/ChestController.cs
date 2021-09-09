using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestController : MonoBehaviour
{
    public Text frameText;
    public Text centerText;
    private bool isDrawer1Open = false;
    private bool isTrigger = false;
    private bool isSpongePicked = false;
    public Animator animator;
    public GameObject sponge;
    public GameObject playersSponge;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrigger)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                isDrawer1Open = !isDrawer1Open;
                animator.SetBool("Drawer1isOpen", isDrawer1Open);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform.gameObject.name == "Drawer1" && isDrawer1Open)
                {
                    if(!isSpongePicked)
                    {
                        centerText.text = "You have collected a sponge";
                        sponge.SetActive(false);
                        playersSponge.SetActive(true);
                        isSpongePicked = true;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDrawer1Open)
        {
            frameText.text = "Press [1] to close drawer1";
        }
        else
        {
            frameText.text = "Press [1] to open drawer1";
        }

        isTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        frameText.text = "";
        isTrigger = false;
    }
}
