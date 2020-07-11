using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class IceWall : MonoBehaviour, IMagic
{
    [SerializeField] private float secondsToLife = 7;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, secondsToLife);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
