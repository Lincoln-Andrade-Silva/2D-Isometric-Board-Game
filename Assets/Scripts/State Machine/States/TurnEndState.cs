using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEndState : State
{
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(AddCharacterDelay());
    }

    IEnumerator AddCharacterDelay()
    {
        Turn.character.chargeTime += 300;

        if (Turn.hasMoved)
            Turn.character.chargeTime += 100;
        if (Turn.hasActed)
            Turn.character.chargeTime += 100;


        Turn.character.chargeTime -= Turn.character.GetStats(StatsEnum.SPEED);

        Turn.hasMoved = Turn.hasActed = false;
        yield return new WaitForSeconds(0.5f);
        machine.ChangeTo<TurnStartState>();
    }
}
