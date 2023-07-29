using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoader : MonoBehaviour
{
    public Character characterPrefeb;

    //job
    //mapObj
    //characters location in this map
    public static MapLoader instance;

    void Awake()
    {
        instance = this;
    }

    public void CreateCharacters()
    {
        GameObject holder = new GameObject("Characters Holder");
        holder.transform.parent = Board.instance.transform;

        Character character = Instantiate(characterPrefeb, Board.instance.GetTile(new Vector3Int(-4, -3, 0))
            .worldPos, Quaternion.identity, holder.transform);
    }
}
