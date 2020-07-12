using UnityEngine;

public class Game : MonoBehaviour
{
    public delegate void MagicUpdateHandler(Magic magic);
    public static event MagicUpdateHandler MagicUpdated;

    [SerializeField] private GameUI gameUi;
    private Magic magic;
    // Start is called before the first frame update
    void Start()
    {
        Player.PlayerIsDead += GameOver;
        Player.PlayerIsHit += UpdateHealthBar;
    }

    public void SetCurrentMagic(Magic magic)
    {
        this.magic = magic;
        MagicUpdated.Invoke(this.magic);
    }

    private void GameOver()
    {
        
    }

    private void UpdateHealthBar(float health)
    {
        gameUi.UpdateHealthBar(health);
    }
}
