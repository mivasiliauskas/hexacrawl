using System.Collections;
using System.Collections.Generic;

using UnityEngine;
public class Player : Entity
{
    public Player(Component parent) : base(parent)
    {
        var sprite = SpriteLoader.GetRandomCharacter();
        parent.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
    }
}
