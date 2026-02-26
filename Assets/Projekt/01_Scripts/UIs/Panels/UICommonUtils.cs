using UnityEngine;


// 패널 등 열기 닫기 등 UI가 공통적으로 기능 정의
public abstract class UICommonUtils : MonoBehaviour
{



    public virtual void OpenUI()
    {
        gameObject.SetActive(true);
        
    }

    public virtual void CloseUI()
    {
        gameObject.SetActive(false);
    }

    // 뒤로가기 버튼 클릭 시 해당 UI를 닫고, 이전으로 돌아가기 위한 기능 
    public void OnClickBackBtn()
    {
        
        UIManager.Instance.PopUI();
    }
}
