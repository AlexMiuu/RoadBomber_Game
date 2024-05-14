using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankscriptV2 : MonoBehaviour
{
    private bool isobstaclehit;
    public Transform barrel1;
    public Transform barrel2;
    public int viteza_barrel_spin;
    public Transform standulpttevi;
    public int viteza;

    // public ParticleSystem smoke;
    // public ParticleSystem fire;
    //RaycastHit hit;
    //private int ok = 0;
    [SerializeField] private Transform target;
    public float range=40;
    //--------------------------------------------------------------------------------------------------------------------------------------------------
    //--------------------------------------------------------------------------------------------------------------------------------------------
    private void Start()
    {
        InvokeRepeating("Track", 0.5f, 0.5f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TEST_VAR")
        {
          //  Instantiate(obiectdistrus, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }
    }
     void Track()
    {
        GameObject[] obstacole = GameObject.FindGameObjectsWithTag("obs");
        GameObject pp = null;
        float mini = 999;
        foreach (GameObject obstacol in obstacole)
        {
            float dist = Vector3.Distance(obstacol.transform.position, transform.position);
            if (dist < mini)
            {
                pp = obstacol;
                mini = dist;
            }
        }
        if (pp != null && mini<=range)
        {
            target = pp.transform;
        }

    }
    void Update()
    {
        barrel1.transform.Rotate(0, 0, 180 * Time.deltaTime * viteza_barrel_spin);
        barrel2.transform.Rotate(0, 0, 180 * Time.deltaTime * viteza_barrel_spin);
        if (target != null)
        {
            float degreesPerSecond = 360 * Time.deltaTime;
            Vector3 direction = target.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            standulpttevi.transform.rotation = Quaternion.RotateTowards(standulpttevi.transform.rotation, targetRotation, degreesPerSecond);
            Destroy(target.transform.gameObject, 0.1f);
        }


        /* *COD VECHI* 
         * Vector3 poz = transform.position;

        int obslayer = 100;
         * -------------------------------------------------------------------------------------------------------------------------------------------
        //             |ROTATIE FATA|
        if (Physics.Raycast(transform.position, transform.forward, out hit, obslayer) && hit.transform.gameObject.tag == "obs")
        {

            shoot();
            Debug.DrawRay(transform.position, transform.forward * obslayer, Color.red);
            return;
        }

        //      |ROTATIE DREAPTA|
        if (Physics.Raycast(transform.position, transform.right, out hit, obslayer) && hit.transform.gameObject.tag == "obs")
        {

            shoot();
            Debug.DrawRay(transform.position, transform.right * obslayer, Color.red);
            return;
        }

        // |ROTATIE PE DIAGONALA DREAPTA|
        if (Physics.Raycast(poz, Quaternion.Euler(0, 45, 0) * transform.forward, out hit, obslayer) && hit.transform.gameObject.tag == "obs")
        {

            shoot();
            Debug.DrawRay(poz, transform.forward * obslayer, Color.green);
            return;
        }

        // |ROTATIE PE DIAGONALA STANGA|
        if (Physics.Raycast(poz, Quaternion.Euler(0, -45, 0) * transform.forward, out hit, obslayer) && hit.transform.gameObject.tag == "obs")
        {

            shoot();
            Debug.DrawRay(poz, transform.forward * obslayer, Color.green);
            return;
        }
        //  hit.transform.gameObject.tag = "Untagged";
        ok = 0;
        -----------------------------------------------------------------------------------------------------------------------------------------------------------
        *COD VECHI*
        */
    }
}
/*
    public void shoot()
    {
        float degreesPerSecond = 360 * Time.deltaTime;

        // Instantiate(obiectdistrus, hit.transform.position, hit.transform.rotation);
        Vector3 direction = hit.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        standulpttevi.transform.rotation = Quaternion.RotateTowards(standulpttevi.transform.rotation, targetRotation, degreesPerSecond);
      
        //cam.Shake();   
        // StartCoroutine("waitillfire");
        hit.collider.gameObject.GetComponent<MeshRenderer>().enabled = false;
        Destroy(hit.transform.gameObject,0.5f);

        hit.transform.gameObject.tag = "Untagged";

    }
*/
    /*
    IEnumerator waitillfire()
    {
        float n = 0;
        while (n < 0.9f)
        {
            n += Time.deltaTime;
            yield return null;
        }
        Transform clona = Instantiate(obiectdistrus, hit.transform.position, hit.transform.rotation);
        foreach (Transform child in clona)
        {
            if (child.TryGetComponent<Rigidbody>(out Rigidbody childbody))
            {
                childbody.AddExplosionForce(100f, clona.transform.position, 5f);
            }
        }
        Destroy(clona.gameObject, 1.5f);
        StopCoroutine("waitillfire");
    }
    */