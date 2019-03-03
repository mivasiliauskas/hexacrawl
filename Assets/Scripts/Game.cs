using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    public static Player Player;

    public static void ForceGameOver()
    {
        GameObject.Find("Sounds").transform.Find("You Lose").GetComponent<AudioSource>().Play();

        GameObject.Find("HUD").transform.Find("Game Over").gameObject.SetActive(true);
    }
}
