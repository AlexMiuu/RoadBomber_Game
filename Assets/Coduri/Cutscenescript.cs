using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Cutscenescript : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;
    public GameObject imagine;

    //public Text fpsText;
    //public float deltaTime;


    private void Start()
    {
     
        StartCoroutine("Sequence");
    }

    IEnumerator Sequence()
    {
        imagine.SetActive(false);
        yield return new WaitForSeconds(3.3f);
        camera1.SetActive(false);
        camera3.SetActive(true);
        imagine.SetActive(true);
        StopCoroutine("Sequence");
    }
    /*
     * 
     *SHOW FPS FUNCTION
     void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil(fps).ToString();

    }
    */



}

