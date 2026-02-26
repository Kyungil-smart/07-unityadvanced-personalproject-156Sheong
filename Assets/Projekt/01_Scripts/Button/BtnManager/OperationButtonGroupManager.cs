using System.Collections.Generic;
using UnityEngine;


public class OperationButtonGroupManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> OperationCanvasList = new List<GameObject>();
        



    private void Awake()
    {
        Init();
    }




    private void Init()
    {
        
        if (OperationCanvasList != null)    // 리스트 비어있을 것을 대비해 예외처리
        {
            DeactivateCanvas();
        }
    }


    // 모두 비활성화 시키기
    private void DeactivateCanvas()
    {
        
        foreach (GameObject canvas in OperationCanvasList)
        {
            if (canvas.activeSelf) canvas.SetActive(false);
        }
    }


    // 각 버튼을 누를 시 행동, 리스트 인덱스로 제어해서 순서 잘 지켜야함

    // 미션 버튼 클릭 시
    public void OnClickMissionBtn()
    {
        // 여러 패널이 함께 열리는 것을 방지하기 위해 나머지는 비활성화
        DeactivateCanvas();

        OperationCanvasList[0].SetActive(true);
    }

    // 캠페인 버튼 클릭 시
    public void OnClickCampaignBtn()
    {
        DeactivateCanvas();

        OperationCanvasList[1].SetActive(true);
    }

    // 전투 버튼 클릭 시
    public void OnClickBattlesBtn()
    {
        DeactivateCanvas();

        OperationCanvasList[2].SetActive(true);
    }

    // 이벤트 버튼 클릭 시
    public void OnClickEventStoryBtn()
    {
        DeactivateCanvas();

        OperationCanvasList[3].SetActive(true);
    }

}
