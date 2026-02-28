using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


// 전투 컨텐츠 스윕 기능 스크립트
// IBeginDragHandler : 유니티의 UI 시스템에서 드래그 동작이 시작되는 지점 감시 및 처리 인터페이스
// IEndDragHandler : 유니티의 UI 시스템에서 드래그 동작이 끝나는 지점 감시 및 처리 인터페이스
// https://youtu.be/zeHdty9RUaA?si=p94j9DEJAVDuO6KW 일부 기능 고박사 유튜브 기반 스크립트 참고 -> 나중에 기능이 너무 무거워서 수정함


public class SwipeUI : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private List<SwipeContentsUI> swipeContents = new List<SwipeContentsUI>();   // 스윕 대상이 될 자식 오브젝트 위치
    [SerializeField] private RectTransform contentRect; // 이동을 담당하는 오브젝트의 위치
    [SerializeField] private float addPosY = 0f;    // 중심 지점을 보정해주는 y 축 보정값, 실제로 테스트하며 적절한 값을 찾아서 넣어야 함
    [SerializeField] private float snapSpeed = 0f; // 드래그를 멈췄을 때 스냅되는 속도


    private bool isSwipeMode = false;   // 현재 유저가 드래그 중인지 체크
    private float[] targetPositions;    // 각 컨텐츠가 중앙에 위치할 때 컨텐츠의 목표 y 값 들
    private float targetPosY;       // 최종적으로 이동해야 할 목표 y좌표
    private int currentIndex = 0;       // 현재 중앙에 선택된 컨텐츠의 인덱스 번호


    private void Start()
    {
        // 캔버스 레이아웃과 그래픽 변경을 다음 프레임까지 안 기다리고 바로 적용하도록 강제
        // 이 함수가 없었을 때 인덱스가 무조건 0번을 기준으로 초기화되는 문제가 생겨서 추가함
        Canvas.ForceUpdateCanvases();

        // 이 스크립트가 붙은 자식 오브젝트를 모두 찾아 배열에 넣는 기능, 자식 오브젝트가 생성된 이후 시작해야해서 Awake 대신 Start로
        targetPositions = new float[swipeContents.Count];

        // 각 자식 오브젝트가 화면 중앙에 오려면 얼마나 이동해야하는지 거리를 미리 계산
        for (int i = 0; i < swipeContents.Count; i++)
        {
            // 컨텐츠의 로컬 위치를 기준으로 역산해 컨텐츠의 목표 위치 잡기
            RectTransform rect = swipeContents[i].GetComponent<RectTransform>();
            targetPositions[i] = -rect.localPosition.y + addPosY;
        }


        // 최초 오픈에서 리스트 0 번이 확정적으로 중심에 놓이도록 처리
        // anchoredPosition 유니티 엔진의 기본 UI 프로퍼티
        // UI는 설정이 'Screen Space - Overlay' or 'Camera'로 되어있으면 평면이라 벡터 2 사용
        AutoUIMoveToPos(0);
        contentRect.anchoredPosition = new Vector2(contentRect.anchoredPosition.x, targetPosY);
    }



    private void Update()
    {
        // 유저가 드래그 중이 아닐 때만 스냅을 실행 (기존에는 Update 시 계속 실행되게 했는데, 매 프레임마다 작동하는게 구조상 비효율적이라 수정)
        // 유저가 조작 중일 때는 유니티의 기본 물리 법칙을 따름
        if (!isSwipeMode)
        {
            // Mathf.Lerp를 사용해 현재 위치 -> 목표 위지로 부드럽게 이동
            float newY = Mathf.Lerp(contentRect.anchoredPosition.y, targetPosY, Time.deltaTime * snapSpeed);
            contentRect.anchoredPosition = new Vector2(contentRect.anchoredPosition.x, newY);
        }
    }


    // 유저가 드래그 시 자동으로 호출되는 함수, IBeginDragHandler 필요
    // PointerEventData : 유니티에서 포인터 기반 입력을 할 때 입력 위치, 클릭 회수, 드래그 상태 등 각종 정보를 담고 있는 데이터 클래스
    public void OnBeginDrag(PointerEventData eventData)
    {
        isSwipeMode = true;
    }


    // 유저가 드래그 종료 시 자동으로 호출되는 함수, IEndDragHandler 필요
    public void OnEndDrag(PointerEventData eventDate)
    {
        isSwipeMode = false;

        //드래그 멈출 때 가까운 목표 찾기
        targetPosY = FindClosestPos(contentRect.anchoredPosition.y);
    }



    // 현재 스크롤 위치에서 가장 가까운 컨텐츠 좌표 찾기
    private float FindClosestPos(float currentY)
    {
        float closestPos = targetPositions[0];
        float minDistance = Mathf.Abs(targetPositions[0] - currentY);
        int closestIndex = 0;

        // 모든 컨텐츠의 좌표 불러옴 -> 그중 가장 가까운 위치와 대상 컨텐츠 저장
        for (int i = 1; i < targetPositions.Length; i++)
        {
            float distance = Mathf.Abs(targetPositions[i] - currentY);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestPos = targetPositions[i];
                closestIndex = i;
            }


        }

        // 가장 가까운 컨텐츠의 인덱스를 저장
        currentIndex = closestIndex;

        UpdateFocusEffects();

        return closestPos;
    }



    //실제 중심점까지 이동시키는 기능
    private void AutoUIMoveToPos(int index)
    {
        if (index >= 0 && index < targetPositions.Length)
        {
            targetPosY = targetPositions[index];
            currentIndex = index;

            UpdateFocusEffects();
        }
    }


    // 중앙에 있는 컨텐츠를 켜주는 기능
    private void UpdateFocusEffects()
    {
        for (int i = 0; i < swipeContents.Count; i++)
        {
            // 모든 하위 컨텐츠 순회해 중앙은 true / 아니면 false 처리
            if (i == currentIndex)
            {
                swipeContents[i].SetSwipeContents(true);
            }
            else
            {
                swipeContents[i].SetSwipeContents(false);
            }
        }
    }

}

