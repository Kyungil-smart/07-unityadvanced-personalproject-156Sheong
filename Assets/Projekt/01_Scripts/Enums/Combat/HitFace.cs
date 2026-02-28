

// 피격당하는 면이 어디인지 판단하는 enum
// 피격 방향에 따라 피해를 다르게 계산하기 위해 필요 (전차는 정면에 강한데 헬기를 활용한 탑 어택이나 지뢰를 활용한 바텀 어택에 약한 것 등 구현 위함)
public enum HitFace
{
    Default,
    Front,
    Back,
    Top,
    Bottom,
    Right,
    Left,


}
