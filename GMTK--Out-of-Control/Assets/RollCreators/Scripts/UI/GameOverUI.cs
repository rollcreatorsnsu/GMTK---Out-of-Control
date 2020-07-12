using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Text text;

    public void Dead()
    {
        text.text = "You are dead!";
        gameObject.SetActive(true);
    }

    public void Win()
    {
        text.text = "You won!";
        gameObject.SetActive(true);
    }

    public void OK()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
