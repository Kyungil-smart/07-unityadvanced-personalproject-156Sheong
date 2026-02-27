using System.Collections.Generic;


// SceneData Json 파일을 직렬화하는 틀

public class SceneDataInfo
{
    // 식별자
    public int sceneID;

    // 씬 관련 텍스트
    public string sceneName;
    public string sceneDesc;
    
    // 씬 종류
    public string sceneType;
    public int difficultyNumber;

    // 씬 챕터 및 번호
    public int chapterNumber; 
    public int sortNumber;

    // 입장 제한
    public string entryLimit;
    public int maxEntryPerCycle;
    public int entryCostID;
    public int price;

    // 보상
    public int firstClearRewardID;
    public int repeatClearRewardID;
    public int repeatDefeatRewardID;
    // 추후 별보상 조건 2, 3도 추가 필요(1은 클리어로 통일해서 생략) -> 스테이지 단위가 아닌 챕터에서 보상을 해줌

    // 해금 조건
    public string unlockReq;
    public int unlockNumber;


}


// SceneData 래퍼 클래스, 이걸로 감싸줘야 함
[System.Serializable]
public class SceneDataWrapper
{
    public List<SceneDataInfo> SceneData;
}
