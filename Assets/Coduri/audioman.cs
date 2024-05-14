using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
public class audioman : MonoBehaviour
{
    public AudioMixer audio;
   // public GameObject enabled;
  //  public GameObject disabled;
    //public Volume postp;
    public AudioMixer muzica;
    private void Start()
    {

           /* if (PlayerPrefs.GetInt("PP")==1)
        {
            disabled.SetActive(false);
            enabled.SetActive(true);
            postp.enabled = true;
        }
        else
        {
            disabled.SetActive(true);
            enabled.SetActive(false);
            postp.enabled = false;
        }
        if (PlayerPrefs.GetInt("primadata") == 0)
        {
            PlayerPrefs.SetInt("PP", 1);
        }
           */
    }
    public void setvolume(float volume)
    {
        audio.SetFloat("volummm", volume);
    }


    public void setmusic(float vomm)
    {
        muzica.SetFloat("musicvolm", vomm);
    }
    public void Calitate(int qualityindex)
    {
        QualitySettings.SetQualityLevel(qualityindex);
    }

 /*   public void SetarePP()
    {
        PlayerPrefs.SetInt("PP", 1);
    }
    public void desetareSetarePP()
    {
        PlayerPrefs.SetInt("PP", 0);
    }
 */
}
