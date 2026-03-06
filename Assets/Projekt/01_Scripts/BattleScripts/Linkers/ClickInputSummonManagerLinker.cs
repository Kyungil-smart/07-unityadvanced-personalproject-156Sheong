using UnityEngine;
using R3;


[RequireComponent(typeof(ClickInputComponent))]
public class ClickInputSummonManagerLinker : MonoBehaviour
{
    [SerializeField] SummonManager summonManager;
    
    void Start()
    {
       
        var mouseClickInput = GetComponent<ClickInputComponent>();
       
        if (mouseClickInput == null || summonManager == null) return;


       
        mouseClickInput.OnClick
        .Subscribe(mousePosition => summonManager.SummonCharacter(mousePosition))
        .AddTo(this);
    }
}
