using UnityEngine;

public class Troll : Enemy
{
    protected override void Move()
    {
        transform.position += (player.transform.position - transform.position).normalized * Time.deltaTime;
    }
}
