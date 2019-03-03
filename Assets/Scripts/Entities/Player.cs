using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
public class Player : Entity
{
    public Player(HexCell parent) : base(parent)
    {
        this.view = new EntityView("player");
        this.model = new EntityModel("player");

        var sprite = SpriteLoader.sprites.First(s => s.name.StartsWith("hiwky"));
        if (sprite == null)
        {
            sprite = SpriteLoader.GetRandomCharacter();
        }
        parent.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
    }
}
