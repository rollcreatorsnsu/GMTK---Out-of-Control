using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Text healthBar;
    [SerializeField] private GameObject pausePanel;
    public void UpdateHealthBar(float health)
    {
        healthBar.text = $"{health}/5";
    }

    public void Menu()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
}
