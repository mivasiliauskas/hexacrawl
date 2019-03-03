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

    public void Move(HexDirection direction)
    {
        if (!parent.neighbours.ContainsKey(direction))
        {
            return;
        }

        HexCell neighbour = this.parent.neighbours[direction];

        model.Health -= neighbour.entity.model.Health;

        if (model.Health < 0 ) {
            Game.ForceGameOver();
        }

        AudioManager.audioSource.PlayOneShot(this.view.view.moveSound);
        this.parent.SetNeighboursAllowed(false);

        // switch entities
        Entity neighbourEntity = neighbour.entity;
        neighbour.entity = this;
        this.parent.entity = neighbourEntity;

        // switch transforms
        Transform neighbourSprite = neighbour.Sprite;
        this.parent.Sprite.SetParent(neighbour.transform, false);
        neighbourSprite.SetParent(this.parent.transform, false);

        this.parent = neighbour;

        this.parent.SetNeighboursAllowed(true);
    }
}
