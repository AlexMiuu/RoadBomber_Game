using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatieobiect : MonoBehaviour
{
    public float viteza=1;
 


    void Update()
    {
        transform.Rotate(Vector3.up * viteza);
        
    }
    public void Reintoarcere()
    {
        transform.rotation = Quaternion.Euler(0, -180, 0);
    }
}
