using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coincollecter : MonoBehaviour
{
 
    public bool ok;
    int coin = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Ban")
            Destroy(other.gameObject);
           coin++;  
       
    }
  
    void OnGUI()
    {
        GUI.Label(new Rect(100, 100, 300,300), "Coin: "+coin);

    }
    
}
