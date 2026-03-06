using UnityEngine;
using R3;

// 코인 매니저와 IntTextUpdater를 연결하는 스크립트
public class CoinManagerIntTextUpdaterLinker : MonoBehaviour
{
    // 필요한 컴포넌트 참조
    [SerializeField] CoinManager coinManager;
    [SerializeField] IntTextUpdaterComponent intTextUpdater;
    

    void Start()
    {
        // 해당 컴포넌트가 할당 안되면 리턴
        if (coinManager == null || intTextUpdater == null) return;

        // 코민 매니저의 코인 값 변경될 때 업데이트
        coinManager.Coins
        .Subscribe(value => intTextUpdater.UpdateText(value))
        .AddTo(this);

        // 초기 코인 값으로 텍스트 업데이트
        intTextUpdater.UpdateText(coinManager.firstCoin);

    }
}
