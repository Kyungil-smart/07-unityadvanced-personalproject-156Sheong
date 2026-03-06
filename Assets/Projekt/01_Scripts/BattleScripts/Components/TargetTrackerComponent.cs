using UnityEngine;
using R3;
using System;
using System.Collections.Generic;

public class TargetTrackerComponent : MonoBehaviour
{
    // 데미지 대상 리스트로 받아옴 -> 테스트용 SerializeField
    [SerializeField] List<IDamageable> targets = new List<IDamageable>();

    // 메모리 누수 방지 위해 Subject는 MonoBehaviour의 생명주기에 맞춰 관리, AddTo(this)로 자동 해제
    readonly Subject<IDamageable> targetAddedSubject = new Subject<IDamageable>();
    public Observable<IDamageable> OnTargetAdded => targetAddedSubject;

    void Awake()
    {
        
        targetAddedSubject.AddTo(this);
    }

    public void AddTarget(IDamageable target)
    {
        // 타켓이 살아있고 기존 리스트에 없다면 추가
        if (target != null && target.IsAlive && !targets.Contains(target))
        {
            // 새로운 타겟 추가
            targets.Add(target);
            
            targetAddedSubject.OnNext(target);
        }
    }

    public void RemoveTarget(IDamageable target)
    {
        // 나가거나 죽은 타겟 제거
        if (target != null && targets.Contains(target))
        {
            targets.Remove(target);
            
        }
    }

    
    public List<IDamageable> GetAliveTargets()
    {
        // 죽었거나 null 인 타겟 제거
        targets.RemoveAll(t => t == null || !t.IsAlive);

        // 현재 살아있는 타겟은 리스트를 복사해서 반환
        return new List<IDamageable>(targets);
    }

    // 현재 위치에서 가장 가까운 타겟 찾기
    public IDamageable FindClosestTarget(Vector3 currentPosition)
    {
        IDamageable closestTarget = null;
        float closestDistance = Mathf.Infinity;

        // 타겟 리스트 순회하면서 가장 가까운 타겟 찾기
        foreach (var target in targets)
        {
            // 타겟이 살아있고, null 이 아닌 경우 거리 계산
            if (target != null && target.IsAlive)
            {
                var distance = Vector3.Distance(currentPosition, target.RelatedGameObject.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestTarget = target;
                }
            }
        }
        return closestTarget;
    }
}
