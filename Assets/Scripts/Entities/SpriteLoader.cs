using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class SpriteLoader
{
    static Sprite[] characters;
    static Sprite[] monsters;
    static Sprite[] potions;

    public static Sprite[] sprites;

    static System.Random random = new System.Random();

    static SpriteLoader()
    {
        sprites = Resources.LoadAll<Sprite>("Sprites");
        characters = sprites.Where(s => s.name.StartsWith("characters")).ToArray<Sprite>();
        monsters = sprites.Where(s => s.name.StartsWith("monsters")).ToArray<Sprite>();
        potions = sprites.Where(s => s.name.StartsWith("potions")).ToArray<Sprite>();
    }

    public static Sprite GetRandomCharacter()
    {
        return characters[random.Next(characters.Length)];
    }
    public static Sprite GetRandomMonster()
    {
        return monsters[random.Next(monsters.Length)];
    }
    public static Sprite GetPotion(string name)
    {
        name = name.Replace("potion", "potions");
        return potions.First(x => x.name.Equals(name));
    }
}
