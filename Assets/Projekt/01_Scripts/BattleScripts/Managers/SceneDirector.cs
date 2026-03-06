using UnityEngine;
using UnityEngine.SceneManagement;


// 임시용 씬 전환 매니저
public class SceneDirector : MonoBehaviour
{
    public void GoToSceneName(string sceneName)
    {
        
        SceneManager.LoadScene(sceneName);
    }
}
