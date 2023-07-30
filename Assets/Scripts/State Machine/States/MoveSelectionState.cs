using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSelectionState : State
{
    public override void Enter()
    {
        base.Enter();
        inputs.OnMove += OnMoveTilesSelector;
        inputs.OnFire += OnFire;
    }

    public override void Exit()
    {
        base.Exit();
        inputs.OnMove -= OnMoveTilesSelector;
        inputs.OnFire -= OnFire;
    }

    void OnFire(object sender, object args)
    {
        int button = (int)args;

        if (button == 1)
        {
            machine.ChangeTo<MoveSequenceState>();
        }

        if (button == 2)
        {
            machine.ChangeTo<ChooseActionState>();
        }
    }
}
