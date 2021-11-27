using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offsrt;
    public float smothSpeed = 0.125f;

    private void Start()
    {
        offsrt = transform.position - target.transform.position;
    }

    //runs right after update
    void LateUpdate()
    {
        Vector3 newPos = target.transform.position + offsrt;

        transform.position = newPos;
    }
}