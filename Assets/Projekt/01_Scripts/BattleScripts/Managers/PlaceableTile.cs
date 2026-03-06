using UnityEngine;
using UnityEngine.Tilemaps;


// 임시용 타일 내 배치 가능 여부 타일
[CreateAssetMenu(fileName = "New Placeable Tiles", menuName = "Tiles/Placeable Tile")]
public class PlaceableTile : Tile
{
    // 배치 가능 여부
    public bool canPlaceCharacter = true;

}