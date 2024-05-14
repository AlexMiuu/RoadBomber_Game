using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.Advertisements;
using TMPro;
public class boostpowerup : MonoBehaviour, IUnityAdsListener
{

    //  private script3masinatest masinaactiune;
    //private NEWCARSCRIPT masinaactiune;
    public int coin = 0;
    public Text Bani;
    private Animator anim;
    public bool bombaa = false;
    public Image bombasprite;
    //public script3masinatest scriptmasina;
    public NEWCARSCRIPT scriptmasina;
    private Rigidbody rigid;

    public float intensitate;
    private Vignette vignettelayer;
    private ChromaticAberration chromaticlayer;
    private PaniniProjection paninilayer;
    private ColorAdjustments colorlayer;

    public bool powerupcheck = false;
    public Volume volume;
    Transform bombaactual;

    [SerializeField] [Range(0F, 4f)] float lerptime;

    public ParticleSystem fum;
    public ParticleSystem explozie;
    private ParticleSystem efect;

    public int raza;
    public int numarbombe = 0;

    public float marime_xyz = 1f;
    public Text numaratoarebomba;
    public GameObject deathscreen;

    public GameObject pausescreen;
    public bool Pscreen = false;
    public bool deathscreenbool = false;

    private bool okkk = false;

    public Transform acestjucator;
    public Transform acestjucator2;
    public Button rez;

    public GameObject informatiisuplimentare;

    public Button bombbutton;
    public bool respawncheck = false;
    public GameObject counteranimator;

    public GameObject invuln;
    public ParticleSystem foc;
    public ParticleSystem fummotor;
    public AudioSource SUNETPOWER1;
    public AudioSource sunetpower2;
    public AudioSource sunetban;
    public AudioSource explozieeeee;


    public Rigidbody sferaaa;
    public AudioSource sunepowertime;

    public Transform APC;
    public GameObject skinmasina;



    [SerializeField] private TMP_Text textboost;
    [SerializeField] private GameObject animatiepowerupbomba;
    [SerializeField] private GameObject animatieBOOST;
    [SerializeField] private GameObject animatieAPC_BOost;
    [SerializeField] private Camera cameraactuala;
    [SerializeField] private GameObject roatadreaptafata;
    [SerializeField] private GameObject roatastangafata;
    [SerializeField] private GameObject roatadreaptaspate;
    [SerializeField] private GameObject roatastangaspate;
    [SerializeField] private bool speedok=false;
    [SerializeField] private int numarboost=0;
    [SerializeField] private TMP_Text cronometru_text;


    private bool activeAPC = false;
#if UNITY_IOS
    private string gameId = "4155198";
#elif UNITY_ANDROID
    private string gameId = "4155199";
#endif

    string mySurfacingId = "rewardedVideo";

    bool testMode = false;

    public void Awake()
    {

        anim = gameObject.GetComponent<Animator>();
        // masinaactiune = GetComponent<script3masinatest>();
     //   masinaactiune = GetComponent<NEWCARSCRIPT>();
        bombasprite.enabled = false;
        deathscreen.SetActive(false);
        pausescreen.SetActive(false);
        rigid = GetComponent<Rigidbody>();
        Pscreen = false;
        bombbutton.onClick.AddListener(activarebomba);
       
    }



    void Start()
    {
        APC.gameObject.SetActive(false);
        PlayerPrefs.SetFloat("TreaptaViteza", 20);
        volume.profile.TryGet<Vignette>(out vignettelayer);
        volume.profile.TryGet<ChromaticAberration>(out chromaticlayer);
        volume.profile.TryGet<PaniniProjection>(out paninilayer);
        volume.profile.TryGet<ColorAdjustments>(out colorlayer);
        fum.gameObject.SetActive(false);
        explozie.gameObject.SetActive(false);
        rez.onClick.AddListener(() => ShowRewardedVideo());
        invuln.SetActive(false);
        foc.gameObject.SetActive(false);


        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);

