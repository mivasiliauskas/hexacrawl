using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Entity
{
    protected Component parent;

    public AudioClip moveSound;

    public Entity(Component parent)
    {
        this.parent = parent;
        moveSound = (AudioClip)Resources.Load("Audio/footstep00");
    }

}
