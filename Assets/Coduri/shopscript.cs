using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class shopscript : MonoBehaviour
{

    public TMPro.TMP_Text textbani;
    public int bani;
    public int pret;
   

    private void Awake()
    {
            bani = PlayerPrefs.GetInt("TOTALBANI") + PlayerPrefs.GetInt("NumardeBani");
            PlayerPrefs.SetInt("TOTALBANI", bani);
        PlayerPrefs.SetInt("NumardeBani",0);
        Debug.Log(bani);

    }
      void Update()
    {
        bani = PlayerPrefs.GetInt("TOTALBANI");
        textbani.text = " " +bani +" ";

    }

   
 
}
