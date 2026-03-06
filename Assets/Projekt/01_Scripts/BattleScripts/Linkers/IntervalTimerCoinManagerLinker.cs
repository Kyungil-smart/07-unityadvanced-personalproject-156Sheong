using UnityEngine;
using R3;

// 코인 매니저를 인터벌 타이머와 연결
[RequireComponent(typeof(IntervalTimerComponent))]
public class IntervalTimerCoinManagerLinker : MonoBehaviour
{
    [SerializeField] CoinManager coinManager;
    [SerializeField] int coinsToAdd = 0;

    void Start()
    {
        // 필요한 컴포넌트
        var intervalTimer = GetComponent<IntervalTimerComponent>();

        // 컴포넌트 존재하는지 확인
        if (intervalTimer == null || coinManager == null) return;


        // 인터벌 타이머 이벤트 구독해 코인 추가
        intervalTimer.OnIntervalEl
        .Subscribe(_ => coinManager.AddCoins(coinsToAdd))
        .AddTo(this);

        // 인터벌 타이머 활성화
        intervalTimer.Active();

    }
}
