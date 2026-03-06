using UnityEngine;
using R3;


// TargetTrackerComponent의 가장 가까운 타겟을 MovementComponent의 방향으로 설정
[RequireComponent(typeof(MovementComponent))]
public class TargetTrackerMovementLinker : MonoBehaviour
{
    [SerializeField] TargetTrackerComponent targetTracker;
    private MovementComponent movement;

    void Start()
    {

        movement = GetComponent<MovementComponent>();

        if (targetTracker == null || movement == null) return;


    }


    void Update()
    {

        var closestTarget = targetTracker.FindClosestTarget(transform.position);

        // 가장 가까운 타겟 있으면 그 타겟의 위치로 이동 방향 설정, 
        if (closestTarget != null)
        {

            var targetPosition = closestTarget.RelatedGameObject.transform.position;
            movement.SetDirection(targetPosition - transform.position);
        }
        // 가장 가까운 타겟 없으면 이동 방향 초기화
        else
        {

            movement.ResetToDefaultDirection();
        }

    }
}
