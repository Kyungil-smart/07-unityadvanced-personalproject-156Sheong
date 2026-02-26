using UnityEngine;

// 유니티 타워 디펜스 탬플릿 싱글톤 예제 코드 참고
public abstract class Singleton<St> : MonoBehaviour where St : Singleton<St>
{
    public static St Instance { get; protected set; }

    // 현재 싱글톤 인스턴스가 존재하는 지 여부
    public static bool hasInstance => Instance != null;


    protected virtual void Awake()
    {
        // 싱글톤 인스턴스 탄생 시점에 새로 생성된 같은 타입 오브젝트가 있으면 삭제
        if (hasInstance)
        {
            Destroy(gameObject);
        }
        // 만약 처음 생성된 오브젝트라면 싱클톤 인스턴스로 형변환하고 파괴되지 않도록 설정
        else
        {
            Instance = (St)this;
            DontDestroyOnLoad(gameObject);
        }

    }

    protected virtual void OnDestroy()
    {
        // 싱글톤 인스턴스가 파괴될 때 인스턴스 변수 초기화 (static이라 참조 완전히 비워 삭제해야함)
        if (Instance == this) Instance = null;

    }
}
