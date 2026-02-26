using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEngine;
using UnityEngine.UI;



// 오디오를 받아서 재생하고 볼륨을 조절하는 역할
public class SoundManager : Singleton<SoundManager>
{


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

}
