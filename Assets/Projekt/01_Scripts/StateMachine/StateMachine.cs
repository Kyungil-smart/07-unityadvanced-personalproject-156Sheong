using UnityEngine;

public class StateMachine
{
    IState _currentState;

    // 유니티 씬에 있는 객체가 이 기능을 활용해 자신의 상태를 전환 / 실행함
    public void ChangeState(IState state)
    {
        // 기존의 현재 상태를 나가고 새 상태로 바꾸는 기능
        _currentState?.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    // MonoBeheavior 를 상속받는 유니티 이벤트 함수 Update() 랑 다른 함수
    public void Update()
    {
        _currentState.Update();
    }
}
