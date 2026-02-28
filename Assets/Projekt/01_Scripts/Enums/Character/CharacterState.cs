

// 캐릭터의 상태, 추후 상태 패턴이나 BT 등 다른 기능으로 바꿔 사용할 예정
public enum CharacterState
{
    Default,    // (사용 안할 기본값)
    Idle,       // 기본
    Move,       // 이동
    AimTarget,  // 조준
    Attack,     // 공격
    Reloaind,   // 재장전
    Capturing,  // 점령
    Cover,      // 엄폐
    Shocked,    // 충격 받음(이속, 장전 속도, 명중률 하락)
    Retreat,    // 후퇴(이속 및 회피율 높아진 채로 아군 베이스까지 이동, 컨트롤 불가)
}
