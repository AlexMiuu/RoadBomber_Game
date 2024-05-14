using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pingponganimator : MonoBehaviour
{
    [SerializeField] private Vector3 size;
    [SerializeField] private LeanTweenType tip;
    private void OnEnable()
    {
        AdReward();   
    }

    public void AdReward()
    {
        LeanTween.scale(gameObject, new Vector3(0.37f, 0.40f, 0.37f), 0.5f).setDelay(0.2f).setEase(tip).setLoopPingPong().setIgnoreTimeScale(true); 
    }
}
