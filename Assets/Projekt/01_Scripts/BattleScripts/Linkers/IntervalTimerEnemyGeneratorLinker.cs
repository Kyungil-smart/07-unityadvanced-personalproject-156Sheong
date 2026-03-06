using UnityEngine;
using R3;

// 인터벌 타이머와 적 생성기를 연결
[RequireComponent(typeof(IntervalTimerComponent))]
public class IntervalTimerEnemyGeneratorLinker : MonoBehaviour
{
    [SerializeField] EnemyGenerator enemyGenerator;
   
    void Start()
    {
       
        var intervalTimer = GetComponent<IntervalTimerComponent>();
        

        if (intervalTimer == null || enemyGenerator == null) return;


        
        intervalTimer.OnIntervalEl
        .Subscribe(_ => enemyGenerator.SpawnEnemy())
        .AddTo(this);


        intervalTimer.Active();
    }
}
