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
    private GameObject nearestEnemy = null;

    void Start()
    {
        player = GameObject.Find("Player"); // TODO: optimize
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
        foreach (GameObject enemyOnj in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemyOnj.transform.position);
            if (distance < minDistance)
            {
                nearestEnemy = enemyOnj;
                minDistance = distance;
            }
        }
        if (nearestEnemy != null)
        {
            transform.position = nearestEnemy.transform.position;
        }
        animator.Play("Light Bolt");
    }

    public void Hit()
    {
        if (nearestEnemy == null)
        {
            player.GetComponent<Player>().Hit(damage);
        }
        else
        {
            nearestEnemy.GetComponent<Enemy>().Hit(damage);
        }
        Destroy(gameObject);
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
