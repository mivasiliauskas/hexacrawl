using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour
{
    public int chunkCountX = 4, chunkCountZ = 3;
    int cellCountX, cellCountZ;

    public Color defaultColor = Color.white;
    public Color touchedColor = Color.magenta;

    public HexGridChunk chunkPrefab;

    public HexCell cellPrefab;

    HexCell[] cells;
    HexGridChunk[] chunks;

    public Text cellLabelPrefab;

    void Awake()
    {
        cellCountX = chunkCountX * HexMetrics.chunkSizeX;
        cellCountZ = chunkCountZ * HexMetrics.chunkSizeZ;

        CreateChunks();
        CreateCells();
    }
    void CreateChunks()
    {
        chunks = new HexGridChunk[chunkCountX * chunkCountZ];

        for (int z = 0, i = 0; z < chunkCountZ; z++)
        {
            for (int x = 0; x < chunkCountX; x++)
            {
                HexGridChunk chunk = chunks[i++] = Instantiate(chunkPrefab);
                chunk.transform.SetParent(transform);
            }
        }
    }

    void CreateCells()
    {
        cells = new HexCell[cellCountZ * cellCountX];

        for (int z = 0, i = 0; z < cellCountZ; z++)
        {
            for (int x = 0; x < cellCountX; x++)
            {
                CreateCell(x, z, i++);
            }
        }

        var cell = cells[cells.Length / 2];
        Game.Player = new Player(cell);
        Game.Player.parent.SetNeighboursAllowed(true);
    }

    void CreateCell(int x, int z, int i)
    {
        Vector3 position;
        position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f);
        position.y = 0f;
        position.z = z * (HexMetrics.outerRadius * 1.5f);

        HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
        cell.transform.localPosition = position;
        cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);
        cell.baseColor = defaultColor;

        int sw = new HexCoordinates(cell.coordinates.X, cell.coordinates.Z - 1).ToIndex(cellCountX);
        int se = new HexCoordinates(cell.coordinates.X + 1, cell.coordinates.Z - 1).ToIndex(cellCountX);

        // set neighbours
        if (cell.coordinates.X - cell.coordinates.Y > 1)
        {
            // cell.baseColor = Color.blue;
            int index = new HexCoordinates(cell.coordinates.X - 1, cell.coordinates.Z).ToIndex(cellCountX);
            cell.neighbours.Add(HexDirection.W, cells[index]);
            cells[index].neighbours.Add(HexDirection.E, cell);
        }

        if (cell.coordinates.Z != 0 && cell.coordinates.X != cell.coordinates.Y)
        {
            // cell.baseColor = Color.blue;
            int index = new HexCoordinates(cell.coordinates.X, cell.coordinates.Z - 1).ToIndex(cellCountX);
            cell.neighbours.Add(HexDirection.SW, cells[index]);
            cells[index].neighbours.Add(HexDirection.NE, cell);
        }

        if (cell.coordinates.Z != 0 && cell.coordinates.X - cell.coordinates.Y + 1 != cellCountX * 2)
        {
            // cell.baseColor = Color.blue;
            int index = new HexCoordinates(cell.coordinates.X + 1, cell.coordinates.Z - 1).ToIndex(cellCountX);
            cell.neighbours.Add(HexDirection.SE, cells[index]);
            cells[index].neighbours.Add(HexDirection.NW, cell);
        }

        cell.entity = new Monster(cell, "monster_1");

        /*
        Text label = Instantiate<Text>(cellLabelPrefab);
        label.rectTransform.anchoredPosition =
            new Vector2(position.x, position.z);
        label.text = cell.coordinates.ToStringOnSeparateLines();

        cell.uiRect = label.rectTransform;
        */

        AddCellToChunk(x, z, cell);
    }

    void AddCellToChunk(int x, int z, HexCell cell)
    {
        int chunkX = x / HexMetrics.chunkSizeX;
        int chunkZ = z / HexMetrics.chunkSizeZ;
        HexGridChunk chunk = chunks[chunkX + chunkZ * chunkCountX];

        int localX = x - chunkX * HexMetrics.chunkSizeX;
        int localZ = z - chunkZ * HexMetrics.chunkSizeZ;
        chunk.AddCell(localX + localZ * HexMetrics.chunkSizeX, cell);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            HandleInput();
        }
        HandleMouseMove();
        foreach (KeyCode keyCode in keyDirections.Keys)
        {
            if (Input.GetKeyDown(keyCode))
            {
                HandlePlayerMovement(keyDirections[keyCode]);
            }
        }
    }

    void HandlePlayerMovement(HexDirection direction)
    {
        if (Game.Player.parent.neighbours.ContainsKey(direction))
        {
            Game.Player.Move(direction);
        }
    }

    void HandleInput()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(inputRay, out hit))
        {
            TouchCell(hit.point);
        }
    }


    void HandleMouseMove()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(inputRay, out hit))
        {
            HighlightCell(hit.point);
        }
    }

    HexCell activeCell;

    Color previousColor;

    void HighlightCell(Vector3 position)
    {
        position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        int index = coordinates.X + coordinates.Z * cellCountX + coordinates.Z / 2;
        HexCell cell = cells[index];


        if (activeCell != null && activeCell.highlighted)
        {
            activeCell.highlighted = false;
            activeCell.chunk.Triangulate();
        }
        activeCell = cell;

        cell.highlighted = true;
        cell.chunk.Triangulate();
    }

    void TouchCell(Vector3 position)
    {
        position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        int index = coordinates.ToIndex(cellCountX);
        HexCell cell = cells[index];

#if UNITY_EDITOR
        UnityEditor.Selection.activeGameObject = cell.gameObject;
#endif
    }

    Dictionary<KeyCode, HexDirection> keyDirections = new Dictionary<KeyCode, HexDirection>(){
        {KeyCode.E, HexDirection.NE},
        {KeyCode.D, HexDirection.E},
        {KeyCode.C, HexDirection.SE},
        {KeyCode.Z, HexDirection.SW},
        {KeyCode.A, HexDirection.W},
        {KeyCode.Q, HexDirection.NW},
    };
}