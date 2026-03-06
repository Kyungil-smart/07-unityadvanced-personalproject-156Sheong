using UnityEngine;



// 전투 씬의 전반을 관리하는 클래스
public class BattleManager : MonoBehaviour
{
    [SerializeField] private EnemyGenerator enemyGenerator;
    [SerializeField] private GameObject gameClearPanel;
    [SerializeField] private GameObject gameOverPanel;

    bool isGameEnded = false;

    // 게임이 끝났을 때 적 생성기를 비활성화하는 메서드
    void GameFinish()
    {
        enemyGenerator.gameObject.SetActive(false);
    }


    // 게임 클리어 시 호출되는 기능
    public void GameClear()
    {
        if (isGameEnded) return;

        isGameEnded = true;

        SoundManager.Instance.PlaySound(3);
        GameFinish();
        gameClearPanel.SetActive(true);
    }
    

    // 게임 패배 시 호출되는 기능
    public void GameOver()
    {
        if (isGameEnded) return;

        isGameEnded = true;

        SoundManager.Instance.PlaySound(4);
        GameFinish();
        gameOverPanel.SetActive(true);
    }
}
