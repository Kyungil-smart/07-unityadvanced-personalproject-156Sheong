using UnityEngine;
using System.Collections.Generic;
using System.Collections;



// 오디오를 받아서 재생하고 볼륨을 조절하는 역할
public class SoundManager : Singleton<SoundManager>
{

    public List<AudioClip> soundEffects; // 이펙트 클립 리스트
    public List<int> maxPlayCounts; // 최대 재생 횟수 리스트

    [Range(0f, 1f)]
    public float seVolume = 0f; // 이펙트 볼륨

    
    List<AudioSource> audioSources = new List<AudioSource>(); // 현재 재생 중인 AudioSource 리스트
    List<int> currentPlayCounts; // 현재 재생 중인 횟수 리스트


    private void Awake()
    {
        // 부모 오브젝트를 불러와 싱글톤화
        base.Awake();


        // 최대 재생 횟수 리스트 초기화
        currentPlayCounts = new List<int>(new int[soundEffects.Count]);
    }

    // 사운드 재생
    public void PlaySound(int soundIndex)
    {
        // 유효한 인덱스 인지 확인
        if (soundIndex >= 0 && soundIndex < soundEffects.Count)
        {
            // 최대 재생 횟수보다 현재 재생 중인 횟수가 적은 경우에만 재생
            if (currentPlayCounts[soundIndex] < maxPlayCounts[soundIndex])
            {
                // 새로운 AudioSource를 생성하여 사운드 재생
                AudioSource newAudioSource = gameObject.AddComponent<AudioSource>();
                newAudioSource.clip = soundEffects[soundIndex]; // 사운드 클립 설정
                newAudioSource.volume = seVolume; // 볼륨 설정
                newAudioSource.Play();  // 사운드 재생
                audioSources.Add(newAudioSource);   // 재생 중인 AudioSource 리스트에 추가

                // 현재 재생 중인 횟수 증가
                currentPlayCounts[soundIndex]++;

                // 사운드가 끝난 후 AudioSource를 제거하는 코루틴 시작
                StartCoroutine(RemoveAudioSourceAfterPlaying(newAudioSource, soundIndex));
            }
        }

    }

    // 사운드 재생이 끝난 후 AudioSource를 제거하는 코루틴
    IEnumerator RemoveAudioSourceAfterPlaying(AudioSource source, int soundIndex)
    {
        // 사운드가 재생되는 동안 대기
        yield return new WaitWhile(() => source.isPlaying);

        // 재생이 끝난 후 AudioSource 제거
        audioSources.Remove(source);
        Destroy(source);

        // 현재 재생 중인 횟수 감소
        currentPlayCounts[soundIndex]--;
    }

    /*
    private AudioSource _sourceSE;
    private AudioSource _sourceBGM;


    // 아래는 추후 변경할 부분, 현재는 임시로 간단히 볼륨 조절
    // public Slider tempSliderBGM;
    public AudioClip tempClip;
    // public float SEVolume { get; set; } = 1f;
    // public float BGMVolume { get; set; } = 1f;


    protected override void Awake()
    {
        // 부모 오브젝트를 불러와 싱글톤화
        base.Awake();


        // 임시로 AudioSource 컴포넌트 추가
        _sourceBGM = GetComponent<AudioSource>();
    }

    void Start()
    {
        // tempSliderBGM.value = _sourceBGM.volume;
        _sourceBGM.clip = this.tempClip;
        _sourceBGM.loop = true;
        _sourceBGM.Play();
    }


    // 효과음 재생

    // 배경음 재생



    // 볼륨 조절
    public void SetVolume(float volume)
    {
        // _sourceBGM.volume = tempSliderBGM.value;
    }
    */
}
