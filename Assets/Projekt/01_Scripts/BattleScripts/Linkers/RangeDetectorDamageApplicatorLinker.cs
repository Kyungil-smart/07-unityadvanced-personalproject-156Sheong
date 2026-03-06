using UnityEngine;
using R3;

//

[RequireComponent(typeof(RangeDetectorComponent), typeof(DamageApplicatorComponent))]
public class RangeDetectorDamageApplicatorLinker : MonoBehaviour
{
    void Start()
    {
        
        var rangeDetector = GetComponent<RangeDetectorComponent>();
        var damageApplicator = GetComponent<DamageApplicatorComponent>();

       
        if (rangeDetector == null || damageApplicator == null) return;


        
        rangeDetector.OnTargetEntered
        .Subscribe(target => damageApplicator.ApplyDamage(target))
        .AddTo(this);

    }
}
