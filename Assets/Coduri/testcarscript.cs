using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcarscript : MonoBehaviour
{
    public float viteza = 2;
    private Rigidbody rbb;
    void Start()
    {
        rbb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float orizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 mobile = new Vector3(orizontal, 0.0f, vertical);

        rbb.AddForce(mobile * viteza);
    }
}
