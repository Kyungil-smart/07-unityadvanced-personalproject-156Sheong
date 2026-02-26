using UnityEngine;

public class BtnSelectedState : IState
{
    BottomButtonController _btn;

    public BtnSelectedState(BottomButtonController button)
    {
        _btn = button;
    }


    public void Enter()
    {
        // 애니메이션, 버튼 활성화
        _btn.SetSelected(true);
        _btn.SetTextVisible(true);
    }

    public void Update()
    {


        // 선택된 상태에서 다시 클릭 시, Idle 상태로 복귀
        // BtnPressed 을 소비하기 위해 조건문은 의도적으로 남아있어야함
        if (_btn.IsClickInput())
        {
            // 무조건 1개의 버튼이 활성화된 상태어야 해서 주석처리
            // _btn.ChangeState(_btn.BtnIdle);
        }
        
    }

    public void Exit()
    {

    }
}
