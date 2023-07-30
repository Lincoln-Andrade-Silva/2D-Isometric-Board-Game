using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStartState : State
{
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(SelectCharacter());
    }

    IEnumerator SelectCharacter()
    {
        machine.characters.Sort((x, y) => x.chargeTime.CompareTo(y.chargeTime));

        Turn.character = machine.characters[0];
        yield return null;
        machine.ChangeTo<ChooseActionState>();
    }
}
