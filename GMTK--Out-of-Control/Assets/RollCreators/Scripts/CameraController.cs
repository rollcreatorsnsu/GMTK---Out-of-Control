using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Player player;
    private void Update()
    {
        float playerX = Camera.main.WorldToViewportPoint(player.transform.position).x;
        if (playerX < 0.1)
        {
            Camera.main.transform.position += Vector3.left * Time.deltaTime * player.speed;
        }
        else if (playerX > 0.9)
        {
            Camera.main.transform.position += Vector3.right * Time.deltaTime * player.speed;
        }
    }
}
