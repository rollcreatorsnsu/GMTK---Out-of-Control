using UnityEngine;

public class Bat : Enemy
{

    private Animator animator;

    void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.Hit(damage);
        }
    }

    protected override void Move()
    {
        animator.Play("Fly");
        transform.position += (player.transform.position - transform.position).normalized * Time.deltaTime;
    }

    protected override void Die()
    {
        animator.Play("Вшу");
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
}
