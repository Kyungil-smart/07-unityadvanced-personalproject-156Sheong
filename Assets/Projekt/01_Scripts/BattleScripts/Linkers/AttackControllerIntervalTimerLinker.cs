using UnityEngine;
using R3;


// 공격 상태가 되면 타이머 작동, 공격이 끝나면 타이머 멈추는 컴포넌트
[RequireComponent(typeof(AttackControllerComponent), typeof(IntervalTimerComponent))]
public class AttackControllerIntervalTimerLinker : MonoBehaviour
{
    void Start()
    {
        // 연결에 필요한 컴포넌트 가져오기
        var attackController = GetComponent<AttackControllerComponent>();
        var intervalTimer = GetComponent<IntervalTimerComponent>();


        // 관련 컴포넌트가 없는 경우 링크 연결 안함
        if (attackController == null || intervalTimer == null) return;


        // AttackController의 공격 시작 시 IntervalTimer 활성화 연결
        attackController.OnAttackStart
        .Subscribe(_ => intervalTimer.Active())
        .AddTo(this);

        // AttackController의 공격 종료 시 IntervalTimer 비활성화 연결
        attackController.OnAttackEnd
        .Subscribe(_ => intervalTimer.DeActive())
        .AddTo(this);
    }
}
