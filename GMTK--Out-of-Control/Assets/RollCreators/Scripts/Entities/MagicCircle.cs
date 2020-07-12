using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicCircle : MonoBehaviour
{
    
    [SerializeField] private Game game;
    [SerializeField] private List<Magic> enums;
    [SerializeField] private List<Sprite> activeSprites;
    [SerializeField] private List<Sprite> inactiveSprites;
    [SerializeField] private List<SpriteRenderer> images;
    private int iterations = 0;

    public void SetState()
    {
        iterations++;
        iterations %= 4;
        images[0].sprite = activeSprites[iterations];
        for (int i = 1; i < 4; i++)
        {
            images[i].sprite = inactiveSprites[(iterations + i) % 4];
        }
        game.SetCurrentMagic(enums[iterations]);
    }
}
