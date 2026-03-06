using UnityEngine;
using R3;


// HP와 게임 클리어를 연결하는 스크립트
[RequireComponent(typeof(HPComponent))]
public class HPGameClearLinker : MonoBehaviour
{
    [SerializeField] BattleManager battleManager;


    void Start()
    {
        // HPComponent를 가져옴
        var hp = GetComponent<HPComponent>();

  
        if (hp == null || battleManager == null) return;


        // 베이스 등의 HP가 0이 되었을 때 게임 클리어 이벤트를 발생시키도록 구독
        hp.OnDeath
        .Subscribe(_ => battleManager.GameClear())
        .AddTo(this);
    }
}
