using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class aniamtor_pause : MonoBehaviour
{
  //  [SerializeField] private RectTransform obiectptanimare;
    [SerializeField] private UnityEvent oncomplete;
    [SerializeField] private UnityEvent oncompl2;
    [SerializeField] private Text textvalue;

    public UnityEvent onCompleteCallback;
    private void OnEnable()
    {
        Powerin();
    }


    public void Powerin()
    {
        LeanTween.cancel(gameObject);
        transform.localScale = Vector3.one;
        LeanTween.scale(gameObject, Vector3.one*1.5f, 0.7f).setEasePunch().setOnComplete(OnComplete).setIgnoreTimeScale(true);
    //    LeanTween.value(gameObject, 0f,1.5f, 0.7f).setEasePunch().setOnUpdate(set);
        //LeanTween.moveX(obiectptanimare, 120, 0.5f);
    }

    public void OnComplete()
    {
        if(onCompleteCallback!=null)
        {
            onCompleteCallback.Invoke();
        }
    }
    public void Powerout()
    {
        LeanTween.scale(gameObject, new Vector3(0, 0, 0), 0.5f);
        //    LeanTween.moveX(obiectptanimare, 500, 0.5f).setOnComplete(Oncomplt2);
     gameObject.SetActive(false);

    }

  public void set(float value)
    {
        textvalue.text = value.ToString("F1");
    }
}
