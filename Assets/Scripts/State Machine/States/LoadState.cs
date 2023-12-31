using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadState : State
{
    public override void Enter()
    {
        StartCoroutine(LoadSequence());
    }

    IEnumerator LoadSequence()
    {
        yield return StartCoroutine(Board.instance.InitSequence(this));

        yield return null;
        MapLoader.instance.CreateCharacters();
        yield return null;
        InitialTurnOrdering();

        StateMachineController.instance.ChangeTo<ChooseActionState>();
    }

    void InitialTurnOrdering()
    {
        int first = Random.Range(0, machine.characters.Count);

        Turn.hasActed = false;
        Turn.hasMoved = false;
        Turn.character = machine.characters[first];
    }
}
