using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public int iLevelToLoad;
    public string sLevelToLoad;
    public Transform player;

    public bool useIntegerToLoadLevel = false;
    private void OnLevelWasLoaded(int level)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject; // to acess all the information about the object we collided with

        if (collisionGameObject.name == "Player")
        {
            LoadScene();
        }
    }

    void LoadScene()
    {
        if (player.position.x >= 82.511)
        {
            SceneManager.LoadScene(sLevelToLoad);
        }
    }
}