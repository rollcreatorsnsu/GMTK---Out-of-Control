using UnityEngine;

public class Game : MonoBehaviour
{
    public delegate void MagicUpdateHandler(Magic magic);
    public static event MagicUpdateHandler MagicUpdated;

    private Magic magic;
    // Start is called before the first frame update
    void Start()
    {
        Player.PlayerIsDead += GameOver;
    }

    public void SetCurrentMagic(Magic magic)
    {
        this.magic = magic;
        MagicUpdated.Invoke(this.magic);
    }

    private void GameOver()
    {
        
    }
}
