using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DitzeGames.Effects;
public class tankscripittest : MonoBehaviour
{
    private bool isobstaclehit;
    public Transform barrel1;
    public Transform barrel2;
    public int viteza_barrel_spin;
    public Transform standulpttevi;
    public int viteza;
    public ParticleSystem muzzleflash;
    public ParticleSystem muzzleflash2;
    public ParticleSystem smoke;
    public ParticleSystem fire;
    // RaycastHit hit;
    public camerashacker cam;
    public Transform obiectdistrus;
    private int ok = 0;
    //--------------------------------------------------------------------------------------------------------------------------------------------------

    public float moveInput;
    private float turnInput;
    private bool isCarGrounded;
    private float moveInput2;

    public float airDrag;
    public float groundDrag;

    public float fwdSpeed;
    public float revSpeed;
    public float turnSpeed;

    public Rigidbody sphereRB;
    public int treap = 100;

    private float NewRotation;
    private float newmovement;
    // public Joystick joy;
    [SerializeField] private Transform target;
    public float range;
    //--------------------------------------------------------------------------------------------------------------------------------------------

    void Start()
    {
        InvokeRepeating("Track", 0.5f, 0.5f);
        sphereRB.transform.parent = null;

        muzzleflash.gameObject.SetActive(false);
        muzzleflash2.gameObject.SetActive(false);

        fire.gameObject.SetActive(false);
    }
/*
    public void shoot()
    {
        float degreesPerSecond = 360 * Time.deltaTime;

        // Instantiate(obiectdistrus, hit.transform.position, hit.transform.rotation);
        Vector3 direction = hit.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        standulpttevi.transform.rotation = Quaternion.RotateTowards(standulpttevi.transform.rotation, targetRotation, degreesPerSecond);
        muzzleflash.gameObject.SetActive(true);
        muzzleflash2.gameObject.SetActive(true);
        //cam.Shake();   
        StartCoroutine("waitillfire");
        Destroy(hit.transform.gameObject, 1.2f);
     
        //    hit.transform.gameObject.tag = "Untagged";

    }*/
/*
 IEnumerator waitillfire()
    {
        float n = 0;
        while(n<0.9f)
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
        cam.Shake();
        StopCoroutine("waitillfire");
    }
*/
     public void Track()
    {
        GameObject [] obstacole = GameObject.FindGameObjectsWithTag("obs");
        GameObject pp = null;
        float mini = 99999;
        foreach(GameObject obstacol in obstacole)
        {
            float dist = Vector3.Distance(obstacol.transform.position, transform.position);
            if (dist < mini)
            {
                pp = obstacol;
                mini = dist;
            }
        }
        if (pp != null && mini<range)
        {
            target = pp.transform;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TEST_VAR")
        {
            Instantiate(obiectdistrus, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }
    }
    void Update()
    {
        //ray();
        barrel1.transform.Rotate(0, 0, 180 * Time.deltaTime * viteza_barrel_spin);
        barrel2.transform.Rotate(0, 0, 180 * Time.deltaTime * viteza_barrel_spin);
        Vector3 poz = transform.position;

        //int obslayer = 40;


        moveInput = 10f;
        turnInput = Input.GetAxis("Horizontal");
        moveInput2 = Input.GetAxis("Vertical");
        // turnInput = Mathf.Clamp(turnInput, -90, 90);
        moveInput *= moveInput > 0 ? fwdSpeed : revSpeed;

        //set cars position to sphere
        transform.position = sphereRB.transform.position;

        //set cars rotation
        NewRotation = turnInput * turnSpeed * Time.smoothDeltaTime;
        transform.Rotate(0, NewRotation, 0, Space.World);
        //   transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        //sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
        newmovement = moveInput2 * moveInput * Time.smoothDeltaTime;
        sphereRB.transform.position += transform.forward * newmovement;
        //  sphereRB.AddForce(transform.forward * newmovement, ForceMode.Acceleration);

        if(target!=null)
        {
            float degreesPerSecond = 360 * Time.deltaTime;
            Vector3 direction = target.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            standulpttevi.transform.rotation = Quaternion.RotateTowards(standulpttevi.transform.rotation, targetRotation, degreesPerSecond);
            Destroy(target.transform.gameObject, 1f);
        }

/*
        if (Physics.Raycast(new Vector3(transform.position.x-10f, transform.position.y-5, transform.position.z), transform.forward, out hit, obslayer) && hit.transform.gameObject.tag == "obs")
        {

            shoot();
            Debug.DrawRay(transform.position, transform.forward * obslayer, Color.blue);
            return;
        }
 */
        //             |ROTATIE FATA|
       

        //      |ROTATIE DREAPTA|
       /* if (Physics.Raycast(transform.position, transform.right, out hit, obslayer) && hit.transform.gameObject.tag == "obs")
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
        muzzleflash.gameObject.SetActive(false);
        muzzleflash2.gameObject.SetActive(false);
       */


    }
    /*
    void ray()
    {
        Vector3 poz = this.transform.position;
        int obslayer = 40;
        RaycastHit hit;
        if (Physics.Raycast(poz, this.transform.TransformDirection(Vector3.forward), out hit, obslayer))
        {
            if (hit.transform.gameObject.tag == "obs")
            {/*
            float degreesPerSecond = 360 * Time.deltaTime;

            // Instantiate(obiectdistrus, hit.transform.position, hit.transform.rotation);
            Vector3 direction = hit.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            standulpttevi.transform.rotation = Quaternion.RotateTowards(standulpttevi.transform.rotation, targetRotation, degreesPerSecond);
            muzzleflash.gameObject.SetActive(true);
            muzzleflash2.gameObject.SetActive(true);
            //cam.Shake();   
            StartCoroutine("waitillfire");
            
                Destroy(hit.transform.gameObject);
                Debug.DrawRay(transform.position, transform.forward * obslayer, Color.red);
            }
            return;
        }
    }    */
    
   
}
