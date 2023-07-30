using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{

    protected InputController inputs { get { return InputController.instance; } }
    protected StateMachineController machine { get { return StateMachineController.instance; } }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    protected void OnMoveTilesSelector(object sender, object args)
    {
        Vector3Int input = (Vector3Int)args;
        TilesLogic tile = Board.instance.GetTile(Selector.instance.position + input);

        if (!(tile is null))
        {
            MoveSelector(tile);
        }
    }

    protected void MoveSelector(Vector3Int position)
    {
        MoveSelector(Board.instance.GetTile(position));
    }

    protected void MoveSelector(TilesLogic tile)
    {
        Selector.instance.tile = tile;
        Selector.instance.spriteRenderer.sortingOrder = tile.contentOrder;
        Selector.instance.transform.position = tile.worldPos;

        machine.selectedTile = tile;
    }
}
