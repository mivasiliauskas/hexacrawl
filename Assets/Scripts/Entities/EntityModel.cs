using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class EntityModel
{
    public EntityModelTemplate model;

    public int Health;

    public EntityModel(string name)
    {
        this.model = EntityModelTemplate.characters.First(x => x.Name.Equals(name));
        this.Health = model.MaxHealth;
    }
}
