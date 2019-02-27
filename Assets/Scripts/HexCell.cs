using UnityEngine;

public class HexCell : MonoBehaviour
{
    public Sprite[] characters;

    static System.Random random = new System.Random();

    void Awake()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = characters[random.Next(characters.Length)];
    }

    public Color color;

    public HexCoordinates coordinates;

    public RectTransform uiRect;

    public HexGridChunk chunk;
}