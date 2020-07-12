using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBone : MonoBehaviour
{
    [SerializeField] private float damage;
    private Player player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>(); // TODO: optimize
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
        transform.position += (player.transform.position.x < transform.position.x ? Vector3.left : Vector3.right) * Time.deltaTime;
    }
}
