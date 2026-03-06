using UnityEngine;
using UnityEngine.UI;

public class HPBarUIComponent : MonoBehaviour
{
    Slider sliderCurrentHP;


    private void Awake()
    {
        sliderCurrentHP = GetComponent<Slider>();
    }

    // HP 바 초기화 및 최대 HP 설정
    public void Initialize(int maxHP)
    {
        sliderCurrentHP.maxValue = maxHP;
        sliderCurrentHP.value = maxHP;
    }

    // HP 바 업데이트
    public void UpdateHP(int currentHP)
    {
        sliderCurrentHP.value = currentHP;
    }
}
