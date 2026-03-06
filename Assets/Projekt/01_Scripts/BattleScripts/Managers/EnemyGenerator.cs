using UnityEngine;


// 몬스터 생성 관리 클래스
public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs; // 몬스터 프리팹 배열
    int currentEnemyIndex = 0;  // 현재 생성할 몬스터 인덱스

    // 몬스터 생성 기능
    public void SpawnEnemy()
    {
        // 모든 몬스터가 생성된 경우 더 이상 생성하지 않음
        if (currentEnemyIndex >= enemyPrefabs.Length) return;

        // 몬스터가 생성될 위치 계산
        float randomX = Random.Range(-4.5f, 4.5f);  
        float randomZ = Random.Range(-4.5f, 4.5f);

        Vector3 spawnPosition = new Vector3(randomX, 1.5f, randomZ);   // 몬스터가 생성될 위치 설정

        // 몬스터 프리펩 생성
        Instantiate(enemyPrefabs[currentEnemyIndex], spawnPosition, Quaternion.identity);
        
        currentEnemyIndex++;    // 다음 몬스터 인덱스로 이동
    }
}
