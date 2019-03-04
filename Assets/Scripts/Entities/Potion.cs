using System.Collections;
using System.Collections.Generic;

using UnityEngine;
public class Potion : Entity
{
    public Potion(HexCell parent, string name) : base(parent, name)
    {
        var sprite = SpriteLoader.GetPotion(name);
        parent.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
    }
}
