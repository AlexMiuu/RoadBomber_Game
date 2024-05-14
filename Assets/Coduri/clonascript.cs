using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clonascript : MonoBehaviour
{
    public float moveInput;
    public float fwdSpeed;
    public Rigidbody sphereRB;
    public int treap = 100; 
    public float revSpeed;
    private float turnInput;
    private float NewRotation;
    public float turnSpeed;
    private void Update()
    {
        moveInput = 1f;
        moveInput *= moveInput > 0 ? fwdSpeed : revSpeed; 
        NewRotation = turnInput * turnSpeed * Time.deltaTime;
        transform.position = sphereRB.transform.position;

      
        if (this.transform.position.z > treap)
        {
            fwdSpeed += 5;
            treap += 550;
       
        }
    }
 

}
