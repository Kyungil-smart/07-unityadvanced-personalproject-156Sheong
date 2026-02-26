using UnityEngine;

public class BtnBlockedState : IState
{
    ButtonController _btn;

    public BtnBlockedState(ButtonController button)
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
