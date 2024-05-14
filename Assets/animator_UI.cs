using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class animator_UI : MonoBehaviour
{
    public RectTransform obiectptanimare;
    public GameObject platou;
    [SerializeField] private Button butonintoarcere;
    [SerializeField] private UnityEvent oncomplete;

    public void OnAnimatorMovein()
    {
        LeanTween.moveX(obiectptanimare, 0, 0.2f);
        LeanTween.moveY(obiectptanimare, 0, 0.2f);


    }


    private void AdReward()
    {
        LeanTween.scale(obiectptanimare,new Vector3(0.226791f, 0.226791f, 0.226791f), 0.5f).setLoopPingPong();
    }    
    public void OnAnimatorMoveinShp()
    {
        LeanTween.moveX(obiectptanimare, 45, 0.2f);
    }
    public void OnAnimatorMoveout()
    {
        LeanTween.moveX(obiectptanimare, -800, 0.2f);

    }
    public void FadeOut()
    {
        LeanTween.scale(obiectptanimare, new Vector3(0,0,0), 0.5f);

    }
    public void FadeIn()
    {
        LeanTween.scale(obiectptanimare, new Vector3(1, 1, 1), 0.5f);

    }

    public void ShopPlatou()
    {
        LeanTween.moveLocalY(platou, 0.7300001f, 1f);
    }
   
    public void ShopPLatouBACK()
    {
        LeanTween.moveLocalY(platou, -0.54f, 1f);
    }
    public void Presss()
    {
        butonintoarcere.onClick.Invoke();
    }

     public void Powerin()
    {
        transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(obiectptanimare, new Vector3(1, 1, 1), 0.5f);
        LeanTween.moveX(obiectptanimare, 0, 0.2f).setOnComplete(onCompletecal);
    }

    public void Powerout()
    {
LeanTween.scale(obiectptanimare, new Vector3(0, 0, 0), 0.5f);
        LeanTween.moveX(obiectptanimare, 500, 0.2f);
        
    }

    private void onCompletecal()
    {
        if (oncomplete != null)
        {
            Powerout();
        }
    }
}
