using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{

    public int Health
    {
        get
        {
            return model.Health;
        }
        set
        {
            if (model.model.MaxHealth < value)
            {
                value = model.model.MaxHealth;
            }
            model.Health = value;

            GameObject.Find("HUD").transform.Find("Health").FindDeepChild("Value").GetComponent<Text>().text = value.ToString();

            if (value <= 0)
            {
                Game.ForceGameOver();
            }
        }
    }

    public Player(HexCell parent) : base(parent, "player")
    {
        // makes little sense
        Health = this.model.Health;

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

        AudioManager.audioSource.PlayOneShot(this.view.view.moveSound);

        this.parent.SetNeighboursAllowed(false);

        if (neighbour.entity is Monster)
        {
            Health -= neighbour.entity.model.Health;

            // switch entities
            Entity neighbourEntity = neighbour.entity;
            neighbour.entity = this;
            this.parent.entity = neighbourEntity;

            // switch transforms
            Transform neighbourSprite = neighbour.Sprite;
            this.parent.Sprite.SetParent(neighbour.transform, false);
            neighbourSprite.SetParent(this.parent.transform, false);

            this.parent = neighbour;
        }
        else if (neighbour.entity is Potion)
        {
            Health += neighbour.entity.model.Health;

            this.parent.entity = new None(this.parent);
            neighbour.entity = this;

            Object.Destroy(neighbour.Sprite.gameObject);
            this.parent.Sprite.SetParent(neighbour.transform, false);

            this.parent = neighbour;
        }
        else if (neighbour.entity is None)
        {

            // switch entities
            Entity neighbourEntity = neighbour.entity;
            neighbour.entity = this;
            this.parent.entity = neighbourEntity;

            // switch transforms
            this.parent.Sprite.SetParent(neighbour.transform, false);

            this.parent = neighbour;
        }

        this.parent.SetNeighboursAllowed(true);
    }
}
