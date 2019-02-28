using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLoader
{
    static Sprite[] characters;

    static System.Random random = new System.Random();

    static SpriteLoader()
    {
        characters = Resources.LoadAll<Sprite>("Sprites");
    }

    public static Sprite GetRandomCharacter(){
        return characters[random.Next(characters.Length)];
    }
}
