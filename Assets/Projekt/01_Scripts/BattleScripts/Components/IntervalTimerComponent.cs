using UnityEngine;
using R3;

// 일정 간격마다 투사체 등을 생성하는 컴포넌트
public class IntervalTimerComponent : MonoBehaviour
{
    [SerializeField] float interval = 0f;
    private float timer = 0f;
    bool isActive = false;

    // 안전을 위해 자동으로 생명 주기 관리
    readonly Subject<Unit> intervalElapsedSubject = new Subject<Unit>();
    public Observable<Unit> OnIntervalEl => intervalElapsedSubject;

    void Awake()
    {
        // 생명 주기에 맞춰 Subject 관리, AddTo(this)로 자동 해제
        intervalElapsedSubject.AddTo(this);
    }


    void Update()
    {
        if (!isActive) return;

        timer += Time.deltaTime;
        if (timer >= interval)
        {
            // 구독자에게 전체 간격이 지났음을 알림
            intervalElapsedSubject.OnNext(Unit.Default);
            timer = 0f;
        }
    }

    // 외부에서 호출하는 타이머 시작
    public void Active()
    {
        isActive = true;
        timer = interval;
    }

    // 외부에서 호출하는 타이머 정지
    public void DeActive()
    {
        isActive = false;
    }

}
