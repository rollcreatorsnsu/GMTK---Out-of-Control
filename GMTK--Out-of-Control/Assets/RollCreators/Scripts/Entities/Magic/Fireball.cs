using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(Animator))]
public class Fireball : MonoBehaviour, IMagic
{
    [SerializeField] private GameObject explosion;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float speed = 4;
    private Vector3 direction;

    void Start()
    {
        bool isLeft = GameObject.Find("Player").transform.localScale.x < 0; // TODO: optimization
        direction = isLeft ? Vector3.left : Vector3.right;
        Vector3 scale = transform.localScale;
        scale.x = isLeft ? -1 : 1;
        transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime * speed;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Solid"))
        {
            Instantiate(explosion, firePoint.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
