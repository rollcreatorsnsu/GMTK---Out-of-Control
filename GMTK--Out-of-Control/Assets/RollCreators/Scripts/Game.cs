using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    public delegate void MagicUpdateHandler(Magic magic);
    public static event MagicUpdateHandler MagicUpdated;

    [SerializeField] private GameUI gameUi;
    [SerializeField] private GameOverUI gameOverUi;
    private Magic magic;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Player.PlayerIsDead += GameOver;
        Player.PlayerIsHit += UpdateHealthBar;
        StartCoroutine(UpdateMagic()); // TODO: delete, just debug
    }

    public void SetCurrentMagic(Magic magic)
    {
        this.magic = magic;
        MagicUpdated?.Invoke(this.magic);
    }

    private void GameOver()
    {
        gameOverUi.Dead();
    }

    private void UpdateHealthBar(float health)
    {
        gameUi.UpdateHealthBar(health);
    }

    private IEnumerator UpdateMagic()
    {
        Magic[] magics = (Magic[])Enum.GetValues(typeof(Magic));
        SetCurrentMagic(magics[Random.Range(0, magics.Length)]);
        yield return new WaitForSeconds(0.5f);
    }
}
