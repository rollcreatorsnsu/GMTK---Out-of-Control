﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public delegate void MagicUpdateHandler(Magic magic);
    public event MagicUpdateHandler MagicUpdated;

    private Magic magic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCurrentMagic(Magic magic)
    {
        this.magic = magic;
        MagicUpdated.Invoke(this.magic);
    }
}
