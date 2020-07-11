using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Fireball : MonoBehaviour, IMagic
{
    [SerializeField] private GameObject explosion;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Time.time;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Solid"))
        {
            Instantiate(explosion);
            Destroy(gameObject);
        }
    }
}
