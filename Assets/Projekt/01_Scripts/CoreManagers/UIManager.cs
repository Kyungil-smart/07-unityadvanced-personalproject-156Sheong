using System.Buffers.Text;
using System.Collections.Generic;
using UnityEngine;


// 전체 UI 흐름과 히스토리, 뒤로가기 등을 제어하는 중앙 관리자 역할
public class UIManager : Singleton<UIManager>
{

    // 새로운 인풋 시스템 사용을 위한 변수
    private GameInputActions _inputActions;

    // UI 히스토리 제어용 스택
    private Stack<UICommonUtils> _uiStack = new Stack<UICommonUtils>();


    protected override void Awake()
    {
        // 부모 오브젝트를 불러와 싱글톤화
        base.Awake();

        // 새운 인풋 시스템 객체 생성, 활성화 후 연결
        _inputActions = new GameInputActions();
        _inputActions.UI.Enable();
        _inputActions.UI.Back.performed += ctx => PopUI();
    }


    // 혹시 매니저가 파괴되면 이벤트 해제 (싱글톤이라 파괴될 일 없을 예정)
    private void OnDestroy()
    {
        base.OnDestroy();

        if (_inputActions != null)
        {
            _inputActions.UI.Back.performed -= ctx => PopUI();
            _inputActions.UI.Disable();
        }
    }


    // 새 창을 열 때 호출
    public void PushUI(UICommonUtils uiToOpen)
    {
        
        _uiStack.Push(uiToOpen);
        uiToOpen.OpenUI();
        
    }

    // 창을 닫을 때 호출
    public void PopUI()
    {
        // 스택에 열려있는 창이 하나라도 남아있다면 뒤로 가기
        if (_uiStack.Count > 0)
        {
            UICommonUtils topUI = _uiStack.Pop();
            topUI.CloseUI();
        }
        else
        {
            Debug.Log("메인 화면");
        }
    }


    // 캔버스 이동 시 열린 팝업 모두 닫고 이동하는 기능
    public void ClearStackAndOpen(UICommonUtils moveContents)
    {
        // 기존 팝업 모두 닫기
        while (_uiStack.Count > 0)
        {
            UICommonUtils ui = _uiStack.Pop();
            if (ui != null) ui.CloseUI(); 
        }

        // 팝업 다 닫고 캔버스 이동
        PushUI(moveContents);
    }


    // 씬 전환시 모든 스택 클리어
    public void ClearAllUI()
    {
        _uiStack.Clear();
    }
}
