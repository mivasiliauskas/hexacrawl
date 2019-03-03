using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityViewTemplate
{

    static System.Random random = new System.Random();

    public AudioClip moveSound;

    public string Name { get; private set; }

    public EntityViewTemplate(string name)
    {
        Name = name;
        moveSound = (AudioClip)Resources.Load("Audio/footstep00");
    }

    public static List<EntityViewTemplate> characters = new List<EntityViewTemplate>(){
        new EntityViewTemplate("player"),
        new EntityViewTemplate("monster_1"),
        new EntityViewTemplate("monster_2"),
    };

}
