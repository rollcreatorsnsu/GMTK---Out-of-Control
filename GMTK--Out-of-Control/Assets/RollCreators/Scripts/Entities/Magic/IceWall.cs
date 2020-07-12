using System;
using System.Collections;
using System.Dynamic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D), typeof(Animator))]
public class IceWall : MonoBehaviour, IMagic
{
    private Animator animator;
    [SerializeField] private float secondsToLife = 7;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Fall());
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(secondsToLife);
        animator.Play("Ice_Wall_destroy");
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
}
