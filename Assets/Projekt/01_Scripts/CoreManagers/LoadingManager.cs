using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// 씬 로딩 + 로딩 중 대기 화면을 담당
public class LoadingManager : Singleton<GameManager>
{

    // 넘어갈 씬들 명칭
    [SerializeField] private List<string> sceneToLoad = new List<string>();


    // 로딩 완료 시 활성화할 버튼
    [SerializeField] GameObject buttonForNextScene;

    // 랜덤으로 이미지 넘어가기 위한 기능
    [Header("RandomBGVars")]
    [SerializeField] List<GameObject> firstLoadingImgs = new List<GameObject>();    // 로딩 중 랜덤으로 보여줄 이미지들
    [SerializeField] GameObject loadingCanvas;   // 이미지를 표시할 캔버스
    [SerializeField] private float changeInterval = 0f;



    // Awake 를 사용할거면 protected override void Awake() 형태로 해야함


    // 초기에 씬 넘어가는 기능 -> 나중에 기능 추가 시 수정해야
    private void Start()
    {
        // @ 임시 비동기 씬 로딩, 추후 개선 예정
        StartCoroutine(LoadSceneAsync(sceneToLoad[1]));
        Debug.Log("Scene_Opening 로딩 완료");

    }


    // 로딩이 완료될 때까지 대기하는 비동기 로딩
    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
             // 로딩 완료 시 버튼 활성화
            yield return null;
        }
    }


    // 로딩 완료 후 버튼 클릭 활성화 기능


    // 로딩 완료 후 버튼 클릭 시, 실제 씬 넘어가는 기능


    // 로딩 중에 n초마다 랜덤으로 이미지 넘어가는 기능

}
