using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D), typeof(Animator))]
public class LightningStrike : MonoBehaviour, IMagic
{

    [SerializeField] private float damage;
    private HashSet<GameObject> enemies = new HashSet<GameObject>();
    private GameObject player;
    private bool updated = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!updated)
        {
            updated = true;
            return;
        }
        float minDistance = Single.PositiveInfinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemyOnj in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemyOnj.transform.position);
            if (distance < minDistance)
            {
                nearestEnemy = enemyOnj;
                minDistance = distance;
            }
        }

        if (nearestEnemy == null)
        {
            HitPlayer(player.GetComponent<Player>());
        }
        else
        {
            HitEnemy(nearestEnemy.GetComponent<Enemy>());
        }
    }

    private void HitPlayer(Player player)
    {
        animator.Play("Light Bolt");
        player.Hit(damage);
    }
    
    private void HitEnemy(Enemy enemy)
    {
        transform.position = enemy.transform.position;
        animator.Play("Light Bolt");
        enemy.Hit(damage);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemies.Add(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
        }
    }
}
