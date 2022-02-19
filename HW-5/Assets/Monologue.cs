using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monologue : MonoBehaviour
{
    public string[] Lines;
    public int currentLine = 0;
    private void Start()
    {
        FindObjectOfType<PlayerMovment>().enabled = false;
        GetComponent<Text>().text = Lines[currentLine];
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (currentLine == Lines.Length -1)
            {
                GetComponent<Text>().text = "";
                FindObjectOfType<PlayerMovment>().enabled = true;
                Destroy(this);
            }
            if (currentLine < Lines.Length - 1)
                ChangeLines();
        }
    }

    private void ChangeLines()
    {
        currentLine++;
        GetComponent<Text>().text = Lines[currentLine];
    }
}
