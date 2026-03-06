using UnityEngine;
using R3;

// 타겟에게 데미지를 적용하는 컴포넌트
public class DamageApplicatorComponent : MonoBehaviour
{
    [field: SerializeField] public int ATKPower { get; set; }


    // 데미지 적용 알리는 용도
    readonly Subject<Unit> damageAppliedSubject = new Subject<Unit>();
    public Observable<Unit> OnDamageApplied => damageAppliedSubject;

    private void Awake()
    {
        // 메모리 누수 방지를 위한 관리, AddTo(this)로 자동으로 같이 해제
        damageAppliedSubject.AddTo(this);
    }

    

    // 타겟에게 데미지 적용
    public void ApplyDamage(IDamageable target)
    {
        if (target != null)
        {
            target.TakeDamage(ATKPower);
            damageAppliedSubject.OnNext(Unit.Default);  // 데미지 적용을 알림(이펙트나 사운드로 추가 가능)
        }
    }
}
