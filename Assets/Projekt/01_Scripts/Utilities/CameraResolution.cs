using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    // 카메라의 해상도를 고정하는 스크립트
    // 용도 : 다양한 모바일 환경의 해상도를 관리하기 위함
    // 단점 : 앵커를 사용하지 않아야함
    // https://www.youtube.com/watch?v=uQZFawccnNg 기반
    void Start()
    {
        Camera mainCamera = GetComponent<Camera>();
        Rect rect = mainCamera.rect;    // Output의 viewport Rect의 요소 4가지를 모두 가져옴

        float scaleHeight = ((float)Screen.width / Screen.height) / ((float)9 / 16); // 보정하고 싶은 기준의 가로 / 세로 비율을 맞추는 기능
        float scaleWidth = 1f / scaleHeight;

        // 위 아래가 남는 경우
        if(scaleHeight < 1)
        {
            rect.height = scaleHeight;
            rect.y = (1f - scaleHeight) / 2f;
        }
        // 좌 우가 남는 경우
        else
        {
            rect.width = scaleWidth;
            rect.x = (1f - scaleWidth) / 2f;
        }

        // 위에서 수정한 것을 대입
        mainCamera.rect = rect;
    }

    // 카메라 밖은 완전히 검게 표시
    void OnPreCull() => GL.Clear(true, true, Color.black);
}
