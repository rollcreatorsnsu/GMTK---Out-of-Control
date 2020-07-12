using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationUI : MonoBehaviour
{
    public void Yes()
    {
        Application.Quit();
    }

    public void No()
    {
        gameObject.SetActive(false);
    }
}
