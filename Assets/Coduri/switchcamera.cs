using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class switchcamera : MonoBehaviour
{
    public void PLayfunct()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quitfunc()
    {
        Application.Quit();
    }
}
