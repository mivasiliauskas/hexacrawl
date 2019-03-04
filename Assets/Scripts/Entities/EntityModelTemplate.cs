using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityModelTemplate
{
    public string Name { get; private set; }
    public int MaxHealth { get; private set; }

    public EntityModelTemplate(string name, int health = 0)
    {
        Name = name;
        MaxHealth = health;
    }

    public static List<EntityModelTemplate> characters = new List<EntityModelTemplate>(){
        new EntityModelTemplate("none", 0),
        new EntityModelTemplate("player", 3),
        new EntityModelTemplate("monster_1", 1),
        new EntityModelTemplate("monster_2", 2),
        new EntityModelTemplate("potion_0", 1),
    };
}
