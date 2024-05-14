using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class aniamtor_UI2 : MonoBehaviour
{
    public RectTransform obiectptanimare;
    [SerializeField] private float delay;
    [SerializeField] private Vector3 marime;
    public void OnEnable()
    {
        FadeIn2();
    }
    public void FadeOut2()
    {
       
        LeanTween.scale(obiectptanimare, new Vector3(0, 0, 0), 0.5f);

    }
    public void FadeIn2()
    {
        transform.localScale = new Vector3(0, 0, 0);
        // LeanTween.scale(obiectptanimare, new Vector3(1,1,1),delay);
        LeanTween.scale(obiectptanimare, marime, delay).setIgnoreTimeScale(true);
    }

    //void OnComplete()
    //{
    //    if (onCompleteCallback!=null)
    //    {
    //        onCompleteCallback.Invoke();
    //    }
    //}
    public void Punch()
    {  
            LeanTween.scale(obiectptanimare, Vector3.one * 1.5f, 0.5f).setEasePunch().setIgnoreTimeScale(true);
    }

    

}
