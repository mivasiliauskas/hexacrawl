using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Entity
{
    public HexCell parent;

    public EntityView view;
    public EntityModel model;

    public Entity(HexCell parent, string name)
    {
        this.model = new EntityModel(name);
        this.view = new EntityView(name);
        this.parent = parent;
    }

}
