using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{

    public float smoothspeed = 1.25f;
    public Vector3 offset;
    public lista lis;
    void Update()
    {
        Vector3 desirepos = lis.obiect.position + offset;
        Vector3 smooth = Vector3.Lerp(transform.position, desirepos, smoothspeed);
        transform.position = smooth;
        transform.LookAt(lis.obiect);
    }
}
