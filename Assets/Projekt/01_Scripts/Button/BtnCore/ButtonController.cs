using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;


// 버튼 입력 처리 / 애니메이션 등 기능 작동용

// IPointerClickHandler : 이벤트 시스템에 영향 받는 UI 오브젝트에 사용하는 클릭이나 터치 관련 인터페이스
public class ButtonController : MonoBehaviour, IPointerClickHandler
{
    // 버튼 관련 매니저 연결용
    [SerializeField] BottonButtonGroupManager _btnGroupManager;

    // 버튼 애니메이터 연결용
    [SerializeField] Animator _animator;

    // 텍스트 UI 연결용
    [SerializeField] GameObject _textUIObj;

    // 가운데 패널 연결용
    [SerializeField] GameObject _mainPanel;
    [SerializeField] GameObject _panelBGImg;

    // 처음에 버튼 활성화할지 선택하는 용도
    [SerializeField] bool isFirstActive;

    StateMachine _stateMachine;

    // 버튼이 사용할 State 들
    public BtnIdleState BtnIdle { get; private set; }
    public BtnSelectedState BtnSelected { get; private set; }
    public BtnBlockedState BtnBlocked { get; private set; }

    // 판단용 버튼 속성 프로퍼티
    public bool IsSelected { get; private set; }
    public bool IsUnlocked { get; private set; }

    public bool BtnPressed { get; private set; }

    // 인풋
    // GameInputActions _inputActions;



    void Awake()
    {
        // 앞서 선언한 State 나 인풋 등 객체 만들기
        _stateMachine = new StateMachine();
        BtnIdle = new BtnIdleState(this);
        BtnSelected = new BtnSelectedState(this);
        BtnBlocked = new BtnBlockedState(this);



        // _inputActions = new GameInputActions();
    }

    void OnEnable()
    {
        // _inputActions.UI.Click.performed += OnClick;
    }

    void OnDisable()
    {
        // _inputActions.UI.Click.performed -= OnClick;
    }

    void Start()
    {
        // 처음에 선택되어있으면 디폴트 값으로 활성화하고, 아니면 기존 상태로 놓기
        if (isFirstActive)
        {
            _stateMachine.ChangeState(BtnSelected);
            _btnGroupManager.OnButtonSelected(this);    // 매니저에 초기 상태 등록해줘야 함
        }
        else _stateMachine.ChangeState(BtnIdle);
    }

    void Update()
    {
        // 매 프레임마다 상태 머신이 현재 상태를 업데이트해야 작동함
        _stateMachine.Update();
    }

    // IState랑 연결하는 부분
    public void ChangeState(IState state)
    {
        _stateMachine.ChangeState(state);
    }


    // 인풋 콜백
    //void OnClick(InputAction.CallbackContext ctx)
    //{
    //    if (ctx.performed) BtnPressed = true;
    //}


    // Unity의 EventSystem이 알아서 호출해주는 콜백 함수, IPointerClickHandler 인터페이스 필요
    public void OnPointerClick(PointerEventData eventData)
    {
        _btnGroupManager.OnButtonSelected(this);   // 매니저에게 알림 호출
        BtnPressed = true;
    }

    public bool IsClickInput()
    {
        if (BtnPressed)
        {
            BtnPressed = false;
            return true;
        }

        return false;
    }

    // 비활성화시 텍스트 및 패널 숨김 <-> 활성화시 텍스트와 패널도 활성화
    public void SetTextVisible(bool value)
    {
        _textUIObj.SetActive(value);
        _mainPanel.SetActive(value);
        _panelBGImg.SetActive(value);
    }


    // 애니메이션
    public void SetSelected(bool value)
    {
        _animator.SetBool("IsSelected", value);
    }
}

