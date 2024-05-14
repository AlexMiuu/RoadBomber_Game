using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animamtor_ui3 : MonoBehaviour
{
    [SerializeField] private RectTransform obiectptanimare;
    [SerializeField] private float delay;
    public LeanTweenType tip_efect;

    public void OnEnable()
    {
        TransitionCarShop();
    }
    public void TransitionCarShop()
    {
        transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(obiectptanimare, new Vector3(3.932344f, 1.060158f, 0.1453463f), 0.4f).setEase(LeanTweenType.
easeOutBack);

    }
}
