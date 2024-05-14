using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class switchcars : MonoBehaviour
{
    public int selectat;
    public GameObject asta;
    private int selectatcopie;


    public Button buybut;
    public Button selectbut;

    public TMP_Text pret2;

    public int[] preturi;
    public bool[] masinideblocate = new bool[3] { true, false, false };

    [SerializeField] private Button CoinShop;
    [SerializeField] private admanager reclame;
    [SerializeField] private TMP_Text selectbutton_text;
    [SerializeField] private GameObject checkmark;
    [SerializeField] private Image checkk;

    void Start()
    {
        selectat= PlayerPrefs.GetInt("NumarMasina");
        select();
    }
    void Update()
    {
        if (PlayerPrefs.GetInt("Boolnume" + selectat)!=0)
        {
            checkk.color=new Color32(51, 200, 0, 255);
            selectbutton_text.color = new Color32(51, 200, 0, 255);
            selectbut.interactable = true;
            buybut.interactable = false;
            pret2.text = "Bought";
        }
     else
        {
            checkk.color = new Color32(200, 0, 17, 255);
            selectbutton_text.color = new Color32(200, 0, 17, 255);
            selectbut.interactable = false;
            pret2.text = preturi[selectat]+" ";
             buybut.interactable = true;
         //   buybut.interactable = (PlayerPrefs.GetInt("TOTALBANI") >= preturi[selectat]);
        }

    }

    public void select()
    {
        int i = 0; 
        foreach (Transform masina1 in transform) 
        {
            Debug.Log(i);
            if (i == selectat)
            {
                float x = Random.Range(0.5f, 1.2f);
                masina1.gameObject.SetActive(true);
                LeanTween.cancel(gameObject);
                transform.localPosition = new Vector3(0, 5, 0);
                LeanTween.moveLocalY(gameObject, 0.4520004f, x).setEase(LeanTweenType.easeOutBounce);
             
            }
            else
                masina1.gameObject.SetActive(false);
            i++; 
        }
    }

    public void nextcar()
    {
        selectatcopie = selectat;
        if (selectat >= transform.childCount - 1)
            selectat = 0;
        else
            selectat++;

      if(selectatcopie!=selectat)
        {
            select();
        }
    }

    public void masinaspate()
    {
        selectatcopie = selectat;
        if (selectat <= 0)
            selectat = transform.childCount - 1;
        else
            selectat--;

        if (selectatcopie != selectat)
        {
            select();
        }
    }

    public void Selectare()
    {
        checkmark.SetActive(true);
        PlayerPrefs.SetInt("NumarMasina", selectat);
        Debug.Log("MATA" + selectat);

    }

    public void Cumparare()
    {
        if (PlayerPrefs.GetInt("TOTALBANI") >= preturi[selectat])
        {
            reclame.ShowRewardedVideo();
            PlayerPrefs.SetInt("TOTALBANI", PlayerPrefs.GetInt("TOTALBANI") - preturi[selectat]);
            masinideblocate[selectat] = true;
            Save();
        }
        else
        {
            CoinShop.onClick.Invoke();
        }
    

    }
    public void Save()
    {
        for(int i=0;i<=masinideblocate.Length;i++)
        {
            PlayerPrefs.SetInt("Boolnume" + selectat, 1);
        }
    }
}
