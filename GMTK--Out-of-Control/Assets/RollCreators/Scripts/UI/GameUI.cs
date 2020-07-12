using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private List<Image> healthBar;
    [SerializeField] private Sprite fullHpSprite;
    [SerializeField] private Sprite emptyHpSprite;

    public void UpdateHealthBar(float health)
    {
        for (int i = 0; i < 5; i++)
        {
            healthBar[0].sprite =  (health > i) ? fullHpSprite : emptyHpSprite;
        }
    }

    public void Menu()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
}
