using UnityEngine;
using UnityEngine.InputSystem;


// 카메라를 제어하는 스크립트

[RequireComponent(typeof(Camera))]  // 카메라 필요함을 강제
public class CameraController : MonoBehaviour
{
    // 카메라 좌표
    [SerializeField] private float posMinX = 0f;
    [SerializeField] private float posMaxX = 0f;
    [SerializeField] private float posMinZ = 0f;
    [SerializeField] private float posMaxZ = 0f;

    // 카메라 좌표 보정
    [SerializeField] private float zOffset = 0f;

    //카메라 제어 컴포넌트
    private Camera cam;

    // 카메라 드래그용 변수
    private bool isDragging = false;
    private Vector2 pointerPosition;    // 화면상 터치 위치
    private Vector3 dragOrigin; // 드래그 시작 터치의 월드 위치

    private Plane groundPlane;  // 가상의 바닥

    private void Awake()
    {
        cam = GetComponent<Camera>();

        // 3차원 공간 상에 가상의 바닥 만들기
        // 법선 벡터는 Vector3.up (y축 방향), 평면은 원점(0,0,0)을 지나도록 설정
        groundPlane = new Plane(Vector3.up, Vector3.zero);  
    }


    public void OnClick(InputAction.CallbackContext context)
    {

        // 드래그 시작 시 바닥 좌표를 계산해 시작점으로
        if (context.started)
        {
            isDragging = true;
            dragOrigin = GetWorldPosition(pointerPosition);
        }
        // 드래그 종료시 드래그 상태 해제
        else if (context.canceled)
        {
            isDragging = false;
        }
    }

    public void OnPointerMove(InputAction.CallbackContext context)
    {
        pointerPosition = context.ReadValue<Vector2>();
    }

    void LateUpdate()
    {
        if (isDragging)
        {
            // 
            Vector3 currentWorldPos = cam.ScreenToWorldPoint(pointerPosition);

            //  
            Vector3 difference = dragOrigin - currentWorldPos;
            Vector3 targetPosition = transform.position + difference;

            // 
            float camHeight = cam.orthographicSize;
            float camWidth = cam.orthographicSize * cam.aspect;

            float clampedX = Mathf.Clamp(targetPosition.x, posMinX + camWidth, posMaxX - camWidth);
            float clampedZ = Mathf.Clamp(targetPosition.z, posMinZ + camHeight, posMaxZ - camHeight);

            // 
            transform.position = new Vector3(clampedX, transform.position.y, clampedZ);
        }
    }

    private Vector3 GetWorldPosition(Vector2 screenPos)
    {
        // 
        Ray ray = cam.ScreenPointToRay(screenPos);

        // 
        if (groundPlane.Raycast(ray, out float hitDistance))
        {
            // 
            Vector3 hitPoint = ray.GetPoint(hitDistance);

            // 
            hitPoint.z += zOffset;

            return hitPoint;
        }

        // 
        return transform.position;
    }
}

