using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityModelTemplate
{
    static System.Random random = new System.Random();

    public string Name { get; private set; }
    public int MaxHealth { get; private set; }

    public EntityModelTemplate(string name, int health)
    {
        Name = name;
        MaxHealth = health;
    }

    public static List<EntityModelTemplate> characters = new List<EntityModelTemplate>(){
        new EntityModelTemplate("player", 10),
        new EntityModelTemplate("monster_1", 10),
        new EntityModelTemplate("monster_2", 20),
    };

    public static EntityModelTemplate GetRandomMonster()
    {
        return characters[random.Next(characters.Count)];
    }

}
