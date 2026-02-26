using UnityEngine;


// 공통 뒤로가기 버튼 기능용 클래스
public class CommonBackButton : MonoBehaviour
{
    // UIManager 를 활용한 뒤로가기 기능, 유니티 버튼 이벤트에 연결
    public void OnClickBack()
    {
        if (UIManager.hasInstance)
        {
            UIManager.Instance.PopUI();
        }
        else
        {
            Debug.LogWarning("UIManager가 없음");
        }
    }
}