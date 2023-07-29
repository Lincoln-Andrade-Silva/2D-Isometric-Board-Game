using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public List<Floor> floors;
    public Dictionary<Vector3Int, TilesLogic> tiles;

    public static Board instance;

    [HideInInspector]
    public Grid grid;

    void Awake()
    {
        instance = this;
        grid = GetComponent<Grid>();
        tiles = new Dictionary<Vector3Int, TilesLogic>();
    }

    void Start()
    {
        InitSequence();
    }

    public void InitSequence()
    {
        LoadFloors();
        Ordering();
    }

    public void LoadFloors()
    {
        for (int i = 0; i < floors.Count; i++)
        {
            List<Vector3Int> floorTiles = floors[i].LoadTiles();
            for (int j = 0; j < floorTiles.Count; j++)
            {
                if (!tiles.ContainsKey(floorTiles[j]))
                {
                    CreateTile(floorTiles[j], floors[i]);
                }
            }
        }
    }

    public void CreateTile(Vector3Int pos, Floor floor)
    {
        Vector3 worldPos = grid.CellToWorld(pos);
        worldPos.y += (floor.tilemap.tileAnchor.y / 2) - 0.5f + 0.12f;
        TilesLogic tilesLogic = new TilesLogic(pos, worldPos, floor);
        tiles.Add(pos, tilesLogic);
    }

    public void Ordering()
    {
        foreach (TilesLogic tile in tiles.Values)
        {
            int floorIndex = floors.IndexOf(tile.floor);
            floorIndex -= 2;

            if (floorIndex >= floors.Count || floorIndex < 0)
            {
                continue;
            }
            Floor floorToCheck = floors[floorIndex];

            Vector3Int pos = tile.pos;
            IsNECheck(floorToCheck, tile, pos + Vector3Int.right);
            IsNECheck(floorToCheck, tile, pos + Vector3Int.up);
            IsNECheck(floorToCheck, tile, pos + Vector3Int.right + pos + Vector3Int.up);
        }
    }

    void IsNECheck(Floor floor, TilesLogic tilesLogic, Vector3Int NEPosition)
    {
        if (floor.tilemap.HasTile(NEPosition))
        {
            tilesLogic.contentOrder = floor.order;
        }
    }

    public TilesLogic GetTile(Vector3Int pos)
    {
        TilesLogic tile = null;
        instance.tiles.TryGetValue(pos, out tile);

        return tile;
    }
}
