using R3;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int firstCoin = 0;  // 초기 코인

    // 코인 값 관리
    [SerializeField] SerializableReactiveProperty<int> coins = new SerializableReactiveProperty<int>(); // 코인 값이 변경될 때마다 구독하는 실제 프로퍼티
    public ReadOnlyReactiveProperty<int> Coins => coins;    // 외부에서 코인 값을 읽을 수 있도록 공개하는 읽기 전용 프로퍼티


    private void Awake()
    {
        coins.Value = firstCoin;
        coins.AddTo(this);
    }


    // 코인 추가
    public void AddCoins(int amount)
    {

        coins.Value += amount;
    }


    // 코인 소모
    public bool SpendCoins(int amount)
    {

        if (coins.Value >= amount)
        {
            SoundManager.Instance.PlaySound(2);

            coins.Value -= amount;
            return true;
        }

        SoundManager.Instance.PlaySound(1);

  
        return false;
    }
}
