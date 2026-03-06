using UnityEngine;
using R3;


[RequireComponent(typeof(HPComponent), typeof(ManualDestroyComponent))] // 두 컴포넌트가 반드시 있어야 함을 의미
public class HPManualDestroyLinker : MonoBehaviour
{
    
    void Start()
    {
        // 필요한 부품 가져오기
        var hp = GetComponent<HPComponent>();
        var manualDestroy = GetComponent<ManualDestroyComponent>();

        // 오류 방지를 위한 코드
        if (hp == null || manualDestroy == null) return;


        // R3 기능을 활용해 부품 연결하기
        // hp의 deathSubject에 구독하여, 알람이 발생하면 manualDestroy의 DestroySelf() 메서드 호출
        hp.OnDeath
        .Subscribe(_ => manualDestroy.DestroySelf())
        .AddTo(this);
    }

    
}
