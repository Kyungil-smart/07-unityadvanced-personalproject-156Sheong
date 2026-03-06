using UnityEngine;
using R3;


// 프리펩을 생성만 해주는 스크립트
public class GameObjectSpawnerComponent : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject FirePoint;
    [SerializeField] private int atkPower = 0;

    // 구독 알림
    readonly Subject<GameObject> objSpawnedSubject = new Subject<GameObject>();
    public Observable<GameObject> OnObjectSpawned => objSpawnedSubject;

    void Awake()
    {
        // R3 로 자동 구독 제어
        objSpawnedSubject.AddTo(this);
    }

    // 오브젝트 생성시 호출
    public void Spawn()
    {
        // 프리펩을 현재 위치에 생성
        GameObject spawnedObject = Instantiate(bullet, FirePoint.transform.position, Quaternion.identity);
        spawnedObject.GetComponent<DamageApplicatorComponent>().ATKPower = atkPower;
        objSpawnedSubject.OnNext(spawnedObject);
    }
}
