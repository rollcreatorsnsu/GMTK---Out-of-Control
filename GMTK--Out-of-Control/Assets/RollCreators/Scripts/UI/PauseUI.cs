using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private Text soundButtonText;
    [SerializeField] private GameObject confirmationUI;

    public void Continue()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Sound()
    {
        if (AudioListener.volume == 1)
        {
            soundButtonText.text = "Sound ON";
            AudioListener.volume = 0;
        }
        else
        {
            soundButtonText.text = "Sound OFF";
            AudioListener.volume = 1;
        }
    }

    public void Exit()
    {
        confirmationUI.SetActive(true);
    }
}
