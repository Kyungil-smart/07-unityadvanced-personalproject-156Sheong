using UnityEngine;

public class BtnBlockedState : IState
{
    BottomButtonController _btn;

    public BtnBlockedState(BottomButtonController button)
    {
        _btn = button;
    }


    public void Enter()
    {
        //
    }

    public void Update()
    {

    }

    public void Exit()
    {

    }
}
