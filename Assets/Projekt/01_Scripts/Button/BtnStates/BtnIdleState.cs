using UnityEngine;

public class BtnIdleState : IState
{
    ButtonController _btn;

    public BtnIdleState(ButtonController button)
    {
        _btn = button;
    }


    public void Enter() 
    {
        // 버튼이 대기 상태로 돌아올 시 애니메이션, 버튼 꺼줌
        _btn.SetSelected(false);
        _btn.SetTextVisible(false);
    }

    public void Update()
    {
        // 대기 상태에서 클릭 시 상태 전환
        if (_btn.IsClickInput())
        {
            _btn.ChangeState(_btn.BtnSelected);
        }
    }

    public void Exit()
    {

    }


}
