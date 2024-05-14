using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animator_UItransition : MonoBehaviour
{
    [SerializeField] private RectTransform obiectdeanimat;
    [SerializeField] private RectTransform obiectdeanimat2;
    [SerializeField] private RectTransform obiectdeanimat3;
    private int ok = 1;
    private void OnEnable()
    {
        if (ok == 1)
        {
            FadeIn();
            ok = 0;
        }
        else
        {
            FadeOut();
            ok = 1;
        }
    }

    public void FadeIn()
    {
        LeanTween.moveX(obiectdeanimat, -198, 1f);
        LeanTween.moveX(obiectdeanimat2, 207, 1f);
        LeanTween.rotate(obiectdeanimat3, 180, 1.2f);
        LeanTween.alpha(obiectdeanimat3, 0, 1.2f);
        LeanTween.size(obiectdeanimat3, new Vector2(0.1f, 0.1f), 1);
    }


    public void FadeOut()
    {
        LeanTween.moveX(obiectdeanimat, 198, 0.4f);
        LeanTween.moveX(obiectdeanimat2, -207, 0.4f);
        LeanTween.rotate(obiectdeanimat3, 360, 1.8f);
        LeanTween.alpha(obiectdeanimat3, 1,1.8f);
        LeanTween.size(obiectdeanimat3, new Vector2(90f, 90f), 1.8f);
    }

}
