using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected FieldOfView fieldOfView;
    [SerializeField] protected float damage;
    protected Player player;

    void Start()
    {
        fieldOfView.PlayerIn += FollowPlayer;
        fieldOfView.PlayerOut += UnfollowPlayer;
    }

    void Update()
    {
        if (player == null) return;
        Move();
    }

    void FollowPlayer(Player player)
    {
        this.player = player;
    }

    void UnfollowPlayer()
    {
        player = null;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.Hit(damage);
        }
    }

    abstract protected void Move();

}
