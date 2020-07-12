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
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.Hit(damage);
        }
    }

    protected override void Move()
    {
        Vector3 scale = transform.localScale;
        scale.x = transform.position.x > player.transform.position.x ? -1 : 1;
        transform.localScale = scale;
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
