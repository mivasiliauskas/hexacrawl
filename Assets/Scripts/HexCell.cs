using UnityEngine;

public class HexCell : MonoBehaviour
{
    public Color color;

    public HexCoordinates coordinates;

    public RectTransform uiRect;

    public HexGridChunk chunk;

    public Entity entity;

    void Awake()
    {
    }
}