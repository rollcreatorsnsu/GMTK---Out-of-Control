using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Rise : MonoBehaviour
{
    [SerializeField] private string dieAnimationName;

    private void Delete()
    {
        Destroy(gameObject);
    }

    public void Die()
    {
        GetComponent<Animator>().Play(dieAnimationName);
    }
}
