using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilesLogic : MonoBehaviour
{
    public Vector3Int pos;
    public Vector3 worldPos;
    public GameObject content;
    public Floor floor;
    public int contentOrder;

    //public TileType tileType;

    public TilesLogic() { }

    public TilesLogic(Vector3Int pos, Vector3 worldPos, Floor floor)
    {
        this.pos = pos;
        this.worldPos = worldPos;
        this.floor = floor;
        this.contentOrder = floor.contentOrder;
    }

    public static TilesLogic Create(Vector3Int pos, Vector3 worldPos, Floor floor)
    {
        TilesLogic tilesLogic = new TilesLogic(pos, worldPos, floor);
        return tilesLogic;
    }
}
