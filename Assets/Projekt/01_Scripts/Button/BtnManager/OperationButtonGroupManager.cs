using System.Collections.Generic;
using UnityEngine;


public class OperationButtonGroupManager : MonoBehaviour
{
    [SerializeField] private GameObject OperationCanvas;
    [SerializeField] private List<ContentPanelUI> OperationPanelList = new List<ContentPanelUI>();
        



    private void Awake()
    {
        Init();
    }




    private void Init()
    {

        // 첫 시작 시 캔버스 비활성화 처리
        if (OperationCanvas != null)
        {
            OperationCanvas.SetActive(false);
        }

        // 아래는 구버젼이라 주석 처리
        /*
        if (OperationPanelList != null)    // 리스트 비어있을 것을 대비해 예외처리
        {
            DeactivatePanels();
        }
        */
    }


    // 전투 버튼 클릭 시 캔버스 활성화
    public void OnClickBattleTab()
    {
        // 캔버스 활성화
        OperationCanvas.SetActive(true);
    }

    // 전투 컨텐츠 캔버스 안에서 각각의 하위 컨텐츠 창 클릭 시 푸쉬 처리 
    public void OnClickOperationButtons(int index)
    {
        // 전투 컨텐츠 캔버스 활성화
        if (OperationCanvas != null && !OperationCanvas.activeSelf)
        {
            OperationCanvas.SetActive(true);
        }

        // 하위 컨텐츠 패널 활성화 요청
        UIManager.Instance.PushUI(OperationPanelList[index]);
    }



    // 아래는 구버젼이라 주석 처리
    /*
    // 캔버스 활성화, 비활성화 기능
    // 추후 다른 기능이 생길 수도 있을 고려해 미리 만듦
    private void SetActivePanel(bool tf)
    {
        OperationCanvas.SetActive(tf);
    }


    // 모두 비활성화 시키기
    private void DeactivatePanels()
    {
        
        foreach (GameObject canvas in OperationPanelList)
        {
            if (canvas.activeSelf) canvas.SetActive(false);
        }
    }



    // 각 버튼을 누를 시 행동, 리스트 인덱스로 제어해서 순서 잘 지켜야함
    public void OnClickOperationButtons(int index)
    {
        SetActivePanel(true);

        // 여러 패널이 함께 열리는 것을 방지하기 위해 나머지는 비활성화
        DeactivatePanels();

        // 해당 인덱스 패널만 활성화
        OperationPanelList[index].SetActive(true);
    }

    */



}
