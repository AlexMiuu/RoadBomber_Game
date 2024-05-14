using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class obiect : MonoBehaviour
{
    public int pret;
    public Button acesta;
    public Button selectat;
    public bool masinaselectata = false;
    public switchcars switchh;
    public bool cumparat = false;
    public idmasina indice;
    void Start()
    {
        switchh = GetComponent<switchcars>();
        if(PlayerPrefs.GetInt("Masina1")==1)
        {
            acesta.interactable = false;
        }
        else
            if(PlayerPrefs.GetInt("Masina2")==1)
        {
            acesta.interactable = false;
        }
    }
    public void Cumpara()
    { 
        if (PlayerPrefs.GetInt("TOTALBANI") >= pret)
        {
            PlayerPrefs.SetInt("TOTALBANI", PlayerPrefs.GetInt("TOTALBANI")-pret);
            acesta.interactable = false;
            selectat.interactable = true;
            cumparat = true;
            if(indice.id==1)
            {
                PlayerPrefs.SetInt("Masina1", 1);

            }
            else
                if(indice.id==2)
            {
                PlayerPrefs.SetInt("Masina2", 1);
            }
        }
    }

   
}
