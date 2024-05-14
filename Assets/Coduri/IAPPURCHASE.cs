using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPPURCHASE : MonoBehaviour
{
    private string coins1 = "com.miugames.roadbomber.coins1";
    private string coins2 = "com.miugames.roadbomber.coins2";
    private string coins3 = "com.miugames.roadbomber.coins3";

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == coins1)
        {
            PlayerPrefs.SetInt("TOTALBANI", PlayerPrefs.GetInt("TOTALBANI") + 500);
            Debug.Log("+++500");
        }

        if(product.definition.id==coins2)
        {
            PlayerPrefs.SetInt("TOTALBANI", PlayerPrefs.GetInt("TOTALBANI") + 2500);
            Debug.Log("+++2500");
        }

        if (product.definition.id == coins3)
        {
            PlayerPrefs.SetInt("TOTALBANI", PlayerPrefs.GetInt("TOTALBANI") + 7500);
            Debug.Log("+++7500");
        }

    }


    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase" + product.definition.id + "failed due to" + reason);
    }
}
