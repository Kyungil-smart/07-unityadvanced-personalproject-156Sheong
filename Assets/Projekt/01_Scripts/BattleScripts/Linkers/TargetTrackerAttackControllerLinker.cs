using UnityEngine;
using R3;


// TargetTrackerComponent의 타겟 추가 이벤트를 구독하여 AttackControllerComponent의 공격 시작 메서드를 호출
[RequireComponent(typeof(AttackControllerComponent))]
public class TargetTrackerAttackControllerLinker : MonoBehaviour
{
    [SerializeField] TargetTrackerComponent targetTracker;
    AttackControllerComponent attackController;
    

    void Start()
    {
        
        attackController = GetComponent<AttackControllerComponent>();

        
        if (targetTracker == null || attackController == null) return;


        
        targetTracker.OnTargetAdded
        .Subscribe(_ => attackController.StartAttack())
        .AddTo(this);
    }

    void Update()
    {
        // 살아있는 타겟이 있는지 확인, 없으면 공격 종료
        if (targetTracker.GetAliveTargets().Count == 0) attackController.EndAttack();

    }
}
