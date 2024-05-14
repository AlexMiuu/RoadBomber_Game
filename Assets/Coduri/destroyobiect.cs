using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyobiect : MonoBehaviour
{
    public GameObject m1;
    public GameObject m2;
    public GameObject m3;
    public GameObject m4;
    public GameObject m5;
    public GameObject m01;
    public GameObject m02;
    public GameObject m03;
    public GameObject m04;
    public GameObject m05;
    public GameObject m06;
    public GameObject m07;
    public GameObject tutorial;
    public GameObject bot1;
    void Start()
    {
        
        Time.timeScale = 1;
        tutorial.SetActive(true);
        StartCoroutine(disablee());
        if(PlayerPrefs.GetInt("primadata")==1)
        {
            Destroy(tutorial.gameObject);
        }
    }
    IEnumerator disablee()
    {
        float min = 0;
        while(min<2)
        {
            min += Time.deltaTime;
            yield return null;
        }
        Destroy(m1);
        Destroy(m3);
        Destroy(m2);
        Destroy(m4);
        Destroy(m5);
        Destroy(m01);
        Destroy(m02);
        Destroy(m03);
        Destroy(m04);
        Destroy(m05);
        Destroy(m06);
        Destroy(m07);
        /* m2.SetActive(false);
         m3.SetActive(false);
         m1.SetActive(false);
     */
    }

    public void Timp()
    {
        Time.timeScale = 0;
    }

    public void revin()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("primadata", 1);
    }
}
