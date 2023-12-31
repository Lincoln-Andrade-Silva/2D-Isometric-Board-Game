using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamState : State
{
    public override void Enter()
    {
        base.Enter();
        inputs.OnMove += OnMoveTilesSelector;
        inputs.OnFire += OnFire;
        CheckNullPosition();
    }

    public override void Exit()
    {
        base.Exit();
        inputs.OnMove -= OnMoveTilesSelector;
        inputs.OnFire -= OnFire;
    }

    void CheckNullPosition()
    {
        if (Selector.instance.tile == null)
        {
            TilesLogic tile = Board.instance.GetTile(new Vector3Int(0, 2, 0));
            Selector.instance.tile = tile;
            Selector.instance.spriteRenderer.sortingOrder = tile.contentOrder;
            Selector.instance.transform.position = tile.worldPos;
        }
    }

    void OnFire(object sender, object args)
    {
        int button = (int)args;

        if (button == 1)
        {

        }

        if (button == 2)
        {
            machine.ChangeTo<ChooseActionState>();
        }
    }
}
