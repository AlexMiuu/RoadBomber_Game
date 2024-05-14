using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scor : MonoBehaviour
{
    public Transform masina;
    public Text scorul;
    public TMP_Text scor2;
    public TMP_Text highestscore;
    public float numarul;
    public script3masinatest viteza;
    public float treapta;
    public int vitezainit = 200;
    public TMP_Text numardebanipemeniu;
    private void Start()
    {
        highestscore.text = PlayerPrefs.GetFloat("HighScore").ToString("0");

    }
    private void Update()
    {
        scorul.text = masina.position.z.ToString("0");
        scor2.text= masina.position.z.ToString("0");
        numardebanipemeniu.text = PlayerPrefs.GetInt("NumardeBani").ToString("0");
        PlayerPrefs.SetFloat("Score", masina.position.z);
        if (masina.position.z > PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore",masina.position.z);
            highestscore.text = masina.position.z.ToString("0");
            //PlayerPrefs.GetFloat("HighScore").ToString("0");
      
        }
        numarul = masina.position.z;

        if (numarul>=treapta )
        {
            vitezainit = vitezainit + 50;
            viteza.maxMotorTorque = vitezainit;
            treapta = numarul + 100;
        }

     
            
    }
}
