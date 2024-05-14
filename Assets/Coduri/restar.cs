using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restar : MonoBehaviour
{
    private switchcamera inter;
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("TOTALBANI", PlayerPrefs.GetInt("TOTALBANI") + PlayerPrefs.GetInt("NumardeBani"));
        PlayerPrefs.SetInt("NumardeBani", 0);
        PlayerPrefs.SetFloat("TreaptaViteza", 0);
        Debug.Log("but");
        Time.timeScale = 1;

    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("NumardeBani", 0);

        Application.Quit();
    }

    public void Resume()
    {
        Time.timeScale= 1;
    }
 
    public void  plusbanidupaad()
    {
        PlayerPrefs.SetInt("NumardeBani", PlayerPrefs.GetInt("NumardeBani")+20);
    }
}

