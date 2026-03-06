using UnityEngine;
using R3;

public class AttackControllerComponent : MonoBehaviour
{

    readonly Subject<Unit> attackStartSubject = new Subject<Unit>();    // 공격 시작 신호
    public Observable<Unit> OnAttackStart => attackStartSubject;    // 외부에서 공격 시작 구독

    readonly Subject<Unit> attackEndSubject = new Subject<Unit>();  //공격 종료 신호
    public Observable<Unit> OnAttackEnd => attackEndSubject;    // 오부에서 공격 종료 구독

    // 공격 중인지 여부를 나타냄
    bool isAttacking = false;

    private void Awake()
    {
        // 메모리 누수 방지 위한 구독 및 AddTo(this) 로 자동 관리
        attackStartSubject.AddTo(this);
        attackEndSubject.AddTo(this);
    }

    public void StartAttack()
    {
        if (!isAttacking)
        {
            
            isAttacking = true;
            attackStartSubject.OnNext(Unit.Default);
        }
    }

    public void EndAttack()
    {
        if (isAttacking)
        {
            
            isAttacking = false;
            attackEndSubject.OnNext(Unit.Default);
        }
    }
}
