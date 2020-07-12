using UnityEngine;
using UnityEngine.Timeline;

public class Skeleton : Enemy
{
    [SerializeField] private float distance;
    [SerializeField] private GameObject bone;
    [SerializeField] private Transform firePoint;
    private Animator animator;

    void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }
    protected override void Move()
    {
        Vector3 scale = transform.localScale;
        scale.x = transform.position.x > player.transform.position.x ? -1 : 1;
        transform.localScale = scale;
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
        Instantiate(bone, firePoint.position, Quaternion.identity);
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
