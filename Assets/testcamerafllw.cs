using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcamerafllw : MonoBehaviour
{
    public float smoothspeed = 1.25f;
    public Vector3 offset;
    public Transform player;

    void Update()
    {
        Vector3 desirepos = player.transform.position + offset;
        Vector3 smooth = Vector3.Lerp(transform.position, desirepos, smoothspeed);
        transform.position = smooth;
        transform.LookAt(player);
    }
}
