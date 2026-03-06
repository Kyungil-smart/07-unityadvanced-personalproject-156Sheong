using UnityEngine;
using R3;

public class RangeDetectorComponent : MonoBehaviour
{
    // 구독 할 수 잇는 이벤트를 제공하기 위한 subject 및 observable
    readonly Subject<IDamageable> targetEnteredSubject = new Subject<IDamageable>();
    public Observable<IDamageable> OnTargetEntered => targetEnteredSubject;

    readonly Subject<IDamageable> targetExitedSubject = new Subject<IDamageable>();
    public Observable<IDamageable> OnTargetExited => targetExitedSubject;

    // 감지할 대상 레이어를 선택
    [SerializeField] LayerMask targetLayer;

    void Awake()
    {
        // R3 사용한 구독 관리
        targetEnteredSubject.AddTo(this);
        targetExitedSubject.AddTo(this);
    }

    // 적이 들어왔을 때
    private void OnTriggerEnter(Collider other)
    {
        // 1 << other.gameObject.layer : 충돌한 객체의 레이어 번호를 비트값으로 변환 -> 이후 targetLayer과 비트 연산을 통해 해당 레이어가 감지 대상인지 확인
        if (((1 << other.gameObject.layer) & targetLayer) != 0)
        {
            var damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
               // 감지된 객체 구독 추가
                targetEnteredSubject.OnNext(damageable);
            }
        }
    }

    // 적이 나갔을 때
    private void OnTriggerExit(Collider other)
    {
        if (((1 << other.gameObject.layer) & targetLayer) != 0)
        {
            var damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                // 감지된 객체 구독 제거
                targetExitedSubject.OnNext(damageable);
            }
        }
    }

}
