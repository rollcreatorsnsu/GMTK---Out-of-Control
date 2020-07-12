using UnityEngine;

public class Skeleton : Enemy
{
    protected override void Move()
    {
        transform.position += (player.transform.position - transform.position).normalized * Time.deltaTime;
    }
}
