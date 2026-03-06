using UnityEngine;
using R3;


[RequireComponent(typeof(HPBarUIComponent))]
public class HPBarUILinker : MonoBehaviour
{
    [SerializeField] HPComponent hp;
    
    void Start()
    {
        
        var hpBarUI = GetComponent<HPBarUIComponent>();
       
        if (hp == null || hpBarUI == null) return;


        
        hp.CurrentHP
        .Subscribe(value => hpBarUI.UpdateHP(value))
        .AddTo(this);

        
        hpBarUI.Initialize(hp.maxHP);

    }
}
