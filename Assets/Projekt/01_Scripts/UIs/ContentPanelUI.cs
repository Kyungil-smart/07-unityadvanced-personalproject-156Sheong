using UnityEngine;

// UICommonUtils를 상속받고, 게임 오브젝트에서 사용할 클래스 
public class ContentPanelUI : UICommonUtils
{
    // 패널 꺼질 때 같이 꺼져야할 부모 캔퍼스 (있다면 연결)
    [SerializeField] private GameObject parentCanvas;


    public override void CloseUI()
    {
        // 자기 자신을 끄는 UICommonUtils 의 기본 기능 (상속 받아 가져옴)
        base.CloseUI();

        // 부모 캔버스가 있고 활성화 중이라면 같이 끔
        if (parentCanvas != null && parentCanvas.activeSelf)
        {
            parentCanvas.SetActive(false);
        }
    }
}
