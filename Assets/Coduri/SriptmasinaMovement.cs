using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SriptmasinaMovement : MonoBehaviour
{
    public Transform centerOfMass;

    public WheelCollider collider_dreapta_fata;
    public WheelCollider collider_stanga_fata;
    public WheelCollider collider_dreapta_spate;
    public WheelCollider collider_stanga_spate;

    public Transform roata_dreapta_fata;
    public Transform roata_stanga_fata;
    public Transform roata_dreapta_spate;
    public Transform roata_stanga_spate;

    public float motorTorque=200f;
    public float virajmaxim=20f;
    private Rigidbody rigidb;
    void Start()
    {
        rigidb = GetComponent<Rigidbody>();
        rigidb.centerOfMass = centerOfMass.localPosition;
    }

    void FixedUpdate()
    {
        collider_dreapta_spate.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        collider_stanga_spate.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        collider_stanga_fata.steerAngle = Input.GetAxis("Horizontal") * virajmaxim;
            collider_dreapta_fata.steerAngle= Input.GetAxis("Horizontal") * virajmaxim;
    }

     void Update()
    {
        var pozitie = Vector3.zero;
        var rotatie = Quaternion.identity;

        collider_dreapta_fata.GetWorldPose(out pozitie, out rotatie);
roata_dreapta_fata.position = pozitie;
        roata_dreapta_fata.rotation = rotatie * Quaternion.Euler(0, 180, 0);
        

        collider_dreapta_spate.GetWorldPose(out pozitie, out rotatie);
  roata_dreapta_spate.position = pozitie;
        roata_dreapta_spate.rotation = rotatie* Quaternion.Euler(0,180,0);
      

        collider_stanga_fata.GetWorldPose(out pozitie, out rotatie);
              roata_stanga_fata.position = pozitie;
        roata_stanga_fata.rotation = rotatie;
 

        collider_stanga_spate.GetWorldPose(out pozitie, out rotatie);
              roata_stanga_spate.position = pozitie;
        roata_stanga_spate.rotation = rotatie;


       

    }
}
