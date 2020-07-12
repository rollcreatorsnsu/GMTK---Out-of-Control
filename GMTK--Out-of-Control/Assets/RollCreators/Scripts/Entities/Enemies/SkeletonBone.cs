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
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy")) return;
        if (other.gameObject.CompareTag("Player"))
        {
            player.Hit(damage);
        }
        Destroy(gameObject);
    }

    protected void Move()
    {
        transform.position += (player.transform.position - transform.position).normalized * Time.deltaTime;
    }
}
