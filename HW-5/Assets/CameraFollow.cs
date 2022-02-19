using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offsrt;
    public float smothSpeed = 0.125f;
    const float WaterHeight = (float)-5.59;
    bool stopFollowing;//stop the camera when you fall throw the water .
    public GameManager gameManager;

    bool banditDrowned = false;

    Vector3 lastPos;

    private void Start()
    {
        offsrt = transform.position - target.transform.position;//get the position of the bandit
    }

    //runs right after update
    void LateUpdate()
    {
        if (!stopFollowing)
        {
            Vector3 newPos = target.transform.position + offsrt;
            //stop Following at a certain hight 
            if (transform.position.y <= WaterHeight && banditDrowned == false)
            {
                stopFollowing = true;
                banditDrowned = true;
                gameManager.EndGame();

            }
            transform.position = newPos;
        }
    }



}