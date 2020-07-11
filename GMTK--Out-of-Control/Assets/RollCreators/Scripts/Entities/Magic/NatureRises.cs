using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class NatureRises : MonoBehaviour, IMagic
{
    [SerializeField] private GameObject rise;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            rises.Add(Instantiate(rise, other.gameObject.transform.position, Quaternion.identity));
        }
    }
}
