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
    GameObject holder;

    void Awake()
    {
        instance = this;
        holder = new GameObject("Characters Holder");
    }

    void Start()
    {
        holder.transform.parent = Board.instance.transform;
    }

    public void CreateCharacters()
    {
        StateMachineController.instance.characters.Add(CreateCharacter(new Vector3Int(-4, -3, 0), "Player", 0));
        StateMachineController.instance.characters.Add(CreateCharacter(new Vector3Int(-6, -3, 0), "Enemy", 1));
    }

    public Character CreateCharacter(Vector3Int pos, string name, int faction)
    {
        TilesLogic tile = Board.instance.GetTile(pos);

        Character character = Instantiate(characterPrefeb, tile.worldPos, Quaternion.identity, holder.transform);
        character.tile = tile;
        character.name = name;
        character.faction = faction;

        return character;
    }
}
