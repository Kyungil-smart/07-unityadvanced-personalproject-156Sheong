using UnityEngine;
using UnityEngine.Events;


// 박스 콜라이더의 어느 지점에서 충돌했는지 확인하는 기능
// 처음에 만든 기능은 회전 시 실제 면과 다른 면이 감지되는 버그가 발생하여 대폭 수정
[RequireComponent(typeof(BoxCollider))] // 박스 콜라이더가 없다면 자동으로 생성해주는 기능 
public class HitFaceDetector : MonoBehaviour
{

    public UnityEvent<HitFace> hitFaceEvent;

    private BoxCollider _hitCollider;

    private void Awake()
    {
        
        _hitCollider = GetComponent<BoxCollider>();
    }


    private void OnTriggerEnter(Collider other)
    {
        // 트리거에 들어온 대상이 내 기준 어느 쪽인지 계산
        // _hitCollider.center 는 로컬 좌표이고, TransformPoint()는 월드 좌표로 변한하는 기능(회전, 크기, 위치 모두 고려)
        Vector3 myCenterWorld = transform.TransformPoint(_hitCollider.center);

        // 충될된 상대의 가장 가까운 지점 찾기
        // .ClosestPoint() : 대상 위에서 () 사이 가장 가까운 지점 찾기
        Vector3 targetPoint = other.ClosestPoint(myCenterWorld);
        Vector3 directionToTargetWorld = targetPoint - myCenterWorld;   // 도착지 - 출발지를 하여 방향과 거리를 알려줌

        // CalculateHitFace 함수에 넣어 면 판별
        HitFace hitFace = CalculateHitFace(directionToTargetWorld);

        // 다른 곳에 연결하기 위해 필요한 외부에 이벤트 발송
        hitFaceEvent?.Invoke(hitFace);
    }


    private HitFace CalculateHitFace(Vector3 worldDirection)
    {
        // 오브젝트의 회전값을 무시하고 정면 기준 방향 재정렬
        // InverseTransformDirection() : 월드 공간의 방향이 대상의 로컬에선 어느 방향인가로 변환(회전만 고려, 위치 / 크기는 고려 X)
        Vector3 localDirection = transform.InverseTransformDirection(worldDirection);

        // 판별을 위해 좌표를 절대값 변환
        // 음수 값과 양수 값이 같이 있을 때, 크기만 비교하기 위해 필요
        float absX = Mathf.Abs(localDirection.x);
        float absY = Mathf.Abs(localDirection.y);
        float absZ = Mathf.Abs(localDirection.z);

        // 각 축 판별
        if (absZ > absX && absZ > absY) return localDirection.z > 0 ? HitFace.Front : HitFace.Back;         // 정면이 가장 많이 사용될 값이라 예상되어 위쪽에 위치함
        else if (absX > absY && absX > absZ) return localDirection.x > 0 ? HitFace.Right : HitFace.Left;
        else if (absY > absX && absY > absZ) return localDirection.y > 0 ? HitFace.Top : HitFace.Bottom;
        else return HitFace.Default;    // 사실상 나오는 안 되는 HitFace enum 값

    }
}
