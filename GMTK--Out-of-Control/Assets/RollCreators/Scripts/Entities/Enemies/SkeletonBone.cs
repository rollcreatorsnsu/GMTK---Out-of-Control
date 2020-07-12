using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBone : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed = 2;
    private Player player;
    private Vector3 direction;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>(); // TODO: optimize
        direction = player.transform.position.x < transform.position.x ? Vector3.left : Vector3.right;
    }

    void Update()
    {
        Move();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        bool isPlayer = other.gameObject.CompareTag("Player");
        if (isPlayer || other.gameObject.CompareTag("Solid"))
        {
            if (isPlayer)
            {
                player.Hit(damage);
            }
            Destroy(gameObject);
        }
    }

    protected void Move()
    {
        transform.position += direction * Time.deltaTime * speed;
    }
}
