using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{
    public string messege;
    public Text textElement;

    public void Setup(string str)
    {
        this.messege = str;
        textElement.text = str;
        gameObject.SetActive(true);
       
    }


    public void RestartButton()
    {
        SceneManager.LoadScene("momo");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
