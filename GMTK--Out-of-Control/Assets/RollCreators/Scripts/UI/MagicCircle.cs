using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircle : MonoBehaviour
{
    [SerializeField] private Game game;
    
    public void SetState(Magic magic)
    {
        game.SetCurrentMagic(magic);
    }
}
