using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NEWCARSCRIPT : MonoBehaviour
{
    //fix rotation of car
    //fix gravity of car

    //raycast

    public float moveInput;
    public float turnInput;
    private bool isCarGrounded;

    public float airDrag;
    public float groundDrag;

    public float fwdSpeed;
    public float revSpeed;
    public float turnSpeed;

    public Rigidbody sphereRB;
    public int treap = 100;

    private float NewRotation;
    public Joystick joy;
    private Button pp;

    private float newmovement;
    private float moveInput2;

    void Start()
    {
        //detach rigidbody from car
        sphereRB.transform.parent = null;
        PlayerPrefs.SetInt("Treapta", treap);
    }

    void Update()
    {
        moveInput = 1f;
        if (Time.timeScale == 0)
        {
            turnInput = 0;
            NewRotation = 0;
        }
        else
        { 
            turnInput = joy.Horizontal;     
            moveInput2 = joy.Vertical;
        }
    
        /*
        // turnInput = Mathf.Clamp(turnInput, -90, 90);
        moveInput *= moveInput > 0 ? fwdSpeed : revSpeed;

        //set cars position to sphere
        transform.position = sphereRB.transform.position;

        //set cars rotation
        NewRotation = turnInput * turnSpeed * Time.deltaTime;                      
        transform.Rotate(0, NewRotation, 0, Space.World);
        */


        moveInput *= moveInput > 0 ? fwdSpeed : revSpeed;
        transform.position = sphereRB.transform.position;
        NewRotation = turnInput * turnSpeed * Time.smoothDeltaTime;
        transform.Rotate(0, NewRotation, 0, Space.World);


        


        // raycast ground check
        RaycastHit hit;
        int groundLayer = 1;
        isCarGrounded = Physics.Raycast(transform.position, -transform.up, out hit, groundLayer);

        transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;

        if (isCarGrounded)
        {
            sphereRB.drag = groundDrag;
        }
        else
        {
            sphereRB.drag = airDrag;
        }

        if (this.transform.position.z > treap)
        {
            if (PlayerPrefs.GetInt("Treapta") >= 1750)
            {
                fwdSpeed += 0;
            }
            else
            {
                fwdSpeed += 2;
                treap += 250;
               // turnSpeed += 5;
                PlayerPrefs.SetInt("Treapta", treap);
                PlayerPrefs.SetFloat("TreaptaViteza", fwdSpeed);
            }
        }
        

    }


    private void FixedUpdate()
    {
        if (isCarGrounded)
        {
            //move car
            //sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
            newmovement = moveInput * Time.smoothDeltaTime;
            sphereRB.transform.position += transform.forward * newmovement;
        }
        else
        {
            //add extra gravity
            sphereRB.AddForce(transform.up * -10);

        }
    }


}

