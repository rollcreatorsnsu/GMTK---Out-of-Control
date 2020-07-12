using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] bool jump_move;
    [SerializeField] float jump_speed = 200;
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
    [SerializeField] private GameObject magicCircle;
    public float speed = 2;
    private float lastHit = 0;
    private float lastAttack = 0;
    private Magic magic = Magic.FIREBALL;
    private Dictionary<Magic, GameObject> magics = new Dictionary<Magic, GameObject>();
    private Animator animator;
    
    
    // Start is called before the first frame update
    void Start()
    {
        jump_move = false;
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
        if (health < 0) return;
//        Debug.Log(jump_move);
        if (Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.UpArrow) && !jump_move)
        {
            jump_move = true;
            transform.position += Vector3.up * Time.deltaTime * jump_speed;
            animator.Play("Jump");
        }

        if (jump_move)
        {
            transform.position += Vector3.up * Time.deltaTime * jump_speed;
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
            scale = magicCircle.transform.localScale;
            scale.x = -1;
            magicCircle.transform.localScale = scale;
            transform.position += Vector3.left * Time.deltaTime * speed;
            Walk();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 scale = transform.localScale;
            scale.x = 1;
            transform.localScale = scale;
            scale = magicCircle.transform.localScale;
            scale.x = 1;
            magicCircle.transform.localScale = scale;
            transform.position += Vector3.right * Time.deltaTime * speed;
            Walk();
        }
        
        if (Input.GetKeyUp(KeyCode.X) && !jump_move)
        {
            Attack();
        }
        
    }

    public void Jumped()
    {
        Debug.Log("jumped");
        jump_move = false;
    }

    private void Walk()
    {
        if (!jump_move)
        {
            animator.Play("Walking");
        }
        else
        {
            Debug.Log("Move");
        }
    }

    private void Attack()
    {
        if (Time.time - lastAttack < attackTime) return;
        animator.Play(magicAnimationNames[magic]);
        lastAttack = Time.time;
    }

    public void DoAttack(Magic magic)
    {
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
        if (Time.time - lastHit < hitTime || health < 0) return;
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
