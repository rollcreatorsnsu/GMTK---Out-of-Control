using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroUI : MonoBehaviour
{
    [SerializeField] private AudioSource music;

    private void Start()
    {
        DontDestroyOnLoad(music.gameObject);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
