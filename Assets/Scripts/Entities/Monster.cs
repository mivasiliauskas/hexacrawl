﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;
public class Monster : Entity
{
    public Monster(HexCell parent, string name) : base(parent, name)
    {
        var sprite = SpriteLoader.GetRandomMonster();
        parent.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
    }
}
