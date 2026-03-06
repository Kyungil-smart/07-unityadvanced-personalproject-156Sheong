using UnityEngine;


// 임시로 3D 공간에서 이동 가능한 범위를 정의하는 컴포넌트
public class MovementBounds3DComponent : MonoBehaviour
{
    [SerializeField] float minX = -5f;
    [SerializeField] float maxX = 4f;
    [SerializeField] float minZ = -14f;
    [SerializeField] float maxZ = 11f;

    private void LateUpdate()
    {
        Vector3 newPos = transform.position;

        // 3D 환경의 바닥 이동을 제어하기 위해 X축과 Z축을 Clamp 
        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
        newPos.z = Mathf.Clamp(newPos.z, minZ, maxZ);

        transform.position = newPos;
    }
}
