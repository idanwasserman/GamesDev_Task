using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    private float speed = 3,angularSpeed = 25;
    private CharacterController controller;
    private float rotationAboutY = 0,rotationAboutX = 0;
    public GameObject camera; // publics must be initialized in Unity
    private AudioSource stepSound;
    private float stepDiff = 0.025f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        stepSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float dx, dy=-1/*kind of a gravity*/, dz;

        // rotation about Y
        rotationAboutY += Input.GetAxis("Mouse X") * angularSpeed * Time.deltaTime;
        transform.localEulerAngles = new Vector3(0, rotationAboutY, 0);

        // rotation about X
        rotationAboutX -= Input.GetAxis("Mouse Y") * angularSpeed * Time.deltaTime;
        camera.transform.localEulerAngles = new Vector3(rotationAboutX, 0, 0);

        // moving forward/backward/left/right
        dz = Input.GetAxis("Vertical"); // can be -1, 0 , 1
        dz *= speed * Time.deltaTime;

        dx = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        Vector3 motion = new Vector3(dx, dy, dz); // in Local coordinates
        motion = transform.TransformDirection(motion);// change to Global coordinates
        controller.Move(motion);//in Global coordinates

        if(dx > stepDiff || dx < -stepDiff || dz > stepDiff || dz < -stepDiff)
        {
            if(!stepSound.isPlaying)
            {
                stepSound.Play();
            }
        }

    }
}
