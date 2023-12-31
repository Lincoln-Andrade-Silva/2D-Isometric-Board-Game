using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSequenceState : State
{
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(MoveSequence());
    }

    public override void Exit()
    {
        base.Exit();
    }

    IEnumerator MoveSequence()
    {
        List<TilesLogic> path = new List<TilesLogic>();
        path.Add(machine.selectedTile);

        Movement movement = Turn.character.GetComponent<Movement>();

        yield return StartCoroutine(movement.Move(path));
        yield return new WaitForSeconds(0.2f);

        Turn.hasMoved = true;
        machine.ChangeTo<ChooseActionState>();
    }
}
