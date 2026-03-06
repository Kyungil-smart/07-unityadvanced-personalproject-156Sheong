using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;


// 임시용 타일 내 배치 가능 여부 컴포넌트

public class TileValidatorComponent : MonoBehaviour
{
    [SerializeField] List<PlaceableTile> placeableTiles = new List<PlaceableTile>();

    // 지정한 타일이 배치 가능한지 검사하는 기능
    public bool IsPlaceableTile(Tilemap tilemap, Vector3Int cellPosition)
    {
        TileBase tile = tilemap.GetTile(cellPosition);

        
        return tile != null &&  // 실제 타일이 존재하나
            tile is PlaceableTile placeableTile &&  // 타일이 PlaceableTile 타입
            placeableTile.canPlaceCharacter &&  // 캐릭터 배치 가능 여부 확인
            placeableTiles.Contains(placeableTile); // 배치 가능한  타일 목록에 포함되어있는지
    }
}
