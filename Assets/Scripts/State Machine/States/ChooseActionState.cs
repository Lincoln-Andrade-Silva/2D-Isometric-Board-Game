using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseActionState : State
{
    int index;
    public override void Enter()
    {
        base.Enter();
        index = 0;
        ChangeSelector();

        inputs.OnMove += OnMove;
        inputs.OnFire += OnFire;
        machine.chooseActionPanel.MoveTo("Show");
    }

    public override void Exit()
    {
        base.Exit();
        inputs.OnMove -= OnMove;
        inputs.OnFire -= OnFire;
        machine.chooseActionPanel.MoveTo("Hide");
    }

    void OnMove(object sender, object args)
    {
        Vector3Int button = (Vector3Int)args;

        if (button == Vector3Int.left)
        {
            index--;
            ChangeSelector();
        }
        else if (button == Vector3Int.right)
        {
            index++;
            ChangeSelector();
        }
    }

    void OnFire(object sender, object args)
    {
        int button = (int)args;

        if (button == 1)
        {
            ActionButtons();
        }

        if (button == 2)
        {
            machine.ChangeTo<RoamState>();
        }
    }

    void ChangeSelector()
    {
        int actionButtonsCount = machine.chooseActionButtons.Count;

        if (index == -1)
        {
            index = actionButtonsCount - 1;

        }
        else if (index == actionButtonsCount)
        {
            index = 0;
        }

        machine.chooseActionSelection.transform.localPosition =
           machine.chooseActionButtons[index].transform.localPosition;
    }

    void ActionButtons()
    {
        switch (index)
        {
            case 0:
                //machine.ChangeTo<MoveTargetState>();
                break;
            case 1:
                //machine.ChangeTo<ActionSelectState>();
                break;
            case 2:
                //machine.ChangeTo<ItemSelectState>();
                break;
            case 3:
                //machine.ChangeTo<WaitState>();
                break;
        }
    }
}