       LeanTween.rotateX(roatastangafata, 180, 0.2f).setLoopPingPong();
       LeanTween.rotateX(roatadreaptafata, 180, 0.2f).setLoopPingPong();
        LeanTween.rotateX(roatastangaspate, 180, 0.2f).setLoopPingPong();
        LeanTween.rotateX(roatadreaptaspate, 180, 0.2f).setLoopPingPong();
    }


    /*
     * ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
     * DE SCHIMBAT .tag==" " IN CompareTag(" "); PT. O PERFORMANTA MAI BUNA IN PRINCIPIU
     * DE SCHIMBAT .tag==" " IN CompareTag(" "); PT. O PERFORMANTA MAI BUNA IN PRINCIPIU
     * DE SCHIMBAT .tag==" " IN CompareTag(" "); PT. O PERFORMANTA MAI BUNA IN PRINCIPIU
     * DE SCHIMBAT .tag==" " IN CompareTag(" "); PT. O PERFORMANTA MAI BUNA IN PRINCIPIU 
     *-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bariera")
        {
            PlayerPrefs.SetInt("carcrash", PlayerPrefs.GetInt("carcrash") + 1);
            Time.timeScale = 0;
            //    Debug.Log("LOVIT");
            informatiisuplimentare.SetActive(false);
            deathscreen.SetActive(true);
            deathscreenbool = true;
            okkk = true;
            return;
        }

        if (other.gameObject.tag == "obs")
        {
            PlayerPrefs.SetInt("carcrash", PlayerPrefs.GetInt("carcrash") + 1);
            Time.timeScale = 0;
            //  Debug.Log("LOVIT");
            informatiisuplimentare.SetActive(false);
            deathscreen.SetActive(true);
            deathscreenbool = true;
            okkk = true;
            return;
        }

        if (other.gameObject.tag == "coin")
        {
            sunetban.Play();
            efect = other.GetComponentInChildren(typeof(ParticleSystem)) as ParticleSystem;
            efect.Play();
            other.GetComponent<MeshRenderer>().enabled = false;
            // Destroy(other.gameObject);
            coin++;
            PlayerPrefs.SetInt("NumardeBani", coin);
            return;

        }
        if (other.gameObject.tag == "goldcoin")
        {
            sunetban.Play();
            efect = other.GetComponentInChildren(typeof(ParticleSystem)) as ParticleSystem;
            efect.Play();
            other.GetComponent<MeshRenderer>().enabled = false;
            coin += 2;
            PlayerPrefs.SetInt("NumardeBani", coin);
            return;
        }

        if (other.gameObject.tag == "obstacol" && activeAPC == false)
        {
            Handheld.Vibrate();
            speedok = true;
            numarboost++;
            invuln.SetActive(true);
            StartCoroutine(DurataPowerup());
            animatieBOOST.SetActive(true);
            Destroy(other.gameObject);
            return;
        }
        else
        if (other.gameObject.tag == "boostinceput")
        {
            StartCoroutine(DurataPowerupinceput_cutscene());
            Destroy(other.gameObject);
            return;
        }

        if (other.gameObject.tag == "bomba" && bombaa == false && activeAPC == false)
        {
            animatiepowerupbomba.SetActive(true);
            SUNETPOWER1.Play();
            var off = new Vector3(0, 1, 0);
            var scale = new Vector3(1, 1, 1);
            // invuln.gameObject.SetActive(true);
            PlayerPrefs.SetInt("Numardebombe", PlayerPrefs.GetInt("Numardebombe") + 1);
            // bombaa = true;

            if (numarbombe == 0)
            {
                bombaactual = other.transform;
                other.transform.position = Vector3.Lerp(this.transform.position + off, other.transform.position, lerptime * Time.deltaTime);
                other.transform.localScale = scale;
                other.transform.parent = this.transform;
                Destroy(other.GetComponent<BoxCollider>());
                bombasprite.enabled = true;

                numarbombe++;

            }
            else
            if (numarbombe >= 1)

            {
                animatiepowerupbomba.GetComponent<aniamtor_pause>().Powerin();
                numarbombe++;
                marime_xyz += 0.2f;
                bombaactual.transform.localScale = new Vector3(marime_xyz, marime_xyz, marime_xyz);
                raza += 20;
                Destroy(other.gameObject);
            }

        }

        if(other.gameObject.tag== "imunitateboost")
        {
            Handheld.Vibrate();
            Destroy(other.gameObject);
            return;
        }

        if (other.gameObject.tag == "APC_B" && activeAPC==false && speedok==false)
        {
         //   DurataPowerup();
            bombbutton.onClick.Invoke();
         //   StartCoroutine(DurataPowerup());
            animatieAPC_BOost.SetActive(true);
            activeAPC = true;
            StartCoroutine(APCpowerup());
            Destroy(other.gameObject);
            return;
        }

    }
    /*  public void OnCollisionEnter(Collision collision)
      {
          if (collision.gameObject.tag == "obs")
          {

              Time.timeScale = 0;
              Debug.Log("LOVIT");
              informatiisuplimentare.SetActive(false);
              deathscreen.SetActive(true);
              deathscreenbool = true;
              okkk = true;
          }
      }
    */
    IEnumerator DurataPowerup()
    {

        float durata = 5;
        if (numarboost > 1)
        {
            durata += 2;
        }
        foc.gameObject.SetActive(true);
        fummotor.gameObject.SetActive(false); scriptmasina.fwdSpeed +=10f;
        animatieBOOST.GetComponent<aniamtor_pause>().Powerin();
        while (durata > 0)
        {
            textboost.text = durata.ToString("F1");
            powerupcheckon();
            IMUNITATE();
            // masinaactiune.maxMotorTorque = PlayerPrefs.GetFloat("TreaptaViteza") + 1000f;
           
            durata -= Time.deltaTime;
            yield return null;
        }
        numarboost=0;
        animatieBOOST.SetActive(false);
        invuln.SetActive(false);
        foc.gameObject.SetActive(false);
        fummotor.gameObject.SetActive(true);
        speedok = false;
        //  masinaactiune.maxMotorTorque = PlayerPrefs.GetFloat("TreaptaViteza");
        scriptmasina.fwdSpeed -= 10f;
        powerupcheckoff();
        StopCoroutine("DurataPowerup");

    }


    IEnumerator DurataPowerupinceput_cutscene()
    {

        float durata = 0;
        while (durata < 5)
        {
            //  masinaactiune.maxMotorTorque = PlayerPrefs.GetFloat("TreaptaViteza") + 1000f;

            scriptmasina.fwdSpeed = PlayerPrefs.GetFloat("TreaptaViteza") + 10f;
            durata += Time.deltaTime;
            yield return null;
        }
        //  masinaactiune.maxMotorTorque = 250;
        scriptmasina.fwdSpeed = 20;
        StopCoroutine("DurataPowerup");

    }
    private void Update()
    {

        numaratoarebomba.text = numarbombe.ToString("0");
        Bani.text =  coin+"";

        roatastangafata.transform.rotation = Quaternion.Slerp(roatastangafata.transform.rotation, transform.rotation * transform.rotation * Quaternion.Euler(1, 1, 1), 0.1f);
        roatadreaptafata.transform.rotation = Quaternion.Slerp(roatadreaptafata.transform.rotation, transform.rotation * transform.rotation * Quaternion.Euler(1, 1, 1), 0.1f);

        if (this.transform.localPosition.x > 20 || this.transform.localPosition.x < -20)
        {
            Time.timeScale = 0;
            deathscreen.SetActive(true);
            deathscreenbool = true;
            informatiisuplimentare.SetActive(false);

        }

        if (this.transform.localPosition.x < -10)
        {
            Time.timeScale = 0;
            deathscreen.SetActive(true);
            deathscreenbool = true;
            informatiisuplimentare.SetActive(false);
        }
        // Debug.Log("rotatiepey" + this.transform.rotation.eulerAngles.y);
        if (this.transform.rotation.eulerAngles.y >= 135 && this.transform.rotation.eulerAngles.y <= 225)
        {
            Time.timeScale = 0;
            deathscreen.SetActive(true);
            deathscreenbool = true;
            //Debug.Log("VALOCARE"+" "+acestjucator.transform.rotation.eulerAngles.y);
        }
      


        //Pause screen 
        if (Input.GetKeyDown(KeyCode.Escape) && Pscreen == false && deathscreenbool == false)
        {
            pausescreen.SetActive(true);
            Time.timeScale = 0;
            Pscreen = true;
            informatiisuplimentare.SetActive(false);
        }
        else
        if (Input.GetKeyDown(KeyCode.Escape) && Pscreen == true)
        {

            pausescreen.SetActive(false);
            Time.timeScale = 1;
            Pscreen = false;
            informatiisuplimentare.SetActive(true);

        }

    }

    //RESPAWN DUPA AD SI INVINCIBILITATE PT N SECUNDE
    public void revindupaad()
    { 
        deathscreen.SetActive(false);
        informatiisuplimentare.SetActive(true);
        deathscreenbool = false;
        acestjucator.transform.position = new Vector3(0, acestjucator.transform.position.y, acestjucator.transform.position.z);
        acestjucator.transform.rotation = Quaternion.Euler(0, 0, 0);
        acestjucator2.transform.rotation = Quaternion.Euler(0, 0, 0);
        sferaaa.velocity = Vector3.zero;
       // scriptmasina.turnInput = 0;
        invuln.SetActive(true);
        StartCoroutine(Cronometru());
        StartCoroutine(DurataPowerup());
      
        
    }
    IEnumerator Cronometru()
    { 
        float durata = 3;  
        counteranimator.SetActive(true);
        Time.timeScale = 0;
       
        while (durata > 0)
        {
            cronometru_text.text = durata.ToString("F0");
            durata -= Time.unscaledDeltaTime;
            yield return null;
        }
        counteranimator.SetActive(false);
        Time.timeScale = 1;
        StopCoroutine("Cronometru");
    }

    void Explozie()
    {
        Collider[] obiect = Physics.OverlapSphere(transform.position, raza);

        foreach (Collider obapropiere in obiect)
        {
            if (obapropiere.GetComponent<Rigidbody>() != null)
            {
                Rigidbody rb = obapropiere.GetComponent<Rigidbody>();
                if (obapropiere.tag == "obs")
                {

                    Destroy(rb.transform.gameObject);
                    //rb.AddExplosionForce(100000f, transform.position, raza);
                    //rb.transform.gameObject.tag = "Untagged";
                }
                if (obapropiere.tag == "bariera")
                {
                    rb.transform.gameObject.tag = "Untagged";
                }
            }
        }

    }


    void IMUNITATE()
    {
        Collider[] obiect = Physics.OverlapSphere(transform.position, raza);

        foreach (Collider obapropiere in obiect)
        {
            if (obapropiere.GetComponent<Rigidbody>() != null)
            {
                Rigidbody rb = obapropiere.GetComponent<Rigidbody>();
                if (obapropiere.tag == "obs")
                {

                    rb.transform.gameObject.tag = "imunitateboost";
                    //rb.AddExplosionForce(100000f, transform.position, raza);
                    //rb.transform.gameObject.tag = "Untagged";
                }
            }
        }

    }


    //MODIFICAREEEEEEEEEEE 
   // IEnumerator Respawn()
    //{
    //    float n = Time.realtimeSinceStartup + 5.5f;
    //    invuln.gameObject.SetActive(true);
    //    counteranimator.SetTrigger("trig1");
    //    while (Time.realtimeSinceStartup < n)
    //    {

    //        respawncheckon();
    //        yield return null;

    //    }
    //    invuln.gameObject.SetActive(false);
    //    Time.timeScale = 1;
    //    Explozie();
    //    respawncheckoff();
    //    //  Debug.Log("VALOAREROTATIE" + " " + acestjucator.transform.localRotation);
    //    //   StopCoroutine("Respawn");
    //}
    //MODIFICAREEEEEEEEEEE 



    public void activarebomba()
    {
        if (numarbombe != 0) //&& bombaa == true)
        {
            explozieeeee.Play();
            numarbombe = 0;
            var tr = bombaactual;
            bombaa = false;
            bombasprite.enabled = false;
            fum.gameObject.SetActive(true);
            explozie.gameObject.SetActive(true);
            fum.Play();
            explozie.Play();
            Explozie();
            numarbombe = 0;
            Destroy(tr.gameObject);

        }
    }


    IEnumerator APCpowerup()
    {
        APC.gameObject.SetActive(true);
        cameraactuala.GetComponent<camerafollow>().offset = new Vector3(0, 10, -10);
        fummotor.gameObject.SetActive(false);
        skinmasina.SetActive(false);
        float n = 0;
       // Vector3 offset = new Vector3(0, 0.5f, 0);
       // Vector3 pozitieAPC = acestjucator.transform.position;
       // Quaternion rotatieAPC = acestjucator.transform.rotation;
       // Transform tank= Instantiate(APC,pozitieAPC+offset,rotatieAPC, acestjucator2);
        // tank.transform.parent = acestjucator2.transform;
        while (n<10)
        {
            n += Time.deltaTime;
            yield return null;
        }
        animatieAPC_BOost.SetActive(false);
        activeAPC = false;
        skinmasina.SetActive(true);
        //Destroy(tank.gameObject);
        fummotor.gameObject.SetActive(true);
        cameraactuala.GetComponent<camerafollow>().offset = new Vector3(0,3,-5);
        APC.gameObject.SetActive(false);
    }

    void respawncheckon()
    {

            vignettelayer.intensity.value = intensitate;
            chromaticlayer.intensity.value = 1;
    }
    
    void timppoweon()
    {
        colorlayer.saturation.value = -55f;
        vignettelayer.intensity.value = 0.6f;
        paninilayer.distance.value = 0.2f;
        vignettelayer.color.value = new Color(1, 0, 1, 1);
    }

    void timppoweroff()
    {
        colorlayer.saturation.value = 25;
        paninilayer.distance.value = 0;
        vignettelayer.intensity.value = 0;
        vignettelayer.color.value = new Color(0, 0, 0, 1);
    }    

    void respawncheckoff()
    {
       chromaticlayer.intensity.value = 0;
       vignettelayer.intensity.value = 0;
     }

    void powerupcheckon()
    {
        vignettelayer.intensity.value = intensitate;
        chromaticlayer.intensity.value = 1;
    }

    void powerupcheckoff()
    {
        chromaticlayer.intensity.value = 0;
        vignettelayer.intensity.value = 0;

    }




    //AD SYSTEM IMPLEMENTATION TEST AD SYSTEM IMPLEMENTATION TEST AD SYSTEM IMPLEMENTATION TEST AD SYSTEM IMPLEMENTATION TEST AD SYSTEM IMPLEMENTATION TEST
    //AD SYSTEM IMPLEMENTATION TEST AD SYSTEM IMPLEMENTATION TEST AD SYSTEM IMPLEMENTATION TEST AD SYSTEM IMPLEMENTATION TEST AD SYSTEM IMPLEMENTATION TEST



    public void ShowRewardedVideo()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(mySurfacingId))
        {
            Advertisement.Show(mySurfacingId);
        }
        else
        {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            revindupaad();
            PlayerPrefs.SetInt("NumardeBani", PlayerPrefs.GetInt("NumardeBani") + 20);
            Debug.Log("Am efectuat +20");
            // Reward the user for watching the ad to completion.
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady(string surfacingId)
    {
        // If the ready Ad Unit or legacy Placement is rewarded, show the ad:
        if (surfacingId == mySurfacingId)
        {
            // Optional actions to take when theAd Unit or legacy Placement becomes ready (for example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string surfacingId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
}




