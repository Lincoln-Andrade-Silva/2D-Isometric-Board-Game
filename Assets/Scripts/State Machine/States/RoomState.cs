using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomState : State
{
    public override void Enter()
    {
        base.Enter();
        InputController.instance.OnMove += OnMove;
        CheckNullPosition();
    }

    public override void Exit()
    {
        base.Exit();
        InputController.instance.OnMove -= OnMove;
    }

    void OnMove(object sender, object args)
    {
        Vector3Int input = (Vector3Int)args;
        TilesLogic tile = Board.instance.GetTile(Selector.instance.position + input);

        if (!(tile is null))
        {
            Selector.instance.tile = tile;
            Selector.instance.position = tile.pos;
            Selector.instance.spriteRenderer.sortingOrder = tile.contentOrder;
            Selector.instance.transform.position = tile.worldPos;
        }
    }

    void CheckNullPosition()
    {
        if (Selector.instance.position == null)
        {
            TilesLogic tile = Board.instance.GetTile(new Vector3Int(0, 2, 0));
            Selector.instance.tile = tile;
            Selector.instance.position = tile.pos;
            Selector.instance.spriteRenderer.sortingOrder = tile.contentOrder;
            Selector.instance.transform.position = tile.worldPos;
        }
    }
}
