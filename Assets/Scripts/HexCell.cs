using UnityEngine;

public class HexCell : MonoBehaviour
{
    public Sprite[] characters;

    static System.Random random = new System.Random();

    public Color color;

    public HexCoordinates coordinates;

    public RectTransform uiRect;

    public HexGridChunk chunk;

    public Entity entity;

    int index;

    void Awake()
    {
        index = random.Next(characters.Length);
        GetComponentInChildren<SpriteRenderer>().sprite = characters[index];
    }
}