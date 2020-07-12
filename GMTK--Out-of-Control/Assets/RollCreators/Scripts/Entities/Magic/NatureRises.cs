using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class NatureRises : MonoBehaviour, IMagic
{
    [SerializeField] private GameObject riseSmall;
    [SerializeField] private GameObject riseBig;
    [SerializeField] private float time;
    private List<GameObject> rises = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, time);
    }

    private void OnDestroy()
    {
        foreach (GameObject rise in rises)
        {
            Destroy(rise);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy is Skeleton)
            {
                rises.Add(Instantiate(riseSmall, other.gameObject.transform.position, Quaternion.identity));
            }
            else if (enemy is Troll)
            {
                rises.Add(Instantiate(riseBig, other.gameObject.transform.position, Quaternion.identity));
            }
        }
    }
}
