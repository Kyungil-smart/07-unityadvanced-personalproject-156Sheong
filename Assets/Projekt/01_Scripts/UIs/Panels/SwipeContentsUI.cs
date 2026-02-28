using UnityEngine;



// 각 컨텐츠에 붙어서, SwipeUI가 해당 컨텐츠를 중심에 넣으면 각 대상의 크기가 커지고 버튼을 활성화하는 스크립트
public class SwipeContentsUI : MonoBehaviour
{
    [SerializeField] private RectTransform myRect;
    [SerializeField] private GameObject myButton;
    [SerializeField] private float scaleMulti = 0f;


    // 각 컨텐츠가 중앙인지 여부를 받아서 실행되는 기능
    public void SetSwipeContents(bool state)
    {

        myButton.SetActive(state);

        if (state == true) myRect.localScale = Vector3.one * scaleMulti;
        else myRect.localScale = Vector3.one;
    }
}
