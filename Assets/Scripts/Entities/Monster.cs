using System.Collections;
using System.Collections.Generic;

using UnityEngine;
public class Monster : Entity
{
    public Monster(HexCell parent, string name) : base(parent)
    {
        this.model = new EntityModel(name);
        this.view = new EntityView(name);
        var sprite = SpriteLoader.GetRandomMonster();
        parent.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
    }
}
