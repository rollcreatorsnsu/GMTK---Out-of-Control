using UnityEngine;

public class Bat : Enemy
{

    private Animator animator;
    private bool isFlied = false;

    void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.Hit(damage);
        }
    }

    protected override void Move()
    {
        if (!isFlied)
        {
            animator.Play("ToHunt");
            isFlied = true;
        }
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
