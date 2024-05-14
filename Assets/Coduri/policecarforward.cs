using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class policecarforward : MonoBehaviour
{
    public float velocitate;
    private void Start()
    {
        Destroy(this.gameObject,5.2f);
    }
    void Update()
    {
       transform.position += transform.forward * velocitate * Time.deltaTime;
    }
    
}
