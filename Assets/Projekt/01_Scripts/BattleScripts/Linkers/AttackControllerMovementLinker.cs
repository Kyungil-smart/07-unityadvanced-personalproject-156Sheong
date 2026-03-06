using UnityEngine;
using R3;


// 유닛이 공격 시 멈추고, 공격이 끝나면 다시 움직이는 연결을 담당하는 컴포넌트
[RequireComponent(typeof(AttackControllerComponent), typeof(MovementComponent))]
public class AttackControllerMovementLinker : MonoBehaviour
{
    void Start()
    {
        // 연결에 필요한 컴포넌트
        var attackController = GetComponent<AttackControllerComponent>();
        var movement = GetComponent<MovementComponent>();


        // 캄포넌트 없으면 연결 안함
        if (attackController == null || movement == null) return;


        // 공격 시 멈춤
        attackController.OnAttackStart
        .Subscribe(_ => movement.StopMoving())
        .AddTo(this);

        // 공격이 끝나면 재이동
        attackController.OnAttackEnd
        .Subscribe(_ => movement.StartMoving())
        .AddTo(this);

    }
}
