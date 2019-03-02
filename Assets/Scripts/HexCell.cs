using System.Collections.Generic;

using UnityEngine;

public class HexCell : MonoBehaviour
{
    private bool isAllowed;
    public bool IsAllowed
    {
        get
        {
            return isAllowed;
        }
        set
        {
            isAllowed = value;
            chunk.Dirty();
        }
    }
    public bool highlighted;

    public Color color
    {
        get
        {
            return highlighted ? highlightColor
                : IsAllowed ? allowColor
                : baseColor;
        }
    }

    Color highlightColor = Color.yellow;
    Color allowColor = Color.green;

    public Color baseColor;

    public HexCoordinates coordinates;

    public RectTransform uiRect;

    public HexGridChunk chunk;

    public Entity entity;

    public Dictionary<HexDirection, HexCell> neighbours = new Dictionary<HexDirection, HexCell>();

    public Transform Sprite
    {
        get
        {
            return transform.Find("Sprite");
        }
    }


    public void SetNeighboursAllowed(bool isAllowed)
    {
        foreach (HexCell neighbour in neighbours.Values)
        {
            neighbour.IsAllowed = isAllowed;
        }
    }
}