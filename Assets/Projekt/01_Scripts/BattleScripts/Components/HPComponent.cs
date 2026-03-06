using UnityEngine;
using R3;   //반응형 프로그래밍 라이브러리
// event, delegate, UnityEvent 대신 변화가 있을 때만 갱신시킬 수 있는 기능


public class HPComponent : MonoBehaviour, IDamageable
{
    public int maxHP = 0;
    [SerializeField] SerializableReactiveProperty<int> currentHP = new SerializableReactiveProperty<int>();
    public ReadOnlyReactiveProperty<int> CurrentHP => currentHP;

    private bool isAlive = true;
    public bool IsAlive => isAlive;

    
    readonly private Subject<Unit> deathSubject = new Subject<Unit>();  // 사망 신호를 보내기 위한 Subject, <Unit>은 객체 없음을 의미, 단순히 신호만 보내기 위해 사용
    public Observable<Unit> OnDeath => deathSubject;    // 외부에서 구독할 수 있는 Observable, Observable 는 듣기만 하는 인터페이스, Subject는 듣고 말할 수 있는 인터페이스

    public GameObject RelatedGameObject => gameObject;

    private void Awake()
    {
        currentHP.Value = maxHP;
        currentHP.AddTo(this);
        isAlive = true;

        deathSubject.AddTo(this);
    }


    public void TakeDamage(int dmg)
    {
        if (!isAlive)
        {
            return;
        }


        currentHP.Value -= dmg;

        if (currentHP.Value <= 0)
        {
            currentHP.Value = 0;
            DieCharcater();
        }
    }


    // 사망시 처리
    public void DieCharcater()
    {
        
        if (!isAlive)
        {
            return;
        }
        isAlive = false;

        // 구독하고 있는 곳에서 사망 신호 발송
        deathSubject.OnNext(Unit.Default);
    }

    
}
