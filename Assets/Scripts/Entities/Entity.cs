using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Entity
{
    protected Component parent;

    public Entity(Component parent)
    {
        this.parent = parent;
    }

}
