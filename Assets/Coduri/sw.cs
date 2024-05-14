using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class sw : MonoBehaviour
{
    public Button interact;
    public int i;
    /*
     void Start()
    {
        StartCoroutine(Delay());
    }
    */
    private void Update()
    {
        if(i==0)
            {
                StartCoroutine(Delay());
            i = 1;
            }
    }
    public IEnumerator Delay()
    {
        float durata=0;
        while (durata < 6)
        {
            durata += Time.deltaTime;
            interact.interactable = false;
            yield return null;
        }
        interact.interactable = true;
       // StopCoroutine("Delay");
        
    }
    public void ii()
    {
        i=0;
    }
}
