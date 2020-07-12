using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected FieldOfView fieldOfView;
    [SerializeField] protected float health;
    [SerializeField] protected float damage;
    protected Player player;

    protected void Start()
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

    public void Hit(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            Die();
        }
    }

    abstract protected void Move();

    abstract protected void Die();

}
