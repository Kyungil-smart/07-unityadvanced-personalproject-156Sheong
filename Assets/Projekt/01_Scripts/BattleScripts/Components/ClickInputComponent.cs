using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using R3;

// 클릭 이벤트를 제공하는 컴포넌트
public class ClickInputComponent : MonoBehaviour
{
    readonly Subject<Vector3> clickSubject = new Subject<Vector3>();
    public Observable<Vector3> OnClick => clickSubject;

    // 보정 값
    [SerializeField] private float zOffsetCorrection = -2.63f;


    // GameInputActions 클래스를 담을 변수
    private GameInputActions gameInput;

    private void Awake()
    {
        // 메모리 누수 방지를 위한 자동 관리
        clickSubject.AddTo(this);


        gameInput = new GameInputActions();

        // 클릭이 수행되었을 때, HandleLeftClick 함수를 실행하라고 구독
        // C#의 기본 이벤트 방식을 사용
        gameInput.UI.Click.performed += HandleLeftClick;
    }

    private void OnEnable()
    {
        // 컴포넌트가 켜질 때 UI 액션 맵을 활성화
        gameInput.UI.Enable();
    }

    private void OnDisable()
    {
        // 컴포넌트가 꺼질 때 입력을 차단
        gameInput.UI.Disable();
    }

    private void OnDestroy()
    {
        // 파괴될 때 이벤트 구독을 해제
        gameInput.UI.Click.performed -= HandleLeftClick;
    }


    private void HandleLeftClick(InputAction.CallbackContext context)
    {
        // UI 요소 위에서 클릭 시 처리 X
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) return;

        // PointMove 액션에서 2D 화면 좌표 읽어 3D 월드 좌표로 변환
        Vector2 screenPosition = gameInput.UI.PointMove.ReadValue<Vector2>();
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        // 변환 시 좌표를 보정
        worldPosition.z += zOffsetCorrection;

        // 발송
        clickSubject.OnNext(worldPosition);
    }
}