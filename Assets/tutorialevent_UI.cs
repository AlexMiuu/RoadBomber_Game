using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class tutorialevent_UI : MonoBehaviour
{
    public UnityEvent oncomplete;
    [SerializeField] private float delay;
    [SerializeField] private Vector3 sizee;
    public void OnEnable()
    {
        transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(gameObject,sizee, 0.4f).setDelay(delay).setOnComplete(onCompletecall).setIgnoreTimeScale(true); ;
    }

    public void onCompletecall()
    {
        if(oncomplete!=null)
        {
            Onclose();
            oncomplete.Invoke();
            Time.timeScale = 0;
        }
    }

    public void Onclose()
    {
        LeanTween.scale(gameObject, new Vector3(0,0,0), 0.4f).setDelay(delay).setOnComplete(erase).setIgnoreTimeScale(true); ;
    }

    public void erase()
    {
       Time.timeScale = 1;
        gameObject.SetActive(false);
    }


}
