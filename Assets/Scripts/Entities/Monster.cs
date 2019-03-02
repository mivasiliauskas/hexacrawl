using System.Collections;
using System.Collections.Generic;

using UnityEngine;
public class Monster : Entity
{
    public Monster(Component parent) : base(parent)
    {
        var sprite = SpriteLoader.GetRandomMonster();
        parent.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
    }
}
