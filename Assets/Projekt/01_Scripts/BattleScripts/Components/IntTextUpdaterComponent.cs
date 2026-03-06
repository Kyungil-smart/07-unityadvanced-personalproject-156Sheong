using UnityEngine;
using TMPro;


// int 값을 텍스트로 업데이트하는 컴포넌트
// 그려야하는 int 값의 의미는 모르고 화면에 그려주기만 하는 기능
public class IntTextUpdaterComponent : MonoBehaviour
{
    TextMeshProUGUI targetText;

    
    private void Awake()
    {
        targetText = GetComponent<TextMeshProUGUI>();
    }

    // int 를 받아서 텍스트로 업데이트하는 기능
    public void UpdateText(int value)
    {
        targetText.text = value.ToString();
    }
}
