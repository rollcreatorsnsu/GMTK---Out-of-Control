using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Player : MonoBehaviour
{
    [Serializable]
    private struct MagicMapItem
    {
        public Magic magicEnum;
        public GameObject magicObject;
    }
    
    public delegate void DeathHandler();
    public static event DeathHandler PlayerIsDead;
    
    [SerializeField] private float health;
    [SerializeField] private float hitTime = 0.5f;
    [SerializeField] private float attackTime = 0.5f;
    [SerializeField] private List<MagicMapItem> magicsList;
    private float lastHit = 0;
    private float lastAttack = 0;
    private Magic magic;
    private Dictionary<Magic, GameObject> magics;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (MagicMapItem magicItem in magicsList)
        {
            magics.Add(magicItem.magicEnum, magicItem.magicObject);
        }
        Game.MagicUpdated += MagicUpdateHandler;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Time.deltaTime;
        }
        
        if (Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            transform.position += Vector3.up;
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (Time.time - lastAttack < attackTime) return;
        lastAttack = Time.time;
        Instantiate(magics[magic]);
    }

    private void Die()
    {
        PlayerIsDead.Invoke();
    }

    private void MagicUpdateHandler(Magic magic)
    {
        this.magic = magic;
    }

    public void Hit(float damage)
    {
        if (Time.time - lastHit < hitTime) return;
        lastHit = Time.time;
        health -= damage;
        if (health < 0)
        {
            Die();
        }
    }

}
