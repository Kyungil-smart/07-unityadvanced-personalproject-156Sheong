using UnityEngine;
using R3;



[RequireComponent(typeof(IntervalTimerComponent), typeof(GameObjectSpawnerComponent))]
public class IntervalTimerObjectSpawnerLinker : MonoBehaviour
{
    void Start()
    {
        
        var intervalTimer = GetComponent<IntervalTimerComponent>();
        var objectSpawner = GetComponent<GameObjectSpawnerComponent>();


        if (intervalTimer == null || objectSpawner == null) return;



        intervalTimer.OnIntervalEl
        .Subscribe(_ => objectSpawner.Spawn())
        .AddTo(this);

    }
}
