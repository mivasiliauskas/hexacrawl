using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class EntityView
{
    public EntityViewTemplate view;
    public EntityView(string name)
    {
        this.view = EntityViewTemplate.characters.First(x => x.Name.Equals(name));
    }
}
