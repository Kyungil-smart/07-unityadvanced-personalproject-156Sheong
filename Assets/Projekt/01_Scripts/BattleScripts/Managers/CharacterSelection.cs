using UnityEngine;
using System.Collections.Generic;


public class CharacterSelection : MonoBehaviour
{
    // 유저가 UI에서 선택할 수 있는 캐릭터 정보 리스트
    [SerializeField] List<CharacterInfo> characterInfos = new List<CharacterInfo>();
    CharacterInfo selectedCharacterInfo;



   
    void Start()
    {
        // 게임 시작 시 캐릭터 정보 리스트에서 첫 번째 캐릭터를 기본으로 선택
        if (characterInfos.Count > 0)
        {
            selectedCharacterInfo = characterInfos[0];
        }

    }


    // 다른 스크립트에서 선택된 캐릭터 정보를 가져올 때 호출되는 메서드
    public CharacterInfo GetSelectedCharacterInfo()
    {
        return selectedCharacterInfo;   // 현재 선택된 캐릭터 정보를 반환
    }


    // 유저가 UI에서 캐릭터를 선택할 때 호출되는 메서드
    public void SelectedCharacter(int index)
    {
        if (index >= 0 || index < characterInfos.Count)
        {
            

            // 유저가 선택한 인덱스에 해당하는 캐릭터 정보를 변수에 저장
            selectedCharacterInfo = characterInfos[index];

        }

    }

}
