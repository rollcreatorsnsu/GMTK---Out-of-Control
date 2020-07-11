using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FieldOfView : MonoBehaviour 
{
    public delegate void PlayerInHandler(Player player);
    public delegate void PlayerOutHandler();
    public event PlayerInHandler PlayerIn;
    public event PlayerOutHandler PlayerOut;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerIn.Invoke(other.gameObject.GetComponent<Player>());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerOut.Invoke();
        }
    }
}
