using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D), typeof(Animator))]
public class IceWall : MonoBehaviour, IMagic
{
    [SerializeField] private Animator animator;
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
        animator.Play("Ice Wall_destroy");
    }
}
