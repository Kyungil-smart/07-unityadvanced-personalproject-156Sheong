using UnityEngine;

[System.Serializable]
public class CharacterInfo
{
    public GameObject characterPrefab;  // 캐릭터 프리팹 참조
    public int placementCost = 0;   // 캐릭터를 소환하는 데 필요한 코인 비용
}