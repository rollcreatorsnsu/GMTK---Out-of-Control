using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Player : MonoBehaviour
{
    public delegate void Death();
    public static event Death PlayerIsDead;

    [SerializeField] private float health;

    // Start is called before the first frame update
    void Start()
    {
        Game.MagicUpdated += MagicUpdateHandler;
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

    private void Die()
    {
        PlayerIsDead.Invoke();
    }

    private void MagicUpdateHandler(Magic magic)
    {

    }

    public void Hit(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            Die();
        }
    }

}
