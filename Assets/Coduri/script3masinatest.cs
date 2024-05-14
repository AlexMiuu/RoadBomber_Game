using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class script3masinatest : MonoBehaviour
{

    [System.Serializable]
    public class AxleInfo
    {
        public WheelCollider leftWheel;
        public WheelCollider rightWheel;
        public bool motor;
        public bool steering;
    }


    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public Transform centru;
    private Rigidbody rb;
    public Joystick joyy;

    //public Transform asta;
    public int treap=100;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass=centru.localPosition;
    }
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

     Transform visualWheel = collider.transform.GetChild(0);

       var  position=Vector3.zero;
       var  rotation=Quaternion.identity ;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void Update()
    {

        float motor = maxMotorTorque;
        float steering = maxSteeringAngle * joyy.Horizontal;

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
        Debug.Log(motor);
        if(this.transform.position.z>treap)
        {
            maxMotorTorque += 25;
            treap += 400;
            PlayerPrefs.SetFloat("TreaptaViteza", maxMotorTorque);
        }

    }
}
