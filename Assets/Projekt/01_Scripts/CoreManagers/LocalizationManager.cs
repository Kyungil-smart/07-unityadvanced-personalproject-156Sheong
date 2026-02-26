using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;


// https://www.youtube.com/watch?v=VNhzMEsy7xc 기반 스크립트 수정
public class LocalizationManager : Singleton<LocalizationManager>
{
    [SerializeField] private int defaultIndex = 0;
    private bool isChanging;



    protected override void Awake()
    {
        // 부모 오브젝트를 불러와 싱글톤화
        base.Awake();

        // ------ 유저 세이브 없으면 디폴트 언어 설정 ------

        // @ 유저 세이브 추가 필요
        ChangeLocale(defaultIndex); // 디폴트 언어는 0번(영어)
    }



    public void ChangeLocale(int index)
    {
        if (isChanging) return;

        StartCoroutine(ChangeRoutine(index));
    }

    IEnumerator ChangeRoutine(int index)
    {
        isChanging = true;

        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];

        isChanging = false;
    }
}
