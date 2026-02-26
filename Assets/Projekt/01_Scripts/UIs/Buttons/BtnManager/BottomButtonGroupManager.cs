using UnityEngine;

// 메인 메뉴 하단의 버튼 그룹을 관리하는 매니저
public class BottomButtonGroupManager : MonoBehaviour, IButtonGroup
{
    BottomButtonController _currentSelected;


    // 버튼 클릭시 호출되어서 판단함
    public void OnButtonSelected(BottomButtonController selectedBtn)
    {
        // 이전에 다른 선택된 버튼이 존재하고, 현재 선택된 버튼이 이 버튼이 아니라면 기본 상태로 복귀
        if(_currentSelected != null && _currentSelected != selectedBtn)
        {
            _currentSelected.ChangeState(_currentSelected.BtnIdle);
        }


        // 무조건 1개 버튼은 활성화된 상태여야 하기에 같은 버튼 다시 누르면 작동 안하도록 주석 처리함
        /*
        // 같은 버튼을 다시 누를 시, 해당 버튼 선택 해제 후 바로 함수 종료
        
        if (_currentSelected == selectedBtn)
        {
            _currentSelected = null;
            return;
        }
        */

        _currentSelected = selectedBtn;
    }


}
