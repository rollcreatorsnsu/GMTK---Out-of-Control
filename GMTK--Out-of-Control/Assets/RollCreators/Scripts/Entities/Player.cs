using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(Animator))]
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

    public delegate void HitHandler(float health);
    public static event HitHandler PlayerIsHit;
    
    private static Dictionary<Magic, string> magicAnimationNames = new Dictionary<Magic, string>();

    static Player()
    {
        magicAnimationNames.Add(Magic.FIREBALL, "Fireball");
        magicAnimationNames.Add(Magic.ICE_WALL, "Ice Wall");
        magicAnimationNames.Add(Magic.LIGHTNING_STRIKE, "Lightning Strike");
        magicAnimationNames.Add(Magic.NATURE_RISES, "Nature Rises");
    }
    
    [SerializeField] private float health;
    [SerializeField] private float hitTime = 0.5f;
    [SerializeField] private float attackTime = 0.5f;
    [SerializeField] private List<MagicMapItem> magicsList;
    [SerializeField] private Transform firePoint;
    private float lastHit = 0;
    private float lastAttack = 0;
    private Magic magic = Magic.LIGHTNING_STRIKE;
    private Dictionary<Magic, GameObject> magics = new Dictionary<Magic, GameObject>();
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        foreach (MagicMapItem magicItem in magicsList)
        {
            magics.Add(magicItem.magicEnum, magicItem.magicObject);
        }
        Game.MagicUpdated += MagicUpdateHandler;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
            transform.position += Vector3.left * Time.deltaTime;
            Walk();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 scale = transform.localScale;
            scale.x = 1;
            transform.localScale = scale;
            transform.position += Vector3.right * Time.deltaTime;
            Walk();
        }
        
        if (Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.Play("Jump");
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            Attack();
        }
    }

    private void Walk()
    {
        animator.Play("Walking");
    }

    private void Attack()
    {
        if (Time.time - lastAttack < attackTime) return;
        animator.Play(magicAnimationNames[magic]);
        lastAttack = Time.time;
        Instantiate(magics[magic], firePoint.position, Quaternion.identity);
    }

    private void Die()
    {
        animator.Play("Die");
        PlayerIsDead.Invoke();
    }

    private void MagicUpdateHandler(Magic magic)
    {
        this.magic = magic;
    }

    public void Hit(float damage)
    {
        if (Time.time - lastHit < hitTime) return;
        animator.Play("Hit");
        lastHit = Time.time;
        health -= damage;
        PlayerIsHit?.Invoke(health);
        if (health < 0)
        {
            Die();
        }
    }

}
