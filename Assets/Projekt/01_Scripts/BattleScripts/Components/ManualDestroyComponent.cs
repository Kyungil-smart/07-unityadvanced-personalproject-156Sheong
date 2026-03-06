using UnityEngine;

public class ManualDestroyComponent : MonoBehaviour
{
    // 임시로 구현한 오브젝트 파괴 스크립트 -> 추후 오브젝트 풀로 변경할 예정

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
