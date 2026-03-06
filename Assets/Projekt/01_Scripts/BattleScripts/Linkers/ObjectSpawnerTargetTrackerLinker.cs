using UnityEngine;
using R3;



// 오브젝트 스포너가 생성한 오브젝트가 가장 가까운 타겟을 향하도록 하는 컴포넌트
[RequireComponent(typeof(GameObjectSpawnerComponent))]
public class ObjectSpawnerTargetTrackerLinker : MonoBehaviour
{
    [SerializeField] TargetTrackerComponent targetTracker;
    
    void Start()
    {
        
        var objectSpawner = GetComponent<GameObjectSpawnerComponent>();

        
        if (objectSpawner == null || targetTracker == null) return;

        // 오브젝트 스포너에서 오브젝트가 생성될 때마다 HandleObjectSpawned 구독
        objectSpawner.OnObjectSpawned
        .Subscribe(spawnedObject => HandleObjectSpawned(spawnedObject))
        .AddTo(this);
    }


    // 오브젝트가 생성될 때 가장 가까운 타겟을 향하도록 설정
    void HandleObjectSpawned(GameObject spawnedObject)
    {
        var movement = spawnedObject.GetComponent<MovementComponent>();


        if (movement == null) return;


        var closestTarget = targetTracker.FindClosestTarget(spawnedObject.transform.position);

        if (closestTarget != null)
        {
            
            Vector3 direction = (closestTarget.RelatedGameObject.transform.position - spawnedObject.transform.position).normalized;
            movement.SetDirection(direction);
        }

    }
}
