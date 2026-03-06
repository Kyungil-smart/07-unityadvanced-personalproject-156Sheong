using UnityEngine;
using R3;


// IntervalTimerComponent의 인터벌이 끝날 때마다 SoundManager에서 사운드 재생
[RequireComponent(typeof(IntervalTimerComponent))]
public class IntervalTimerSoundManagerLinker : MonoBehaviour
{
    [SerializeField] int soundIndex = 0;

    void Start()
    {

        var intervalTimer = GetComponent<IntervalTimerComponent>();


        if (intervalTimer == null || SoundManager.Instance == null) return;


        // IntervalTimerComponent의 OnIntervalEl 이벤트에 구독하여 사운드 재생
        intervalTimer.OnIntervalEl
        .Subscribe(_ => SoundManager.Instance.PlaySound(soundIndex))
        .AddTo(this);
    }
}
