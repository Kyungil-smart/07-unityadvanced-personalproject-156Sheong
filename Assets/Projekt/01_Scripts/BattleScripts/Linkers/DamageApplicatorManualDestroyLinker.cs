using UnityEngine;
using R3;


[RequireComponent(typeof(DamageApplicatorComponent), typeof(ManualDestroyComponent))]
public class DamageApplicatorManualDestroyLinker : MonoBehaviour
{
    void Start()
    {
        // 필요한 컴포넌트
        var damageApplicator = GetComponent<DamageApplicatorComponent>();
        var manualDestroy = GetComponent<ManualDestroyComponent>();

        // 필요한 컴포넌트 없을 때 리턴
        if (damageApplicator == null || manualDestroy == null) return;


        // 데미지 적용 시 오브젝트 파괴를 연결
        damageApplicator.OnDamageApplied
        .Subscribe(_ => manualDestroy.DestroySelf())
        .AddTo(this);

    }
}
