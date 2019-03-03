using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Entity
{
    public HexCell parent;

    public EntityView view;
    public EntityModel model;

    public Entity(HexCell parent)
    {
        this.parent = parent;
    }

    public void Move(HexDirection direction){
        
            AudioManager.audioSource.PlayOneShot(this.view.view.moveSound);
        
            this.parent.SetNeighboursAllowed(false);

            HexCell neighbour = this.parent.neighbours[direction];

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
