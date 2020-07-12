using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FieldOfView : MonoBehaviour 
{
    public delegate void PlayerInHandler(Player player);
    public delegate void PlayerOutHandler();
    public event PlayerInHandler PlayerIn;
    public event PlayerOutHandler PlayerOut;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerIn?.Invoke(other.gameObject.GetComponent<Player>());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerOut?.Invoke();
        }
    }
}
