using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
public class lista : MonoBehaviour
{
    public Transform[] listamasini;
    public int index;
    public Transform spawn;
    public Transform obiect;

    public Transform TRANS;

    public Camera cam;
    public float smoothspeed=1.25f;
    public Vector3 offset;

  



    public Text scorul;
    public TMP_Text scor2;
    public TMP_Text highestscore;
    public float numarul;
    //  private script3masinatest viteza;
    public TMP_Text numardebanipemeniu;

   public bool okkk2 = false;
    //public GameObject deathscreeen2;


    private void Start()
    {
        int select = PlayerPrefs.GetInt("NumarMasina");
        /*  GameObject prefab = listamasini[select];
          GameObject clona = Instantiate(prefab, spawn.position, Quaternion.identity); 
        */
        Transform prefab = listamasini[select];
        Transform clona = Instantiate(prefab, spawn.position, Quaternion.identity);
        TRANS.transform.parent = clona.transform;
        obiect = clona;
        highestscore.text = PlayerPrefs.GetFloat("HighScore").ToString("0");
        //  viteza = GetComponent<script3masinatest>();

       // deathscreeen2.SetActive(false);
       for(int i=0;i<=listamasini.Length-1;i++)
            if(i!=select)
            {
                listamasini[i] = null;
            }

    }

    void Update()
    {
        Vector3 desirepos = obiect.position + offset;
        Vector3 smooth = Vector3.Lerp(transform.position, desirepos, smoothspeed);
        transform.position = smooth;
        //cam.transform.position = obiect.transform.position - offset;
        //cam.transform.position = new Vector3(obiect.transform.position.x-2,obiect.transform.position.y, obiect.transform.position.z-5);


        scorul.text = obiect.position.z.ToString("0");
        scor2.text = obiect.position.z.ToString("0");
        numardebanipemeniu.text = PlayerPrefs.GetInt("NumardeBani").ToString("0");
        PlayerPrefs.SetFloat("Score", obiect.position.z);
        if (obiect.position.z > PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", obiect.position.z);
            highestscore.text = obiect.position.z.ToString("0");
            //PlayerPrefs.GetFloat("HighScore").ToString("0");

        }
        //schimbarea vitezei
        /* numarul = obiect.position.z;

         if (numarul >= treapta)
         {
             vitezainit = vitezainit + 50;
             viteza.maxMotorTorque = vitezainit;
             treapta = numarul + 100;
         }

         */
  


    }

    //RESPAWN DUPA AD SI INVINCIBILITATE PT N SECUNDE
    public void revindupaad()
    {
        Time.timeScale = 1;
        // deathscreen.SetActive(false);
        //deathscreenbool = false;
        obiect.transform.position = new Vector3(0, obiect.transform.localPosition.y, obiect.transform.localPosition.z); 
      //  deathscreeen2.SetActive(false);
        // StartCoroutine("Respawn");

    }

    /* IEnumerator Respawn()
      {
          float n = 0;
          while (n < 5)
          {
              colliderjucator.enabled = false;
              n += Time.deltaTime;
              yield return null;
          }
          colliderjucator.enabled = true;
    okkk2=false;
          //   StopCoroutine("Respawn");
      }
      */

  

}
