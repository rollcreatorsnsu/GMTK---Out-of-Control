using UnityEngine;
using UnityEngine.Timeline;

public class Skeleton : Enemy
{
    [SerializeField] private float distance;
    [SerializeField] private GameObject bone;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    protected override void Move()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > distance)
        {
            animator.Play("Move");
            transform.position += (player.transform.position - transform.position).normalized * Time.deltaTime;
        }
        else
        {
            animator.Play("Attack");
        }
    }

    public void Attack()
    {
        Instantiate(bone, transform.position, Quaternion.identity);
    }
    
    protected override void Die()
    {
        animator.Play("Die");
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
}
