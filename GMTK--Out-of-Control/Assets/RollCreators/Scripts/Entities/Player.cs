using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private Game game;

    // Start is called before the first frame update
    void Start()
    {
        game.MagicUpdated += MagicUpdateHandler;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            transform.position += Vector3.up;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime;
        }
    }

    private void MagicUpdateHandler(Magic magic)
    {
        
    }
}
