using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0f;
    [SerializeField] Vector3 moveDirection = Vector3.right;

    Vector3 defaultDirection; 
    bool isMoving = true;


    private void Awake()
    {
        defaultDirection = moveDirection;
    }


    void Update()
    {
        if (isMoving)
        {
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }

    }


    public void SetDirection(Vector3 direction)
    {
        // 방향 노말라이즈
        moveDirection = direction.normalized;
    }

    // 이슈가 생겼을 때 원래 가던 길 복구하는 기능
    public void ResetToDefaultDirection()
    {
        moveDirection = defaultDirection; 
    }


    // 이동 시작 및 정지를 캡슐화하여 관리
    public void StartMoving()
    {
        isMoving = true;
    }
    public void StopMoving()
    {
        isMoving = false;
    }
}
