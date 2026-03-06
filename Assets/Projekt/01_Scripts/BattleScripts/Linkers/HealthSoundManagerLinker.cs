using UnityEngine;
using R3;

// HPComponent의 HP가 변경될 때마다 SoundManager에서 사운드 재생
[RequireComponent(typeof(HPComponent))]
public class HealthSoundManagerLinker : MonoBehaviour
{
    void Start()
    {

        var health = GetComponent<HPComponent>();


        if (health == null || SoundManager.Instance == null) return;

        // HP가 변경될 때마다 효과음 재생 
        health.CurrentHP
        .Skip(1)    // 1번째 값은 초기 값이라 제외
        .Subscribe(_ => SoundManager.Instance.PlaySound(5))
        .AddTo(this);
    }
}