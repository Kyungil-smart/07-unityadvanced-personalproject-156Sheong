using UnityEngine;
using R3;



[RequireComponent(typeof(RangeDetectorComponent), typeof(TargetTrackerComponent))]
public class RangeDetectorTargetTrackerLinker : MonoBehaviour
{
    void Start()
    {

        var rangeDetector = GetComponent<RangeDetectorComponent>();
        var targetTracker = GetComponent<TargetTrackerComponent>();


        if (rangeDetector == null || targetTracker == null) return;


        rangeDetector.OnTargetEntered
        .Subscribe(target => targetTracker.AddTarget(target))
        .AddTo(this);

        rangeDetector.OnTargetExited
        .Subscribe(target => targetTracker.RemoveTarget(target))
        .AddTo(this);

    }
}
