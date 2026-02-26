using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public List<GameObject> coreManagers = new List<GameObject>();




    // Awake 를 사용할거면 protected override void Awake() 형태로 해야함


    // 임시로 초기에 씬 넘어가는 기능 구현
    private void Start()
    {
        Init();

    }


    private void Init()
    {
        // 자식 오브젝트로 각종 매니저 생성
        foreach (GameObject manager in coreManagers)
        {
            if (manager != null)
            {
                GameObject newManager = Instantiate(manager, transform);
                newManager.name = manager.name;
            }
        }
    }

}
