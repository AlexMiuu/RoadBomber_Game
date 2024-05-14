using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TransitionManager : MonoBehaviour
{
    [SerializeField] private animator_UItransition tranzitie;
    public string url1;
    public string url2;
    public string url3;
    public void fadein()
    {
        PlayerPrefs.SetInt("Rundejucate", PlayerPrefs.GetInt("Rundejucate") + 1);
        StartCoroutine(Animatie(SceneManager.GetActiveScene().buildIndex + 1));

    }


    IEnumerator Animatie(int index)
    {
        tranzitie.FadeOut();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(index);

    }

    public void OpenLink1()
    {
        Application.OpenURL(url1);
    }

    public void OpenLink2()
    {
        Application.OpenURL(url2);
    }

    public void OpneLink3()
     {
           Application.OpenURL(url3);
     }
}

