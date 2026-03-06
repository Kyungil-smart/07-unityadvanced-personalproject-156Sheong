using UnityEngine;
using UnityEngine.Tilemaps;

// 플레이어가 맵에 캐릭터를 소환하는 기능을 담당하는 매니저
public class SummonManager : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] CharacterSelection characterSelection;
    [SerializeField] TileValidatorComponent tileValidator;
    [SerializeField] CoinManager coinManager;


    public void SummonCharacter(Vector3 mousePosition)
    {
        // 유저가 클릭한 위치를 타일맵의 셀 위치로 변환
        var cellPosition = tilemap.WorldToCell(mousePosition);

        // 해당 셀 위치가 유효한 타일인지 검사
        if (!tileValidator.IsPlaceableTile(tilemap, cellPosition)) return;

        // 유저가 선택한 캐릭터 프리팹 정보를 가져옴
        var selectedCharacterPrefab = characterSelection.GetSelectedCharacterInfo();
        if (selectedCharacterPrefab == null) return;


        // 캐릭터 소환에 필요한 코인을 차감. 코인이 부족하면 소환하지 않음
        if (!coinManager.SpendCoins(selectedCharacterPrefab.placementCost)) return;


        // 타일맵의 셀 위치를 월드 좌표로 변환하여 캐릭터 프리팹을 소환
        var cellCenterPos = tilemap.GetCellCenterWorld(cellPosition);
        Instantiate(selectedCharacterPrefab.characterPrefab, cellCenterPos, Quaternion.identity);

    }
}
