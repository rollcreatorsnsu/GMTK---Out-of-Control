using UnityEngine;

public class Bat : Enemy
{
    protected override void Move()
    {
        transform.position += (player.transform.position - transform.position).normalized * Time.deltaTime;
    }
}
