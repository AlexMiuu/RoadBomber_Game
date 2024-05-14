using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManagerStatistici : MonoBehaviour
{
    public TMP_Text highscore;
    public TMP_Text RundeJucate;
    public TMP_Text Crashes;
    public TMP_Text Bombs;
    public TMP_Text fpslimiter;
    

    void Start()
    {
        Application.targetFrameRate = 90;
        fpslimiter.text = Application.targetFrameRate.ToString("0");
        highscore.text = PlayerPrefs.GetFloat("HighScore").ToString("0");
        RundeJucate.text = PlayerPrefs.GetInt("Rundejucate").ToString("0");
        Bombs.text = PlayerPrefs.GetInt("Numardebombe").ToString("0");
        Crashes.text = PlayerPrefs.GetInt("carcrash").ToString("0");
    }
    
    public void FpsPLUS()
    {
        if (Application.targetFrameRate <120)
        {
            Application.targetFrameRate += 30;
            fpslimiter.text = Application.targetFrameRate.ToString("0");
        }
    }
    public void FpsMINUS()
    {
        if (Application.targetFrameRate > 30)
        {
            Application.targetFrameRate -= 30;
            fpslimiter.text = Application.targetFrameRate.ToString("0");
        }
    }

}
