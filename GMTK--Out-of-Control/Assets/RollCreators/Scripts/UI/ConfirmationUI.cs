﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmationUI : MonoBehaviour
{
    public void Yes()
    {
        SceneManager.LoadScene("Menu");
    }

    public void No()
    {
        gameObject.SetActive(false);
    }
}
