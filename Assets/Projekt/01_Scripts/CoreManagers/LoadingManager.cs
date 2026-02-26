using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// 씬 로딩 + 로딩 중 대기 화면을 담당
public class LoadingManager : MonoBehaviour
{

    // 로딩 관련 기능 기능
    [Header("ForLoading")]
    [SerializeField] private List<string> sceneToLoad = new List<string>(); // 넘어갈 씬들 명칭
    [SerializeField] GameObject darkVail;   // 로딩 씬 시작 시 제거될 검은 이미지
    [SerializeField] GameObject buttonForNextScene; // 로딩 완료 시 활성화할 버튼


    // 랜덤으로 이미지 넘어가기 위한 기능
    [Header("RandomBGVars")]
    [SerializeField] List<GameObject> firstLoadingImgs = new List<GameObject>();    // 로딩 중 랜덤으로 보여줄 이미지들
    [SerializeField] GameObject loadingCanvas;   // 이미지를 표시할 캔버스
    [SerializeField] private float changeInterval = 0f;




    // 씬 로딩 관련해서 Awake 를 사용할거면 protected override void Awake() 형태로 해야함
    private void Awake()
    {
        Init();
    }


    
    private void Start()
    {
        // Build Settings 기준의 현재 씬 번호 확인
        int currentSceneNumber = SceneManager.GetActiveScene().buildIndex;

        // 현재 씬 번호에 따라 동작하는 기능
        if(currentSceneNumber == 0) ChangeScene(1);
        else
        {
            // @ 외부에서 번호 받고, 이에 따라 신 로딩하는 기능 필요
            ChangeScene(1);
        }

        // 배경 이미지 정해진 시간마다 바꿔주는 코루틴 시작
        StartCoroutine(AutoChangeImg());

        darkVail.SetActive(false);
    }


    private void Update()
    {
        
    }


    private void Init()
    {
        // 로딩 완료 후에 표시할 오브젝트 비활성화 시키기
        if (buttonForNextScene != null && buttonForNextScene.activeSelf)
        {
            buttonForNextScene.SetActive(false); // 비활성화
        }

        // 처음에 검은 화면 활성화 시키기
        if (darkVail != null && !darkVail.activeSelf)
        {
            darkVail.SetActive(true); // 활성화
        }
    }


    // 로딩이 완료될 때까지 대기하는 비동기 로딩
    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // 로딩이 완료 되어도 자동으로 씬 넘어가지 않도록 하는 기능
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            buttonForNextScene.SetActive(true); // 로딩 완료 시 버튼 활성화
            yield return null;
        }
    }


    // 로딩 완료 후 버튼 클릭 시, 실제 씬 넘어가는 기능
    public void ChangeScene(int sceneNumber)
    {
        // @ 임시 비동기 씬 로딩, 추후 개선 예정
        // sceneToLoad 리스트의 번호에 해당하는 씬의 string 명칭을 가지고, Build Settings 에서 해당 이름 씬 찾아서 로딩하는 기능
        StartCoroutine(LoadSceneAsync(sceneToLoad[sceneNumber]));
        Debug.Log($"{sceneNumber} 번째 씬 로딩 완료");
    }


    // 로딩 중에 n초마다 랜덤으로 이미지 넘어가는 기능, 이미지 리스트 0기면 오류남
    IEnumerator AutoChangeImg()
    {
        // 계속 반복
        while (true)
        {
            // 리스트에서 이미지 개수 가져오기
            int randomIndex = Random.Range(0, firstLoadingImgs.Count);

            // 순환하면서 모든 이미지 비활성화 시키기
            foreach (GameObject imgBGs in firstLoadingImgs) imgBGs.SetActive(false);
            
            // 이후에 랜덤으로 선택된 이미지 활성화하기
            firstLoadingImgs[randomIndex].SetActive(true);

            // n초 대기
            yield return new WaitForSeconds(changeInterval);
        }
    }
}
