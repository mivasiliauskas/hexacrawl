using UnityEngine;
using UnityEngine.UI;

public class HexGridChunk : MonoBehaviour
{
    HexCell[] cells;

    HexMesh hexMesh;

    Canvas gridCanvas;

    bool isDirty;

    void Awake()
    {
        gridCanvas = GetComponentInChildren<Canvas>();
        hexMesh = GetComponentInChildren<HexMesh>();

        cells = new HexCell[HexMetrics.chunkSizeX * HexMetrics.chunkSizeZ];
    }

    void Start()
    {
        hexMesh.Triangulate(cells);
    }

    void Update()
    {
        if (isDirty)
        {
            Triangulate();
            isDirty = false;
        }
    }

    public void AddCell(int index, HexCell cell)
    {
        cells[index] = cell;
        cell.transform.SetParent(transform, false);
        if (cell.uiRect != null)
            cell.uiRect.SetParent(gridCanvas.transform, false);
        cell.chunk = this;
    }

    public void Triangulate()
    {
        hexMesh.Triangulate(cells);
    }

    public void Dirty(){
        isDirty = true;
    }
}