using UnityEngine;

public class HexCell : MonoBehaviour
{
    public bool highlighted;

    public Color color
    {
        get
        {
            if (highlighted)
            {
                return highlightColor;
            }
            return baseColor;
        }
    }

    public Color highlightColor = Color.green;

    public Color baseColor;

    public HexCoordinates coordinates;

    public RectTransform uiRect;

    public HexGridChunk chunk;

    public Entity entity;
}