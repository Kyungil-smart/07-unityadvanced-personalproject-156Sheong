using UnityEngine;



// 투사체 등이 일정 시간 후에 사라지도록 하는 컴포넌트
public class TimedDestroyComponent : MonoBehaviour
{
    [SerializeField] float timeToDestroy = 0f;
    
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
