using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatieobiect02 : MonoBehaviour
{
    // Start is called before the first frame update
    public float viteza = 1;

    private void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.up * viteza);

    }

    void Reintoarcere()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }    
}
