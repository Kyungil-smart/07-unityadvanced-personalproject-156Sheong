using UnityEngine;


// 상태 패턴용 공용 인터페이스
// 버튼, 캐릭터 등 다양한 상태 패턴에서 사용할 예정
public interface IState
{
    void Enter();

    void Update();

    void Exit();
}
