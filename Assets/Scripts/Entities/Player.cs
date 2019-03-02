using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
public class Player : Entity
{
    public Player(Component parent) : base(parent)
    {
        var sprite = SpriteLoader.sprites.First(s => s.name.StartsWith("hiwky"));
        if (sprite == null)
        {
            sprite = SpriteLoader.GetRandomCharacter();
        }
        parent.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
    }
}
